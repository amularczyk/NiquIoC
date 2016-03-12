using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NiquIoC
{
    internal static class EmitHelper
    {
        internal static Func<object[], object> CreateObjectFunction(ConstructorInfo ctor)
        {
            var dm = new DynamicMethod($"_CreateObjectFactory_{Guid.NewGuid()}", typeof (object), new[] {typeof (object[])}, true);
            ILGenerator ilgen = dm.GetILGenerator();
            ilgen.DeclareLocal(typeof (int));
            ilgen.DeclareLocal(typeof (object));

            ilgen.Emit(OpCodes.Ldc_I4_0);
            ilgen.Emit(OpCodes.Stloc_0);

            ParameterInfo[] parameters = ctor.GetParameters();
            for (var i = 0; i < parameters.Length; i++)
            {
                EmitIntOntoStack(ilgen, i);
                ilgen.Emit(OpCodes.Stloc_0);
                ilgen.Emit(OpCodes.Ldarg_0);
                EmitIntOntoStack(ilgen, i);
                ilgen.Emit(OpCodes.Ldelem_Ref);
                Type paramType = parameters[i].ParameterType;
                if (paramType != typeof (object))
                {
                    ilgen.Emit(OpCodes.Castclass, paramType);
                }
            }
            ilgen.Emit(OpCodes.Newobj, ctor);
            ilgen.Emit(OpCodes.Ret);

            return (Func<object[], object>) dm.CreateDelegate(typeof (Func<object[], object>));
        }

        private static void EmitIntOntoStack(ILGenerator il, int value)
        {
            switch (value)
            {
                case -1:
                    il.Emit(OpCodes.Ldc_I4_M1);
                    break;
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
                    if (value >= -128 && value <= 127)
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
    }
}