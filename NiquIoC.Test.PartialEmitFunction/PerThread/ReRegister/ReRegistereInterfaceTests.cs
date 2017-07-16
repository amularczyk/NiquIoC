using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.PerThread.ReRegister
{
    [TestClass]
    public class ReRegistereInterfaceTests
    {
        [TestMethod]
        public void InterfaceReRegisteredFromInstanceToInstance_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            IEmptyClass emptyClass3 = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerThread();
            IEmptyClass emptyClass1 = null;
            IEmptyClass emptyClass2 = null;
            IEmptyClass emptyClass4 = null;
            IEmptyClass emptyClass5 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterInstance(emptyClass3).AsPerThread();
                emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass5 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


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
            c.RegisterType<IEmptyClass>(container => emptyClass).AsPerThread();
            IEmptyClass emptyClass1 = null;
            IEmptyClass emptyClass2 = null;
            IEmptyClass emptyClass3 = null;
            IEmptyClass emptyClass4 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterType<IEmptyClass>(container => new EmptyClass()).AsPerThread();
                emptyClass3 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromInstanceToObjectFactory_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerThread();
            IEmptyClass emptyClass1 = null;
            IEmptyClass emptyClass2 = null;
            IEmptyClass emptyClass3 = null;
            IEmptyClass emptyClass4 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterType<IEmptyClass>(container => new EmptyClass()).AsPerThread();
                emptyClass3 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromObjectFactoryToInstance_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<IEmptyClass>(container => new EmptyClass()).AsPerThread();
            IEmptyClass emptyClass1 = null;
            IEmptyClass emptyClass2 = null;
            IEmptyClass emptyClass3 = null;
            IEmptyClass emptyClass4 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterInstance(emptyClass).AsPerThread();
                emptyClass3 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromClassToObjectFactory_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            IEmptyClass emptyClass1 = null;
            IEmptyClass emptyClass2 = null;
            IEmptyClass emptyClass3 = null;
            IEmptyClass emptyClass4 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterType<IEmptyClass>(container => new EmptyClass()).AsPerThread();
                emptyClass3 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromClassToInstance_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            IEmptyClass emptyClass1 = null;
            IEmptyClass emptyClass2 = null;
            IEmptyClass emptyClass3 = null;
            IEmptyClass emptyClass4 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterInstance(emptyClass).AsPerThread();
                emptyClass3 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass4 = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheSameClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClass, SampleClass>().AsPerThread();
            ISampleClass sampleClass1 = null;
            ISampleClass sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);

                c.RegisterType<ISampleClass, SampleClass>().AsPerThread();
                sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheOther_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClass, SampleClass>().AsPerThread();
            ISampleClass sampleClass1 = null;
            ISampleClass sampleClass2 = null;
            ISampleClass sampleClass3 = null;
            ISampleClass sampleClass4 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);

                c.RegisterType<ISampleClass, SampleClassOther>().AsPerThread();
                sampleClass3 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);
                sampleClass4 = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.GetType(), sampleClass2.GetType());
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass3, sampleClass4);
            Assert.AreEqual(sampleClass3.GetType(), sampleClass4.GetType());
            Assert.AreEqual(sampleClass3.EmptyClass, sampleClass4.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass3);
            Assert.AreNotEqual(sampleClass1.GetType(), sampleClass3.GetType());
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass3.EmptyClass);
        }
    }
}