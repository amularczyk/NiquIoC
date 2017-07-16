using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

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


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithClassDependencyMethod();
            var sampleClass2 = new SampleClassWithClassDependencyMethod();


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
        public void DifferentHttpContexts_DifferentObjects_BuildUpClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithClassDependencyMethod();
            var sampleClass2 = new SampleClassWithClassDependencyMethod();


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
        public void BuildUpClassWithCycleInConstructorWithClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithCycleInConstructorWithClassDependencyMethod(null);


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException),
            "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.SampleClassWithCycleInConstructorWithClassDependencyMethod")]
        public void ResolveClassWithCycleInConstructorWithClassDependencyMethod_Failed()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithCycleInConstructorWithClassDependencyMethod>();


            var sampleClass = HttpContextTestsHelper.Initialize()
                .ResolveObject<SampleClassWithCycleInConstructorWithClassDependencyMethod>(c,
                    ResolveKind.PartialEmitFunction);


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void BuildUpClassWithoutDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithoutClassDependencyMethod();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithDependencyMethodWithReturnType_Failed()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithClassDependencyMethodWithReturnType();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithManyClassDependencyMethods();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithManyClassDependencyMethods();
            var sampleClass2 = new SampleClassWithManyClassDependencyMethods();


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
        public void DifferentHttpContexts_DifferentObjects_BuildUpClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithManyClassDependencyMethods();
            var sampleClass2 = new SampleClassWithManyClassDependencyMethods();


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
        public void BuildUpClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithManyClassParametersInDependencyMethod();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithManyClassParametersInDependencyMethod();
            var sampleClass2 = new SampleClassWithManyClassParametersInDependencyMethod();


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
            DifferentHttpContexts_DifferentObjects_BuildUpClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithManyClassParametersInDependencyMethod();
            var sampleClass2 = new SampleClassWithManyClassParametersInDependencyMethod();


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
        public void BuildUpClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>();
            var sampleClass = new SampleClassWithNestedClassDependencyMethod();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod.EmptyClass);
        }

        [TestMethod]
        public void SameHttpContext_DifferentObjects_BuildUpClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithNestedClassDependencyMethod();
            var sampleClass2 = new SampleClassWithNestedClassDependencyMethod();


            var objs = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, sampleClass2, ResolveKind.PartialEmitFunction);
            sampleClass1 = objs.Item1;
            sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyMethod,
                sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass,
                sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);
        }

        [TestMethod]
        public void DifferentHttpContexts_DifferentObjects_BuildUpClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>().AsPerHttpContext();
            var sampleClass1 = new SampleClassWithNestedClassDependencyMethod();
            var sampleClass2 = new SampleClassWithNestedClassDependencyMethod();


            sampleClass1 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass1, ResolveKind.PartialEmitFunction);
            sampleClass2 = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass2, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyMethod,
                sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass,
                sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);
        }
    }
}