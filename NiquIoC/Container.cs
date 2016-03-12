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
            _typeContainer = new Dictionary<Type, RegisterTypeInfo>();
            _constructorInfoForTypeCache = new Dictionary<Type, Tuple<ConstructorInfo, List<ParameterInfo>>>();
            _createObjectFunctionForConstructorCache = new Dictionary<ConstructorInfo, Func<object[], object>>();
            _propertiesInfoForTypeCache = new Dictionary<Type, List<PropertyInfo>>();
        }

        #region Private Fields

        private readonly IDictionary<Type, RegisterTypeInfo> _typeContainer;

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
            var resolvedTypes = new Dictionary<Type, bool>();
            var instance = (T) Resolve(typeof (T), resolvedTypes);
            return instance;
        }

        public void BuildUp<T>(T instance)
        {
            var resolvedTypes = new Dictionary<Type, bool>();
            ResolveProperty(instance, typeof (T), resolvedTypes);
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
            if (!_typeContainer.ContainsKey(typeFrom))
            {
                _typeContainer.Add(typeFrom, new RegisterTypeInfo(isSingleton, typeTo, instance));
            }
            else
            {
                _typeContainer[typeFrom] = new RegisterTypeInfo(isSingleton, typeTo, instance);
            }
        }

        private object Resolve(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            try
            {
                RegisterTypeInfo result = _typeContainer[type];

                if (!result.IsSingleton)
                {
                    return CreateInstance(result.ReturnType, resolvedTypes);
                }

                if (result.Instance != null)
                {
                    return result.Instance;
                }
                else
                {
                    object value = CreateInstance(result.ReturnType, resolvedTypes);
                    result.Instance = value;
                    return value;
                }
            }
            catch (NoProperConstructorException)
            {
                throw;
            }
            catch (CycleForTypeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new TypeNotRegisteredException();
            }
        }

        private object CreateInstance(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            CheckCycleForType(resolvedTypes, type);

            if (!_constructorInfoForTypeCache.ContainsKey(type))
            {
                CreateConstructorInfoForTypeCache(type, resolvedTypes);
            }

            ConstructorInfo ctor = _constructorInfoForTypeCache[type].Item1;
            List<ParameterInfo> ctorParameters = _constructorInfoForTypeCache[type].Item2;
            int ctorParametersCount = ctorParameters.Count;

            var parameters = new object[ctorParametersCount];
            for (var i = 0; i < ctorParametersCount; i++)
            {
                parameters[i] = Resolve(ctorParameters[i].ParameterType, resolvedTypes);
            }
            resolvedTypes[type] = true; //When object of correct type was created - it means there is no cycle for this type, so we mark this type

            if (!_createObjectFunctionForConstructorCache.ContainsKey(ctor))
            {
                Func<object[], object> factoryMethod = EmitHelper.CreateObjectFunction(ctor);
                _createObjectFunctionForConstructorCache.Add(ctor, factoryMethod);
            }

            object obj = _createObjectFunctionForConstructorCache[ctor](parameters);
            ResolveProperty(obj, type, resolvedTypes);

            return obj;
        }

        private void CreateConstructorInfoForTypeCache(Type type, Dictionary<Type, bool> resolvedTypes)
        {
            ConstructorInfo[] allConstructors = type.GetConstructors();

            int maxParameter = -1;
            IList<ConstructorInfo> goodConstructors = allConstructors.Where(c => c.GetCustomAttributes(typeof (DependencyConstrutor), false).Any()).ToList();

            if (!goodConstructors.Any())
            {
                maxParameter = allConstructors.Max(c => c.GetParameters().Length);
                goodConstructors = allConstructors.Where(c => c.GetParameters().Length == maxParameter).ToList();
            }

            if (goodConstructors.Count == 1)
            {
                ConstructorInfo constructor = goodConstructors.First();
                List<ParameterInfo> consParameters = constructor.GetParameters().ToList();
                if (maxParameter == -1)
                {
                    maxParameter = consParameters.Count;
                }

                var parameters = new object[maxParameter];
                for (var i = 0; i < maxParameter; i++)
                {
                    parameters[i] = Resolve(consParameters[i].ParameterType, resolvedTypes);
                }

                _constructorInfoForTypeCache.Add(type, Tuple.Create(constructor, consParameters));
            }
            else
            {
                throw new NoProperConstructorException();
            }
        }

        private void ResolveProperty(object obj, Type type, Dictionary<Type, bool> resolvedTypes)
        {
            if (!_propertiesInfoForTypeCache.ContainsKey(type))
            {
                _propertiesInfoForTypeCache.Add(type, type.GetProperties().Where(p => p.GetCustomAttributes(typeof (DependencyProperty), false).Any() && p.SetMethod != null).ToList());
            }

            List<PropertyInfo> properties = _propertiesInfoForTypeCache[type];
            foreach (PropertyInfo property in properties)
            {
                property.SetValue(obj, Resolve(property.PropertyType, resolvedTypes));
            }
        }

        private void CheckCycleForType(Dictionary<Type, bool> resolvedTypes, Type type)
        {
            if (resolvedTypes.ContainsKey(type))
            {
                //When value for type is true - it means that we checked this type and it does not have cycle. 
                //When value for type is false - it means that this type has cycle.
                if (!resolvedTypes[type])
                {
                    throw new CycleForTypeException(type);
                }
            }
            else
            {
                //We add a new type with value false - it means that we are checking this type.
                resolvedTypes.Add(type, false);
            }
        }

        #endregion
    }
}