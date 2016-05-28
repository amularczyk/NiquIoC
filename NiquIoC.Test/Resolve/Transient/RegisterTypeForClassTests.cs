using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.Transient
{
    [TestClass]
    public class RegisterTypeForClassTests
    {
        [TestMethod]
        public void RegisteredClassWithConstructorWithoutParameters_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();

            var sampleClass = c.Resolve<EmptyClass>();

            Assert.IsNotNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void InternalClassNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClass>();

            var sampleClass = c.Resolve<SampleClass>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisteredClassWithConstructorWithParameter_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();

            var sampleClass = c.Resolve<SampleClass>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException), "Appeared cycle when resolving constructor for object of type NiquIoC.Test.ClassDefinitions.FirstClassWithCycleInConstructor")]
        public void RegisteredClassWithCycleInConstructor_Fail()
        {
            var c = new Container();
            c.RegisterType<SecondClassWithCycleInConstructor>();
            c.RegisterType<FirstClassWithCycleInConstructor>();

            var sampleClass = c.Resolve<FirstClassWithCycleInConstructor>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisteredClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();

            var sampleClass1 = c.Resolve<SampleClass>();
            var sampleClass2 = c.Resolve<SampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}