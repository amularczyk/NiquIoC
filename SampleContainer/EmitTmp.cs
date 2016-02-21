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
        
        public Bar Foo2()
        {
            var b = new Bar();
            var t = b.GetType();
            var i = t.GetConstructor(Type.EmptyTypes);

            DynamicMethod create = new DynamicMethod("Create", typeof(Bar), Type.EmptyTypes);

            ILGenerator ilgen = create.GetILGenerator();
            ilgen.Emit(OpCodes.Newobj, i);
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
            ilgen.Emit(OpCodes.Castclass, typeof(Bar)); //Cast to Type t
            ilgen.Emit(OpCodes.Newobj, i2);
            ilgen.Emit(OpCodes.Ret);

            return (Bar2)create.Invoke(null, null);
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
}