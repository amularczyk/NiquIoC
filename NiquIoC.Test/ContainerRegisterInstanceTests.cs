using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Interfaces;

namespace NiquIoC.Test
{
    [TestClass]
    public class ContainerRegisterInstanceTests
    {
        [TestMethod]
        public void EmptyClass_Success()
        {
            IContainer c = new Container();
            var emptyClass1 = new EmptyClass();
            c.RegisterInstance(emptyClass1);

            var emptyClass2 = c.Resolve<EmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
        }

        [TestMethod]
        public void ClassNeededByOtherClass_Success()
        {
            IContainer c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<ISampleClass, SampleClass>();
            c.RegisterInstance(emptyClass);

            var sampleClass = c.Resolve<ISampleClass>();

            Assert.IsNotNull(sampleClass);
            Assert.AreEqual(emptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void ClassWithConstructorWithSimpleType_Success()
        {
            IContainer c = new Container();
            const string text = "Text";
            c.RegisterInstance(text);
            c.RegisterType<SampleClassWithSimpleType>();

            var sampleClassWithSimpleType = c.Resolve<SampleClassWithSimpleType>();

            Assert.IsNotNull(sampleClassWithSimpleType);
            Assert.IsNotNull(sampleClassWithSimpleType.Text);
            Assert.AreEqual(sampleClassWithSimpleType.Text, text);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException))]
        public void Resolve_MissingRegistrationOfSimpleType_Fail()
        {
            IContainer c = new Container();
            c.RegisterType<SampleClassWithSimpleType>();

            var sampleClassWithSimpleType = c.Resolve<SampleClassWithSimpleType>();

            Assert.IsNull(sampleClassWithSimpleType);
        }
    }
}