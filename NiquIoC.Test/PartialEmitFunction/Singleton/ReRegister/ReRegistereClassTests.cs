using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Singleton.ReRegister
{
    [TestClass]
    public class ReRegistereClassTests
    {
        [TestMethod]
        public void ClassReRegisteredFromClassToTheSameClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve<EmptyClass>();
            var emptyClass2 = c.Resolve<EmptyClass>();

            c.RegisterType<EmptyClass>().AsSingleton();
            var emptyClass3 = c.Resolve<EmptyClass>();
            var emptyClass4 = c.Resolve<EmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromInstanceToInstance_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsSingleton();
            var emptyClass1 = c.Resolve<EmptyClass>();
            var emptyClass2 = c.Resolve<EmptyClass>();

            var emptyClass3 = new EmptyClass();
            c.RegisterInstance(emptyClass3).AsSingleton();
            var emptyClass4 = c.Resolve<EmptyClass>();
            var emptyClass5 = c.Resolve<EmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreEqual(emptyClass4, emptyClass5);
            Assert.AreNotEqual(emptyClass, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromObjectFactoryToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<EmptyClass>(() => emptyClass).AsSingleton();
            var emptyClass1 = c.Resolve<EmptyClass>();
            var emptyClass2 = c.Resolve<EmptyClass>();

            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsSingleton();
            var emptyClass3 = c.Resolve<EmptyClass>();
            var emptyClass4 = c.Resolve<EmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass2, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromInstanceToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsSingleton();
            var emptyClass1 = c.Resolve<EmptyClass>();
            var emptyClass2 = c.Resolve<EmptyClass>();

            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsSingleton();
            var emptyClass3 = c.Resolve<EmptyClass>();
            var emptyClass4 = c.Resolve<EmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void ClassReRegisteredFromObjectFactoryToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsSingleton();
            var emptyClass1 = c.Resolve<EmptyClass>();
            var emptyClass2 = c.Resolve<EmptyClass>();

            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsSingleton();
            var emptyClass3 = c.Resolve<EmptyClass>();
            var emptyClass4 = c.Resolve<EmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass);
        }

        [TestMethod]
        public void ClassReRegisteredFromClassToObjectFactory_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve<EmptyClass>();
            var emptyClass2 = c.Resolve<EmptyClass>();

            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsSingleton();
            var emptyClass3 = c.Resolve<EmptyClass>();
            var emptyClass4 = c.Resolve<EmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromClassToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve<EmptyClass>();
            var emptyClass2 = c.Resolve<EmptyClass>();

            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsSingleton();
            var emptyClass3 = c.Resolve<EmptyClass>();
            var emptyClass4 = c.Resolve<EmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass);
        }
    }
}