using System.IO;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;
using NiquIoC.Test.WebApplication.Controllers;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyMethodTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>();


            var sampleClass = TestsHelper.ResolveObject<SampleClassWithClassDependencyMethod>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>();

            SampleClassWithClassDependencyMethod sampleClass1 = null;
            SampleClassWithClassDependencyMethod sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<SampleClassWithClassDependencyMethod>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<SampleClassWithClassDependencyMethod>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_RegisterClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>();

            SampleClassWithClassDependencyMethod sampleClass1 = null;
            SampleClassWithClassDependencyMethod sampleClass2 = null;


            var thread1 = new Thread(() => { sampleClass1 = c.Resolve<SampleClassWithClassDependencyMethod>(ResolveKind.PartialEmitFunction); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { sampleClass2 = c.Resolve<SampleClassWithClassDependencyMethod>(ResolveKind.PartialEmitFunction); });
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithoutDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithoutClassDependencyMethod>();
            SampleClassWithoutClassDependencyMethod sampleClass = null;


            var thread = new Thread(() => { sampleClass = c.Resolve<SampleClassWithoutClassDependencyMethod>(ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithDependencyMethodWithReturnType_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethodWithReturnType>();
            SampleClassWithClassDependencyMethodWithReturnType sampleClass = null;


            var thread = new Thread(() => { sampleClass = c.Resolve<SampleClassWithClassDependencyMethodWithReturnType>(ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithManyClassDependencyMethods>();
            SampleClassWithManyClassDependencyMethods sampleClass = null;


            var thread = new Thread(() => { sampleClass = c.Resolve<SampleClassWithManyClassDependencyMethods>(ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithManyClassDependencyMethods>();
            SampleClassWithManyClassDependencyMethods sampleClass1 = null;
            SampleClassWithManyClassDependencyMethods sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<SampleClassWithManyClassDependencyMethods>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<SampleClassWithManyClassDependencyMethods>(ResolveKind.PartialEmitFunction);
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
        public void DifferentThreads_DifferentObjects_RegisterClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithManyClassDependencyMethods>();
            SampleClassWithManyClassDependencyMethods sampleClass1 = null;
            SampleClassWithManyClassDependencyMethods sampleClass2 = null;


            var thread1 = new Thread(() => { sampleClass1 = c.Resolve<SampleClassWithManyClassDependencyMethods>(ResolveKind.PartialEmitFunction); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { sampleClass2 = c.Resolve<SampleClassWithManyClassDependencyMethods>(ResolveKind.PartialEmitFunction); });
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
        public void RegisterClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithManyClassParametersInDependencyMethod>();
            SampleClassWithManyClassParametersInDependencyMethod sampleClass = null;


            var thread = new Thread(() => { sampleClass = c.Resolve<SampleClassWithManyClassParametersInDependencyMethod>(ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithManyClassParametersInDependencyMethod>();
            SampleClassWithManyClassParametersInDependencyMethod sampleClass1 = null;
            SampleClassWithManyClassParametersInDependencyMethod sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<SampleClassWithManyClassParametersInDependencyMethod>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<SampleClassWithManyClassParametersInDependencyMethod>(ResolveKind.PartialEmitFunction);
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
        public void DifferentThreads_DifferentObjects_RegisterClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithManyClassParametersInDependencyMethod>();
            SampleClassWithManyClassParametersInDependencyMethod sampleClass1 = null;
            SampleClassWithManyClassParametersInDependencyMethod sampleClass2 = null;


            var thread1 = new Thread(() => { sampleClass1 = c.Resolve<SampleClassWithManyClassParametersInDependencyMethod>(ResolveKind.PartialEmitFunction); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { sampleClass2 = c.Resolve<SampleClassWithManyClassParametersInDependencyMethod>(ResolveKind.PartialEmitFunction); });
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
        public void RegisterClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>().AsPerHttpContext();
            c.RegisterType<SampleClassWithNestedClassDependencyMethod>();
            SampleClassWithNestedClassDependencyMethod sampleClass = null;


            var thread = new Thread(() => { sampleClass = c.Resolve<SampleClassWithNestedClassDependencyMethod>(ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>().AsPerHttpContext();
            c.RegisterType<SampleClassWithNestedClassDependencyMethod>();
            SampleClassWithNestedClassDependencyMethod sampleClass1 = null;
            SampleClassWithNestedClassDependencyMethod sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<SampleClassWithNestedClassDependencyMethod>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<SampleClassWithNestedClassDependencyMethod>(ResolveKind.PartialEmitFunction);
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
        public void DifferentThreads_DifferentObjects_RegisterClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>().AsPerHttpContext();
            c.RegisterType<SampleClassWithNestedClassDependencyMethod>();
            SampleClassWithNestedClassDependencyMethod sampleClass1 = null;
            SampleClassWithNestedClassDependencyMethod sampleClass2 = null;


            var thread1 = new Thread(() => { sampleClass1 = c.Resolve<SampleClassWithNestedClassDependencyMethod>(ResolveKind.PartialEmitFunction); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { sampleClass2 = c.Resolve<SampleClassWithNestedClassDependencyMethod>(ResolveKind.PartialEmitFunction); });
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