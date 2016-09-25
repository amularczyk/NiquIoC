﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction.Transient
{
    [TestClass]
    public class RegisterClassWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisteredClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyProperty>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();

            var sampleClass1 = c.Resolve<SampleClassWithClassDependencyProperty>(ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithClassDependencyProperty>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithoutDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithoutClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithoutClassDependencyProperty>(ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();

            var sampleClass = c.Resolve<SampleClassWithManyClassDependencyProperties>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();

            var sampleClass1 = c.Resolve<SampleClassWithManyClassDependencyProperties>(ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithManyClassDependencyProperties>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void RegisteredClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithNestedClassDependencyProperty>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();

            var sampleClass1 = c.Resolve<SampleClassWithNestedClassDependencyProperty>(ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithNestedClassDependencyProperty>(ResolveKind.FullEmitFunction);

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
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyPropertyWithoutSetMethod>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyPropertyWithoutSetMethod>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}