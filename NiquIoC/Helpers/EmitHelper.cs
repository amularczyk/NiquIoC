using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NiquIoC.Helpers
{
    internal static class EmitHelper
    {
        //http://stackoverflow.com/questions/8219343/reflection-emit-create-object-with-parameters
        internal static Func<object[], object> CreateObjectFunction(ConstructorInfo ctor)
        {
            //this method return a function that provide fast creation of a new instastance for given constructorInfo
            var dm = new DynamicMethod($"Create_{ctor.DeclaringType?.FullName.Replace('.', '_')}", typeof (object), new[] {typeof (object[])}, true); //we create a dynamic method
            ILGenerator ilgen = dm.GetILGenerator();    //we get the IL Generator from dynamic method
            
            ParameterInfo[] parameters = ctor.GetParameters();  //we get constructor parameters
            for (var i = 0; i < parameters.Length; i++)
            {
                ilgen.Emit(OpCodes.Ldarg_0);    //first we put a correct parameter onto the stack
                EmitIntOntoStack(ilgen, i);     //next we put a correct index onto the stack again
                ilgen.Emit(OpCodes.Ldelem_Ref); //then we take an index and a parameter from the stack and we put the parameter in an array in a correct index
                Type paramType = parameters[i].ParameterType;
                ilgen.Emit(OpCodes.Castclass, paramType);   //finally we cast the parameter to the correct type
            }
            ilgen.Emit(OpCodes.Newobj, ctor);   //at the end we create a new object that takes an array of parameters as constructor parameters
            ilgen.Emit(OpCodes.Ret);            //we return created object

            return (Func<object[], object>) dm.CreateDelegate(typeof (Func<object[], object>));
        }

        private static void EmitIntOntoStack(ILGenerator il, int value)
        {
            //this method helps put an int value onto the stack
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