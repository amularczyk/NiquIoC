using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.ManyEmitFunctions
{
    [TestClass]
    public class ContainerRegisterTypeWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisterClassWithManyDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClass, SampleClass>();
            c.RegisterType<SampleClassWithManyDependencyProperties>();

            var sampleClass = c.Resolve<SampleClassWithManyDependencyProperties>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.SampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithNestedDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithDependencyProperty, SampleClassWithDependencyProperty>();
            c.RegisterType<SampleClassWithNestedDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithNestedDependencyProperty>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithDependencyPropertyWithoutSetMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithDependencyPropertyWithoutSetMethod>();

            var sampleClass = c.Resolve<SampleClassWithDependencyPropertyWithoutSetMethod>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithManyDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClass, SampleClass>();
            c.RegisterType<ISampleClassWithManyDependencyProperties, SampleClassWithManyDependencyProperties>();

            var sampleClass = c.Resolve<ISampleClassWithManyDependencyProperties>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.SampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithNestedDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithDependencyProperty, SampleClassWithDependencyProperty>();
            c.RegisterType<ISampleClassWithNestedDependencyProperty, SampleClassWithNestedDependencyProperty>();

            var sampleClass = c.Resolve<ISampleClassWithNestedDependencyProperty>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyPropertyWithoutSetMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithDependencyPropertyWithoutSetMethod, SampleClassWithDependencyPropertyWithoutSetMethod>();

            var sampleClass = c.Resolve<ISampleClassWithDependencyPropertyWithoutSetMethod>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyPropertyWithoutSetMethodWithInterface_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithDependencyPropertyWithoutSetMethodWithInterface, SampleClassWithDependencyPropertyWithoutSetMethodWithInterface>();

            var sampleClass = c.Resolve<ISampleClassWithDependencyPropertyWithoutSetMethodWithInterface>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}