using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Transient
{
    [TestClass]
    public class RegisterTypeForClassTests
    {
        [TestMethod]
        public void RegisterClassWithConstructorWithoutParameters_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();

            var sampleClass = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void InternalClassNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClass>();

            var sampleClass = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type System.String has not been registered.")]
        public void InternalStringTypeNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithStringType>();

            var sampleClassWithSimpleType = c.Resolve<SampleClassWithStringType>(ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClassWithSimpleType);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type System.Int32 has not been registered.")]
        public void InternalIntTypeNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithIntType>();

            var sampleClassWithSimpleType = c.Resolve<SampleClassWithIntType>(ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClassWithSimpleType);
        }

        [TestMethod]
        public void RegisterClassWithConstructorWithParameter_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();

            var sampleClass = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException),
            "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.FirstClassWithCycleInConstructor")]
        public void RegisterClassWithCycleInConstructor_Fail()
        {
            var c = new Container();
            c.RegisterType<SecondClassWithCycleInConstructor>();
            c.RegisterType<FirstClassWithCycleInConstructor>();

            var sampleClass = c.Resolve<FirstClassWithCycleInConstructor>(ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();

            var sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}