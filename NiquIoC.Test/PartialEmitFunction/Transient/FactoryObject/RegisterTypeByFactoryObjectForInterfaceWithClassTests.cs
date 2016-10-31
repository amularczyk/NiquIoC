﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Transient.FactoryObject
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForInterfaceWithClassTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<ISampleClass>(() => new SampleClass(emptyClass));

            var sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void FactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            ISampleClass sampleClass = new SampleClass(emptyClass);
            c.RegisterType<ISampleClass>(() => sampleClass);

            var sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>(() => new EmptyClass());
            c.RegisterType<ISampleClass, SampleClass>();

            var sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<EmptyClass>(() => emptyClass);
            c.RegisterType<ISampleClass, SampleClass>();

            var sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}