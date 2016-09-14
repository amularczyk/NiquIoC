using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NiquIoC.Attributes;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Extensions;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    public class Container : IContainer
    {
        //ToDo: WarmUp?
        public Container()
        {
            _registeredTypesCache = new Dictionary<Type, ContainerMember>();

            _parametersInfoForMethodCache = new Dictionary<MethodInfo, List<ParameterInfo>>();

            _partialEmitFunctionResolve = new PartialEmitFunctionResolve(_registeredTypesCache);
            _fullEmitFunctionResolve = new FullEmitFunctionResolve(_registeredTypesCache);
        }

        #region Private Fields
        private readonly Dictionary<Type, ContainerMember> _registeredTypesCache;

        private readonly Dictionary<MethodInfo, List<ParameterInfo>> _parametersInfoForMethodCache;

        private readonly IResolve _partialEmitFunctionResolve;
        private readonly IResolve _fullEmitFunctionResolve;
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
            return (T)Resolve(typeof(T), resolveKind);
        }

        public void BuildUp<T>(T instance)
        {
            var type = typeof(T);
            BuildUp(instance, type.IsInterface ? instance.GetType() : type);
        }
        #endregion

        #region Private Methods
        private object Resolve(Type type, ResolveKind resolveKind)
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

            switch (resolveKind)
            {
                case ResolveKind.PartialEmitFunction:
                    return _partialEmitFunctionResolve.Resolve(containerMember, obj => BuildUp(obj, containerMember));

                case ResolveKind.FullEmitFunction:
                    return _fullEmitFunctionResolve.Resolve(containerMember, obj => BuildUp(obj, containerMember));

                default:
                    throw new NotImplementedException($"ResolveKind {resolveKind} is not implemented.");
            }
        }

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

                ClearCacheInResolves(typeTo);
            }

            return Register(new ContainerMember(objectLifetimeManager) { RegisteredType = typeFrom, ReturnType = typeTo });
        }

        private void ClearCacheInResolves(Type type)
        {
            _partialEmitFunctionResolve.ClearCache(type);
            _fullEmitFunctionResolve.ClearCache(type);
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
            _registeredTypesCache[containerMember.RegisteredType] = containerMember;

            return containerMember;
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

        private void ResolveProperties(object obj, ContainerMember containerMember)
        {
            if (containerMember.PropertiesInfo == null) //if we do not have a properties info in the cache, we create it
            {
                containerMember.PropertiesInfo =
                    containerMember.ReturnType.GetProperties().Where(p => p.GetCustomAttributes(typeof(DependencyProperty), false).Any() && p.SetMethod != null).ToList();
            }

            foreach (var property in containerMember.PropertiesInfo) //we are filling the required properties
            {
                property.SetValue(obj, Resolve(property.PropertyType, ResolveKind.PartialEmitFunction));
            }
        }

        private void ResolveProperties(object obj, Type type)
        {
            var propertiesInfo = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(DependencyProperty), false).Any() && p.SetMethod != null).ToList();

            foreach (var property in propertiesInfo) //we are filling the required properties
            {
                property.SetValue(obj, Resolve(property.PropertyType, ResolveKind.PartialEmitFunction));
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
                    parameters[i] = Resolve(methodParameters[i].ParameterType, ResolveKind.PartialEmitFunction);
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
                    parameters[i] = Resolve(methodParameters[i].ParameterType, ResolveKind.PartialEmitFunction);
                }
                method.Invoke(obj, parameters);
            }
        }

        private void CreateConstructorInfoForTypesCache(ContainerMember containerMember) //this function recursively create cache for constructor info and constructor parameters for given type
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

                        if (parameterContainerMember.Constructor == null && parameterContainerMember.CreateCache)
                            //if we do not have constructor info in the cache for a given parameter type, we create it
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