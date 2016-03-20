using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Interfaces;

namespace NiquIoC.Test
{
    [TestClass]
    public class ContainerBasicTests
    {
        [TestMethod]
        [ExpectedException(typeof (TypeNotRegisteredException))]
        public void ClassNotRegistered_Fail()
        {
            IContainer c = new Container();

            var sampleClass = c.Resolve<EmptyClass>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void ClassWithConstructorWithoutParametersRegistered_Success()
        {
            IContainer c = new Container();
            c.RegisterType<EmptyClass>();

            var sampleClass = c.Resolve<EmptyClass>();

            Assert.IsNotNull(sampleClass);
        }
        

        [TestMethod]
        public void ClassWithConstructorWithParameter_Success()
        {
            IContainer c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();

            var sampleClass = c.Resolve<SampleClass>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof (TypeNotRegisteredException))]
        public void MissingRegistration_Fail()
        {
            IContainer c = new Container();
            c.RegisterType<SampleClass>();

            var sampleClass = c.Resolve<SampleClass>();

            Assert.IsNull(sampleClass);
        }
        
        [TestMethod]
        [ExpectedException(typeof (CycleForTypeException))]
        public void ClassWithCycleInConstructor_Fail()
        {
            IContainer c = new Container();
            c.RegisterType<SecondClassWithCycleInConstructor>();
            c.RegisterType<FirstClassWithCycleInConstructor>();

            var sampleClass = c.Resolve<FirstClassWithCycleInConstructor>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void ClassRegisteredAsNotSingleton_Success()
        {
            IContainer c = new Container();
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

        [TestMethod]
        public void ClassRegisteredAsSingleton_Success()
        {
            IContainer c = new Container();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<EmptyClass>().AsSingleton();

            var sampleClass1 = c.Resolve<SampleClass>();
            var sampleClass2 = c.Resolve<SampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void ClassReRegistered_Success()
        {
            IContainer c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();

            var sampleClass1 = c.Resolve<SampleClass>();
            c.RegisterType<SampleClass>().AsSingleton();
            var sampleClass2 = c.Resolve<SampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}