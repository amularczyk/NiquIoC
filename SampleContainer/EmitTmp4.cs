using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace SampleContainer
{
    public class EmitTmp4
    {
        static Dictionary<Type, Func<object[], object>> _createCache = new Dictionary<Type, Func<object[], object>>();

        public static object Create<T>()
        {
            var ctor = GetConstructor(typeof(T));
            if (ctor != null)
            {
                var dm = new DynamicMethod($"_CreationFacotry_{Guid.NewGuid()}", typeof (object), new[] {typeof (object[])}, true);
                var ilgen = dm.GetILGenerator();
                ilgen.DeclareLocal(typeof (int));
                ilgen.DeclareLocal(typeof (object));

                ilgen.Emit(OpCodes.Ldc_I4_0); // [0]
                ilgen.Emit(OpCodes.Stloc_0); //[nothing]

                var parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    EmitInt32(ilgen, i); // [args][index]
                    ilgen.Emit(OpCodes.Stloc_0); // [args][index]
                    ilgen.Emit(OpCodes.Ldarg_0); //[args]
                    EmitInt32(ilgen, i); // [args][index]
                    ilgen.Emit(OpCodes.Ldelem_Ref); // [item-in-args-at-index]
                    var paramType = parameters[i].ParameterType;
                    if (paramType != typeof (object))
                    {
                        ilgen.Emit(OpCodes.Castclass, paramType); //Cast to Type t
                    }
                }
                ilgen.Emit(OpCodes.Newobj, ctor); //[new-object]
                //ilgen.Emit(OpCodes.Stloc_1); // nothing
                //ilgen.Emit(OpCodes.Ldloc_1); //[new-object]
                ilgen.Emit(OpCodes.Ret);

                var factoryMethod = (Func<object[], object>) dm.CreateDelegate(typeof (Func<object[], object>));
                _createCache.Add(typeof(T), factoryMethod);

                var arguments = parameters.Select(p => CreateObject(GetConstructor(p.ParameterType))).ToArray();

                var result = (T)factoryMethod(arguments);
                return result;
            }

            return null;
        }

        private static ConstructorInfo GetConstructor(Type type)
        {
            return type.GetConstructors()[0];
        }

        private static object CreateObject(ConstructorInfo ctor)
        {
            return ctor.Invoke(null);
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