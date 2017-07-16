using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.PerThread.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyPropertyAndDependencyMethodTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyPropertyAndDependencyMethodWithSameType_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>();
            SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>(ResolveKind
                        .PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass.EmptyClassFromDependencyProperty, sampleClass.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void
            SameThread_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithSameType_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>();
            SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType sampleClass1 = null;
            SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 =
                    c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>(ResolveKind
                        .PartialEmitFunction);
                sampleClass2 =
                    c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>(ResolveKind
                        .PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass1.EmptyClassFromDependencyMethod);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass2.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty,
                sampleClass2.EmptyClassFromDependencyProperty);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyMethod, sampleClass2.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void
            DifferentThreads_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithSameType_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>();
            SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType sampleClass1 = null;
            SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType sampleClass2 = null;


            var thread1 = new Thread(container =>
            {
                sampleClass1 =
                    c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>(ResolveKind
                        .PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(container =>
            {
                sampleClass2 =
                    c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>(ResolveKind
                        .PartialEmitFunction);
            });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass1.EmptyClassFromDependencyMethod);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass2.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyProperty,
                sampleClass2.EmptyClassFromDependencyProperty);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyMethod,
                sampleClass2.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();
            SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>(
                        ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass, sampleClass.EmptyClass);
            Assert.AreEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void
            SameThread_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();
            SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass1 = null;
            SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 =
                    c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>(ResolveKind
                        .PartialEmitFunction);
                sampleClass2 =
                    c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>(ResolveKind
                        .PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass1.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass.EmptyClass, sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass2.SampleClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass2.SampleClass.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void
            DifferentThreads_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();
            SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass1 = null;
            SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass2 = null;


            var thread1 = new Thread(container =>
            {
                sampleClass1 =
                    c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>(
                        ResolveKind.PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(container =>
            {
                sampleClass2 =
                    c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>(
                        ResolveKind.PartialEmitFunction);
            });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass1.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass.EmptyClass, sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass2.SampleClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass2.SampleClass.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}