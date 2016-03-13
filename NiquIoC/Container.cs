using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NiquIoC.Attributes;
using NiquIoC.Exceptions;

namespace NiquIoC
{
    public class Container : IContainer
    {
        public Container()
        {
            _registeredTypeCache = new Dictionary<Type, RegisterTypeInfo>();

            _constructorInfoForTypeCache = new Dictionary<Type, Tuple<ConstructorInfo, List<ParameterInfo>>>();
            _propertiesInfoForTypeCache = new Dictionary<Type, List<PropertyInfo>>();
            _createObjectFunctionForConstructorCache = new Dictionary<ConstructorInfo, Func<object[], object>>();
        }

        #region Private Fields

        private readonly IDictionary<Type, RegisterTypeInfo> _registeredTypeCache;

        private readonly IDictionary<Type, Tuple<ConstructorInfo, List<ParameterInfo>>> _constructorInfoForTypeCache;
        private readonly IDictionary<Type, List<PropertyInfo>> _propertiesInfoForTypeCache;
        private readonly IDictionary<ConstructorInfo, Func<object[], object>> _createObjectFunctionForConstructorCache;

        #endregion

        #region IContainer

        public void RegisterType<T>(bool isSingleton)
            where T : class
        {
            RegisterType(typeof(T), typeof(T), isSingleton);
        }

        public void RegisterType<TFrom, TTo>(bool isSingleton)
            where TTo : TFrom
        {
            RegisterType(typeof(TFrom), typeof(TTo), isSingleton);
        }

        public void RegisterInstance<T>(T instance)
        {
            RegisterInstance(typeof (T), typeof (T).IsInterface ? instance.GetType() : typeof (T), instance);
        }

        public T Resolve<T>()
        {
            var resolvedTypes = new Dictionary<Type, bool>();   //to check cycles for the types
            var instance = (T) Resolve(typeof (T), resolvedTypes);
            return instance;
        }

        public void BuildUp<T>(T instance)
        {
            var resolvedTypes = new Dictionary<Type, bool>();   //to check cycles for the types
            ResolveProperties(instance, typeof (T), resolvedTypes);
        }

        #endregion

        #region Private Methods

        private void RegisterType(Type typeFrom, Type typeTo, bool isSingleton)
        {
            Register(typeFrom, typeTo, isSingleton, null);
        }

        private void RegisterInstance(Type typeFrom, Type typeTo, object instance)
        {
            Register(typeFrom, typeTo, true, instance);
        }

        private void Register(Type typeFrom, Type typeTo, bool isSingleton, object instance)
        {
            if (!_registeredTypeCache.ContainsKey(typeFrom))  //if the type is not registered yet, we add new value to the cache
            {
                _registeredTypeCache.Add(typeFrom, new RegisterTypeInfo(isSingleton, typeTo, instance));
            }
            else    //if the type is registered, we change the value in the cache
            {
                _registeredTypeCache[typeFrom] = new RegisterTypeInfo(isSingleton, typeTo, instance);
            }
        }

        private object Resolve(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            try
            {
                RegisterTypeInfo result = _registeredTypeCache[type];   //getting a value from the cache for the correct type

                if (!result.IsSingleton)    //if type is not registered as singleton we return a new instance all the time
                {
                    return CreateInstance(result.ReturnType, resolvedTypes);
                }

                if (result.Instance != null)    //for singleton if we created an instance earlier, we return this value
                {
                    return result.Instance;
                }
                else    //if we did not create an instance earlier, so we create a new instance and add this instance to the cache
                {
                    object value = CreateInstance(result.ReturnType, resolvedTypes);
                    result.Instance = value;
                    return value;
                }
            }
            catch (KeyNotFoundException)
            {
                throw new TypeNotRegisteredException();
            }
        }

        private object CreateInstance(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            CheckCycleForType(resolvedTypes, type); //at the beginning we check cycle for the type

            if (!_constructorInfoForTypeCache.ContainsKey(type))    //if we do not have constructor info in the cache for a given type, we create it
            {
                CreateConstructorInfoForTypeCache(type);
            }

            ConstructorInfo ctor = _constructorInfoForTypeCache[type].Item1;
            List<ParameterInfo> ctorParameters = _constructorInfoForTypeCache[type].Item2;
            int ctorParametersCount = ctorParameters.Count;

            var parameters = new object[ctorParametersCount];
            for (var i = 0; i < ctorParametersCount; i++)   //we create as array with the parameters of the constructor and we fill it
            {
                parameters[i] = Resolve(ctorParameters[i].ParameterType, resolvedTypes);
            }
            resolvedTypes[type] = true; //we can mark the type, because it does not have cycle

            if (!_createObjectFunctionForConstructorCache.ContainsKey(ctor))    //if we do not have a create object function in the cache, we create it
            {
                Func<object[], object> factoryMethod = EmitHelper.CreateObjectFunction(ctor);
                _createObjectFunctionForConstructorCache.Add(ctor, factoryMethod);
            }

            object obj = _createObjectFunctionForConstructorCache[ctor](parameters);
            ResolveProperties(obj, type, resolvedTypes);  //when we have a new instance of the type, we have to resolve the properties yet

            return obj;
        }

        private void CreateConstructorInfoForTypeCache(Type type)
        {
            ConstructorInfo[] allConstructors = type.GetConstructors();
            
            //first we are look for the constructor with attribute DependencyConstrutor
            IList<ConstructorInfo> goodConstructors = allConstructors.Where(c => c.GetCustomAttributes(typeof (DependencyConstrutor), false).Any()).ToList();

            if (!goodConstructors.Any())    //if there is no constructor with attribute, then we choose constructor with max number of parameters
            {
                int maxParameter = allConstructors.Max(c => c.GetParameters().Length);
                goodConstructors = allConstructors.Where(c => c.GetParameters().Length == maxParameter).ToList();
            }

            if (goodConstructors.Count == 1)    //if there is only one good constructor, then we add information about it to cache
            {
                ConstructorInfo constructor = goodConstructors.First();
                List<ParameterInfo> consParameters = constructor.GetParameters().ToList();

                _constructorInfoForTypeCache.Add(type, Tuple.Create(constructor, consParameters));
            }
            else    //otherwise we throw suitable exception
            {
                throw new NoProperConstructorException();
            }
        }

        private void ResolveProperties(object obj, Type type, Dictionary<Type, bool> resolvedTypes)
        {
            if (!_propertiesInfoForTypeCache.ContainsKey(type)) //if we do not have a properties info in the cache, we create it
            {
                _propertiesInfoForTypeCache.Add(type, type.GetProperties().Where(p => p.GetCustomAttributes(typeof (DependencyProperty), false).Any() && p.SetMethod != null).ToList());
            }

            List<PropertyInfo> properties = _propertiesInfoForTypeCache[type];
            foreach (PropertyInfo property in properties)   //we are filling the required properties
            {
                property.SetValue(obj, Resolve(property.PropertyType, resolvedTypes));
            }
        }

        private void CheckCycleForType(Dictionary<Type, bool> resolvedTypes, Type type)
        {
            if (resolvedTypes.ContainsKey(type))
            {
                //if a value for the type is true - it means that we checked this type and it does not have cycle
                //if a value for the type is false - it means that this type has cycle
                if (!resolvedTypes[type])
                {
                    throw new CycleForTypeException(type);
                }
            }
            else
            {
                //we add a new type with a value false - it means that we are checking this type
                resolvedTypes.Add(type, false);
            }
        }

        #endregion
    }
}