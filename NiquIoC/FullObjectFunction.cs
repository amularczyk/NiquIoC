using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using NiquIoC.Extensions;
using NiquIoC.Helpers;
using NiquIoC.Interfaces;

namespace NiquIoC
{
    public class FullObjectFunction
    {
        //ToDo: container
        internal static Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object> CreateObjectFunction(FullEmitFunctionResolve container, ContainerMember containerMember,
            IReadOnlyDictionary<Type, ContainerMember> registeredTypesCache)
        {
            var dm = new DynamicMethod($"Create_{containerMember.Constructor.DeclaringType?.FullName.Replace('.', '_')}",
                typeof(object), new[] { typeof(Dictionary<Type, ContainerMember>), typeof(Dictionary<int, Type>) }, typeof(Container).Module, true);
            var ilgen = dm.GetILGenerator();

            foreach (var parameter in containerMember.Parameters)
            {
                CreateObjectFunctionPrivate(container, parameter.ParameterType, registeredTypesCache, ilgen);
            }
            ilgen.Emit(OpCodes.Newobj, containerMember.Constructor);
            ilgen.Emit(OpCodes.Ret);

            return (Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>)dm.CreateDelegate(typeof(Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>));
        }

        private static void CreateObjectFunctionPrivate(FullEmitFunctionResolve container, Type type, IReadOnlyDictionary<Type, ContainerMember> registeredTypesCache, ILGenerator ilgen)
        {
            var constructorInfoForType = registeredTypesCache.GetValue(type);

            if (constructorInfoForType.ObjectLifetimeManager.ObjectFactory == null)
            {
                constructorInfoForType.ObjectLifetimeManager.ObjectFactory = () => container.CreateInstanceFunction(constructorInfoForType, obj => { }); //ToDo: action
            }

            var localTypeVariable = ilgen.DeclareLocal(typeof(Type));
            ilgen.Emit(OpCodes.Ldarg_1);
            EmitHelper.EmitIntOntoStack(ilgen, constructorInfoForType.GetHashCode());
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