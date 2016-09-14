using System;
using System.Reflection.Emit;
using NiquIoC.Helpers;

namespace NiquIoC
{
    public class PartialObjectFunction
    {
        //http://stackoverflow.com/questions/8219343/reflection-emit-create-object-with-parameters
        //http://stackoverflow.com/questions/13478933/reflection-emit-to-create-class-instance
        internal static Func<object[], object> CreateObjectFunction(ContainerMember containerMember)
        {
            var ctor = containerMember.Constructor;
            //this method return a function that provide fast creation of a new instastance for given constructorInfo
            var dm = new DynamicMethod($"Create_{ctor.DeclaringType?.FullName.Replace('.', '_')}", typeof(object), new[] { typeof(object[]) }, true); //we create a dynamic method
            var ilgen = dm.GetILGenerator(); //we get the IL Generator from dynamic method

            var parameters = ctor.GetParameters(); //we get constructor parameters
            for (var i = 0; i < parameters.Length; i++)
            {
                ilgen.Emit(OpCodes.Ldarg_0); //first we put a correct parameter onto the stack
                EmitHelper.EmitIntOntoStack(ilgen, i); //next we put a correct index onto the stack again
                ilgen.Emit(OpCodes.Ldelem_Ref); //then we take an index and a parameter from the stack and we put the parameter in an array in a correct index
                var paramType = parameters[i].ParameterType;
                ilgen.Emit(paramType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, paramType); //finally we cast the parameter to the correct type
            }
            ilgen.Emit(OpCodes.Newobj, ctor); //at the end we create a new object that takes an array of parameters as constructor parameters
            ilgen.Emit(OpCodes.Ret); //we return created object

            return (Func<object[], object>)dm.CreateDelegate(typeof(Func<object[], object>));
        }
    }
}