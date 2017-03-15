using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterInterfaceWithDependencyMethodTests
    {
        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithInterfaceMethod>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterInterfaceWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();
            ISampleClassWithInterfaceMethod sampleClass1 = null;
            ISampleClassWithInterfaceMethod sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<ISampleClassWithInterfaceMethod>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<ISampleClassWithInterfaceMethod>(ResolveKind.PartialEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_RegisterInterfaceWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();


            var sampleClass1 = TestsHelper.ResolveObject<ISampleClassWithInterfaceMethod>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<ISampleClassWithInterfaceMethod>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithoutDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithoutInterfaceDependencyMethod>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithInterfaceMethod>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyMethodWithReturnType_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethodWithReturnType, SampleClassWithInterfaceDependencyMethodWithReturnType>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithInterfaceMethodWithReturnType>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithManyInterfaceDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithManyInterfaceDependencyMethods, SampleClassWithManyInterfaceDependencyMethods>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithManyInterfaceDependencyMethods>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterInterfaceWithManyInterfaceDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithManyInterfaceDependencyMethods, SampleClassWithManyInterfaceDependencyMethods>();
            ISampleClassWithManyInterfaceDependencyMethods sampleClass1 = null;
            ISampleClassWithManyInterfaceDependencyMethods sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<ISampleClassWithManyInterfaceDependencyMethods>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<ISampleClassWithManyInterfaceDependencyMethods>(ResolveKind.PartialEmitFunction);
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
        public void DifferentThreads_DifferentObjects_RegisterInterfaceWithManyInterfaceDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithManyInterfaceDependencyMethods, SampleClassWithManyInterfaceDependencyMethods>();


            var sampleClass1 = TestsHelper.ResolveObject<ISampleClassWithManyInterfaceDependencyMethods>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<ISampleClassWithManyInterfaceDependencyMethods>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithManyInterfaceParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithManyInterfaceParametersInDependencyMethod, SampleClassWithManyInterfaceParametersInDependencyMethod>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithManyInterfaceParametersInDependencyMethod>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterInterfaceWithManyInterfaceParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithManyInterfaceParametersInDependencyMethod, SampleClassWithManyInterfaceParametersInDependencyMethod>();
            ISampleClassWithManyInterfaceParametersInDependencyMethod sampleClass1 = null;
            ISampleClassWithManyInterfaceParametersInDependencyMethod sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<ISampleClassWithManyInterfaceParametersInDependencyMethod>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<ISampleClassWithManyInterfaceParametersInDependencyMethod>(ResolveKind.PartialEmitFunction);
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
        public void DifferentThreads_DifferentObjects_RegisterInterfaceWithManyInterfaceParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithManyInterfaceParametersInDependencyMethod, SampleClassWithManyInterfaceParametersInDependencyMethod>();


            var sampleClass1 = TestsHelper.ResolveObject<ISampleClassWithManyInterfaceParametersInDependencyMethod>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<ISampleClassWithManyInterfaceParametersInDependencyMethod>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithNestedInterfaceDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyMethod, SampleClassWithNestedInterfaceDependencyMethod>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithNestedInterfaceDependencyMethod>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.SampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterInterfaceWithNestedInterfaceDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyMethod, SampleClassWithNestedInterfaceDependencyMethod>();
            ISampleClassWithNestedInterfaceDependencyMethod sampleClass1 = null;
            ISampleClassWithNestedInterfaceDependencyMethod sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<ISampleClassWithNestedInterfaceDependencyMethod>(ResolveKind.PartialEmitFunction);
                sampleClass2 = c.Resolve<ISampleClassWithNestedInterfaceDependencyMethod>(ResolveKind.PartialEmitFunction);
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
        public void DifferentThreads_DifferentObjects_RegisterInterfaceWithNestedInterfaceDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyMethod, SampleClassWithNestedInterfaceDependencyMethod>();


            var sampleClass1 = TestsHelper.ResolveObject<ISampleClassWithNestedInterfaceDependencyMethod>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<ISampleClassWithNestedInterfaceDependencyMethod>(c, ResolveKind.PartialEmitFunction);


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