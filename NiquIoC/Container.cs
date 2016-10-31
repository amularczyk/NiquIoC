using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NiquIoC.Attributes;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Extensions;
using NiquIoC.Interfaces;
using NiquIoC.ObjectLifetimeManagers;
using NiquIoC.Resolve;

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

        public T Resolve<T>(ResolveKind resolveKind)
        {
            return (T)Resolve(typeof(T), resolveKind);
        }

        public void BuildUp<T>(T instance, ResolveKind resolveKind)
        {
            var type = typeof(T);
            BuildUp(instance, type.IsInterface ? instance.GetType() : type, resolveKind);
        }
        #endregion

        #region Private Methods
        private IContainerMember RegisterType<T>(IObjectLifetimeManager objectLifetimeManager)
            where T : class
        {
            var type = typeof(T);
            if (type.IsInterface) //we check if a given type is not an interface (we can not register interface that way)
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

        private IContainerMember RegisterType(Type typeFrom, Type typeTo, IObjectLifetimeManager objectLifetimeManager, bool createCache = true)
        {
            if (_registeredTypesCache.ContainsKey(typeFrom)) //if a given type was registered before, we clear cache for it
            {
                _registeredTypesCache.Remove(typeFrom);

                ClearCacheInResolves(typeTo);
            }

            var containerMember = new ContainerMember(objectLifetimeManager) { RegisteredType = typeFrom, ReturnType = typeTo, ShouldCreateCache = createCache};
            if (!createCache) //we do not check for cycle in constructo for type registered as object factory or instance
            {
                containerMember.IsCycleInConstructor = false;
            }

            return Register(containerMember);
        }

        private void ClearCacheInResolves(Type type)
        {
            _partialEmitFunctionResolve.ClearCache(type);
            _fullEmitFunctionResolve.ClearCache(type);
        }

        private IContainerMember Register(ContainerMember containerMember)
        {
            //if the type is not registered yet, we add new value to the cache
            //if the type is registered, we change the value in the cache
            _registeredTypesCache[containerMember.RegisteredType] = containerMember;

            return containerMember;
        }

        private object Resolve(Type type, ResolveKind resolveKind)
        {
            var containerMember = _registeredTypesCache.GetValue(type); //getting a value from the cache for the correct type

            if (!containerMember.IsCycleInConstructor.HasValue) //if we do not check it before, then do it
            {
                if (containerMember.Constructor == null) //if we do not have constructor info in the cache for a given type, we create it
                {
                    CreateCacheForConstructorInfoForTypes(containerMember);
                }

                CheckCycleForType(containerMember); //we check cycle for the type
            }

            switch (resolveKind) //we call method for given resolve kind
            {
                case ResolveKind.PartialEmitFunction:
                    return _partialEmitFunctionResolve.Resolve(containerMember, (obj, cMember) => BuildUp(obj, cMember, resolveKind));

                case ResolveKind.FullEmitFunction:
                    return _fullEmitFunctionResolve.Resolve(containerMember, (obj, cMember) => BuildUp(obj, cMember, resolveKind));

                default:
                    throw new ResolveKindMissingException(resolveKind);
            }
        }

        private void BuildUp(object obj, Type type, ResolveKind resolveKind)
        {
            if (!_registeredTypesCache.ContainsKey(type))
            {
                _registeredTypesCache[type] = new ContainerMember(new TransientObjectLifetimeManager()) { RegisteredType = type, ReturnType = type, ShouldCreateCache = false };
            }

            BuildUp(obj, _registeredTypesCache[type], resolveKind);
        }

        private void BuildUp(object obj, ContainerMember containerMember, ResolveKind resolveKind)
        {
            ResolveProperties(obj, containerMember, resolveKind);
            ResolveMethods(obj, containerMember, resolveKind);
        }

        private void ResolveProperties(object obj, ContainerMember containerMember, ResolveKind resolveKind)
        {
            if (containerMember.PropertiesInfo == null) //if we do not have properties info in the cache, we create it
            {
                containerMember.PropertiesInfo = containerMember.ReturnType.GetProperties().Where(p => p.GetCustomAttributes(typeof(DependencyProperty), false).Any() && p.SetMethod != null).ToList();
            }

            foreach (var property in containerMember.PropertiesInfo) //we are filling the required properties
            {
                property.SetValue(obj, Resolve(property.PropertyType, resolveKind));
            }
        }

        private void ResolveMethods(object obj, ContainerMember containerMember, ResolveKind resolveKind)
        {
            if (containerMember.MethodsInfo == null) //if we do not have methods info in the cache, we create it
            {
                containerMember.MethodsInfo = containerMember.ReturnType.GetMethods().Where(p => p.ReturnType == typeof(void) && p.GetCustomAttributes(typeof(DependencyMethod), false).Any()).ToList();
            }

            foreach (var method in containerMember.MethodsInfo) //we are filling the required methods
            {
                if (!_parametersInfoForMethodCache.ContainsKey(method)) //if we do not have parameters info for method in the cache, we create it
                {
                    _parametersInfoForMethodCache.Add(method, method.GetParameters().ToList());
                }

                var methodParameters = _parametersInfoForMethodCache[method];
                var ctorParametersCount = methodParameters.Count;
                var parameters = new object[ctorParametersCount];
                for (var i = 0; i < ctorParametersCount; i++) //we create as array with the parameters of the method and we fill it
                {
                    parameters[i] = Resolve(methodParameters[i].ParameterType, resolveKind);
                }
                method.Invoke(obj, parameters);
            }
        }

        private void CreateCacheForConstructorInfoForTypes(ContainerMember containerMember) //this function recursively create cache for constructor info and constructor parameters for given type
        {
            var allConstructors = containerMember.ReturnType.GetConstructors();

            //first we are look for the constructor with attribute DependencyConstrutor
            var goodConstructors = allConstructors.Where(c => c.GetCustomAttributes(typeof(DependencyConstrutor), false).Any()).ToList();

            if (!goodConstructors.Any()) //if there is no constructor with this attribute, then we choose constructor with max number of parameters
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

                        if (parameterContainerMember.Constructor == null && parameterContainerMember.ShouldCreateCache)
                            //if we do not have constructor info in the cache for a given constructor parameter type, we create it
                        {
                            CreateCacheForConstructorInfoForTypes(parameterContainerMember);
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
            if (containerMember.IsCycleInConstructor.HasValue) //if there is a value for cycle in constructor, we check is it true or false
            {
                if (containerMember.IsCycleInConstructor.Value) //if it is true (there is cycle in constructor) we throw suitable exception
                {
                    throw new CycleForTypeException(containerMember.ReturnType);
                }
                return; //otherwise we finish, because everything is ok
            }

            containerMember.IsCycleInConstructor = true; //first we mark, that there is cycle in constructor

            foreach (var parameter in containerMember.Parameters)
            {
                if (_registeredTypesCache.ContainsKey(parameter.ParameterType)) //if we did not check cycle for a given parameter type before, we do it now
                {
                    var parameterContainerMember = _registeredTypesCache.GetValue(parameter.ParameterType); //getting a value from the cache for the correct parameter type
                    CheckCycleForType(parameterContainerMember);
                }
            }

            containerMember.IsCycleInConstructor = false; //if everything is ok, we mark that there is no cycle in constructor
        }
        
        #endregion
    }
}