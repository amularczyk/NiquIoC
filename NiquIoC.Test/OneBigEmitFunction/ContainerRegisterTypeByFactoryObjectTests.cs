﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.OneBigEmitFunction
{
    [TestClass]
    public class ContainerRegisterTypeByFactoryObjectTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<ISampleClass>(() => new SampleClass(emptyClass));

            var sampleClass1 = c.Resolve2<ISampleClass>();
            var sampleClass2 = c.Resolve2<ISampleClass>();

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void FactoryObjectReturnNewObjectRegisteredAsSingleton_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<ISampleClass>(() => new SampleClass(emptyClass)).AsSingleton();

            var sampleClass1 = c.Resolve2<ISampleClass>();
            var sampleClass2 = c.Resolve2<ISampleClass>();

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void FactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            var sampleClass = new SampleClass(emptyClass);
            c.RegisterType<ISampleClass>(() => sampleClass);

            var sampleClass1 = c.Resolve2<ISampleClass>();
            var sampleClass2 = c.Resolve2<ISampleClass>();

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }
    }
}