using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.ObjectLifetimeManagers;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.PerThread
{
    [TestClass]
    public class RegisterTypeForClassTests
    {
        [TestMethod]
        public void DifferentObjects_RegisterClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsCustomObjectLifetimeManager(new ThreadObjectLifetimeManager());
            c.RegisterType<SampleClass>().AsCustomObjectLifetimeManager(new ThreadObjectLifetimeManager());
            SampleClass sampleClass1 = null;
            SampleClass sampleClass2 = null;

            var thread1 = new Thread(() => { sampleClass1 = c.Resolve<SampleClass>(); });
            var thread2 = new Thread(() => { sampleClass2 = c.Resolve<SampleClass>(); });
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClass2_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsCustomObjectLifetimeManager(new ThreadObjectLifetimeManager());
            c.RegisterType<SampleClass>().AsCustomObjectLifetimeManager(new ThreadObjectLifetimeManager());
            SampleClass sampleClass11 = null;
            SampleClass sampleClass12 = null;
            SampleClass sampleClass21 = null;
            SampleClass sampleClass22 = null;

            var thread1 = new Thread(() => { sampleClass11 = c.Resolve<SampleClass>(); sampleClass12 = c.Resolve<SampleClass>(); });
            var thread2 = new Thread(() => { sampleClass21 = c.Resolve<SampleClass>(); sampleClass22 = c.Resolve<SampleClass>(); });
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();

            Assert.IsNotNull(sampleClass11);
            Assert.IsNotNull(sampleClass11.EmptyClass);
            Assert.IsNotNull(sampleClass12);
            Assert.IsNotNull(sampleClass12.EmptyClass);
            Assert.IsNotNull(sampleClass21);
            Assert.IsNotNull(sampleClass21.EmptyClass);
            Assert.IsNotNull(sampleClass22);
            Assert.IsNotNull(sampleClass22.EmptyClass);

            Assert.AreEqual(sampleClass11, sampleClass12);
            Assert.AreEqual(sampleClass11.EmptyClass, sampleClass12.EmptyClass);

            Assert.AreNotEqual(sampleClass11, sampleClass21);
            Assert.AreNotEqual(sampleClass11.EmptyClass, sampleClass21.EmptyClass);

            Assert.AreEqual(sampleClass21, sampleClass22);
            Assert.AreEqual(sampleClass21.EmptyClass, sampleClass22.EmptyClass);
        }
    }
}