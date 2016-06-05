using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.Singleton
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForClassWithInterfaceTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<SampleClassWithInterfaceAsParameter>(() => new SampleClassWithInterfaceAsParameter(emptyClass)).AsSingleton();

            var sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>();
            var sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>();

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void FactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            var sampleClass = new SampleClassWithInterfaceAsParameter(emptyClass);
            c.RegisterType<SampleClassWithInterfaceAsParameter>(() => sampleClass).AsSingleton();

            var sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>();
            var sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>();

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsSingleton();
            c.RegisterType<SampleClassWithInterfaceAsParameter>().AsSingleton();

            var sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>();
            var sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>();

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<IEmptyClass>(() => emptyClass).AsSingleton();
            c.RegisterType<SampleClassWithInterfaceAsParameter>().AsSingleton();

            var sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>();
            var sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>();

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}