using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.OneBigEmitFunction
{
    [TestClass]
    public class ContainerRegisterTypeInterfaceTests
    {
        [TestMethod]
        public void InterfaceRegisteredAsNotSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClass, SampleClass>();

            var sampleClass1 = c.Resolve2<ISampleClass>();
            var sampleClass2 = c.Resolve2<ISampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void InterfaceRegisteredAsSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();

            var sampleClass1 = c.Resolve2<ISampleClass>();
            var sampleClass2 = c.Resolve2<ISampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void InterfaceReRegistered_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();

            var sampleClass1 = c.Resolve2<ISampleClass>();
            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();
            var sampleClass2 = c.Resolve2<ISampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}