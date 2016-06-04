using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
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
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void RegisteredClassWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithoutDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithoutInterfaceDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass = new SampleClassWithManyInterfaceDependencyProperties();

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
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass = new SampleClassWithNestedInterfaceDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }


        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyPropertyWithoutSetMethodWithInterface_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface sampleClass = new SampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}