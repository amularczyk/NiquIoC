using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using NiquIoC.Extensions;
using NiquIoC.Helpers;
using NiquIoC.Interfaces;
using NiquIoC.ObjectLifetimeManagers;

namespace NiquIoC.Resolver
{
    internal class FullEmitFunctionResolver : IResolver
    {
        private readonly Dictionary<Type, Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>> _createFullEmitFunctionForConstructorCache;
        private readonly Dictionary<Type, ContainerMember> _registeredTypesCache;
        private int _registeredTypesCacheCount;

        private Dictionary<int, Type> _typesIndexCache;

        public FullEmitFunctionResolver(Dictionary<Type, ContainerMember> registeredTypesCache)
        {
            _registeredTypesCache = registeredTypesCache;
            _typesIndexCache = _registeredTypesCache.ToDictionary(k => k.Value.GetHashCode(), v => v.Key);
            _registeredTypesCacheCount = registeredTypesCache.Count;
            _createFullEmitFunctionForConstructorCache = new Dictionary<Type, Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>>();
        }

        public object Resolve(ContainerMember containerMember, Action<object, ContainerMember> afterObjectCreate)
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

        private object CreateInstanceFunction(ContainerMember containerMember, Action<object, ContainerMember> afterObjectCreate)
        {
            if (!_createFullEmitFunctionForConstructorCache.ContainsKey(containerMember.ReturnType)) //if we do not have a create object function in the cache, we create it
            {
                var factoryMethod = CreateObjectFunction(containerMember, _registeredTypesCache, afterObjectCreate);
                _createFullEmitFunctionForConstructorCache.Add(containerMember.ReturnType, factoryMethod);
            }

            var registeredTypesCacheCount = _registeredTypesCache.Count;
            if (_registeredTypesCacheCount != registeredTypesCacheCount)
            {
                _typesIndexCache = _registeredTypesCache.ToDictionary(k => k.Value.GetHashCode(), v => v.Key);
                _registeredTypesCacheCount = registeredTypesCacheCount;
            }

            var obj = _createFullEmitFunctionForConstructorCache[containerMember.ReturnType](_registeredTypesCache, _typesIndexCache);
            afterObjectCreate(obj, containerMember); //when we have a new instance of the type, we have to resolve the properties and the methods also

            return obj;
        }

        private Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object> CreateObjectFunction(ContainerMember containerMember,
            IReadOnlyDictionary<Type, ContainerMember> registeredTypesCache, Action<object, ContainerMember> afterObjectCreate)
        {
            var dm = new DynamicMethod($"Create_{containerMember.Constructor.DeclaringType?.FullName.Replace('.', '_')}",
                typeof(object), new[] { typeof(Dictionary<Type, ContainerMember>), typeof(Dictionary<int, Type>) }, typeof(Container).Module, true);
            var ilgen = dm.GetILGenerator();

            foreach (var parameter in containerMember.Parameters)
            {
                CreateObjectFunctionPrivate(parameter.ParameterType, registeredTypesCache, ilgen, afterObjectCreate, new Dictionary<Type, LocalBuilder>());
            }
            ilgen.Emit(OpCodes.Newobj, containerMember.Constructor);
            ilgen.Emit(OpCodes.Ret);

            return (Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>)dm.CreateDelegate(typeof(Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>));
        }

        private void CreateObjectFunctionPrivate(Type type, IReadOnlyDictionary<Type, ContainerMember> registeredTypesCache, ILGenerator ilgen, Action<object, ContainerMember> afterObjectCreate,
            IDictionary<Type, LocalBuilder> localSingletons)
        {
            var containerMember = registeredTypesCache.GetValue(type);

            if (containerMember.ObjectLifetimeManager is TransientObjectLifetimeManager
                && containerMember.ShouldCreateCache)
            {
                foreach (var parameter in containerMember.Parameters)
                {
                    CreateObjectFunctionPrivate(parameter.ParameterType, registeredTypesCache, ilgen, afterObjectCreate, localSingletons);
                }

                ilgen.Emit(OpCodes.Newobj, containerMember.Constructor);
            }
            else if ((containerMember.ObjectLifetimeManager is SingletonObjectLifetimeManager
                      || containerMember.ObjectLifetimeManager is ThreadObjectLifetimeManager
                      || containerMember.ObjectLifetimeManager is HttpContextObjectLifetimeManager)
                     && containerMember.ShouldCreateCache)
            {
                if (localSingletons.ContainsKey(type))
                {
                    ilgen.Emit(OpCodes.Ldloc, localSingletons[type]); //when we created local variable that store our object, than we just put this object onto stack
                }
                else
                {
                    var localSingleton = ilgen.DeclareLocal(type); //we create local variable (this local variable will contain our object)
                    localSingletons.Add(type, localSingleton); //we add this local variable into cache

                    AddEmitOperationsToCraeteObjectFromObjectLifetimeManager(type, ilgen, afterObjectCreate, containerMember);

                    var localVariable = localSingletons[type]; //we take local variable from cache
                    ilgen.Emit(OpCodes.Stloc, localVariable); //we store value in local variable
                    ilgen.Emit(OpCodes.Ldloc, localVariable); //we put value from local variable onto stack
                }
            }
            else
            {
                AddEmitOperationsToCraeteObjectFromObjectLifetimeManager(type, ilgen, afterObjectCreate, containerMember);
            }
        }

        private void AddEmitOperationsToCraeteObjectFromObjectLifetimeManager(Type type, ILGenerator ilgen, Action<object, ContainerMember> afterObjectCreate, ContainerMember containerMember)
        {
            if (containerMember.ObjectLifetimeManager.ObjectFactory == null)
            {
                containerMember.ObjectLifetimeManager.ObjectFactory = () => CreateInstanceFunction(containerMember, afterObjectCreate);
            }

            var localTypeVariable = ilgen.DeclareLocal(typeof(Type));
            ilgen.Emit(OpCodes.Ldarg_1);
            EmitHelper.EmitIntOntoStack(ilgen, containerMember.GetHashCode());
            ilgen.Emit(OpCodes.Call, typeof(Dictionary<int, Type>).GetMethod("get_Item"));
            ilgen.Emit(OpCodes.Stloc, localTypeVariable);
            ilgen.Emit(OpCodes.Ldarg_0);
            ilgen.Emit(OpCodes.Ldloc, localTypeVariable);
            ilgen.Emit(OpCodes.Call, typeof(Dictionary<Type, ContainerMember>).GetMethod("get_Item"));
            ilgen.Emit(OpCodes.Call, typeof(ContainerMember).GetMethod("get_ObjectLifetimeManager", Type.EmptyTypes));
            ilgen.Emit(OpCodes.Call, typeof(IObjectLifetimeManager).GetMethod("GetInstance", Type.EmptyTypes));
            ilgen.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);
        }
    }
}