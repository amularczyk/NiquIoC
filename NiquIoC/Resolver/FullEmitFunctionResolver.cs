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
        private readonly Dictionary<Type, FullEmitFunctionResult>
            _createFullEmitFunctionForConstructorCache;

        private readonly Dictionary<Type, ContainerMember> _registeredTypesCache;
        private int _registeredTypesCacheCount;

        private Dictionary<int, Type> _typesIndexCache;

        public FullEmitFunctionResolver(Dictionary<Type, ContainerMember> registeredTypesCache)
        {
            _registeredTypesCache = registeredTypesCache;
            _typesIndexCache =
                _registeredTypesCache.ToDictionary(k => k.Value.GetHashCode(), v => v.Key);
            _registeredTypesCacheCount = registeredTypesCache.Count;
            _createFullEmitFunctionForConstructorCache =
                new Dictionary<Type, FullEmitFunctionResult>();
        }

        public object Resolve(ContainerMember containerMember,
            Action<object, ContainerMember> afterObjectCreate)
        {
            if (containerMember.ObjectLifetimeManager.ObjectFactory == null)
            {
                containerMember.ObjectLifetimeManager.ObjectFactory =
                    () => GetObject(containerMember, afterObjectCreate);
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

        private object GetObject(ContainerMember containerMember,
            Action<object, ContainerMember> afterObjectCreate)
        {
            var obj = CreateInstanceFunction(containerMember);
            //when we have a new instance of the type, we have to resolve the properties and the methods also
            afterObjectCreate(obj, containerMember);

            return obj;
        }

        private object CreateInstanceFunction(ContainerMember containerMember)
        {
            //if we do not have a create object function in the cache, we create it
            if (!_createFullEmitFunctionForConstructorCache.ContainsKey(containerMember.ReturnType))
            {
                var factoryMethod = CreateObjectFunction(containerMember, _registeredTypesCache);
                _createFullEmitFunctionForConstructorCache.Add(
                    containerMember.ReturnType, factoryMethod);
            }

            ValidateTypesCache();

            var obj =
                _createFullEmitFunctionForConstructorCache[containerMember.ReturnType]
                    .Result(_registeredTypesCache, _typesIndexCache);

            return obj;
        }

        private void ValidateTypesCache()
        {
            var registeredTypesCacheCount = _registeredTypesCache.Count;
            if (_registeredTypesCacheCount != registeredTypesCacheCount)
            {
                _typesIndexCache =
                    _registeredTypesCache.ToDictionary(k => k.Value.GetHashCode(), v => v.Key);
                _registeredTypesCacheCount = registeredTypesCacheCount;
            }
        }

        private FullEmitFunctionResult CreateObjectFunction(ContainerMember containerMember,
            IReadOnlyDictionary<Type, ContainerMember> registeredTypesCache)
        {
            var dm = new DynamicMethod(
                $"Create_{containerMember.Constructor.DeclaringType?.FullName.Replace('.', '_')}",
                typeof(object),
                new[] {typeof(Dictionary<Type, ContainerMember>), typeof(Dictionary<int, Type>)},
                typeof(Container).Module, true);
            var ilgen = dm.GetILGenerator();

            foreach (var parameter in containerMember.Parameters)
            {
                CreateObjectFunctionPrivate(parameter.ParameterType, registeredTypesCache, ilgen,
                    new Dictionary<Type, LocalBuilder>());
            }
            ilgen.Emit(OpCodes.Newobj, containerMember.Constructor);
            ilgen.Emit(OpCodes.Ret);

            var func = dm.CreateDelegate(
                typeof(Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>));
            return new FullEmitFunctionResult
            {
                Result =
                    (Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>)func
            };
        }

        private void CreateObjectFunctionPrivate(Type type,
            IReadOnlyDictionary<Type, ContainerMember> registeredTypesCache, ILGenerator ilgen,
            IDictionary<Type, LocalBuilder> localSingletons)
        {
            var containerMember = registeredTypesCache.GetValue(type);

            if (IsTransient(containerMember) && containerMember.ShouldCreateCache)
            {
                foreach (var parameter in containerMember.Parameters)
                {
                    CreateObjectFunctionPrivate(parameter.ParameterType, registeredTypesCache,
                        ilgen, localSingletons);
                }

                ilgen.Emit(OpCodes.Newobj, containerMember.Constructor);
            }
            else if (IsSingleton(containerMember) && containerMember.ShouldCreateCache)
            {
                if (localSingletons.ContainsKey(type))
                {
                    //when we created local variable that store our object, than we just put this object onto stack
                    ilgen.Emit(OpCodes.Ldloc, localSingletons[type]);
                }
                else
                {
                    //we create local variable (this local variable will contain our object)
                    var localSingleton = ilgen.DeclareLocal(type);
                    //we add this local variable into cache
                    localSingletons.Add(type, localSingleton);

                    AddObjectCreatedByObjectLifetimeManager(type, ilgen, containerMember);

                    //we take local variable from cache
                    var localVariable = localSingletons[type];
                    //we store value in local variable
                    ilgen.Emit(OpCodes.Stloc, localVariable);
                    //we put value from local variable onto stack
                    ilgen.Emit(OpCodes.Ldloc, localVariable);
                }
            }
            else
            {
                AddObjectCreatedByObjectLifetimeManager(type, ilgen, containerMember);
            }
        }

        private static bool IsTransient(ContainerMember containerMember)
        {
            return containerMember.ObjectLifetimeManager is TransientObjectLifetimeManager;
        }

        private static bool IsSingleton(ContainerMember containerMember)
        {
            return containerMember.ObjectLifetimeManager is SingletonObjectLifetimeManager ||
                   containerMember.ObjectLifetimeManager is ThreadObjectLifetimeManager ||
                   containerMember.ObjectLifetimeManager is HttpContextObjectLifetimeManager;
        }

        private void AddObjectCreatedByObjectLifetimeManager(Type type, ILGenerator ilgen,
            ContainerMember containerMember)
        {
            if (containerMember.ObjectLifetimeManager.ObjectFactory == null)
            {
                containerMember.ObjectLifetimeManager.ObjectFactory =
                    () => CreateInstanceFunction(containerMember);
            }

            var localTypeVariable = ilgen.DeclareLocal(typeof(Type));
            ilgen.Emit(OpCodes.Ldarg_1);
            EmitHelper.EmitIntOntoStack(ilgen, containerMember.GetHashCode());
            ilgen.Emit(OpCodes.Call, typeof(Dictionary<int, Type>).GetMethod("get_Item"));
            ilgen.Emit(OpCodes.Stloc, localTypeVariable);
            ilgen.Emit(OpCodes.Ldarg_0);
            ilgen.Emit(OpCodes.Ldloc, localTypeVariable);
            ilgen.Emit(OpCodes.Call,
                typeof(Dictionary<Type, ContainerMember>).GetMethod("get_Item"));
            ilgen.Emit(OpCodes.Call,
                typeof(ContainerMember).GetMethod("get_ObjectLifetimeManager", Type.EmptyTypes));
            ilgen.Emit(OpCodes.Call,
                typeof(IObjectLifetimeManager).GetMethod("GetInstance", Type.EmptyTypes));
            ilgen.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);
        }
    }
}