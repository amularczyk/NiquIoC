using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.PerThread.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterInterfaceWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisterInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            ISampleClassWithInterfaceProperty sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_BuildUpInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            ISampleClassWithInterfaceProperty sampleClass1 = null;
            ISampleClassWithInterfaceProperty sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_BuildUpInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            ISampleClassWithInterfaceProperty sampleClass1 = null;
            ISampleClassWithInterfaceProperty sampleClass2 = null;


            var thread1 = new Thread(() =>
            {
                sampleClass1 = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() =>
            {
                sampleClass2 = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);
            });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceWithoutDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithoutInterfaceDependencyProperty>();
            ISampleClassWithInterfaceProperty sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerThread();
            c
                .RegisterType<ISampleClassWithManyInterfaceDependencyProperties,
                    SampleClassWithManyInterfaceDependencyProperties>();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<ISampleClassWithManyInterfaceDependencyProperties>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerThread();
            c
                .RegisterType<ISampleClassWithManyInterfaceDependencyProperties,
                    SampleClassWithManyInterfaceDependencyProperties>();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass1 = null;
            ISampleClassWithManyInterfaceDependencyProperties sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 =
                    c.Resolve<ISampleClassWithManyInterfaceDependencyProperties>(ResolveKind.PartialEmitFunction);
                sampleClass2 =
                    c.Resolve<ISampleClassWithManyInterfaceDependencyProperties>(ResolveKind.PartialEmitFunction);
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
        public void DifferentThreads_DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerThread();
            c
                .RegisterType<ISampleClassWithManyInterfaceDependencyProperties,
                    SampleClassWithManyInterfaceDependencyProperties>();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass1 = null;
            ISampleClassWithManyInterfaceDependencyProperties sampleClass2 = null;


            var thread1 = new Thread(() =>
            {
                sampleClass1 =
                    c.Resolve<ISampleClassWithManyInterfaceDependencyProperties>(ResolveKind.PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() =>
            {
                sampleClass2 =
                    c.Resolve<ISampleClassWithManyInterfaceDependencyProperties>(ResolveKind.PartialEmitFunction);
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
        public void RegisterInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>()
                .AsPerThread();
            c
                .RegisterType<ISampleClassWithNestedInterfaceDependencyProperty,
                    SampleClassWithNestedInterfaceDependencyProperty>();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>()
                .AsPerThread();
            c
                .RegisterType<ISampleClassWithNestedInterfaceDependencyProperty,
                    SampleClassWithNestedInterfaceDependencyProperty>();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass1 = null;
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 =
                    c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
                sampleClass2 =
                    c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty,
                sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>()
                .AsPerThread();
            c
                .RegisterType<ISampleClassWithNestedInterfaceDependencyProperty,
                    SampleClassWithNestedInterfaceDependencyProperty>();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass1 = null;
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass2 = null;


            var thread1 = new Thread(() =>
            {
                sampleClass1 =
                    c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() =>
            {
                sampleClass2 =
                    c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty,
                sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyPropertyWithoutSetMethodWithInterface_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c
                .RegisterType<ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface,
                    SampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface>();
            ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface>(ResolveKind
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
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>()
                .AsPerThread();
            c
                .RegisterType<ISampleClassWithNestedInterfaceDependencyProperty,
                    SampleClassWithClassInConstructorWithNestedInterfaceDependencyProperty>();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void
            SameThread_DifferentObjects_RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>()
                .AsPerThread();
            c
                .RegisterType<ISampleClassWithNestedInterfaceDependencyProperty,
                    SampleClassWithClassInConstructorWithNestedInterfaceDependencyProperty>();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass1 = null;
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 =
                    c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
                sampleClass2 =
                    c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty,
                sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void
            DifferentThreads_DifferentObjects_RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>()
                .AsPerThread();
            c
                .RegisterType<ISampleClassWithNestedInterfaceDependencyProperty,
                    SampleClassWithClassInConstructorWithNestedInterfaceDependencyProperty>();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass1 = null;
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass2 = null;


            var thread1 = new Thread(() =>
            {
                sampleClass1 =
                    c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() =>
            {
                sampleClass2 =
                    c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.PartialEmitFunction);
            });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty,
                sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }
    }
}