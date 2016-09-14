using System;
using System.Collections.Generic;
using System.Linq;
using NiquIoC.Helpers;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    internal class FullEmitFunctionResolve : IResolve
    {
        private readonly Dictionary<Type, Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>> _createFullEmitFunctionForConstructorCache;
        private readonly Dictionary<Type, ContainerMember> _registeredTypesCache;
        private Dictionary<int, Type> _typesIndexCache;

        public FullEmitFunctionResolve(Dictionary<Type, ContainerMember> registeredTypesCache)
        {
            _registeredTypesCache = registeredTypesCache;
            _createFullEmitFunctionForConstructorCache = new Dictionary<Type, Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>>();
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
            if (_createFullEmitFunctionForConstructorCache.ContainsKey(type))
            {
                _createFullEmitFunctionForConstructorCache.Remove(type);
            }
        }

        //ToDo: internal
        internal object CreateInstanceFunction(ContainerMember containerMember, Action<object> afterObjectCreate) //ToDo !!
        {
            if (!_createFullEmitFunctionForConstructorCache.ContainsKey(containerMember.ReturnType)) //if we do not have a create object function in the cache, we create it
            {
                var factoryMethod = FullObjectFunction.CreateObjectFunction(this, containerMember, _registeredTypesCache); //ToDo: Type ContainerMember
                _createFullEmitFunctionForConstructorCache.Add(containerMember.ReturnType, factoryMethod);
            }

            _typesIndexCache = _registeredTypesCache.ToDictionary(k => k.Value.GetHashCode(), v => v.Key);
            var obj = _createFullEmitFunctionForConstructorCache[containerMember.ReturnType](_registeredTypesCache, _typesIndexCache);
            afterObjectCreate(obj); //when we have a new instance of the type, we have to resolve the properties and the methods also

            return obj;
        }
    }
}