using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction.MixObjectsLifeTime.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterInterfaceWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisterInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();
            c.RegisterType<ISampleClassWithManyInterfaceDependencyProperties, SampleClassWithManyInterfaceDependencyProperties>();


            var sampleClass = c.Resolve<ISampleClassWithManyInterfaceDependencyProperties>(ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();
            c.RegisterType<ISampleClassWithManyInterfaceDependencyProperties, SampleClassWithManyInterfaceDependencyProperties>();


            var sampleClass1 = c.Resolve<ISampleClassWithManyInterfaceDependencyProperties>(ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<ISampleClassWithManyInterfaceDependencyProperties>(ResolveKind.FullEmitFunction);


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
        public void RegisterInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyProperty, SampleClassWithNestedInterfaceDependencyProperty>();


            var sampleClass = c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyProperty, SampleClassWithNestedInterfaceDependencyProperty>();


            var sampleClass1 = c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<ISampleClassWithNestedInterfaceDependencyProperty>(ResolveKind.FullEmitFunction);
            

            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);

            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty, sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass, sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }
    }
}