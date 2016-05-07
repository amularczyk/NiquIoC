using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.OneBigEmitFunction
{
    [TestClass]
    public class ContainerRegisterInstanceTests
    {
        [TestMethod]
        public void EmptyClass_Success()
        {
            var c = new Container();
            var emptyClass1 = new EmptyClass();
            c.RegisterInstance(emptyClass1);

            var emptyClass2 = c.Resolve2<EmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
        }

        [TestMethod]
        public void ClassNeededByOtherClass_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            c.RegisterType<ISampleClass, SampleClass>();

            var sampleClass = c.Resolve2<ISampleClass>();

            Assert.IsNotNull(sampleClass);
            Assert.AreEqual(emptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void ClassWithConstructorWithSimpleType_Success()
        {
            var c = new Container();
            const string text = "Text";
            c.RegisterInstance(text);
            c.RegisterType<SampleClassWithSimpleType>();

            var sampleClassWithSimpleType = c.Resolve2<SampleClassWithSimpleType>();

            Assert.IsNotNull(sampleClassWithSimpleType);
            Assert.IsNotNull(sampleClassWithSimpleType.Text);
            Assert.AreEqual(sampleClassWithSimpleType.Text, text);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException))]
        public void Resolve_MissingRegistrationOfSimpleType_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithSimpleType>();

            var sampleClassWithSimpleType = c.Resolve2<SampleClassWithSimpleType>();

            Assert.IsNull(sampleClassWithSimpleType);
        }
    }
}