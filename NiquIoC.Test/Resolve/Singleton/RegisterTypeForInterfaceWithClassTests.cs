using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.Singleton
{
    [TestClass]
    public class RegisterTypeForInterfaceWithClassTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void InternalClassNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();

            var sampleClass = c.Resolve<ISampleClass>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisteredInterfaceAsClassWithConstructorWithParameter_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();

            var sampleClass = c.Resolve<ISampleClass>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException), "Appeared cycle when resolving constructor for object of type NiquIoC.Test.ClassDefinitions.FirstClassWithCycleInConstructor")]
        public void RegisteredInterfaceAsClassWithCycleInConstructor_Fail()
        {
            var c = new Container();
            c.RegisterType<FirstClassWithCycleInConstructor>().AsSingleton();
            c.RegisterType<SecondClassWithCycleInConstructor>().AsSingleton();
            c.RegisterType<IClassWithCycleInConstructor, ClassWithCycleInConstructorInRegisteredType>().AsSingleton();

            var sampleClass = c.Resolve<IClassWithCycleInConstructor>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void SameObjects_RegisteredInterfaceWithClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();

            var sampleClass1 = c.Resolve<ISampleClass>();
            var sampleClass2 = c.Resolve<ISampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}