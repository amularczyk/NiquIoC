using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.BuildUp
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyPropertyTests
    {
        [TestMethod]
        public void InterfaceWithoutBuildUpWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceProperty sampleClass1 = new SampleClassWithInterfaceDependencyProperty();
            ISampleClassWithInterfaceProperty sampleClass2 = new SampleClassWithInterfaceDependencyProperty();


            var objs = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, sampleClass2, ResolveKind.PartialEmitFunction);
            sampleClass1 = objs.Item1;
            sampleClass2 = objs.Item2;


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
            ISampleClassWithInterfaceProperty sampleClass1 = new SampleClassWithInterfaceDependencyProperty();
            ISampleClassWithInterfaceProperty sampleClass2 = new SampleClassWithInterfaceDependencyProperty();


            sampleClass1 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, ResolveKind.PartialEmitFunction);
            sampleClass2 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass2, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithCycleInConstructorWithClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithCycleInConstructorWithInterfaceDependencyProperty(null);


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException),
            "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.SampleClassWithCycleInConstructorWithInterfaceDependencyProperty")]
        public void ResolveInterfaceWithCycleInConstructorWithClassDependencyMethod_Failed()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c
                .RegisterType<ISampleClassWithInterfaceProperty,
                    SampleClassWithCycleInConstructorWithInterfaceDependencyProperty>();


            var sampleClass = HttpContextTestsHelper.Initialize()
                .ResolveObject<ISampleClassWithInterfaceProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithoutDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithoutInterfaceDependencyProperty();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass =
                new SampleClassWithManyInterfaceDependencyProperties();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>()
                .AsPerHttpContext();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass1 =
                new SampleClassWithManyInterfaceDependencyProperties();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass2 =
                new SampleClassWithManyInterfaceDependencyProperties();


            var objs = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, sampleClass2, ResolveKind.PartialEmitFunction);
            sampleClass1 = objs.Item1;
            sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void
            DifferentHttpContexts_DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>()
                .AsPerHttpContext();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass1 =
                new SampleClassWithManyInterfaceDependencyProperties();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass2 =
                new SampleClassWithManyInterfaceDependencyProperties();


            sampleClass1 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, ResolveKind.PartialEmitFunction);
            sampleClass2 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass2, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass =
                new SampleClassWithNestedInterfaceDependencyProperty();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>()
                .AsPerHttpContext();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass1 =
                new SampleClassWithNestedInterfaceDependencyProperty();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass2 =
                new SampleClassWithNestedInterfaceDependencyProperty();


            var objs = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, sampleClass2, ResolveKind.PartialEmitFunction);
            sampleClass1 = objs.Item1;
            sampleClass2 = objs.Item2;


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
            DifferentHttpContexts_DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>()
                .AsPerHttpContext();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass1 =
                new SampleClassWithNestedInterfaceDependencyProperty();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass2 =
                new SampleClassWithNestedInterfaceDependencyProperty();


            sampleClass1 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, ResolveKind.PartialEmitFunction);
            sampleClass2 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass2, ResolveKind.PartialEmitFunction);


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
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface sampleClass =
                new SampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}