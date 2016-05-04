using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NiquIoC.Attributes;
using NiquIoC.Exceptions;
using NiquIoC.Helpers;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    public class Container : IContainer
    {
        //ToDo: WarmUp?
        public Container()
        {
            _registeredTypeCache = new Dictionary<Type, ContainerMember>();
            _noCycleForTypeCache = new Dictionary<Type, bool>();
            _constructorInfoForTypeCache = new Dictionary<Type, ContainerConstructorInfo>();
            _createObjectFunctionForConstructorCache = new Dictionary<ConstructorInfo, Func<object[], object>>();
            _createObjectFunctionForConstructorCache2 = new Dictionary<Type, Func<object>>();
            _propertiesInfoForTypeCache = new Dictionary<Type, IList<PropertyInfo>>();
            _methodsInfoForTypeCache = new Dictionary<Type, IList<MethodInfo>>();
            _parametersInfoForMethodCache = new Dictionary<MethodInfo, IList<ParameterInfo>>();
        }

        #region Private Fields

        private readonly IDictionary<Type, ContainerMember> _registeredTypeCache;
        private readonly IDictionary<Type, bool> _noCycleForTypeCache;
        private readonly IDictionary<Type, ContainerConstructorInfo> _constructorInfoForTypeCache;
        private readonly IDictionary<ConstructorInfo, Func<object[], object>> _createObjectFunctionForConstructorCache;
        private readonly IDictionary<Type, Func<object>> _createObjectFunctionForConstructorCache2;
        private readonly IDictionary<Type, IList<PropertyInfo>> _propertiesInfoForTypeCache;
        private readonly IDictionary<Type, IList<MethodInfo>> _methodsInfoForTypeCache;
        private readonly IDictionary<MethodInfo, IList<ParameterInfo>> _parametersInfoForMethodCache;

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

        #endregion

        #region Private Methods

        private IContainerMember RegisterType(Type typeFrom, Type typeTo)
        {
            if (_constructorInfoForTypeCache.ContainsKey(typeTo))
            {
                _constructorInfoForTypeCache.Remove(typeTo);
            }

            if (_noCycleForTypeCache.ContainsKey(typeFrom))
            {
                _noCycleForTypeCache.Remove(typeFrom);
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
            _registeredTypeCache[containerMember.RegisteredType] = containerMember;

            return containerMember;
        }

        private object Resolve(Type type)
        {
            var result = GetContainerMember(type); //getting a value from the cache for the correct type

            if (result.ObjectFactory == null) //we do not need to create cache or check cycle for object factory
            {
                if (!_constructorInfoForTypeCache.ContainsKey(result.ReturnType)) //if we do not have constructor info in the cache for a given type, we create it
                {
                    CreateConstructorInfoForTypeCache(result.ReturnType);
                }

                CheckCycleForType(result.ReturnType); //at the beginning we check cycle for the type
            }

            return Resolve(result);
        }

        private object Resolve(ContainerMember result)
        {
            if (!result.IsSingleton) //if type is not registered as singleton we return a new instance all the time
            {
                return ReturnInstance(result);
            }

            if (result.Instance != null) //for singleton if we created an instance earlier, we return this value
            {
                return result.Instance;
            }

            var value = ReturnInstance(result);
            result.Instance = value;

            return value;
        }

        private object Resolve2(Type type)
        {
            var result = GetContainerMember(type); //getting a value from the cache for the correct type

            if (result.ObjectFactory == null) //we do not need to create cache or check cycle for object factory
            {
                if (!_constructorInfoForTypeCache.ContainsKey(result.ReturnType)) //if we do not have constructor info in the cache for a given type, we create it
                {
                    CreateConstructorInfoForTypeCache(result.ReturnType);
                }

                CheckCycleForType(result.ReturnType); //at the beginning we check cycle for the type
            }

            return Resolve2(result);
        }

        private object Resolve2(ContainerMember result)
        {
            if (!result.IsSingleton) //if type is not registered as singleton we return a new instance all the time
            {
                return ReturnInstance2(result);
            }

            if (result.Instance != null) //for singleton if we created an instance earlier, we return this value
            {
                return result.Instance;
            }

            var value = ReturnInstance2(result);
            result.Instance = value;

            return value;
        }

        private object ReturnInstance(IContainerMember result)
        {
            return _registeredTypeCache[result.RegisteredType].ObjectFactory != null
                ? _registeredTypeCache[result.RegisteredType].ObjectFactory()
                : CreateInstance(result.ReturnType);
        }

        private object ReturnInstance2(IContainerMember result)
        {
            return _registeredTypeCache[result.RegisteredType].ObjectFactory != null
                ? _registeredTypeCache[result.RegisteredType].ObjectFactory()
                : CreateInstance2(result.ReturnType);
        }

        private object CreateInstance(Type type)
        {
            var ctor = _constructorInfoForTypeCache[type].Constructor;
            var ctorParameters = _constructorInfoForTypeCache[type].Parameters;
            var ctorParametersCount = ctorParameters.Count;

            var parameters = new object[ctorParametersCount];
            for (var i = 0; i < ctorParametersCount; i++) //we create as array with the parameters of the constructor and we fill it
            {
                parameters[i] = Resolve(ctorParameters[i].ParameterType);
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
            if (!_constructorInfoForTypeCache.ContainsKey(type)) //if we do not have constructor info in the cache for a given type, we create it
            {
                CreateConstructorInfoForTypeCache(type);
            }

            if (!_createObjectFunctionForConstructorCache2.ContainsKey(type)) //if we do not have a create object function in the cache, we create it
            {
                var factoryMethod = EmitHelper.CreateFullObjectFunction(type, _constructorInfoForTypeCache);
                _createObjectFunctionForConstructorCache2.Add(type, factoryMethod);
            }

            var obj = _createObjectFunctionForConstructorCache2[type]();
            ResolveProperties(obj, type); //when we have a new instance of the type, we have to resolve the properties also
            ResolveMethods(obj, type); //when we have a new instance of the type, we have to resolve the methods also

            return obj;
        }

        private void CreateConstructorInfoForTypeCache(Type type) //this function recursively create cache for constructor info and constructor parameters for given type
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
                var constructor = goodConstructors.First();
                var consParameters = (IList<ParameterInfo>) constructor.GetParameters();

                _constructorInfoForTypeCache.Add(type, new ContainerConstructorInfo(constructor, consParameters));

                foreach (var consParameter in consParameters)
                {
                    var parameterType = consParameter.ParameterType;
                    if (_registeredTypeCache.ContainsKey(parameterType))
                    {
                        if (parameterType.IsInterface)  //if a type is interface than we get return type for it
                        {
                            parameterType = _registeredTypeCache[parameterType].ReturnType;
                        }

                        //if we do not have constructor info in the cache for a given parameter type, we create it
                        if (!_constructorInfoForTypeCache.ContainsKey(parameterType))
                        {
                            CreateConstructorInfoForTypeCache(parameterType);
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
            if (!_propertiesInfoForTypeCache.ContainsKey(type)) //if we do not have a properties info in the cache, we create it
            {
                _propertiesInfoForTypeCache.Add(type,
                    type.GetProperties().Where(p => p.GetCustomAttributes(typeof(DependencyProperty), false).Any() && p.SetMethod != null).ToList());
            }

            var properties = _propertiesInfoForTypeCache[type];
            foreach (var property in properties) //we are filling the required properties
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

            var methods = _methodsInfoForTypeCache[type];
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
            if (_noCycleForTypeCache.ContainsKey(type))
            {
                if (!_noCycleForTypeCache[type])
                {
                    throw new CycleForTypeException(type);
                }
                return;
            }

            if (!_registeredTypeCache.ContainsKey(type) && !_constructorInfoForTypeCache.ContainsKey(type))
            {
                return;
            }

            _noCycleForTypeCache.Add(type, false);

            var parameters = _constructorInfoForTypeCache.ContainsKey(type)
                ? _constructorInfoForTypeCache[type].Parameters
                : _constructorInfoForTypeCache[GetContainerMember(type).ReturnType].Parameters;
            foreach (var parameter in parameters)
            {
                CheckCycleForType(parameter.ParameterType);
            }

            _noCycleForTypeCache[type] = true;
        }

        private ContainerMember GetContainerMember(Type type)
        {
            try
            {
                return _registeredTypeCache[type];
            }
            catch (KeyNotFoundException)
            {
                throw new TypeNotRegisteredException(type);
            }
        }

        #endregion
    }
}