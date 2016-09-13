using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NiquIoC.Attributes;
using NiquIoC.Enums;
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
            _typesIndexCache = new Dictionary<int, Type>();

            _createPartialEmitFunctionForConstructorCache = new Dictionary<ConstructorInfo, Func<object[], object>>();
            _createFullEmitFunctionForConstructorCache = new Dictionary<Type, Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>>();

            _parametersInfoForMethodCache = new Dictionary<MethodInfo, List<ParameterInfo>>();

            _warmedUp = false;
            _typeIndex = 0;
        }

        #region Private Fields
        private readonly Dictionary<Type, ContainerMember> _registeredTypesCache;
        private readonly Dictionary<int, Type> _typesIndexCache;

        private readonly Dictionary<ConstructorInfo, Func<object[], object>> _createPartialEmitFunctionForConstructorCache;
        private readonly Dictionary<Type, Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>> _createFullEmitFunctionForConstructorCache;

        private readonly Dictionary<MethodInfo, List<ParameterInfo>> _parametersInfoForMethodCache;
        
        private bool _warmedUp;
        private int _typeIndex;
        #endregion

        #region IContainer
        public IContainerMember RegisterType<T>()
            where T : class
        {
            return RegisterType<T>(new TransientObjectLifetimeManager());
        }

        public IContainerMember RegisterType<TFrom, TTo>()
            where TTo : TFrom
        {
            return RegisterType<TFrom, TTo>(new TransientObjectLifetimeManager());
        }

        public IContainerMember RegisterType<T>(Func<object> objectFactory)
            where T : class
        {
            var type = typeof(T);

            return RegisterType(type, type, new TransientObjectLifetimeManager { ObjectFactory = objectFactory }, false);
        }

        public IContainerMember RegisterInstance<T>(T instance)
        {
            var type = typeof(T);

            return RegisterType(type, type.IsInterface ? instance.GetType() : type, new SingletonObjectLifetimeManager { ObjectFactory = () => instance }, false);
        }

        public T Resolve<T>(ResolveKind resolveKind = ResolveKind.PartialEmitFunction)
        {
            switch (resolveKind)
            {
                case ResolveKind.PartialEmitFunction:
                    return (T)ResolvePartialEmitFunction(typeof(T));

                case ResolveKind.FullEmitFunction:
                    return (T)ResolveFullEmitFunction(typeof(T));

                default:
                    throw new NotImplementedException($"ResolveKind {resolveKind} is not implemented.");
            }
        }

        public void BuildUp<T>(T instance)
        {
            var type = typeof(T);
            BuildUp(instance, type.IsInterface ? instance.GetType() : type);
        }

        public void WarmUp(bool full = false) //ToDo !!
        {
            //foreach (var registeredType in _registeredTypesCache)
            //{
            //    if (registeredType.Value.ObjectFactory == null && registeredType.Value.Instance == null)
            //    {
            //        if (registeredType.Value.Constructor == null)
            //        {
            //            CreateConstructorInfoForTypesCache(registeredType.Value);
            //        }

            //        CheckCycleForType(registeredType.Value);
            //    }
            //}
            //CreateAllSingletons();

            //if (full)
            //{
            //    //TODO: Genereta all caches (including createObjectFunction)
            //}

            //_warmedUp = true;
        }
        #endregion

        #region Private Methods

        private IContainerMember RegisterType<T>(IObjectLifetimeManager objectLifetimeManager)
            where T : class
        {
            var type = typeof(T);
            if (type.IsInterface)
            {
                throw new WrongInterfaceRegistrationException(type);
            }

            return RegisterType(type, type, objectLifetimeManager);
        }

        private IContainerMember RegisterType<TFrom, TTo>(IObjectLifetimeManager objectLifetimeManager)
            where TTo : TFrom
        {
            return RegisterType(typeof(TFrom), typeof(TTo), objectLifetimeManager);
        }

        private IContainerMember RegisterType(Type typeFrom, Type typeTo, IObjectLifetimeManager objectLifetimeManager)
        {
            if (_registeredTypesCache.ContainsKey(typeFrom))
            {
                _registeredTypesCache.Remove(typeFrom);
                _warmedUp = false;

                if (_createFullEmitFunctionForConstructorCache.ContainsKey(typeTo))
                {
                    _createFullEmitFunctionForConstructorCache.Remove(typeTo);
                }
            }

            return Register(new ContainerMember(objectLifetimeManager) { RegisteredType = typeFrom, ReturnType = typeTo });
        }

        private IContainerMember RegisterType(Type typeFrom, Type typeTo, IObjectLifetimeManager objectLifetimeManager, bool createCache)
        {
            var containerMember = new ContainerMember(objectLifetimeManager) { RegisteredType = typeFrom, ReturnType = typeTo, CreateCache = createCache };
            if (!createCache)
            {
                containerMember.CycleInConstructor = false;
            }

            return Register(containerMember);
        }

        private IContainerMember Register(ContainerMember containerMember)
        {
            //if the type is not registered yet, we add new value to the cache
            //if the type is registered, we change the value in the cache
            containerMember.TypeIndex = _typeIndex;
            _registeredTypesCache[containerMember.RegisteredType] = containerMember;
            _typesIndexCache[_typeIndex] = containerMember.RegisteredType;
            _typeIndex++;

            return containerMember;
        }

        private object ResolvePartialEmitFunction(Type type)
        {
            var containerMember = _registeredTypesCache.GetValue(type); //getting a value from the cache for the correct type

            //ToDo: Comments
            if (!containerMember.CycleInConstructor.HasValue) //we do not need to create cache or check cycle for object factory or instance
            {
                if (containerMember.Constructor == null) //if we do not have constructor info in the cache for a given type, we create it
                {
                    CreateConstructorInfoForTypesCache(containerMember);
                }

                CheckCycleForType(containerMember); //at the beginning we check cycle for the type
            }

            return ResolvePartialEmitFunction(containerMember);
        }

        private object ResolvePartialEmitFunction(ContainerMember containerMember)
        {
            if (containerMember.ObjectLifetimeManager.ObjectFactory == null)
            {
                containerMember.ObjectLifetimeManager.ObjectFactory = () => CreateInstancePartialEmitFunction(containerMember);
            }

            return containerMember.ObjectLifetimeManager.GetInstance();
        }

        private object ResolveFullEmitFunction(Type type)
        {
            var containerMember = _registeredTypesCache.GetValue(type); //getting a value from the cache for the correct type

            //ToDo: Comments
            if (!containerMember.CycleInConstructor.HasValue) //we do not need to create cache or check cycle for object factory or instance
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

            return ResolveFullEmitFunction(containerMember);
        }

        private object ResolveFullEmitFunction(ContainerMember containerMember)
        {
            if (containerMember.ObjectLifetimeManager.ObjectFactory == null)
            {
                containerMember.ObjectLifetimeManager.ObjectFactory = () => CreateInstanceFullEmitFunction(containerMember);
            }

            return containerMember.ObjectLifetimeManager.GetInstance();
        }

        private object CreateInstancePartialEmitFunction(ContainerMember containerMember)
        {
            var ctor = containerMember.Constructor;
            var ctorParameters = containerMember.Parameters;
            var ctorParametersCount = ctorParameters.Count;

            var parameters = new object[ctorParametersCount];
            for (var i = 0; i < ctorParametersCount; i++) //we create as array with the parameters of the constructor and we fill it
            {
                var parameterContainerMember = _registeredTypesCache.GetValue(ctorParameters[i].ParameterType);
                parameters[i] = ResolvePartialEmitFunction(parameterContainerMember);
            }

            if (!_createPartialEmitFunctionForConstructorCache.ContainsKey(ctor)) //if we do not have a create object function in the cache, we create it
            {
                var factoryMethod = PartialObjectFunction.CreateObjectFunction(ctor);
                _createPartialEmitFunctionForConstructorCache.Add(ctor, factoryMethod);
            }

            var obj = _createPartialEmitFunctionForConstructorCache[ctor](parameters);
            BuildUp(obj, containerMember); //when we have a new instance of the type, we have to resolve the properties and the methods also

            return obj;
        }

        //ToDo: internal
        internal object CreateInstanceFullEmitFunction(ContainerMember containerMember) //ToDo !!
        {
            if (!_createFullEmitFunctionForConstructorCache.ContainsKey(containerMember.ReturnType)) //if we do not have a create object function in the cache, we create it
            {
                var factoryMethod = FullObjectFunction.CreateObjectFunction(this, containerMember, _registeredTypesCache);
                _createFullEmitFunctionForConstructorCache.Add(containerMember.ReturnType, factoryMethod);
            }

            var obj = _createFullEmitFunctionForConstructorCache[containerMember.ReturnType](_registeredTypesCache, _typesIndexCache);
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

                        if (parameterContainerMember.Constructor == null && parameterContainerMember.CreateCache) //if we do not have constructor info in the cache for a given parameter type, we create it
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
                property.SetValue(obj, ResolvePartialEmitFunction(property.PropertyType));
            }
        }

        private void ResolveProperties(object obj, Type type)
        {
            var propertiesInfo = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(DependencyProperty), false).Any() && p.SetMethod != null).ToList();

            foreach (var property in propertiesInfo) //we are filling the required properties
            {
                property.SetValue(obj, ResolvePartialEmitFunction(property.PropertyType));
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
                    parameters[i] = ResolvePartialEmitFunction(methodParameters[i].ParameterType);
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
                    parameters[i] = ResolvePartialEmitFunction(methodParameters[i].ParameterType);
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
        #endregion
    }
}