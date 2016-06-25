﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction.Singleton
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForClassTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<SampleClass>(() => new SampleClass(emptyClass)).AsSingleton();

            var sampleClass1 = c.Resolve<SampleClass>(Enums.ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(Enums.ResolveKind.FullEmitFunction);

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
            c.RegisterType<SampleClass>(() => sampleClass).AsSingleton();

            var sampleClass1 = c.Resolve<SampleClass>(Enums.ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(Enums.ResolveKind.FullEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();

            var sampleClass1 = c.Resolve<SampleClass>(Enums.ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(Enums.ResolveKind.FullEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<EmptyClass>(() => emptyClass).AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();

            var sampleClass1 = c.Resolve<SampleClass>(Enums.ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<SampleClass>(Enums.ResolveKind.FullEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}