using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace SampleContainer
{
    public class EmitTmp2
    {
        public T Create<T>()
        {
            DynamicMethod create = new DynamicMethod($"_CreationFacotry_{Guid.NewGuid()}", typeof(object), Type.EmptyTypes, true);
            ILGenerator ilgen = create.GetILGenerator();

            ilgen.DeclareLocal(typeof(int));
            ilgen.DeclareLocal(typeof(object));

            ilgen.Emit(OpCodes.Ldc_I4_0); // [0]
            ilgen.Emit(OpCodes.Stloc_0); //[nothing]
            
            var ctor = typeof(T).GetConstructors()[0];
            var parameters = ctor.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                var paramType = parameters[i].ParameterType;

                EmitInt32(ilgen, i); // [args][index]
                ilgen.Emit(OpCodes.Stloc_0); // [args][index]
                //ilgen.Emit(OpCodes.Ldarg_0); //[args]
                var paramCtor = paramType.GetConstructors()[0];
                ilgen.Emit(OpCodes.Newobj, paramCtor);
                EmitInt32(ilgen, i); // [args][index]
                ilgen.Emit(OpCodes.Ldelem_Ref); // [item-in-args-at-index]
                ilgen.Emit(OpCodes.Castclass, paramType); //Cast to Type t
            }

            ilgen.Emit(OpCodes.Newobj, ctor);
            ilgen.Emit(OpCodes.Ret);

            return (T)create.Invoke(null, null);
        }

        private static void EmitInt32(ILGenerator il, int value)
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
                        il.Emit(OpCodes.Ldc_I4_S, (sbyte)value);
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