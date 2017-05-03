using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterInterfaceWithDependencyPropertyAndDependencyMethodTests
    {
        [TestMethod]
        public void RegisterInterfaceWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType, SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>();


            var sampleClass = HttpContextTestsHelper.Initialize().ResolveObject<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass.EmptyClassFromDependencyProperty, sampleClass.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_RegisterInterfaceWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType, SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>();


            var objs = HttpContextTestsHelper.Initialize().ResolveObjects<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = objs.Item1;
            var sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass1.EmptyClassFromDependencyMethod);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass2.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyProperty);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyMethod, sampleClass2.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void DifferentHttpContexts_DifferentObjects_RegisterInterfaceWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType, SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>();


            var sampleClass1 = HttpContextTestsHelper.Initialize().ResolveObject<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = HttpContextTestsHelper.Initialize().ResolveObject<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass1.EmptyClassFromDependencyMethod);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass2.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyProperty);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyMethod, sampleClass2.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void RegisterInterfaceWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes, SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>();


            var sampleClass = HttpContextTestsHelper.Initialize().ResolveObject<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass, sampleClass.EmptyClass);
            Assert.AreEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_RegisterInterfaceWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes, SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>();


            var objs = HttpContextTestsHelper.Initialize().ResolveObjects<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = objs.Item1;
            var sampleClass2 = objs.Item2;


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
        public void DifferentHttpContexts_DifferentObjects_RegisterInterfaceWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes, SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>();


            var sampleClass1 = HttpContextTestsHelper.Initialize().ResolveObject<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = HttpContextTestsHelper.Initialize().ResolveObject<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>(c, ResolveKind.PartialEmitFunction);


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