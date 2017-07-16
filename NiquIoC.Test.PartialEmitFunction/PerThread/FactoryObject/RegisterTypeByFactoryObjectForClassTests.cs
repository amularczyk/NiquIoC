using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.PerThread.FactoryObject
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForClassTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType(container => new SampleClass(emptyClass)).AsPerThread();
            SampleClass sampleClass1 = null;
            SampleClass sampleClass2 = null;


            var thread = new Thread(container =>
            {
                sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
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
            var sampleClass = new SampleClass(emptyClass);
            c.RegisterType(container => sampleClass).AsPerThread();
            SampleClass sampleClass1 = null;
            SampleClass sampleClass2 = null;


            var thread = new Thread(container =>
            {
                sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
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
            c.RegisterType(container => new EmptyClass()).AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            SampleClass sampleClass1 = null;
            SampleClass sampleClass2 = null;


            var thread = new Thread(container =>
            {
                sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
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
            c.RegisterType(container => emptyClass).AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            SampleClass sampleClass1 = null;
            SampleClass sampleClass2 = null;


            var thread = new Thread(container =>
            {
                sampleClass1 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<SampleClass>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}