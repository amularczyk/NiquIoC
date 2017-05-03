using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.BuildUp
{
    [TestClass]
    public class BuildUpForClassWithDependencyPropertyTests
    {
        [TestMethod]
        public void ClassWithoutBuildUpWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithClassDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithClassDependencyProperty();


            sampleClass = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithClassDependencyProperty();
            var sampleClass2 = new SampleClassWithClassDependencyProperty();


            var objs = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass1, sampleClass2, ResolveKind.PartialEmitFunction);
            sampleClass1 = objs.Item1;
            sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentHttpContexts_DifferentObjects_BuildUpClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithClassDependencyProperty();
            var sampleClass2 = new SampleClassWithClassDependencyProperty();


            sampleClass1 = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass1, ResolveKind.PartialEmitFunction);
            sampleClass2 = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass2, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithCycleInConstructorWithClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithCycleInConstructorWithClassDependencyProperty(null);


            sampleClass = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException), "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.SampleClassWithCycleInConstructorWithClassDependencyProperty"
            )]
        public void ResolveClassWithCycleInConstructorWithClassDependencyProperty_Failed()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithCycleInConstructorWithClassDependencyProperty>();


            var sampleClass = HttpContextTestsHelper.Initialize().ResolveObject<SampleClassWithCycleInConstructorWithClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void BuildUpClassWithoutDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithoutClassDependencyProperty();


            sampleClass = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithManyClassDependencyProperties();


            sampleClass = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithManyClassDependencyProperties();
            var sampleClass2 = new SampleClassWithManyClassDependencyProperties();


            var objs = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass1, sampleClass2, ResolveKind.PartialEmitFunction);
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
        public void DifferentHttpContexts_DifferentObjects_BuildUpClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithManyClassDependencyProperties();
            var sampleClass2 = new SampleClassWithManyClassDependencyProperties();


            sampleClass1 = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass1, ResolveKind.PartialEmitFunction);
            sampleClass2 = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass2, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void BuildUpClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            var sampleClass = new SampleClassWithNestedClassDependencyProperty();


            sampleClass = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithNestedClassDependencyProperty();
            var sampleClass2 = new SampleClassWithNestedClassDependencyProperty();


            var objs = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass1, sampleClass2, ResolveKind.PartialEmitFunction);
            sampleClass1 = objs.Item1;
            sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyProperty, sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass, sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentHttpContexts_DifferentObjects_BuildUpClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithNestedClassDependencyProperty();
            var sampleClass2 = new SampleClassWithNestedClassDependencyProperty();


            sampleClass1 = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass1, ResolveKind.PartialEmitFunction);
            sampleClass2 = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass2, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyProperty, sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass, sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithDependencyPropertyWithoutSetMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithClassDependencyPropertyWithoutSetMethod();


            sampleClass = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}