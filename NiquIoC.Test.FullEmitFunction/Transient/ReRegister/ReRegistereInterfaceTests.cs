﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.Transient.ReRegister
{
    [TestClass]
    public class ReRegistereInterfaceTests
    {
        [TestMethod]
        public void InterfaceReRegisteredFromInstanceToInstance_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            IEmptyClass emptyClass3 = new EmptyClass();
            c.RegisterInstance(emptyClass3);
            var emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass5 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreEqual(emptyClass4, emptyClass5);
            Assert.AreNotEqual(emptyClass, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromObjectFactoryToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<IEmptyClass>(container => emptyClass);
            var emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            c.RegisterType<IEmptyClass>(container => new EmptyClass());
            var emptyClass3 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass2, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromInstanceToObjectFactory_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            c.RegisterType<IEmptyClass>(container => new EmptyClass());
            var emptyClass3 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromObjectFactoryToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>(container => new EmptyClass());
            var emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass3 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass2, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromClassToObjectFactory_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            var emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            c.RegisterType<IEmptyClass>(container => new EmptyClass());
            var emptyClass3 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromClassToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsTransient();
            var emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass3 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);
            var emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheSameClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();

            c.RegisterType<ISampleClass, SampleClass>();
            var sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);

            c.RegisterType<ISampleClass, SampleClass>();
            var sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheOther_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();

            c.RegisterType<ISampleClass, SampleClass>();
            var sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);

            c.RegisterType<ISampleClass, SampleClassOther>();
            var sampleClass3 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);
            var sampleClass4 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.GetType(), sampleClass2.GetType());
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass3, sampleClass4);
            Assert.AreEqual(sampleClass3.GetType(), sampleClass4.GetType());
            Assert.AreNotEqual(sampleClass3.EmptyClass, sampleClass4.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass3);
            Assert.AreNotEqual(sampleClass1.GetType(), sampleClass3.GetType());
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass3.EmptyClass);
        }
    }
}