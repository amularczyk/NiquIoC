using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.PerThread.ReRegister
{
    [TestClass]
    public class ReRegistereClassTests
    {
        [TestMethod]
        public void ClassReRegisteredFromClassToTheSameClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            EmptyClass emptyClass1 = null;
            EmptyClass emptyClass2 = null;
            EmptyClass emptyClass3 = null;
            EmptyClass emptyClass4 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterType<EmptyClass>().AsPerThread();
                emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromInstanceToInstance_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            var emptyClass3 = new EmptyClass();
            EmptyClass emptyClass1 = null;
            EmptyClass emptyClass2 = null;
            EmptyClass emptyClass4 = null;
            EmptyClass emptyClass5 = null;
            c.RegisterInstance(emptyClass).AsPerThread();


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterInstance(emptyClass3).AsPerThread();
                emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass5 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
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
        public void ClassReRegisteredFromObjectFactoryToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType(container => emptyClass).AsPerThread();
            EmptyClass emptyClass1 = null;
            EmptyClass emptyClass2 = null;
            EmptyClass emptyClass3 = null;
            EmptyClass emptyClass4 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterType(container => new EmptyClass()).AsPerThread();
                emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass2, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromInstanceToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerThread();
            EmptyClass emptyClass1 = null;
            EmptyClass emptyClass2 = null;
            EmptyClass emptyClass3 = null;
            EmptyClass emptyClass4 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterType(container => new EmptyClass()).AsPerThread();
                emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void ClassReRegisteredFromObjectFactoryToInstance_Success()
        {
            var c = new Container();
            c.RegisterType(container => new EmptyClass()).AsPerThread();
            var emptyClass = new EmptyClass();
            EmptyClass emptyClass1 = null;
            EmptyClass emptyClass2 = null;
            EmptyClass emptyClass3 = null;
            EmptyClass emptyClass4 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterInstance(emptyClass).AsPerThread();
                emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass);
        }

        [TestMethod]
        public void ClassReRegisteredFromClassToObjectFactory_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            EmptyClass emptyClass1 = null;
            EmptyClass emptyClass2 = null;
            EmptyClass emptyClass3 = null;
            EmptyClass emptyClass4 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterType(container => new EmptyClass()).AsPerThread();
                emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromClassToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            var emptyClass = new EmptyClass();
            EmptyClass emptyClass1 = null;
            EmptyClass emptyClass2 = null;
            EmptyClass emptyClass3 = null;
            EmptyClass emptyClass4 = null;


            var thread = new Thread(() =>
            {
                emptyClass1 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass2 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

                c.RegisterInstance(emptyClass).AsPerThread();
                emptyClass3 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
                emptyClass4 = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass);
        }
    }
}