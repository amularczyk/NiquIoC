using System;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;
using NiquIoC.Test.WebApplication.Controllers;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.BuildUp
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyMethodTests
    {
        [TestMethod]
        public void InterfaceWithoutBuildUpWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithoutInterfaceDependencyMethod();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithInterfaceDependencyMethod();


            sampleClass = TestsHelper.BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_BuildUpInterfaceWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceMethod sampleClass1 = new SampleClassWithInterfaceDependencyMethod();
            ISampleClassWithInterfaceMethod sampleClass2 = new SampleClassWithInterfaceDependencyMethod();


            var thread = new Thread(() =>
            {
                c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
                c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_BuildUpInterfaceWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceMethod sampleClass1 = new SampleClassWithInterfaceDependencyMethod();
            ISampleClassWithInterfaceMethod sampleClass2 = new SampleClassWithInterfaceDependencyMethod();


            var thread1 = new Thread(() => { c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction); });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException),
            "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.SampleClassWithCycleInConstructorWithInterfaceDependencyMethod")]
        public void ResolveInterfaceWithCycleInConstructorWithClassDependencyMethodAfterBuildUpObjectOfThisInterface_Failed()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithCycleInConstructorWithInterfaceDependencyMethod>();
            ISampleClassWithInterfaceMethod sampleClass1 = new SampleClassWithCycleInConstructorWithInterfaceDependencyMethod(null);
            SampleClassWithCycleInConstructorWithInterfaceDependencyMethod sampleClass2 = null;
            Exception exception = null;


            var thread = new Thread(() =>
            {
                try
                {
                    c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
                    sampleClass2 = c.Resolve<SampleClassWithCycleInConstructorWithInterfaceDependencyMethod>(ResolveKind.PartialEmitFunction);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });
            thread.Start();
            thread.Join();

            if (exception != null)
            {
                throw exception;
            }


            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNull(sampleClass2);
        }

        [TestMethod]
        public void BuildUpInterfaceWithoutDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithoutInterfaceDependencyMethod();


            var thread = new Thread(() => { c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithDependencyMethodWithReturnType_Failed()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceMethodWithReturnType sampleClass = new SampleClassWithInterfaceDependencyMethodWithReturnType();


            var thread = new Thread(() => { c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithManyInterfaceDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceDependencyMethods sampleClass = new SampleClassWithManyInterfaceDependencyMethods();


            var thread = new Thread(() => { c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            ISampleClassWithManyInterfaceDependencyMethods sampleClass1 = new SampleClassWithManyInterfaceDependencyMethods();
            ISampleClassWithManyInterfaceDependencyMethods sampleClass2 = new SampleClassWithManyInterfaceDependencyMethods();


            var thread = new Thread(() =>
            {
                c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
                c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);
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
        public void DifferentThreads_DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            ISampleClassWithManyInterfaceDependencyMethods sampleClass1 = new SampleClassWithManyInterfaceDependencyMethods();
            ISampleClassWithManyInterfaceDependencyMethods sampleClass2 = new SampleClassWithManyInterfaceDependencyMethods();


            var thread1 = new Thread(() => { c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction); });
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
        public void BuildUpInterfaceWithManyInterfaceParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceParametersInDependencyMethod sampleClass = new SampleClassWithManyInterfaceParametersInDependencyMethod();


            var thread = new Thread(() => { c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_BuildUpInterfaceWithManyInterfaceParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            ISampleClassWithManyInterfaceParametersInDependencyMethod sampleClass1 = new SampleClassWithManyInterfaceParametersInDependencyMethod();
            ISampleClassWithManyInterfaceParametersInDependencyMethod sampleClass2 = new SampleClassWithManyInterfaceParametersInDependencyMethod();


            var thread = new Thread(() =>
            {
                c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
                c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);
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
        public void DifferentThreads_DifferentObjects_BuildUpInterfaceWithManyInterfaceParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            ISampleClassWithManyInterfaceParametersInDependencyMethod sampleClass1 = new SampleClassWithManyInterfaceParametersInDependencyMethod();
            ISampleClassWithManyInterfaceParametersInDependencyMethod sampleClass2 = new SampleClassWithManyInterfaceParametersInDependencyMethod();


            var thread1 = new Thread(() => { c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction); });
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
        public void BuildUpInterfaceWithNestedInterfaceDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();
            ISampleClassWithNestedInterfaceDependencyMethod sampleClass = new SampleClassWithNestedInterfaceDependencyMethod();


            var thread = new Thread(() => { c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.SampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>().AsPerHttpContext();
            ISampleClassWithNestedInterfaceDependencyMethod sampleClass1 = new SampleClassWithNestedInterfaceDependencyMethod();
            ISampleClassWithNestedInterfaceDependencyMethod sampleClass2 = new SampleClassWithNestedInterfaceDependencyMethod();


            var thread = new Thread(() =>
            {
                c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
                c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass1.SampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.IsNotNull(sampleClass2.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
            Assert.AreEqual(sampleClass1.SampleClass.EmptyClass, sampleClass2.SampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>().AsPerHttpContext();
            ISampleClassWithNestedInterfaceDependencyMethod sampleClass1 = new SampleClassWithNestedInterfaceDependencyMethod();
            ISampleClassWithNestedInterfaceDependencyMethod sampleClass2 = new SampleClassWithNestedInterfaceDependencyMethod();


            var thread1 = new Thread(() => { c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction); });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass1.SampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.IsNotNull(sampleClass2.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1.SampleClass.EmptyClass, sampleClass2.SampleClass.EmptyClass);
        }
    }
}