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
    public class BuildUpForClassWithDependencyMethodTests
    {
        [TestMethod]
        public void ClassWithoutBuildUpWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithoutClassDependencyMethod();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithClassDependencyMethod();

            
            sampleClass = TestsHelper.BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_BuildUpClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithClassDependencyMethod();
            var sampleClass2 = new SampleClassWithClassDependencyMethod();


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
        public void DifferentThreads_DifferentObjects_BuildUpClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithClassDependencyMethod();
            var sampleClass2 = new SampleClassWithClassDependencyMethod();


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
        [ExpectedException(typeof(CycleForTypeException), "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.SampleClassWithCycleInConstructorWithClassDependencyMethod")]
        public void ResolveClassWithCycleInConstructorWithClassDependencyMethodAfterBuildUpObjectOfThisClass_Failed()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithCycleInConstructorWithClassDependencyMethod>();
            var sampleClass1 = new SampleClassWithCycleInConstructorWithClassDependencyMethod(null);
            SampleClassWithCycleInConstructorWithClassDependencyMethod sampleClass2 = null;
            Exception exception = null;


            var thread = new Thread(() =>
            {
                try
                {
                    c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
                    sampleClass2 = c.Resolve<SampleClassWithCycleInConstructorWithClassDependencyMethod>(ResolveKind.PartialEmitFunction);
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
        public void BuildUpClassWithoutDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithoutClassDependencyMethod();


            var thread = new Thread(() => { c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithDependencyMethodWithReturnType_Failed()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithClassDependencyMethodWithReturnType();


            var thread = new Thread(() => { c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithManyClassDependencyMethods();


            var thread = new Thread(() => { c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_BuildUpClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithManyClassDependencyMethods();
            var sampleClass2 = new SampleClassWithManyClassDependencyMethods();


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
        public void DifferentThreads_DifferentObjects_BuildUpClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithManyClassDependencyMethods();
            var sampleClass2 = new SampleClassWithManyClassDependencyMethods();


            var thread1 = new Thread(() =>
            {
                c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() =>
            {
                c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);
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
        public void BuildUpClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithManyClassParametersInDependencyMethod();


            var thread = new Thread(() => { c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_BuildUpClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithManyClassParametersInDependencyMethod();
            var sampleClass2 = new SampleClassWithManyClassParametersInDependencyMethod();


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
        public void DifferentThreads_DifferentObjects_BuildUpClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithManyClassParametersInDependencyMethod();
            var sampleClass2 = new SampleClassWithManyClassParametersInDependencyMethod();


            var thread1 = new Thread(() =>
            {
                c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() =>
            {
                c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);
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
        public void BuildUpClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>();
            var sampleClass = new SampleClassWithNestedClassDependencyMethod();


            var thread = new Thread(() => { c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_BuildUpClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithNestedClassDependencyMethod();
            var sampleClass2 = new SampleClassWithNestedClassDependencyMethod();


            var thread = new Thread(() =>
            {
                c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
                c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyMethod, sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass, sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_BuildUpClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithNestedClassDependencyMethod();
            var sampleClass2 = new SampleClassWithNestedClassDependencyMethod();


            var thread1 = new Thread(() =>
            {
                c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() =>
            {
                c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);
            });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyMethod, sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass, sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);
        }
    }
}