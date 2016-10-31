using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Singleton.ReRegister
{
    [TestClass]
    public class ReRegistereInterfaceTests
    {
        [TestMethod]
        public void InterfaceReRegisteredFromInstanceToInstance_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsSingleton();
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            IEmptyClass emptyClass3 = new EmptyClass();
            c.RegisterInstance(emptyClass3).AsSingleton();
            var emptyClass4 = c.Resolve<IEmptyClass>();
            var emptyClass5 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreEqual(emptyClass4, emptyClass5);
            Assert.AreNotEqual(emptyClass, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromObjectFactoryToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<IEmptyClass>(() => emptyClass).AsSingleton();
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsSingleton();
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromInstanceToObjectFactory_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsSingleton();
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsSingleton();
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromObjectFactoryToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsSingleton();
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsSingleton();
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromClassToObjectFactory_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsSingleton();
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromClassToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve<IEmptyClass>();
            var emptyClass2 = c.Resolve<IEmptyClass>();

            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsSingleton();
            var emptyClass3 = c.Resolve<IEmptyClass>();
            var emptyClass4 = c.Resolve<IEmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }
        
        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheSameClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();

            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();
            var sampleClass1 = c.Resolve<ISampleClass>();

            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();
            var sampleClass2 = c.Resolve<ISampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheOther_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();

            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();
            var sampleClass1 = c.Resolve<ISampleClass>();
            var sampleClass2 = c.Resolve<ISampleClass>();

            c.RegisterType<ISampleClass, SampleClassOther>().AsSingleton();
            var sampleClass3 = c.Resolve<ISampleClass>();
            var sampleClass4 = c.Resolve<ISampleClass>();

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.GetType(), sampleClass2.GetType());
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass3, sampleClass4);
            Assert.AreEqual(sampleClass3.GetType(), sampleClass4.GetType());
            Assert.AreEqual(sampleClass3.EmptyClass, sampleClass4.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass3);
            Assert.AreNotEqual(sampleClass1.GetType(), sampleClass3.GetType());
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass3.EmptyClass);
        }
    }
}