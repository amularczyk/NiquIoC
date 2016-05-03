using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace NiquIoC.Helpers
{
    public static class EmitTmp
    {
        public static Func<object> CreateFullObjectFunction(ConstructorInfo ctor, Dictionary<Type, ConstructorInfo> ctorDictionary)
        {
            var dm = new DynamicMethod($"Create_{ctor.DeclaringType?.FullName.Replace('.', '_')}", typeof(object), Type.EmptyTypes, true);
            ILGenerator ilgen = dm.GetILGenerator();

            ParameterInfo[] parameters = ctor.GetParameters();
            for (var i = 0; i < parameters.Length; i++)
            {
                var ctorParam = ctorDictionary[parameters[i].ParameterType];
                CreateFullObjectFunctionPrivate(ctorParam, ctorDictionary, ilgen);
            }
            ilgen.Emit(OpCodes.Newobj, ctor);
            ilgen.Emit(OpCodes.Ret);

            return (Func<object>)dm.CreateDelegate(typeof(Func<object>));
        }

        private static void CreateFullObjectFunctionPrivate(ConstructorInfo ctor, Dictionary<Type, ConstructorInfo> ctorDictionary, ILGenerator ilgen)
        {
            ParameterInfo[] parameters = ctor.GetParameters();
            for (var i = 0; i < parameters.Length; i++)
            {
                var ctorParam = ctorDictionary[parameters[i].ParameterType];
                CreateFullObjectFunctionPrivate(ctorParam, ctorDictionary, ilgen);
            }
            ilgen.Emit(OpCodes.Newobj, ctor);
        }

        public static A FooA()
        {
            var ctor = typeof(A).GetConstructors()[0];

            var dm = new DynamicMethod($"Create", typeof(A), Type.EmptyTypes, true);
            ILGenerator ilgen = dm.GetILGenerator();

            ilgen.Emit(OpCodes.Nop);
            ilgen.Emit(OpCodes.Newobj, ctor);
            ilgen.Emit(OpCodes.Ret);

            return (A)dm.Invoke(null, null);
        }

        public static B FooB()
        {
            var ctor = typeof(B).GetConstructors()[0];

            var dm = new DynamicMethod($"Create", typeof(B), Type.EmptyTypes, true);
            ILGenerator ilgen = dm.GetILGenerator();

            var ctor_a = typeof(A).GetConstructors()[0];

            ilgen.Emit(OpCodes.Nop);
            ilgen.Emit(OpCodes.Newobj, ctor_a);
            ilgen.Emit(OpCodes.Newobj, ctor);
            ilgen.Emit(OpCodes.Ret);

            return (B)dm.Invoke(null, null);
        }

        public static C FooC()
        {
            var ctor = typeof(C).GetConstructors()[0];

            var dm = new DynamicMethod($"Create", typeof(C), Type.EmptyTypes, true);
            ILGenerator ilgen = dm.GetILGenerator();

            var ctor_a = typeof(A).GetConstructors()[0];
            var ctor_b = typeof(B).GetConstructors()[0];

            ilgen.Emit(OpCodes.Nop);
            ilgen.Emit(OpCodes.Newobj, ctor_a);
            ilgen.Emit(OpCodes.Newobj, ctor_b);
            ilgen.Emit(OpCodes.Newobj, ctor_a);
            ilgen.Emit(OpCodes.Newobj, ctor);
            ilgen.Emit(OpCodes.Ret);

            return (C)dm.Invoke(null, null);
        }
    }

    public class A
    {
        public A()
        {
        }
    }

    public class B
    {
        public A A;

        public B(A a)
        {
            A = a;
        }
    }
    public class C
    {
        public A A;
        public B B;
        public C(B b, A a)
        {
            A = a;
            B = b;
        }
    }
}