using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.Transient.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyProperty>();

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();

            var sampleClass1 = c.Resolve<SampleClassWithClassDependencyProperty>();
            var sampleClass2 = c.Resolve<SampleClassWithClassDependencyProperty>();

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithoutDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithoutClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithoutClassDependencyProperty>();

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();

            var sampleClass = c.Resolve<SampleClassWithManyClassDependencyProperties>();

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();

            var sampleClass1 = c.Resolve<SampleClassWithManyClassDependencyProperties>();
            var sampleClass2 = c.Resolve<SampleClassWithManyClassDependencyProperties>();

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
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithNestedClassDependencyProperty>();

            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();

            var sampleClass1 = c.Resolve<SampleClassWithNestedClassDependencyProperty>();
            var sampleClass2 = c.Resolve<SampleClassWithNestedClassDependencyProperty>();

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

            var sampleClass = c.Resolve<SampleClassWithClassDependencyPropertyWithoutSetMethod>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            c.RegisterType<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>();

            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithClassInConstructorWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            c.RegisterType<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>();

            var sampleClass1 = c.Resolve<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>();
            var sampleClass2 = c.Resolve<SampleClassWithClassInConstructorWithNestedClassDependencyProperty>();

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