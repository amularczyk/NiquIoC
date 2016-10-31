﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction
{
    [TestClass]
    public class RegisterClassInstanceTests
    {
        [TestMethod]
        public void RegisterInstanceOfEmptyClass_Success()
        {
            var c = new Container();
            var emptyClass1 = new EmptyClass();
            c.RegisterInstance(emptyClass1);

            var emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(emptyClass1, emptyClass2);
        }

        [TestMethod]
        public void RegisterInstanceOfClassNeededByOtherClass_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<SampleClass>();
            c.RegisterInstance(emptyClass);

            var sampleClass = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.AreEqual(emptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInstanceOfClassWithConstructorWithStringType_Success()
        {
            var c = new Container();
            var text = "Text";
            c.RegisterInstance(text);
            c.RegisterType<SampleClassWithStringType>();

            var sampleClassWithSimpleType = c.Resolve<SampleClassWithStringType>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClassWithSimpleType);
            Assert.IsNotNull(sampleClassWithSimpleType.Text);
            Assert.AreEqual(sampleClassWithSimpleType.Text, text);
        }

        [TestMethod]
        public void RegisterInstanceOfClassWithConstructorWithIntType_Success()
        {
            var c = new Container();
            var value = 2;
            c.RegisterInstance(value);
            c.RegisterType<SampleClassWithIntType>();

            var sampleClassWithSimpleType = c.Resolve<SampleClassWithIntType>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClassWithSimpleType);
            Assert.IsNotNull(sampleClassWithSimpleType.Value);
            Assert.AreEqual(sampleClassWithSimpleType.Value, value);
        }
    }
}