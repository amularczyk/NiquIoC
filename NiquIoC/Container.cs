using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using NiquIoC.Attributes;
using NiquIoC.Exceptions;
using NiquIoC.Helpers;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    public class Container : IContainer
    {
        //ToDo: Move filling all caches to register.
        public Container()
        {
            _registeredTypeCache = new Dictionary<Type, ContainerMember>();
            _noCycleForTypeCache = new Dictionary<Type, bool>();
            _constructorInfoForTypeCache = new Dictionary<Type, Tuple<ConstructorInfo, List<ParameterInfo>>>();
            _createObjectFunctionForConstructorCache = new Dictionary<ConstructorInfo, Func<object[], object>>();
            _propertiesInfoForTypeCache = new Dictionary<Type, List<PropertyInfo>>();
            _methodsInfoForTypeCache = new Dictionary<Type, List<MethodInfo>>();
            _parametersInfoForMethodCache = new Dictionary<MethodInfo, List<ParameterInfo>>();
        }

        #region Private Fields

        private readonly IDictionary<Type, ContainerMember> _registeredTypeCache;
        private readonly IDictionary<Type, bool> _noCycleForTypeCache;
        private readonly IDictionary<Type, Tuple<ConstructorInfo, List<ParameterInfo>>> _constructorInfoForTypeCache;
        private readonly IDictionary<ConstructorInfo, Func<object[], object>> _createObjectFunctionForConstructorCache;
        private readonly IDictionary<Type, List<PropertyInfo>> _propertiesInfoForTypeCache;
        private readonly IDictionary<Type, List<MethodInfo>> _methodsInfoForTypeCache;
        private readonly IDictionary<MethodInfo, List<ParameterInfo>> _parametersInfoForMethodCache;

        #endregion

        #region IContainer

        public IContainerMember RegisterType<T>()
            where T : class
        {
            return RegisterType(typeof(T), typeof(T));
        }

        public IContainerMember RegisterType<T>(Func<object> objectFactory)
            where T : class
        {
            return RegisterObjectFactory(typeof(T), typeof(T), objectFactory);
        }

        public IContainerMember RegisterType<TFrom, TTo>()
            where TTo : TFrom
        {
            return RegisterType(typeof(TFrom), typeof(TTo));
        }

        public IContainerMember RegisterInstance<T>(T instance)
        {
            return RegisterInstance(typeof(T), typeof(T).IsInterface ? instance.GetType() : typeof(T), instance);
        }

        public T Resolve<T>()
        {
            var instance = (T) Resolve(typeof(T));
            return instance;
        }

        public void BuildUp<T>(T instance)
        {
            ResolveProperties(instance, typeof(T));
            ResolveMethods(instance, typeof(T));
        }

        #endregion

        #region Private Methods

        private IContainerMember RegisterType(Type typeFrom, Type typeTo)
        {
            return Register(new ContainerMember {RegisteredType = typeFrom, ReturnType = typeTo});
        }

        private IContainerMember RegisterInstance(Type typeFrom, Type typeTo, object instance)
        {
            return Register(new ContainerMember(instance) {RegisteredType = typeFrom, ReturnType = typeTo});
        }

        private IContainerMember RegisterObjectFactory(Type typeFrom, Type typeTo, Func<object> objectFactory)
        {
            return Register(new ContainerMember(objectFactory) {RegisteredType = typeFrom, ReturnType = typeTo});
        }

        private IContainerMember Register(ContainerMember containerMember)
        {
            if (!_registeredTypeCache.ContainsKey(containerMember.RegisteredType)) //if the type is not registered yet, we add new value to the cache
            {
                _registeredTypeCache.Add(containerMember.RegisteredType, containerMember);
            }
            else //if the type is registered, we change the value in the cache
            {
                _registeredTypeCache[containerMember.RegisteredType] = containerMember;
            }

            return containerMember;
        }

        private object Resolve(Type type)
        {
            try
            {
                ContainerMember result = _registeredTypeCache[type]; //getting a value from the cache for the correct type

                if (!result.IsSingleton) //if type is not registered as singleton we return a new instance all the time
                {
                    return ReturnInstance(result);
                }

                if (result.Instance != null) //for singleton if we created an instance earlier, we return this value
                {
                    return result.Instance;
                }

                object value = ReturnInstance(result);
                result.Instance = value;
                return value;
            }
            catch (KeyNotFoundException)
            {
                throw new TypeNotRegisteredException();
            }
        }

        private object ReturnInstance(ContainerMember result)
        {
            if (_registeredTypeCache[result.RegisteredType].ObjectFactory != null)
            {
                return _registeredTypeCache[result.RegisteredType].ObjectFactory();
            }

            return CreateInstance(result.ReturnType);
        }

        private object CreateInstance(Type type)
        {
            bool check = CheckCycleForType(type); //at the beginning we check cycle for the type

            if (!_constructorInfoForTypeCache.ContainsKey(type)) //if we do not have constructor info in the cache for a given type, we create it
            {
                CreateConstructorInfoForTypeCache(type);
            }

            ConstructorInfo ctor = _constructorInfoForTypeCache[type].Item1;
            List<ParameterInfo> ctorParameters = _constructorInfoForTypeCache[type].Item2;
            int ctorParametersCount = ctorParameters.Count;

            var parameters = new object[ctorParametersCount];
            for (var i = 0; i < ctorParametersCount; i++) //we create as array with the parameters of the constructor and we fill it
            {
                parameters[i] = Resolve(ctorParameters[i].ParameterType);
            }

            if (!check)
            {
                _noCycleForTypeCache[type] = true; //we can mark the type, because it does not have cycle
            }

            if (!_createObjectFunctionForConstructorCache.ContainsKey(ctor)) //if we do not have a create object function in the cache, we create it
            {
                Func<object[], object> factoryMethod = EmitHelper.CreateObjectFunction(ctor);
                _createObjectFunctionForConstructorCache.Add(ctor, factoryMethod);
            }

            object obj = _createObjectFunctionForConstructorCache[ctor](parameters);
            ResolveProperties(obj, type); //when we have a new instance of the type, we have to resolve the properties also
            ResolveMethods(obj, type); //when we have a new instance of the type, we have to resolve the methods also

            return obj;
        }

        private void CreateConstructorInfoForTypeCache(Type type)
        {
            ConstructorInfo[] allConstructors = type.GetConstructors();

            //first we are look for the constructor with attribute DependencyConstrutor
            IList<ConstructorInfo> goodConstructors = allConstructors.Where(c => c.GetCustomAttributes(typeof(DependencyConstrutor), false).Any()).ToList();

            if (!goodConstructors.Any()) //if there is no constructor with attribute, then we choose constructor with max number of parameters
            {
                int maxParameter = allConstructors.Max(c => c.GetParameters().Length);
                goodConstructors = allConstructors.Where(c => c.GetParameters().Length == maxParameter).ToList();
            }

            if (goodConstructors.Count == 1) //if there is only one good constructor, then we add information about it to cache
            {
                ConstructorInfo constructor = goodConstructors.First();
                List<ParameterInfo> consParameters = constructor.GetParameters().ToList();

                _constructorInfoForTypeCache.Add(type, Tuple.Create(constructor, consParameters));
            }
            else //otherwise we throw suitable exception
            {
                throw new NoProperConstructorException();
            }
        }

        private void ResolveProperties(object obj, Type type)
        {
            if (!_propertiesInfoForTypeCache.ContainsKey(type)) //if we do not have a properties info in the cache, we create it
            {
                _propertiesInfoForTypeCache.Add(type,
                    type.GetProperties().Where(p => p.GetCustomAttributes(typeof(DependencyProperty), false).Any() && p.SetMethod != null).ToList());
            }

            List<PropertyInfo> properties = _propertiesInfoForTypeCache[type];
            foreach (PropertyInfo property in properties) //we are filling the required properties
            {
                property.SetValue(obj, Resolve(property.PropertyType));
            }
        }

        private void ResolveMethods(object obj, Type type)
        {
            if (!_methodsInfoForTypeCache.ContainsKey(type)) //if we do not have a methods info in the cache, we create it
            {
                _methodsInfoForTypeCache.Add(type,
                    type.GetMethods().Where(p => p.ReturnType == typeof(void) && p.GetCustomAttributes(typeof(DependencyMethod), false).Any()).ToList());
            }

            List<MethodInfo> methods = _methodsInfoForTypeCache[type];
            foreach (MethodInfo method in methods) //we are filling the required methods
            {
                if (!_parametersInfoForMethodCache.ContainsKey(method))
                {
                    _parametersInfoForMethodCache.Add(method, method.GetParameters().ToList());
                }

                List<ParameterInfo> methodParameters = _parametersInfoForMethodCache[method];
                int ctorParametersCount = methodParameters.Count;
                var parameters = new object[ctorParametersCount];
                for (var i = 0; i < ctorParametersCount; i++) //we create as array with the parameters of the method and we fill it
                {
                    parameters[i] = Resolve(methodParameters[i].ParameterType);
                }
                method.Invoke(obj, parameters);
            }
        }

        private bool CheckCycleForType(Type type)
        {
            if (_noCycleForTypeCache.ContainsKey(type))
            {
                //if a value for the type is true - it means that we checked this type and it does not have cycle
                //if a value for the type is false - it means that this type has cycle
                if (!_noCycleForTypeCache[type])
                {
                    throw new CycleForTypeException(type);
                }
                return true;
            }
            else
            {
                //we add a new type with a value false - it means that we are checking this type
                _noCycleForTypeCache.Add(type, false);
                return false;
            }
        }

        #endregion
    }
}