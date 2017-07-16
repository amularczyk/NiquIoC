using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.MixObjectsLifeTime.SingletonAndTransient.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisterClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();


            var sampleClass = c.Resolve<SampleClassWithManyClassDependencyProperties>(ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();


            var sampleClass1 = c.Resolve<SampleClassWithManyClassDependencyProperties>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithManyClassDependencyProperties>(ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass1.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass.EmptyClass, sampleClass1.EmptyClass);

            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.IsNotNull(sampleClass2.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass2.SampleClass.EmptyClass, sampleClass2.EmptyClass);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
            Assert.AreEqual(sampleClass1.SampleClass.EmptyClass, sampleClass2.SampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();


            var sampleClass = c.Resolve<SampleClassWithNestedClassDependencyProperty>(ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();


            var sampleClass1 = c.Resolve<SampleClassWithNestedClassDependencyProperty>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithNestedClassDependencyProperty>(ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass);

            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyProperty,
                sampleClass2.SampleClassWithClassDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyProperty.EmptyClass,
                sampleClass2.SampleClassWithClassDependencyProperty.EmptyClass);
        }
    }
}