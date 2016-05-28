using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.BuildUp
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisteredClassWithDependencyPropertyWithoutBuildUp_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            var sampleClass = new SampleClassWithInterfaceDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            var sampleClass = new SampleClassWithInterfaceDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithoutDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            var sampleClass = new SampleClassWithoutInterfaceDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            var sampleClass = new SampleClassWithManyInterfaceDependencyProperties();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
        }

        [TestMethod]
        public void RegisteredClassWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            var sampleClass = new SampleClassWithNestedInterfaceDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }
    }
}