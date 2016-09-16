using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.Transient
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyPropertyTests
    {
        [TestMethod]
        public void InterfaceWithoutBuildUpWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceProperty sampleClass1 = new SampleClassWithInterfaceDependencyProperty();
            ISampleClassWithInterfaceProperty sampleClass2 = new SampleClassWithInterfaceDependencyProperty();

            c.BuildUp(sampleClass1);
            c.BuildUp(sampleClass2);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithoutDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithoutInterfaceDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
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
        public void DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass1 = new SampleClassWithManyInterfaceDependencyProperties();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass2 = new SampleClassWithManyInterfaceDependencyProperties();

            c.BuildUp(sampleClass1);
            c.BuildUp(sampleClass2);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceAsParameter);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceAsParameter, sampleClass2.SampleClassWithInterfaceAsParameter);
        }

        [TestMethod]
        public void BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
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
        public void DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass1 = new SampleClassWithNestedInterfaceDependencyProperty();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass2 = new SampleClassWithNestedInterfaceDependencyProperty();

            c.BuildUp(sampleClass1);
            c.BuildUp(sampleClass2);
            
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty, sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass, sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
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