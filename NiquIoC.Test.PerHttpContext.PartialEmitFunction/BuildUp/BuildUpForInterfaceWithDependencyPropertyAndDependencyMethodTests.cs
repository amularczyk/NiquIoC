using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.BuildUp
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyPropertyAndDependencyMethodTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType sampleClass =
                new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass.EmptyClassFromDependencyProperty, sampleClass.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType sampleClass1 =
                new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType sampleClass2 =
                new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType();


            var objs = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, sampleClass2, ResolveKind.PartialEmitFunction);
            sampleClass1 = objs.Item1;
            sampleClass2 = objs.Item2;


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
        public void
            DifferentHttpContexts_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType sampleClass1 =
                new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType sampleClass2 =
                new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType();


            sampleClass1 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, ResolveKind.PartialEmitFunction);
            sampleClass2 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass2, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass1.EmptyClassFromDependencyMethod);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass2.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyProperty,
                sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyMethod,
                sampleClass2.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>()
                .AsPerHttpContext();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass =
                new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass, sampleClass.EmptyClass);
            Assert.AreEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void
            SameHttpContext_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>()
                .AsPerHttpContext();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass1 =
                new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass2 =
                new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes();


            var objs = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, sampleClass2, ResolveKind.PartialEmitFunction);
            sampleClass1 = objs.Item1;
            sampleClass2 = objs.Item2;


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
            DifferentHttpContexts_DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>()
                .AsPerHttpContext();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass1 =
                new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass2 =
                new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes();


            sampleClass1 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, ResolveKind.PartialEmitFunction);
            sampleClass2 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass2, ResolveKind.PartialEmitFunction);


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