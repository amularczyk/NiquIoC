using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Transient.ReRegister
{
    [TestClass]
    public class ReRegistereClassTests
    {
        [TestMethod]
        public void ClassReRegisteredFromClassToTheSameClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            c.RegisterType<EmptyClass>();
            var emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromInstanceToInstance_Success()
        {
            var c = new Container();
            var instanceOfEmptyClass1 = new EmptyClass();
            c.RegisterInstance(instanceOfEmptyClass1);
            var emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            var instanceOfEmptyClass2 = new EmptyClass();
            c.RegisterInstance(instanceOfEmptyClass2);
            var emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(instanceOfEmptyClass1, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(instanceOfEmptyClass2, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(instanceOfEmptyClass1, instanceOfEmptyClass2);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromObjectFactoryToObjectFactory_Success()
        {
            var c = new Container();
            var instanceOfEmptyClass = new EmptyClass();
            c.RegisterType<EmptyClass>(() => instanceOfEmptyClass);
            var emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            c.RegisterType<EmptyClass>(() => new EmptyClass());
            var emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(instanceOfEmptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void ClassReRegisteredFromInstanceToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            c.RegisterType<EmptyClass>(() => new EmptyClass());
            var emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void ClassReRegisteredFromObjectFactoryToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>(() => new EmptyClass());
            var emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass2, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromClassToObjectFactory_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            c.RegisterType<EmptyClass>(() => new EmptyClass());
            var emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
            Assert.AreNotEqual(emptyClass2, emptyClass3);
            Assert.AreNotEqual(emptyClass2, emptyClass4);
        }

        [TestMethod]
        public void ClassReRegisteredFromClassToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            var emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }
    }
}