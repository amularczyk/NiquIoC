﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>();


            var sampleClass = TestsHelper.ResolveObject<SampleClassWithClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>();


            var objs = TestsHelper.ResolveObjects<SampleClassWithClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = objs.Item1;
            var sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_RegisterClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>();


            var sampleClass1 = TestsHelper.ResolveObject<SampleClassWithClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<SampleClassWithClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithoutDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithoutClassDependencyProperty>();


            var sampleClass = TestsHelper.ResolveObject<SampleClassWithoutClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();


            var sampleClass = TestsHelper.ResolveObject<SampleClassWithManyClassDependencyProperties>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();


            var objs = TestsHelper.ResolveObjects<SampleClassWithManyClassDependencyProperties>(c, ResolveKind.PartialEmitFunction);
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
        public void DifferentThreads_DifferentObjects_RegisterClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();


            var sampleClass1 = TestsHelper.ResolveObject<SampleClassWithManyClassDependencyProperties>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<SampleClassWithManyClassDependencyProperties>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void RegisterClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerHttpContext();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();


            var sampleClass = TestsHelper.ResolveObject<SampleClassWithNestedClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerHttpContext();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();


            var objs = TestsHelper.ResolveObjects<SampleClassWithNestedClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = objs.Item1;
            var sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyProperty, sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass, sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_RegisterClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerHttpContext();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();


            var sampleClass1 = TestsHelper.ResolveObject<SampleClassWithNestedClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<SampleClassWithNestedClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);


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
            c.RegisterType<SampleClassWithClassDependencyPropertyWithoutSetMethod>();


            var sampleClass = TestsHelper.ResolveObject<SampleClassWithClassDependencyPropertyWithoutSetMethod>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>();


            var sampleClass = TestsHelper.ResolveObject<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void SameThread_DifferentObjects_RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>();


            var objs = TestsHelper.ResolveObjects<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = objs.Item1;
            var sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyProperty, sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass, sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_DifferentObjects_RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>();


            var sampleClass1 = TestsHelper.ResolveObject<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyProperty, sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass, sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
        }
    }
}