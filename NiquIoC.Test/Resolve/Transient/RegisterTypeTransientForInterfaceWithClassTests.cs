using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.Transient
{
    [TestClass]
    public class RegisterTypeTransientForInterfaceWithClassTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void InternalClassNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<ISampleClass, SampleClass>();

            var sampleClass = c.Resolve<ISampleClass>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisteredInterfaceAsClassWithConstructorWithParameter_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClass, SampleClass>();

            var sampleClass = c.Resolve<ISampleClass>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException), "Appeared cycle when resolving constructor for object of type NiquIoC.Test.ClassDefinitions.FirstClassWithCycleInConstructor")]
        public void RegisteredInterfaceAsClassWithCycleInConstructor_Fail()
        {
            var c = new Container();
            c.RegisterType<FirstClassWithCycleInConstructor>();
            c.RegisterType<SecondClassWithCycleInConstructor>();
            c.RegisterType<IClassWithCycleInConstructor, ClassWithCycleInConstructorInRegisteredType>();

            var sampleClass = c.Resolve<IClassWithCycleInConstructor>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisteredInterfaceWithClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClass, SampleClass>();

            var sampleClass1 = c.Resolve<ISampleClass>();
            var sampleClass2 = c.Resolve<ISampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}