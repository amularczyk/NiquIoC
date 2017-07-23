using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.MixObjectsLifeTime.SingletonAndTransient.FactoryObject
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForClassTests
    {
        [TestMethod]
        public void NestedFactoryObjectRegisteredAsSingletonReturnNewObject_Success()
        {
            var c = new Container();
            c.RegisterType(container => new EmptyClass()).AsSingleton();
            c.RegisterType<SampleClass>();

            var sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectRegisteredAsSingletonReturnTheSameObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType(container => emptyClass).AsSingleton();
            c.RegisterType<SampleClass>();

            var sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectRegisteredAsTransientReturnNewObject_Success()
        {
            var c = new Container();
            c.RegisterType(container => new EmptyClass());
            c.RegisterType<SampleClass>().AsSingleton();

            var sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectRegisteredAsTransientReturnTheSameObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType(container => emptyClass);
            c.RegisterType<SampleClass>().AsSingleton();

            var sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}