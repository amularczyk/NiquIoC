using System.IO;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;
using NiquIoC.Test.WebApplication.Controllers;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.BuildUp
{
    [TestClass]
    public class BuildUpForClassWithDependencyPropertyAndDependencyMethodTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType();


            sampleClass = TestsHelper.BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass.EmptyClassFromDependencyProperty, sampleClass.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType();
            var sampleClass2 = new SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType();


            var thread = new Thread(() =>
            {
                c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
                c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);
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
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyMethod, sampleClass2.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType();
            var sampleClass2 = new SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType();


            var thread1 = new Thread(() => { c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction); });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass1.EmptyClassFromDependencyMethod);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass2.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyMethod, sampleClass2.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes();


            var thread = new Thread(() => { c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass, sampleClass.EmptyClass);
            Assert.AreEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes();
            var sampleClass2 = new SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes();


            var thread = new Thread(() =>
            {
                c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction);
                c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction);
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
        public void DifferentThreads_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes();
            var sampleClass2 = new SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes();


            var thread1 = new Thread(() => { c.BuildUp(sampleClass1, ResolveKind.PartialEmitFunction); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { c.BuildUp(sampleClass2, ResolveKind.PartialEmitFunction); });
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