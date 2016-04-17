using System;
using System.Reflection.Emit;

namespace NiquIoC.Helpers
{
    public static class EmitTmp
    {
        public static A FooA()
        {
            var ctor = typeof(A).GetConstructors()[0];

            var dm = new DynamicMethod($"Create", typeof(A), Type.EmptyTypes, true);
            ILGenerator ilgen = dm.GetILGenerator();

            var obj_a = ilgen.DeclareLocal(typeof(A));

            ilgen.Emit(OpCodes.Nop);
            ilgen.Emit(OpCodes.Newobj, ctor);
            ilgen.Emit(OpCodes.Stloc, obj_a);
            ilgen.Emit(OpCodes.Ldloc, obj_a);
            ilgen.Emit(OpCodes.Ret);

            return (A)dm.Invoke(null, null);
        }

        public static B FooB()
        {
            var ctor = typeof(B).GetConstructors()[0];

            var dm = new DynamicMethod($"Create", typeof(B), Type.EmptyTypes, true);
            ILGenerator ilgen = dm.GetILGenerator();

            var obj_a = ilgen.DeclareLocal(typeof(A));
            var obj_b = ilgen.DeclareLocal(typeof(B));

            var ctor_a = typeof(A).GetConstructors()[0];

            ilgen.Emit(OpCodes.Nop);
            ilgen.Emit(OpCodes.Newobj, ctor_a);
            ilgen.Emit(OpCodes.Stloc, obj_a);
            ilgen.Emit(OpCodes.Ldloc, obj_a);
            ilgen.Emit(OpCodes.Newobj, ctor);
            ilgen.Emit(OpCodes.Stloc, obj_b);
            ilgen.Emit(OpCodes.Ldloc, obj_b);
            ilgen.Emit(OpCodes.Ret);

            return (B)dm.Invoke(null, null);
        }

        public static C FooC()
        {
            var ctor = typeof(C).GetConstructors()[0];

            var dm = new DynamicMethod($"Create", typeof(C), Type.EmptyTypes, true);
            ILGenerator ilgen = dm.GetILGenerator();

            var obj_a1 = ilgen.DeclareLocal(typeof(A));
            var obj_b = ilgen.DeclareLocal(typeof(B));
            var obj_a2 = ilgen.DeclareLocal(typeof(A));
            var obj_c = ilgen.DeclareLocal(typeof(C));

            var ctor_a = typeof(A).GetConstructors()[0];
            var ctor_b = typeof(B).GetConstructors()[0];

            ilgen.Emit(OpCodes.Nop);
            ilgen.Emit(OpCodes.Newobj, ctor_a);
            ilgen.Emit(OpCodes.Stloc, obj_a1);
            ilgen.Emit(OpCodes.Ldloc, obj_a1);
            ilgen.Emit(OpCodes.Newobj, ctor_b);
            ilgen.Emit(OpCodes.Stloc, obj_b);
            ilgen.Emit(OpCodes.Newobj, ctor_a);
            ilgen.Emit(OpCodes.Stloc, obj_a2);
            ilgen.Emit(OpCodes.Ldloc, obj_b);
            ilgen.Emit(OpCodes.Ldloc, obj_a2);
            ilgen.Emit(OpCodes.Newobj, ctor);
            ilgen.Emit(OpCodes.Stloc, obj_c);
            ilgen.Emit(OpCodes.Ldloc, obj_c);
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
        public C(A a, B b)
        {
            A = a;
            B = b;
        }
    }
}