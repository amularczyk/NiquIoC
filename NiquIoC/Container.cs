using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NiquIoC.Attributes;
using NiquIoC.Exceptions;
using NiquIoC.Extensions;
using NiquIoC.Helpers;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    public class Container : IContainer
    {
        //ToDo: WarmUp?
        public Container()
        {
            _registeredTypesCache = new Dictionary<Type, ContainerMember>();
            _noCycleForTypesCache = new Dictionary<Type, bool>();
            _constructorInfoForTypesCache = new Dictionary<Type, ContainerConstructorInfo>();
            _createObjectFunctionForConstructorCache = new Dictionary<ConstructorInfo, Func<object[], object>>();
            _createObjectFunctionForConstructorCache2 = new Dictionary<Type, Func<object>>();
            _propertiesInfoForTypesCache = new Dictionary<Type, List<PropertyInfo>>();
            _methodsInfoForTypesCache = new Dictionary<Type, List<MethodInfo>>();
            _parametersInfoForMethodCache = new Dictionary<MethodInfo, List<ParameterInfo>>();
            _signletonsCache = new Dictionary<Type, object>();
        }

        #region Private Fields

        private readonly Dictionary<Type, ContainerMember> _registeredTypesCache;
        private readonly Dictionary<Type, bool> _noCycleForTypesCache;
        private readonly Dictionary<Type, ContainerConstructorInfo> _constructorInfoForTypesCache;
        private readonly Dictionary<ConstructorInfo, Func<object[], object>> _createObjectFunctionForConstructorCache;
        private readonly Dictionary<Type, Func<object>> _createObjectFunctionForConstructorCache2;
        private readonly Dictionary<Type, List<PropertyInfo>> _propertiesInfoForTypesCache;
        private readonly Dictionary<Type, List<MethodInfo>> _methodsInfoForTypesCache;
        private readonly Dictionary<MethodInfo, List<ParameterInfo>> _parametersInfoForMethodCache;
        private readonly Dictionary<Type, object> _signletonsCache;

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
            return (T) Resolve(typeof(T));
        }

        public T Resolve2<T>()
        {
            return (T) Resolve2(typeof(T));
        }

        public void BuildUp<T>(T instance)
        {
            ResolveProperties(instance, typeof(T));
            ResolveMethods(instance, typeof(T));
        }

        public void WarmUp()
        {
            CreateAllSingletons();
        }

        #endregion

        #region Private Methods

        private IContainerMember RegisterType(Type typeFrom, Type typeTo)
        {
            if (_constructorInfoForTypesCache.ContainsKey(typeTo))
            {
                _constructorInfoForTypesCache.Remove(typeTo);
            }

            if (_noCycleForTypesCache.ContainsKey(typeFrom))
            {
                _noCycleForTypesCache.Remove(typeFrom);
            }

            if (_createObjectFunctionForConstructorCache2.ContainsKey(typeTo))
            {
                _createObjectFunctionForConstructorCache2.Remove(typeTo);
            }

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
            //if the type is not registered yet, we add new value to the cache
            //if the type is registered, we change the value in the cache
            _registeredTypesCache[containerMember.RegisteredType] = containerMember;

            return containerMember;
        }

        private object Resolve(Type type)
        {
            var containerMember = _registeredTypesCache.GetValue(type); //getting a value from the cache for the correct type

            if (containerMember.ObjectFactory == null) //we do not need to create cache or check cycle for object factory
            {
                if (!_constructorInfoForTypesCache.ContainsKey(containerMember.ReturnType)) //if we do not have constructor info in the cache for a given type, we create it
                {
                    CreateConstructorInfoForTypesCache(containerMember.ReturnType);
                }

                CheckCycleForType(containerMember.ReturnType); //at the beginning we check cycle for the type
            }

            return Resolve(containerMember);
        }

        private object Resolve(ContainerMember containerMember)
        {
            if (!containerMember.IsSingleton) //if type is not registered as singleton we return a new instance all the time
            {
                return ReturnInstance(containerMember);
            }

            if (containerMember.Instance != null) //for singleton if we created an instance earlier, we return this value
            {
                return containerMember.Instance;
            }

            var value = ReturnInstance(containerMember);
            containerMember.Instance = value;

            return value;
        }

        private object Resolve2(Type type)
        {
            var containerMember = _registeredTypesCache.GetValue(type); //getting a value from the cache for the correct type

            if (containerMember.ObjectFactory == null) //we do not need to create cache or check cycle for object factory
            {
                if (!_constructorInfoForTypesCache.ContainsKey(containerMember.ReturnType)) //if we do not have constructor info in the cache for a given type, we create it
                {
                    CreateConstructorInfoForTypesCache(containerMember.ReturnType);
                }

                CheckCycleForType(containerMember.ReturnType); //at the beginning we check cycle for the type
            }

            return Resolve2(containerMember);
        }

        private object Resolve2(ContainerMember containerMember)
        {
            if (!containerMember.IsSingleton) //if type is not registered as singleton we return a new instance all the time
            {
                return ReturnInstance2(containerMember);
            }

            if (containerMember.Instance != null) //for singleton if we created an instance earlier, we return this value
            {
                return containerMember.Instance;
            }

            var value = ReturnInstance2(containerMember);
            containerMember.Instance = value;

            return value;
        }

        private object ReturnInstance(ContainerMember containerMember)
        {
            return _registeredTypesCache[containerMember.RegisteredType].ObjectFactory != null
                ? _registeredTypesCache[containerMember.RegisteredType].ObjectFactory()
                : CreateInstance(containerMember.ReturnType);
        }

        private object ReturnInstance2(ContainerMember containerMember)
        {
            return _registeredTypesCache[containerMember.RegisteredType].ObjectFactory != null
                ? _registeredTypesCache[containerMember.RegisteredType].ObjectFactory()
                : CreateInstance2(containerMember.ReturnType);
        }

        private object CreateInstance(Type type)
        {
            var ctor = _constructorInfoForTypesCache[type].Constructor;
            var ctorParameters = _constructorInfoForTypesCache[type].Parameters;
            var ctorParametersCount = ctorParameters.Count;

            var parameters = new object[ctorParametersCount];
            for (var i = 0; i < ctorParametersCount; i++) //we create as array with the parameters of the constructor and we fill it
            {
                var parameterContainerMember = _registeredTypesCache.GetValue(ctorParameters[i].ParameterType);
                parameters[i] = Resolve(parameterContainerMember);
            }

            if (!_createObjectFunctionForConstructorCache.ContainsKey(ctor)) //if we do not have a create object function in the cache, we create it
            {
                var factoryMethod = EmitHelper.CreateObjectFunction(ctor);
                _createObjectFunctionForConstructorCache.Add(ctor, factoryMethod);
            }

            var obj = _createObjectFunctionForConstructorCache[ctor](parameters);
            ResolveProperties(obj, type); //when we have a new instance of the type, we have to resolve the properties also
            ResolveMethods(obj, type); //when we have a new instance of the type, we have to resolve the methods also

            return obj;
        }

        private object CreateInstance2(Type type)
        {
            if (!_createObjectFunctionForConstructorCache2.ContainsKey(type)) //if we do not have a create object function in the cache, we create it
            {
                var factoryMethod = EmitHelper.CreateFullObjectFunction(type, _constructorInfoForTypesCache, _signletonsCache);
                _createObjectFunctionForConstructorCache2.Add(type, factoryMethod);
            }

            var obj = _createObjectFunctionForConstructorCache2[type]();
            ResolveProperties(obj, type); //when we have a new instance of the type, we have to resolve the properties also
            ResolveMethods(obj, type); //when we have a new instance of the type, we have to resolve the methods also

            return obj;
        }

        private void CreateConstructorInfoForTypesCache(Type type) //this function recursively create cache for constructor info and constructor parameters for given type
        {
            var allConstructors = type.GetConstructors();

            //first we are look for the constructor with attribute DependencyConstrutor
            var goodConstructors = allConstructors.Where(c => c.GetCustomAttributes(typeof(DependencyConstrutor), false).Any()).ToList();

            if (!goodConstructors.Any()) //if there is no constructor with attribute, then we choose constructor with max number of parameters
            {
                var maxParameter = allConstructors.Max(c => c.GetParameters().Length);
                goodConstructors = allConstructors.Where(c => c.GetParameters().Length == maxParameter).ToList();
            }

            if (goodConstructors.Count == 1) //if there is only one good constructor, then we add information about it to cache
            {
                var constructor = goodConstructors[0];
                var consParameters = constructor.GetParameters().ToList();

                _constructorInfoForTypesCache.Add(type, new ContainerConstructorInfo(constructor, consParameters));

                foreach (var consParameter in consParameters)
                {
                    var parameterType = consParameter.ParameterType;
                    if (_registeredTypesCache.ContainsKey(parameterType))
                    {
                        if (parameterType.IsInterface) //if a type is interface than we get return type for it
                        {
                            parameterType = _registeredTypesCache.GetValue(parameterType).ReturnType;
                        }

                        //if we do not have constructor info in the cache for a given parameter type, we create it
                        if (!_constructorInfoForTypesCache.ContainsKey(parameterType))
                        {
                            CreateConstructorInfoForTypesCache(parameterType);
                        }
                    }
                }
            }
            else //otherwise we throw suitable exception
            {
                throw new NoProperConstructorException();
            }
        }

        private void ResolveProperties(object obj, Type type)
        {
            if (!_propertiesInfoForTypesCache.ContainsKey(type)) //if we do not have a properties info in the cache, we create it
            {
                _propertiesInfoForTypesCache.Add(type,
                    type.GetProperties().Where(p => p.GetCustomAttributes(typeof(DependencyProperty), false).Any() && p.SetMethod != null).ToList());
            }

            var properties = _propertiesInfoForTypesCache[type];
            foreach (var property in properties) //we are filling the required properties
            {
                property.SetValue(obj, Resolve(property.PropertyType));
            }
        }

        private void ResolveMethods(object obj, Type type)
        {
            if (!_methodsInfoForTypesCache.ContainsKey(type)) //if we do not have a methods info in the cache, we create it
            {
                _methodsInfoForTypesCache.Add(type,
                    type.GetMethods().Where(p => p.ReturnType == typeof(void) && p.GetCustomAttributes(typeof(DependencyMethod), false).Any()).ToList());
            }

            var methods = _methodsInfoForTypesCache[type];
            foreach (var method in methods) //we are filling the required methods
            {
                if (!_parametersInfoForMethodCache.ContainsKey(method))
                {
                    _parametersInfoForMethodCache.Add(method, method.GetParameters().ToList());
                }

                var methodParameters = _parametersInfoForMethodCache[method];
                var ctorParametersCount = methodParameters.Count;
                var parameters = new object[ctorParametersCount];
                for (var i = 0; i < ctorParametersCount; i++) //we create as array with the parameters of the method and we fill it
                {
                    parameters[i] = Resolve(methodParameters[i].ParameterType);
                }
                method.Invoke(obj, parameters);
            }
        }

        private void CheckCycleForType(Type type) //this function recursively check cycle for constructor and constructor parameters for given type
        {
            if (_noCycleForTypesCache.ContainsKey(type))
            {
                if (!_noCycleForTypesCache[type])
                {
                    throw new CycleForTypeException(type);
                }
                return;
            }

            if (_constructorInfoForTypesCache.ContainsKey(type) || _registeredTypesCache.ContainsKey(type))
            {
                _noCycleForTypesCache.Add(type, false);

                var parameters = _constructorInfoForTypesCache.ContainsKey(type)
                    ? _constructorInfoForTypesCache[type].Parameters
                    : _constructorInfoForTypesCache[_registeredTypesCache.GetValue(type).ReturnType].Parameters;
                foreach (var parameter in parameters)
                {
                    CheckCycleForType(parameter.ParameterType);
                }

                _noCycleForTypesCache[type] = true;
            }
        }

        private void CreateAllSingletons()
        {
            foreach (var registeredType in _registeredTypesCache.Where(r => r.Value.Instance != null).ToList())
            {
                _signletonsCache.Add(registeredType.Key, registeredType.Value.Instance);
            }

            foreach (var registeredType in _registeredTypesCache.Where(r => r.Value.IsSingleton && r.Value.Instance == null).ToList())
            {
                var containerMember = registeredType.Value;

                var value = ReturnInstance(containerMember);
                containerMember.Instance = value;
                _signletonsCache.Add(registeredType.Key, value);
            }
        }

        #endregion
    }
}