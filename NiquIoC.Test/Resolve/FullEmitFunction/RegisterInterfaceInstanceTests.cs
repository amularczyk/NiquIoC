using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction
{
    [TestClass]
    public class RegisterInterfaceInstanceTests
    {
        [TestMethod]
        public void RegisterInstanceOfInterfaceOfEmptyClass_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass1 = new EmptyClass();
            c.RegisterInstance(emptyClass1);

            var emptyClass2 = c.Resolve<IEmptyClass>(Enums.ResolveKind.FullEmitFunction);

            Assert.AreEqual(emptyClass1, emptyClass2);
        }

        [TestMethod]
        public void RegisterInstanceOfClassNeededByInterface_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<ISampleClass, SampleClass>();
            c.RegisterInstance(emptyClass);

            var sampleClass = c.Resolve<ISampleClass>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.AreEqual(emptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInstanceOfInterfaceNeededByInterface_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c.RegisterInstance(emptyClass);

            var sampleClass = c.Resolve<ISampleClassWithInterfaceAsParameter>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.AreEqual(emptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInstanceOfInterfaceWithConstructorWithStringType_Success()
        {
            var c = new Container();
            var text = "Text";
            c.RegisterInstance(text);
            c.RegisterType<ISampleClassWithStringType, SampleClassWithStringType>();

            var sampleClassWithSimpleType = c.Resolve<ISampleClassWithStringType>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClassWithSimpleType);
            Assert.IsNotNull(sampleClassWithSimpleType.Text);
            Assert.AreEqual(sampleClassWithSimpleType.Text, text);
        }

        [TestMethod]
        public void RegisterInstanceOfInterfaceWithConstructorWithIntType_Success()
        {
            var c = new Container();
            var value = 2;
            c.RegisterInstance(value);
            c.RegisterType<ISampleClassWithIntType, SampleClassWithIntType>();

            var sampleClassWithSimpleType = c.Resolve<ISampleClassWithIntType>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClassWithSimpleType);
            Assert.IsNotNull(sampleClassWithSimpleType.Value);
            Assert.AreEqual(sampleClassWithSimpleType.Value, value);
        }
    }
}