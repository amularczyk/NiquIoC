using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.PerThread.FactoryObject
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForInterfaceWithClassTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<ISampleClass>(() => new SampleClass(emptyClass)).AsPerThread();
            ISampleClass sampleClass1 = null;
            ISampleClass sampleClass2 = null;


            var thread = new Thread(() => {
                sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);
                sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void FactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            ISampleClass sampleClass = new SampleClass(emptyClass);
            c.RegisterType<ISampleClass>(() => sampleClass).AsPerThread();
            ISampleClass sampleClass1 = null;
            ISampleClass sampleClass2 = null;


            var thread = new Thread(() => {
                sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);
                sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsPerThread();
            c.RegisterType<ISampleClass, SampleClass>().AsPerThread();
            ISampleClass sampleClass1 = null;
            ISampleClass sampleClass2 = null;


            var thread = new Thread(() => {
                sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);
                sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<EmptyClass>(() => emptyClass).AsPerThread();
            c.RegisterType<ISampleClass, SampleClass>().AsPerThread();
            ISampleClass sampleClass1 = null;
            ISampleClass sampleClass2 = null;


            var thread = new Thread(() => {
                sampleClass1 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);
                sampleClass2 = c.Resolve<ISampleClass>(ResolveKind.FullEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}