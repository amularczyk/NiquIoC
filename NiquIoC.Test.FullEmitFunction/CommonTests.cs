using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction
{
    [TestClass]
    public class CommonTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void ClassNotRegistered_Fail()
        {
            var c = new Container();

            var sampleClass = c.Resolve<EmptyClass>(ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.ClassDefinitions.IEmptyClass has not been registered.")]
        public void InterfaceNotRegistered_Fail()
        {
            var c = new Container();

            var sampleClass = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongInterfaceRegistrationException),
            "For interface type NiquIoC.Test.ClassDefinitions.IEmptyClass you must specify a class which implements it.")]
        public void MissingClassThatImplementsInterfaceInRegister_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>();
        }

        [TestMethod]
        public void Resolve_Without_Parameter_When_Container_With_ResolveKind_Success()
        {
            var c = new Container(ResolveKind.FullEmitFunction);
            c.RegisterType<EmptyClass>();

            var emptyClass = c.Resolve<EmptyClass>();

            Assert.IsNotNull(emptyClass);
        }

        [TestMethod]
        public void Resolve_With_Type_As_Parameter_And_Register_With_Type_As_Parameter_Success()
        {
            var c = new Container(ResolveKind.FullEmitFunction);
            c.RegisterType(typeof(EmptyClass));

            var emptyClass = c.Resolve(typeof(EmptyClass));

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is EmptyClass);
        }

        [TestMethod]
        public void Resolve_With_Type_And_ResolveKind_As_Parameter_And_Register_With_Type_As_Parameter_Success()
        {
            var c = new Container();
            c.RegisterType(typeof(EmptyClass));

            var emptyClass = c.Resolve(typeof(EmptyClass), ResolveKind.FullEmitFunction);

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is EmptyClass);
        }

        [TestMethod]
        public void Resolve_With_Type_As_Parameter_And_Register_With_TypeFrom_And_TypeTo_As_Parameter_Success()
        {
            var c = new Container(ResolveKind.FullEmitFunction);
            c.RegisterType(typeof(IEmptyClass), typeof(EmptyClass));

            var emptyClass = c.Resolve(typeof(IEmptyClass));

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is IEmptyClass);
        }

        [TestMethod]
        public void
            Resolve_With_Type_And_ResolveKind_As_Parameter_And_Register_With_TypeFrom_And_TypeTo_As_Parameter_Success()
        {
            var c = new Container(ResolveKind.FullEmitFunction);
            c.RegisterType(typeof(IEmptyClass), typeof(EmptyClass));

            var emptyClass = c.Resolve(typeof(IEmptyClass), ResolveKind.FullEmitFunction);

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is IEmptyClass);
        }

        [TestMethod]
        public void Resolve_With_Type_As_Parameter_And_Register_Object_Factory_With_Type_As_Parameter_Success()
        {
            var c = new Container(ResolveKind.FullEmitFunction);
            c.RegisterType(typeof(EmptyClass), container => new EmptyClass());

            var emptyClass = c.Resolve(typeof(EmptyClass));

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is EmptyClass);
        }

        [TestMethod]
        public void
            Resolve_With_Type_And_ResolveKind_As_Parameter_And_Register_Object_Factory_With_Type_As_Parameter_Success()
        {
            var c = new Container();
            c.RegisterType(typeof(EmptyClass), container => new EmptyClass());

            var emptyClass = c.Resolve(typeof(EmptyClass), ResolveKind.FullEmitFunction);

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is EmptyClass);
        }

        [TestMethod]
        public void
            Resolve_With_Type_As_Parameter_And_Register_Object_Factory_With_Type_As_Parameter_Using_Container_Success()
        {
            var c = new Container(ResolveKind.FullEmitFunction);
            c.RegisterType<EmptyClass>();
            c.RegisterType(typeof(SampleClass), container => new SampleClass(container.Resolve<EmptyClass>()));

            var sampleClass = c.Resolve(typeof(SampleClass));

            Assert.IsNotNull(sampleClass);
            Assert.IsTrue(sampleClass is SampleClass);
            Assert.IsNotNull((sampleClass as SampleClass).EmptyClass);
        }

        [TestMethod]
        public void
            Resolve_With_Type_And_ResolveKind_As_Parameter_And_Register_Object_Factory_With_Type_As_Parameter_Using_Container_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType(typeof(SampleClass),
                container => new SampleClass(container.Resolve<EmptyClass>(ResolveKind.FullEmitFunction)));

            var sampleClass = c.Resolve(typeof(SampleClass), ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsTrue(sampleClass is SampleClass);
            Assert.IsNotNull((sampleClass as SampleClass).EmptyClass);
        }
    }
}