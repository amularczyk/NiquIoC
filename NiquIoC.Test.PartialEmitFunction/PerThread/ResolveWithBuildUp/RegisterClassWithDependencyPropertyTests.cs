using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.PerThread.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            SampleClassWithClassDependencyProperty sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass = c.Resolve<SampleClassWithClassDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            SampleClassWithClassDependencyProperty sampleClass1 = null;
            SampleClassWithClassDependencyProperty sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<SampleClassWithClassDependencyProperty>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<SampleClassWithClassDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_RegisterClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            SampleClassWithClassDependencyProperty sampleClass1 = null;
            SampleClassWithClassDependencyProperty sampleClass2 = null;


            var thread1 = new Thread(container =>
            {
                sampleClass1 = c.Resolve<SampleClassWithClassDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(container =>
            {
                sampleClass2 = c.Resolve<SampleClassWithClassDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithoutDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithoutClassDependencyProperty>();
            SampleClassWithoutClassDependencyProperty sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass = c.Resolve<SampleClassWithoutClassDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();
            SampleClassWithManyClassDependencyProperties sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<SampleClassWithManyClassDependencyProperties>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();
            SampleClassWithManyClassDependencyProperties sampleClass1 = null;
            SampleClassWithManyClassDependencyProperties sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<SampleClassWithManyClassDependencyProperties>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<SampleClassWithManyClassDependencyProperties>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_RegisterClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();
            SampleClassWithManyClassDependencyProperties sampleClass1 = null;
            SampleClassWithManyClassDependencyProperties sampleClass2 = null;


            var thread1 = new Thread(container =>
            {
                sampleClass1 =
                    c.Resolve<SampleClassWithManyClassDependencyProperties>(ResolveKind.PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(container =>
            {
                sampleClass2 =
                    c.Resolve<SampleClassWithManyClassDependencyProperties>(ResolveKind.PartialEmitFunction);
            });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void RegisterClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerThread();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();
            SampleClassWithNestedClassDependencyProperty sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<SampleClassWithNestedClassDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerThread();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();
            SampleClassWithNestedClassDependencyProperty sampleClass1 = null;
            SampleClassWithNestedClassDependencyProperty sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<SampleClassWithNestedClassDependencyProperty>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<SampleClassWithNestedClassDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyProperty,
                sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_RegisterClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerThread();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();
            SampleClassWithNestedClassDependencyProperty sampleClass1 = null;
            SampleClassWithNestedClassDependencyProperty sampleClass2 = null;


            var thread1 = new Thread(container =>
            {
                sampleClass1 =
                    c.Resolve<SampleClassWithNestedClassDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(container =>
            {
                sampleClass2 =
                    c.Resolve<SampleClassWithNestedClassDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyProperty,
                sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithDependencyPropertyWithoutSetMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyPropertyWithoutSetMethod>();
            SampleClassWithClassDependencyPropertyWithoutSetMethod sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<SampleClassWithClassDependencyPropertyWithoutSetMethod>(ResolveKind
                        .PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerThread();
            c.RegisterType<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>();
            SampleClassWithClassInConstructorWithNestedClassDependencyProperty sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>(ResolveKind
                        .PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void
            SameThread_DifferentObjects_RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerThread();
            c.RegisterType<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>();
            SampleClassWithClassInConstructorWithNestedClassDependencyProperty sampleClass1 = null;
            SampleClassWithClassInConstructorWithNestedClassDependencyProperty sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 =
                    c.Resolve<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>(ResolveKind
                        .PartialEmitFunction);
                sampleClass2 =
                    c.Resolve<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>(ResolveKind
                        .PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyProperty,
                sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void
            DifferentThreads_DifferentObjects_RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerThread();
            c.RegisterType<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>();
            SampleClassWithClassInConstructorWithNestedClassDependencyProperty sampleClass1 = null;
            SampleClassWithClassInConstructorWithNestedClassDependencyProperty sampleClass2 = null;


            var thread1 = new Thread(container =>
            {
                sampleClass1 =
                    c.Resolve<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>(ResolveKind
                        .PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(container =>
            {
                sampleClass2 =
                    c.Resolve<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>(ResolveKind
                        .PartialEmitFunction);
            });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyProperty,
                sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
        }
    }
}