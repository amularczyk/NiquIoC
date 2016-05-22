using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.ManyEmitFunctions
{
    [TestClass]
    public class ContainerRegisterTypeInterfaceTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.IEmptyClass has not been registered.")]
        public void InterfaceNotRegistered_Fail()
        {
            var c = new Container();

            var sampleClass = c.Resolve<IEmptyClass>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisteredInterfaceAsClassWithConstructorWithoutParameters_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();

            var sampleClass = c.Resolve<IEmptyClass>();

            Assert.IsNotNull(sampleClass);
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
        public void RegisteredInterfaceAsClassWithConstructorWithInterfaceAsParameter_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceAsParameter>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

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
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.IEmptyClass has not been registered.")]
        public void InternalInterfaceNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceAsParameter>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException), "Appeared cycle when resolving constructor for object of type NiquIoC.Test.ClassDefinitions.FirstClassWithCycleInConstructorInRegisteredType")]
        public void RegisteredInterfaceAsClassWithCycleInConstructor_Fail()
        {
            var c = new Container();
            c.RegisterType<ISecondClassWithCycleInConstructor, SecondClassWithCycleInConstructorInRegisteredType>();
            c.RegisterType<IFirstClassWithCycleInConstructor, FirstClassWithCycleInConstructorInRegisteredType>();

            var sampleClass = c.Resolve<IFirstClassWithCycleInConstructor>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisteredInterfaceAsTransient_Success()
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

        [TestMethod]
        public void RegisteredInterfaceAsSingleton_Success()
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