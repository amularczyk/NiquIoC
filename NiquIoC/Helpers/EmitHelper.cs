using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using NiquIoC.Extensions;
using NiquIoC.Interfaces;

namespace NiquIoC.Helpers
{
    internal static class EmitHelper
    {
        //http://stackoverflow.com/questions/8219343/reflection-emit-create-object-with-parameters
        //http://stackoverflow.com/questions/13478933/reflection-emit-to-create-class-instance
        internal static Func<object[], object> CreateObjectFunction(ConstructorInfo ctor)
        {
            //this method return a function that provide fast creation of a new instastance for given constructorInfo
            var dm = new DynamicMethod($"Create_{ctor.DeclaringType?.FullName.Replace('.', '_')}", typeof(object), new[] {typeof(object[])}, true); //we create a dynamic method
            var ilgen = dm.GetILGenerator(); //we get the IL Generator from dynamic method

            var parameters = ctor.GetParameters(); //we get constructor parameters
            for (var i = 0; i < parameters.Length; i++)
            {
                ilgen.Emit(OpCodes.Ldarg_0); //first we put a correct parameter onto the stack
                EmitIntOntoStack(ilgen, i); //next we put a correct index onto the stack again
                ilgen.Emit(OpCodes.Ldelem_Ref); //then we take an index and a parameter from the stack and we put the parameter in an array in a correct index
                var paramType = parameters[i].ParameterType;
                ilgen.Emit(paramType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, paramType); //finally we cast the parameter to the correct type
            }
            ilgen.Emit(OpCodes.Newobj, ctor); //at the end we create a new object that takes an array of parameters as constructor parameters
            ilgen.Emit(OpCodes.Ret); //we return created object

            return (Func<object[], object>) dm.CreateDelegate(typeof(Func<object[], object>));
        }

        private static void EmitIntOntoStack(ILGenerator il, int value)
        {
            //this method helps put an int value onto the stack
            switch (value)
            {
                case 0:
                    il.Emit(OpCodes.Ldc_I4_0);
                    break;
                case 1:
                    il.Emit(OpCodes.Ldc_I4_1);
                    break;
                case 2:
                    il.Emit(OpCodes.Ldc_I4_2);
                    break;
                case 3:
                    il.Emit(OpCodes.Ldc_I4_3);
                    break;
                case 4:
                    il.Emit(OpCodes.Ldc_I4_4);
                    break;
                case 5:
                    il.Emit(OpCodes.Ldc_I4_5);
                    break;
                case 6:
                    il.Emit(OpCodes.Ldc_I4_6);
                    break;
                case 7:
                    il.Emit(OpCodes.Ldc_I4_7);
                    break;
                case 8:
                    il.Emit(OpCodes.Ldc_I4_8);
                    break;
                default:
                    if (value <= 127)
                    {
                        il.Emit(OpCodes.Ldc_I4_S, (sbyte) value);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldc_I4, value);
                    }
                    break;
            }
        }

        internal static Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object> CreateFullObjectFunction(ContainerMember containerMember, IReadOnlyDictionary<Type, ContainerMember> registeredTypesCache)
        {
            var dm = new DynamicMethod($"Create_{containerMember.Constructor.DeclaringType?.FullName.Replace('.', '_')}",
                typeof(object), new[] {typeof(Dictionary<Type, ContainerMember>), typeof(Dictionary<int, Type>) }, typeof(Container).Module, true);
            var ilgen = dm.GetILGenerator();

            foreach (var parameter in containerMember.Parameters)
            {
                CreateFullObjectFunctionPrivate(parameter.ParameterType, registeredTypesCache, ilgen);
            }
            ilgen.Emit(OpCodes.Newobj, containerMember.Constructor);
            ilgen.Emit(OpCodes.Ret);

            return (Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>) dm.CreateDelegate(typeof(Func<Dictionary<Type, ContainerMember>, Dictionary<int, Type>, object>));
        }

        private static void CreateFullObjectFunctionPrivate(Type type, IReadOnlyDictionary<Type, ContainerMember> registeredTypesCache, ILGenerator ilgen)
        {
            var constructorInfoForType = registeredTypesCache.GetValue(type);

            if (!constructorInfoForType.CreateCache)
            {
                var localTypeVariable = ilgen.DeclareLocal(typeof(Type));
                ilgen.Emit(OpCodes.Ldarg_1);
                EmitIntOntoStack(ilgen, constructorInfoForType.TypeIndex);
                ilgen.Emit(OpCodes.Call, typeof(Dictionary<int, Type>).GetMethod("get_Item"));
                ilgen.Emit(OpCodes.Stloc, localTypeVariable);
                ilgen.Emit(OpCodes.Ldarg_0);
                ilgen.Emit(OpCodes.Ldloc, localTypeVariable);
                ilgen.Emit(OpCodes.Call, typeof(Dictionary<Type, ContainerMember>).GetMethod("get_Item"));
                ilgen.Emit(OpCodes.Call, typeof(ContainerMember).GetMethod("get_ObjectLifetimeManager", Type.EmptyTypes));
                ilgen.Emit(OpCodes.Call, typeof(IObjectLifetimeManager).GetMethod("GetInstance", Type.EmptyTypes));
                ilgen.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);
            }
            else
            {
                foreach (var parameter in constructorInfoForType.Parameters)
                {
                    CreateFullObjectFunctionPrivate(parameter.ParameterType, registeredTypesCache, ilgen);
                }

                ilgen.Emit(OpCodes.Newobj, constructorInfoForType.Constructor);
            }

            //if (signletonsIndexCache.ContainsKey(type))
            //{
            //    ilgen.Emit(OpCodes.Ldarg_0);
            //    EmitIntOntoStack(ilgen, signletonsIndexCache[type]);
            //    ilgen.Emit(OpCodes.Ldelem_Ref);
            //    ilgen.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);
            //}
            //else if (objectFactoryIndexCache.ContainsKey(type))
            //{
            //    ilgen.Emit(OpCodes.Ldarg_1);
            //    EmitIntOntoStack(ilgen, objectFactoryIndexCache[type]);
            //    ilgen.Emit(OpCodes.Ldelem_Ref);
            //    ilgen.Emit(OpCodes.Call, typeof(Func<object>).GetMethod("Invoke", Type.EmptyTypes));
            //    ilgen.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);
            //}
            //else
            //{
            //}
        }
    }
}