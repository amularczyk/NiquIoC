using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.PerThread.FactoryObject
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForClassWithInterfaceTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<SampleClassWithInterfaceAsParameter>(() => new SampleClassWithInterfaceAsParameter(emptyClass)).AsPerThread();
            SampleClassWithInterfaceAsParameter sampleClass1 = null;
            SampleClassWithInterfaceAsParameter sampleClass2 = null;


            var thread = new Thread(() => {
                sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);
                sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);
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
            IEmptyClass emptyClass = new EmptyClass();
            var sampleClass = new SampleClassWithInterfaceAsParameter(emptyClass);
            c.RegisterType<SampleClassWithInterfaceAsParameter>(() => sampleClass).AsPerThread();
            SampleClassWithInterfaceAsParameter sampleClass1 = null;
            SampleClassWithInterfaceAsParameter sampleClass2 = null;


            var thread = new Thread(() => {
                sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);
                sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);
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
            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsPerThread();
            c.RegisterType<SampleClassWithInterfaceAsParameter>().AsPerThread();
            SampleClassWithInterfaceAsParameter sampleClass1 = null;
            SampleClassWithInterfaceAsParameter sampleClass2 = null;


            var thread = new Thread(() => {
                sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);
                sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);
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
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<IEmptyClass>(() => emptyClass).AsPerThread();
            c.RegisterType<SampleClassWithInterfaceAsParameter>().AsPerThread();
            SampleClassWithInterfaceAsParameter sampleClass1 = null;
            SampleClassWithInterfaceAsParameter sampleClass2 = null;


            var thread = new Thread(() => {
                sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);
                sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}