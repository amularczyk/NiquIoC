using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace SampleContainer
{
    public class EmitTmp
    {
        public string Foo()
        {
            const string name = "Foo";
            AssemblyName fooAssemblyName = new AssemblyName
            {
                Version = new Version(1, 0, 0, 0),
                Name = name
            };
            AppDomain appDomain = Thread.GetDomain();
            AssemblyBuilder fooAssemblyBuilder = appDomain.DefineDynamicAssembly(fooAssemblyName, AssemblyBuilderAccess.Run);

            ModuleBuilder bookModuleBuilder = fooAssemblyBuilder.DefineDynamicModule(name);
            TypeBuilder fooTypeBuilder = bookModuleBuilder.DefineType(name + "." + name, TypeAttributes.Class);

            MethodBuilder create = fooTypeBuilder.DefineMethod("Create", MethodAttributes.Public, CallingConventions.Standard, typeof (string), new Type[0]);

            ILGenerator ilgen = create.GetILGenerator();
            ilgen.DeclareLocal(typeof (string));
            ilgen.Emit(OpCodes.Ldstr, "Works?");
            ilgen.Emit(OpCodes.Ret);

            var t = fooTypeBuilder.CreateType();
            object o1 = Activator.CreateInstance(t);
            MethodInfo mi = t.GetMethod("Create");

            return (string)mi.Invoke(o1, null);
        }

        public Bar FooT()
        {
            const string name = "Foo";
            AssemblyName fooAssemblyName = new AssemblyName
            {
                Version = new Version(1, 0, 0, 0),
                Name = name
            };
            AppDomain appDomain = Thread.GetDomain();
            AssemblyBuilder fooAssemblyBuilder = appDomain.DefineDynamicAssembly(fooAssemblyName, AssemblyBuilderAccess.Run);

            ModuleBuilder bookModuleBuilder = fooAssemblyBuilder.DefineDynamicModule(name);
            TypeBuilder fooTypeBuilder = bookModuleBuilder.DefineType(name + "." + name, TypeAttributes.Class);

            MethodBuilder create = fooTypeBuilder.DefineMethod("Create", MethodAttributes.Public, CallingConventions.Standard, typeof(Bar), new Type[0]);

            ILGenerator ilgen = create.GetILGenerator();
            var b = new Bar();
            var t = b.GetType();
            var i = t.GetConstructor(Type.EmptyTypes);
            ilgen.Emit(OpCodes.Newobj, i);
            ilgen.Emit(OpCodes.Stloc_0);
            ilgen.Emit(OpCodes.Ldloc_0);
            ilgen.Emit(OpCodes.Ret);

            var type = fooTypeBuilder.CreateType();
            object o1 = Activator.CreateInstance(t);
            MethodInfo mi = type.GetMethod("Create");

            return (Bar)mi.Invoke(o1, null);
        }

        public Bar Foo2()
        {
            var b = new Bar();
            var t = b.GetType();
            var i = t.GetConstructor(Type.EmptyTypes);

            DynamicMethod create = new DynamicMethod("Create", typeof(Bar), Type.EmptyTypes);

            ILGenerator ilgen = create.GetILGenerator();
            ilgen.Emit(OpCodes.Newobj, i);
            ilgen.Emit(OpCodes.Stloc_0);
            ilgen.Emit(OpCodes.Ldloc_0);
            ilgen.Emit(OpCodes.Ret);

            return (Bar)create.Invoke(null, null);
        }

        public Bar2 Foo3()
        {
            var b = new Bar();
            var t = b.GetType();
            var i = t.GetConstructor(Type.EmptyTypes);
            var b2 = new Bar2(b);
            var t2 = b2.GetType();
            var i2 = t2.GetConstructor(new Type[] { typeof(Bar) });

            DynamicMethod create = new DynamicMethod("Create", typeof(Bar2), Type.EmptyTypes);

            ILGenerator ilgen = create.GetILGenerator();
            ilgen.Emit(OpCodes.Newobj, i);
            ilgen.Emit(OpCodes.Stloc_0);
            ilgen.Emit(OpCodes.Ldloc_0);
            ilgen.Emit(OpCodes.Ldc_I4, 0);
            ilgen.Emit(OpCodes.Ldelem_Ref);
            ilgen.Emit(OpCodes.Castclass, typeof(Bar)); //Cast to Type t
            ilgen.Emit(OpCodes.Newobj, i2);
            ilgen.Emit(OpCodes.Ret);

            return (Bar2)create.Invoke(null, null);
        }

        public Bar3 Foo4()
        {
            var b = new Bar();
            var t = b.GetType();
            var i = t.GetConstructor(Type.EmptyTypes);
            var b2 = new Bar2(b);
            var t2 = b2.GetType();
            var i2 = t2.GetConstructor(new Type[] { typeof(Bar) });
            var b3 = new Bar3(b, b2);
            var t3 = b3.GetType();
            var i3 = t3.GetConstructor(new Type[] { typeof(Bar), typeof(Bar2) });

            DynamicMethod create = new DynamicMethod("Create", typeof(Bar3), Type.EmptyTypes);

            ILGenerator ilgen = create.GetILGenerator();
            ilgen.Emit(OpCodes.Newobj, i);
            ilgen.Emit(OpCodes.Castclass, typeof(Bar)); //Cast to Type t
            //ilgen.Emit(OpCodes.Stloc_0);
            //ilgen.Emit(OpCodes.Ldloc_0);
            ilgen.Emit(OpCodes.Newobj, i2);
            ilgen.Emit(OpCodes.Castclass, typeof(Bar2)); //Cast to Type t
            //ilgen.Emit(OpCodes.Stloc_1);
            //ilgen.Emit(OpCodes.Ldloc_1);
            ilgen.Emit(OpCodes.Newobj, i3);
            ilgen.Emit(OpCodes.Ret);

            return (Bar3)create.Invoke(null, null);
        }

        public Bar5 Foo5()
        {
            var b = new Bar();
            var t = b.GetType();
            var i = t.GetConstructor(Type.EmptyTypes);
            var b4 = new Bar4();
            var t4 = b4.GetType();
            var i4 = t4.GetConstructor(Type.EmptyTypes);
            var b5 = new Bar5(b, b4);
            var t5 = b5.GetType();
            var i5 = t5.GetConstructor(new Type[] { typeof(Bar), typeof(Bar4)});

            DynamicMethod create = new DynamicMethod("Create", typeof(Bar5), Type.EmptyTypes);

            ILGenerator ilgen = create.GetILGenerator();
            ilgen.Emit(OpCodes.Newobj, i);
            ilgen.Emit(OpCodes.Castclass, typeof(Bar)); //Cast to Type t
            ilgen.Emit(OpCodes.Newobj, i4);
            ilgen.Emit(OpCodes.Castclass, typeof(Bar4)); //Cast to Type t
            ilgen.Emit(OpCodes.Newobj, i5);
            ilgen.Emit(OpCodes.Ret);

            return (Bar5)create.Invoke(null, null);
        }

        public Bar5 Foo6()
        {
            var b = new Bar();
            var t = b.GetType();
            var i = t.GetConstructor(Type.EmptyTypes);
            var b4 = new Bar4();
            var t4 = b4.GetType();
            var i4 = t4.GetConstructor(Type.EmptyTypes);
            var b5 = new Bar5(b, b4);
            var t5 = b5.GetType();
            var i5 = t5.GetConstructor(new Type[] { typeof(Bar), typeof(Bar4) });

            DynamicMethod create = new DynamicMethod("Create", typeof(Bar5), Type.EmptyTypes, true);

            ILGenerator ilgen = create.GetILGenerator();

            ilgen.DeclareLocal(typeof(int));
            ilgen.DeclareLocal(typeof(object));

            ilgen.Emit(OpCodes.Ldc_I4_0); // [0]
            ilgen.Emit(OpCodes.Stloc_0); //[nothing]

            ilgen.Emit(OpCodes.Ldc_I4_0);
            ilgen.Emit(OpCodes.Stloc_0); // [args][index]
            ilgen.Emit(OpCodes.Newobj, i);
            ilgen.Emit(OpCodes.Ldc_I4_0);
            ilgen.Emit(OpCodes.Ldelem_Ref); // [item-in-args-at-index]
            ilgen.Emit(OpCodes.Castclass, typeof(Bar)); //Cast to Type t


            ilgen.Emit(OpCodes.Ldc_I4_1);
            ilgen.Emit(OpCodes.Stloc_0); // [args][index]
            ilgen.Emit(OpCodes.Newobj, i4);
            ilgen.Emit(OpCodes.Ldc_I4_1);
            ilgen.Emit(OpCodes.Ldelem_Ref); // [item-in-args-at-index]
            ilgen.Emit(OpCodes.Castclass, typeof(Bar4)); //Cast to Type t

            ilgen.Emit(OpCodes.Newobj, i5);
            ilgen.Emit(OpCodes.Stloc_1); // nothing
            ilgen.Emit(OpCodes.Ldloc_1); //[new-object]
            ilgen.Emit(OpCodes.Ret);

            return (Bar5)create.Invoke(null, null);
        }

        public Bar5 Foo7()
        {
            var i5 = typeof(Bar5).GetConstructors()[0];
            
            DynamicMethod create = new DynamicMethod("Create", typeof(Bar5), new[] { typeof(object[]) }, true);

            ILGenerator ilgen = create.GetILGenerator();

            ilgen.DeclareLocal(typeof(int));
            ilgen.DeclareLocal(typeof(object));

            ilgen.Emit(OpCodes.Ldc_I4_0); // [0]
            ilgen.Emit(OpCodes.Stloc_0); //[nothing]

            ilgen.Emit(OpCodes.Ldc_I4_0);
            ilgen.Emit(OpCodes.Stloc_0); // [args][index]
            ilgen.Emit(OpCodes.Ldarg_0); //[args]
            ilgen.Emit(OpCodes.Ldc_I4_0);
            ilgen.Emit(OpCodes.Ldelem_Ref); // [item-in-args-at-index]
            //ilgen.Emit(OpCodes.Castclass, typeof(Bar)); //Cast to Type t
            ilgen.Emit(OpCodes.Unbox_Any, typeof(Bar)); // same as a cast if ref-type


            ilgen.Emit(OpCodes.Ldc_I4_1);
            ilgen.Emit(OpCodes.Stloc_0); // [args][index]
            ilgen.Emit(OpCodes.Ldarg_0); //[args]
            ilgen.Emit(OpCodes.Ldc_I4_1);
            ilgen.Emit(OpCodes.Ldelem_Ref); // [item-in-args-at-index]
            //ilgen.Emit(OpCodes.Castclass, typeof(Bar4)); //Cast to Type t
            ilgen.Emit(OpCodes.Unbox_Any, typeof(Bar4)); // same as a cast if ref-type

            ilgen.Emit(OpCodes.Newobj, i5);
            ilgen.Emit(OpCodes.Stloc_1); // nothing
            ilgen.Emit(OpCodes.Ldloc_1); //[new-object]
            ilgen.Emit(OpCodes.Ret);


            Func<object[], object> factoryMethod = (Func<object[], object>)create.CreateDelegate(typeof(Func<object[], object>));

            return (Bar5)factoryMethod(new object[] { new Bar(), new Bar4() });
        }
    }

    public class Bar
    {
        public Bar()
        {

        }
    }

    public class Bar2
    {
        public Bar Bar;
        public Bar2(Bar bar)
        {
            Bar = bar;
        }
    }

    public class Bar3
    {
        public Bar Bar;
        public Bar2 Bar2;
        public Bar3(Bar bar2, Bar2 bar)
        {
            Bar = bar2;
            Bar2 = bar;
        }
    }

    public class Bar4
    {
        public Bar4()
        {

        }
    }

    public class Bar5
    {
        public Bar Bar;
        public Bar4 Bar4;
        public Bar5(Bar bar, Bar4 bar4)
        {
            Bar = bar;
            Bar4 = bar4;
        }
    }
}