using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterInterfaceWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisterInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithInterfaceProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();


            var objects = TestsHelper.ResolveObjects<ISampleClassWithInterfaceProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = objects.Item1;
            var sampleClass2 = objects.Item2;


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentHttpContexts_DifferentObjects_BuildUpInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();


            var sampleClass1 = TestsHelper.ResolveObject<ISampleClassWithInterfaceProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<ISampleClassWithInterfaceProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceWithoutDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithoutInterfaceDependencyProperty>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithInterfaceProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithManyInterfaceDependencyProperties, SampleClassWithManyInterfaceDependencyProperties>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithManyInterfaceDependencyProperties>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithManyInterfaceDependencyProperties, SampleClassWithManyInterfaceDependencyProperties>();


            var objs = TestsHelper.ResolveObjects<ISampleClassWithManyInterfaceDependencyProperties>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = objs.Item1;
            var sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void DifferentHttpContexts_DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithManyInterfaceDependencyProperties, SampleClassWithManyInterfaceDependencyProperties>();


            var sampleClass1 = TestsHelper.ResolveObject<ISampleClassWithManyInterfaceDependencyProperties>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<ISampleClassWithManyInterfaceDependencyProperties>(c, ResolveKind.PartialEmitFunction);


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
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyProperty, SampleClassWithNestedInterfaceDependencyProperty>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithNestedInterfaceDependencyProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyProperty, SampleClassWithNestedInterfaceDependencyProperty>();


            var objs = TestsHelper.ResolveObjects<ISampleClassWithNestedInterfaceDependencyProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = objs.Item1;
            var sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty, sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass, sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentHttpContexts_DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyProperty, SampleClassWithNestedInterfaceDependencyProperty>();


            var sampleClass1 = TestsHelper.ResolveObject<ISampleClassWithNestedInterfaceDependencyProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<ISampleClassWithNestedInterfaceDependencyProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty, sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass, sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyPropertyWithoutSetMethodWithInterface_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface, SampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyProperty, SampleClassWithClassInConstructorWithNestedInterfaceDependencyProperty>();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithNestedInterfaceDependencyProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyProperty, SampleClassWithClassInConstructorWithNestedInterfaceDependencyProperty>();


            var objs = TestsHelper.ResolveObjects<ISampleClassWithNestedInterfaceDependencyProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = objs.Item1;
            var sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty, sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass, sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentHttpContexts_DifferentObjects_RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyProperty, SampleClassWithClassInConstructorWithNestedInterfaceDependencyProperty>();


            var sampleClass1 = TestsHelper.ResolveObject<ISampleClassWithNestedInterfaceDependencyProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<ISampleClassWithNestedInterfaceDependencyProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty, sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass, sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }
    }
}