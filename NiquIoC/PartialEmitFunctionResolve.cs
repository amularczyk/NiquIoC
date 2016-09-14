using System;
using System.Collections.Generic;
using NiquIoC.Extensions;
using NiquIoC.Helpers;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    internal class PartialEmitFunctionResolve : IResolve
    {
        private readonly Dictionary<Type, Func<object[], object>> _createPartialEmitFunctionForConstructorCache;
        private readonly Dictionary<Type, ContainerMember> _registeredTypesCache;

        public PartialEmitFunctionResolve(Dictionary<Type, ContainerMember> registeredTypesCache)
        {
            _registeredTypesCache = registeredTypesCache;
            _createPartialEmitFunctionForConstructorCache = new Dictionary<Type, Func<object[], object>>();
        }

        public object Resolve(ContainerMember containerMember, Action<object> afterObjectCreate)
        {
            if (containerMember.ObjectLifetimeManager.ObjectFactory == null)
            {
                containerMember.ObjectLifetimeManager.ObjectFactory = () => CreateInstanceFunction(containerMember, afterObjectCreate);
            }

            return containerMember.ObjectLifetimeManager.GetInstance();
        }

        public void ClearCache(Type type)
        {
            if (_createPartialEmitFunctionForConstructorCache.ContainsKey(type))
            {
                _createPartialEmitFunctionForConstructorCache.Remove(type);
            }
        }

        private object CreateInstanceFunction(ContainerMember containerMember, Action<object> afterObjectCreate)
        {
            var ctor = containerMember.Constructor;
            var ctorParameters = containerMember.Parameters;
            var ctorParametersCount = ctorParameters.Count;

            var parameters = new object[ctorParametersCount];
            for (var i = 0; i < ctorParametersCount; i++) //we create as array with the parameters of the constructor and we fill it
            {
                var parameterContainerMember = _registeredTypesCache.GetValue(ctorParameters[i].ParameterType);
                parameters[i] = Resolve(parameterContainerMember, afterObjectCreate);
            }

            if (!_createPartialEmitFunctionForConstructorCache.ContainsKey(containerMember.ReturnType)) //if we do not have a create object function in the cache, we create it
            {
                var factoryMethod = PartialObjectFunction.CreateObjectFunction(containerMember);
                _createPartialEmitFunctionForConstructorCache.Add(containerMember.ReturnType, factoryMethod);
            }

            var obj = _createPartialEmitFunctionForConstructorCache[containerMember.ReturnType](parameters);
            afterObjectCreate(obj); //when we have a new instance of the type, we have to resolve the properties and the methods also

            return obj;
        }
    }
}