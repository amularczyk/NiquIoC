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

            _createObjectFunctionForConstructorCache = new Dictionary<ConstructorInfo, Func<object[], object>>();
            _createObjectFunctionForConstructorCache2 = new Dictionary<Type, Func<object[], Func<object>[], object>>();

            _parametersInfoForMethodCache = new Dictionary<MethodInfo, List<ParameterInfo>>();
            _signletonsIndexCache = new Dictionary<Type, int>();
            _objectFactoryIndexCache = new Dictionary<Type, int>();

            _objectFactoryCache = new List<Func<object>>();

            _warmedUp = false;
        }

        #region Private Fields
        private readonly Dictionary<Type, ContainerMember> _registeredTypesCache;

        private readonly Dictionary<ConstructorInfo, Func<object[], object>> _createObjectFunctionForConstructorCache;
        private readonly Dictionary<Type, Func<object[], Func<object>[], object>> _createObjectFunctionForConstructorCache2;

        private readonly Dictionary<MethodInfo, List<ParameterInfo>> _parametersInfoForMethodCache;
        private readonly Dictionary<Type, int> _signletonsIndexCache;
        private readonly Dictionary<Type, int> _objectFactoryIndexCache;
        private object[] _signletonsCache;
        private readonly List<Func<object>> _objectFactoryCache;

        private int _index;
        private bool _warmedUp;
        #endregion

        #region IContainer
        public IContainerMember RegisterType<T>()
            where T : class
        {
            var type = typeof(T);
            if (type.IsInterface)
            {
                throw new WrongInterfaceRegistrationException(type);
            }

            return RegisterType(type, type);
        }

        public IContainerMember RegisterType<T>(Func<object> objectFactory)
            where T : class
        {
            var type = typeof(T);
            if (_objectFactoryIndexCache.ContainsKey(type))
            {
                _objectFactoryCache[_objectFactoryIndexCache[type]] = objectFactory;
            }
            else
            {
                _objectFactoryCache.Add(objectFactory);
                _objectFactoryIndexCache.Add(type, _index++);
            }
            return RegisterObjectFactory(type, type, objectFactory);
        }

        public IContainerMember RegisterType<TFrom, TTo>()
            where TTo : TFrom
        {
            return RegisterType(typeof(TFrom), typeof(TTo));
        }

        public IContainerMember RegisterInstance<T>(T instance)
        {
            var type = typeof(T);
            return RegisterInstance(type, type.IsInterface ? instance.GetType() : type, instance);
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
            var type = typeof(T);
            BuildUp(instance, type.IsInterface ? instance.GetType() : type);
        }

        public void WarmUp(bool full = false)
        {
            CreateAllSingletons();

            if (full)
            {
                //TODO: Genereta all caches (including createObjectFunction)
            }

            _warmedUp = true;
        }
        #endregion

        #region Private Methods
        private IContainerMember RegisterType(Type typeFrom, Type typeTo)
        {
            if (_registeredTypesCache.ContainsKey(typeFrom))
            {
                _registeredTypesCache.Remove(typeFrom);
                _signletonsIndexCache.Clear();
                _warmedUp = false;

                if (_createObjectFunctionForConstructorCache2.ContainsKey(typeTo))
                {
                    _createObjectFunctionForConstructorCache2.Remove(typeTo);
                }
            }

            return Register(new ContainerMember {RegisteredType = typeFrom, ReturnType = typeTo});
        }

        private IContainerMember RegisterInstance(Type typeFrom, Type typeTo, object instance)
        {
            return Register(new ContainerMember(instance) {RegisteredType = typeFrom, ReturnType = typeTo, CycleInConstructor = false});
        }

        private IContainerMember RegisterObjectFactory(Type typeFrom, Type typeTo, Func<object> objectFactory)
        {
            return Register(new ContainerMember(objectFactory) {RegisteredType = typeFrom, ReturnType = typeTo, CycleInConstructor = false });
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
                if (containerMember.Constructor == null) //if we do not have constructor info in the cache for a given type, we create it
                {
                    CreateConstructorInfoForTypesCache(containerMember);
                }

                CheckCycleForType(containerMember); //at the beginning we check cycle for the type
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
                if (containerMember.Constructor == null) //if we do not have constructor info in the cache for a given type, we create it
                {
                    CreateConstructorInfoForTypesCache(containerMember);
                }

                CheckCycleForType(containerMember); //at the beginning we check cycle for the type
            }

            if (!_warmedUp)
            {
                WarmUp();
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
                : CreateInstance(containerMember);
        }

        private object ReturnInstance2(ContainerMember containerMember)
        {
            return _registeredTypesCache[containerMember.RegisteredType].ObjectFactory != null
                ? _registeredTypesCache[containerMember.RegisteredType].ObjectFactory()
                : CreateInstance2(containerMember);
        }

        private object CreateInstance(ContainerMember containerMember)
        {
            var ctor = containerMember.Constructor;
            var ctorParameters = containerMember.Parameters;
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
            BuildUp(obj, containerMember); //when we have a new instance of the type, we have to resolve the properties and the methods also

            return obj;
        }

        private object CreateInstance2(ContainerMember containerMember)
        {
            if (!_createObjectFunctionForConstructorCache2.ContainsKey(containerMember.ReturnType)) //if we do not have a create object function in the cache, we create it
            {
                var factoryMethod = EmitHelper.CreateFullObjectFunction(containerMember, _registeredTypesCache, _signletonsIndexCache, _objectFactoryIndexCache);
                _createObjectFunctionForConstructorCache2.Add(containerMember.ReturnType, factoryMethod);
            }

            var obj = _createObjectFunctionForConstructorCache2[containerMember.ReturnType](_signletonsCache, _objectFactoryCache.ToArray());
            BuildUp(obj, containerMember); //when we have a new instance of the type, we have to resolve the properties and the methods also

            return obj;
        }

        private void BuildUp(object obj, Type type)
        {
            if (_registeredTypesCache.ContainsKey(type))
            {
                BuildUp(obj, _registeredTypesCache[type]);
            }
            else
            {
                ResolveProperties(obj, type);
                ResolveMethods(obj, type);
            }
        }

        private void BuildUp(object obj, ContainerMember containerMember)
        {
            ResolveProperties(obj, containerMember);
            ResolveMethods(obj, containerMember);
        }

        private void CreateConstructorInfoForTypesCache(ContainerMember containerMember)
            //this function recursively create cache for constructor info and constructor parameters for given type
        {
            var allConstructors = containerMember.ReturnType.GetConstructors();

            //first we are look for the constructor with attribute DependencyConstrutor
            var goodConstructors = allConstructors.Where(c => c.GetCustomAttributes(typeof(DependencyConstrutor), false).Any()).ToList();

            if (!goodConstructors.Any()) //if there is no constructor with attribute, then we choose constructor with max number of parameters
            {
                var maxParameter = allConstructors.Max(c => c.GetParameters().Length);
                goodConstructors = allConstructors.Where(c => c.GetParameters().Length == maxParameter).ToList();
            }

            if (goodConstructors.Count == 1) //if there is only one good constructor, then we add information about it to cache
            {
                containerMember.Constructor = goodConstructors[0];
                containerMember.Parameters = containerMember.Constructor.GetParameters().ToList();

                foreach (var consParameter in containerMember.Parameters)
                {
                    var parameterType = consParameter.ParameterType;
                    if (_registeredTypesCache.ContainsKey(parameterType))
                    {
                        var parameterContainerMember = _registeredTypesCache[parameterType];

                        if (parameterContainerMember.Constructor == null
                            && parameterContainerMember.Instance == null
                            && parameterContainerMember.ObjectFactory == null) //if we do not have constructor info in the cache for a given parameter type, we create it
                        {
                            CreateConstructorInfoForTypesCache(parameterContainerMember);
                        }
                    }
                }
            }
            else //otherwise we throw suitable exception
            {
                throw new NoProperConstructorException(containerMember.ReturnType);
            }
        }

        private void ResolveProperties(object obj, ContainerMember containerMember)
        {
            if (containerMember.PropertiesInfo == null) //if we do not have a properties info in the cache, we create it
            {
                containerMember.PropertiesInfo =
                    containerMember.ReturnType.GetProperties().Where(p => p.GetCustomAttributes(typeof(DependencyProperty), false).Any() && p.SetMethod != null).ToList();
            }

            foreach (var property in containerMember.PropertiesInfo) //we are filling the required properties
            {
                property.SetValue(obj, Resolve(property.PropertyType));
            }
        }

        private void ResolveProperties(object obj, Type type)
        {
            var propertiesInfo = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(DependencyProperty), false).Any() && p.SetMethod != null).ToList();

            foreach (var property in propertiesInfo) //we are filling the required properties
            {
                property.SetValue(obj, Resolve(property.PropertyType));
            }
        }

        private void ResolveMethods(object obj, ContainerMember containerMember)
        {
            if (containerMember.MethodsInfo == null) //if we do not have a methods info in the cache, we create it
            {
                containerMember.MethodsInfo =
                    containerMember.ReturnType.GetMethods().Where(p => p.ReturnType == typeof(void) && p.GetCustomAttributes(typeof(DependencyMethod), false).Any()).ToList();
            }

            foreach (var method in containerMember.MethodsInfo) //we are filling the required methods
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

        private void ResolveMethods(object obj, Type type)
        {
            var methodsInfo = type.GetMethods().Where(p => p.ReturnType == typeof(void) && p.GetCustomAttributes(typeof(DependencyMethod), false).Any()).ToList();

            foreach (var method in methodsInfo) //we are filling the required methods
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

        private void CheckCycleForType(ContainerMember containerMember) //this function recursively check cycle for constructor and constructor parameters for given type
        {
            if (containerMember.CycleInConstructor.HasValue)
            {
                if (containerMember.CycleInConstructor.Value)
                {
                    throw new CycleForTypeException(containerMember.ReturnType);
                }
                return;
            }

            containerMember.CycleInConstructor = true;

            foreach (var parameter in containerMember.Parameters)
            {
                if (_registeredTypesCache.ContainsKey(parameter.ParameterType)) //if we did not check cycle for a given parameter type, we do it
                {
                    var parameterContainerMember = _registeredTypesCache.GetValue(parameter.ParameterType); //getting a value from the cache for the correct parameter type
                    CheckCycleForType(parameterContainerMember);
                }
            }

            containerMember.CycleInConstructor = false;
        }

        private void CreateAllSingletons()
        {
            var index = 0;
            var singletons = new List<object>();

            foreach (var registeredType in _registeredTypesCache.Where(r => r.Value.Instance != null).ToList())
            {
                singletons.Add(registeredType.Value.Instance);
                _signletonsIndexCache.Add(registeredType.Key, index++);
                if (registeredType.Key != registeredType.Value.ReturnType)
                {
                    singletons.Add(registeredType.Value.Instance);
                    _signletonsIndexCache.Add(registeredType.Value.ReturnType, index++);
                }
            }

            foreach (var registeredType in _registeredTypesCache.Where(r => r.Value.IsSingleton && r.Value.Instance == null).ToList())
            {
                var containerMember = registeredType.Value;

                _signletonsCache = singletons.ToArray();
                containerMember.Instance = ReturnInstance2(containerMember);
                singletons.Add(registeredType.Value.Instance);
                _signletonsIndexCache.Add(registeredType.Key, index++);
                if (registeredType.Key != registeredType.Value.ReturnType)
                {
                    singletons.Add(registeredType.Value.Instance);
                    _signletonsIndexCache.Add(registeredType.Value.ReturnType, index++);
                }
            }

            _signletonsCache = singletons.ToArray();
        }
        #endregion
    }
}