using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Interfaces;

namespace NiquIoC.Test
{
    [TestClass]
    public class ContainerRegisterTypeWithDependencyPropertyTests
    {
        [TestMethod]
        public void ClassWithManyDependencyProperties_Success()
        {
            IContainer c = new Container();
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
        public void ClassWithNestedDependencyProperty_Success()
        {
            IContainer c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithDependencyProperty, SampleClassWithDependencyProperty>();
            c.RegisterType<ISampleClassWithNestedDependencyProperty, SampleClassWithNestedDependencyProperty>();

            var sampleClass = c.Resolve<ISampleClassWithNestedDependencyProperty>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void ClassWithDependencyPropertyWithoutSetMethod_Success()
        {
            IContainer c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithDependencyPropertyWithoutSetMethod, SampleClassWithDependencyPropertyWithoutSetMethod>();

            var sampleClass = c.Resolve<ISampleClassWithDependencyPropertyWithoutSetMethod>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}