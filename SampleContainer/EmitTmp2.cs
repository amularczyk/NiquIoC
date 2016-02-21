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
            DynamicMethod create = new DynamicMethod("Create", typeof(Bar2), Type.EmptyTypes);
            ILGenerator ilgen = create.GetILGenerator();

            Type type = typeof(T);

            var ctor = type.GetConstructors().First();
            var parameters = ctor.GetParameters();

            foreach (var paramInfo in parameters)
            {
                Type paramType = paramInfo.ParameterType;
                var paramCtor = paramType.GetConstructors().First();
                ilgen.Emit(OpCodes.Newobj, paramCtor);
                ilgen.Emit(OpCodes.Castclass, paramType); //Cast to Type t
            }

            ilgen.Emit(OpCodes.Newobj, ctor);
            ilgen.Emit(OpCodes.Ret);

            return (T)create.Invoke(null, null);
        }
    }
}