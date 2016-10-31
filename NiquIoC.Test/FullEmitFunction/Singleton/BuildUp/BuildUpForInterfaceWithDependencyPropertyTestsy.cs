using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.Singleton.BuildUp
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyPropertyTests
    {
        [TestMethod]
        public void InterfaceWithoutBuildUpWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpInterfaceWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            ISampleClassWithInterfaceProperty sampleClass1 = new SampleClassWithInterfaceDependencyProperty();
            ISampleClassWithInterfaceProperty sampleClass2 = new SampleClassWithInterfaceDependencyProperty();

            c.BuildUp(sampleClass1, ResolveKind.FullEmitFunction);
            c.BuildUp(sampleClass2, ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException), "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.SampleClassWithCycleInConstructorWithInterfaceDependencyProperty")]
        public void ResolveInterfaceWithCycleInConstructorWithClassDependencyMethodAfterBuildUpObjectOfThisInterface_Failed()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithCycleInConstructorWithInterfaceDependencyProperty>();
            ISampleClassWithInterfaceProperty sampleClass1 = new SampleClassWithCycleInConstructorWithInterfaceDependencyProperty(null);

            c.BuildUp(sampleClass1, ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithCycleInConstructorWithInterfaceDependencyProperty>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNull(sampleClass2);
        }

        [TestMethod]
        public void BuildUpInterfaceWithoutDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithoutInterfaceDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass = new SampleClassWithManyInterfaceDependencyProperties();

            c.BuildUp(sampleClass, ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass1 = new SampleClassWithManyInterfaceDependencyProperties();
            ISampleClassWithManyInterfaceDependencyProperties sampleClass2 = new SampleClassWithManyInterfaceDependencyProperties();

            c.BuildUp(sampleClass1, ResolveKind.FullEmitFunction);
            c.BuildUp(sampleClass2, ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass = new SampleClassWithNestedInterfaceDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>().AsSingleton();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass1 = new SampleClassWithNestedInterfaceDependencyProperty();
            ISampleClassWithNestedInterfaceDependencyProperty sampleClass2 = new SampleClassWithNestedInterfaceDependencyProperty();

            c.BuildUp(sampleClass1, ResolveKind.FullEmitFunction);
            c.BuildUp(sampleClass2, ResolveKind.FullEmitFunction);
            
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty, sampleClass2.SampleClassWithInterfaceDependencyProperty);
            Assert.AreEqual(sampleClass1.SampleClassWithInterfaceDependencyProperty.EmptyClass, sampleClass2.SampleClassWithInterfaceDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyPropertyWithoutSetMethodWithInterface_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            ISampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface sampleClass = new SampleClassWithClassDependencyPropertyWithoutSetMethodWithInterface();

            c.BuildUp(sampleClass, ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}