using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;

namespace NiquIoC.Test
{
    [TestClass]
    public class ContainerTests
    {
        private IContainer GetContainer()
        {
            return new Container();
        }

        [TestMethod]
        public void RegisterInstance_Class_Success()
        {
            IContainer c = GetContainer();
            var emptyClass = new EmptyClass();
            ISampleClass sampleClass1 = new SampleClass(emptyClass);

            c.RegisterInstance(sampleClass1);
            var sampleClass2 = c.Resolve<ISampleClass>();

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof (TypeNotRegisteredException))]
        public void Resolve_ClassNotRegistered_Fail()
        {
            IContainer c = GetContainer();

            var sampleClass = c.Resolve<EmptyClass>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void Resolve_ClassWithConstructorWithoutParametersRegistered_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(false);

            var sampleClass = c.Resolve<EmptyClass>();

            Assert.IsNotNull(sampleClass);
        }

        [TestMethod]
        public void Resolve_ClassWithManyDependencyProperties_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(false);
            c.RegisterType<ISampleClass, SampleClass>(false);
            c.RegisterType<ISampleClassWithManyDependencyProperties, SampleClassWithManyDependencyProperties>(false);

            var sampleClass = c.Resolve<ISampleClassWithManyDependencyProperties>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.SampleClass.EmptyClass);
        }

        [TestMethod]
        public void Resolve_ClassWithNestedDependencyProperty_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(false);
            c.RegisterType<ISampleClassWithDependencyProperty, SampleClassWithDependencyProperty>(false);
            c.RegisterType<ISampleClassWithNestedDependencyProperty, SampleClassWithNestedDependencyProperty>(false);

            var sampleClass = c.Resolve<ISampleClassWithNestedDependencyProperty>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void Resolve_ClassWithDependencyPropertyWithoutSetMethod_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(false);
            c.RegisterType<ISampleClassWithDependencyPropertyWithoutSetMethod, SampleClassWithDependencyPropertyWithoutSetMethod>(false);

            var sampleClass = c.Resolve<ISampleClassWithDependencyPropertyWithoutSetMethod>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void Resolve_ClassWithConstructorWithParameter_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(false);
            c.RegisterType<SampleClass>(false);

            var sampleClass = c.Resolve<SampleClass>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof (TypeNotRegisteredException))]
        public void Resolve_MissingRegistration_Fail()
        {
            IContainer c = GetContainer();
            c.RegisterType<SampleClass>(false);

            var sampleClass = c.Resolve<SampleClass>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void Resolve_ClassWithConstructorWithSimpleType_Success()
        {
            IContainer c = GetContainer();
            const string text = "Text";
            c.RegisterInstance(text);
            c.RegisterType<SampleClassWithSimpleType>(false);

            var sampleClassWithSimpleType = c.Resolve<SampleClassWithSimpleType>();

            Assert.IsNotNull(sampleClassWithSimpleType);
            Assert.IsNotNull(sampleClassWithSimpleType.Text);
            Assert.AreEqual(sampleClassWithSimpleType.Text, text);
        }

        [TestMethod]
        [ExpectedException(typeof (TypeNotRegisteredException))]
        public void Resolve_MissingRegistrationOfSimpleType_Fail()
        {
            IContainer c = GetContainer();
            c.RegisterType<SampleClassWithSimpleType>(false);

            var sampleClass = c.Resolve<SampleClassWithSimpleType>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void Resolve_ClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(false);
            c.RegisterType<SampleClassWithDependencyConstrutor>(false);

            var sampleClass = c.Resolve<SampleClassWithDependencyConstrutor>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof (NoProperConstructorException))]
        public void Resolve_ClassWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(false);
            c.RegisterType<SampleClassWithTwoDependencyConstrutor>(false);

            var sampleClass = c.Resolve<SampleClassWithTwoDependencyConstrutor>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof (CycleForTypeException))]
        public void Resolve_ClassWithCycleInConstructor_Fail()
        {
            IContainer c = GetContainer();
            c.RegisterType<SecondClassWithCycleInConstructor>(false);
            c.RegisterType<FirstClassWithCycleInConstructor>(false);

            var sampleClass = c.Resolve<FirstClassWithCycleInConstructor>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void Resolve_ClassRegisteredAsNotSingleton_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(false);
            c.RegisterType<SampleClass>(false);

            var sampleClass1 = c.Resolve<SampleClass>();
            var sampleClass2 = c.Resolve<SampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void Resolve_ClassRegisteredAsSingleton_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<SampleClass>(true);
            c.RegisterType<EmptyClass>(true);

            var sampleClass1 = c.Resolve<SampleClass>();
            var sampleClass2 = c.Resolve<SampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void Resolve_ClassReRegistered_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(true);
            c.RegisterType<SampleClass>(true);

            var sampleClass1 = c.Resolve<SampleClass>();
            c.RegisterType<SampleClass>(true);
            var sampleClass2 = c.Resolve<SampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void Resolve_InterfaceRegisteredAsNotSingleton_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(false);
            c.RegisterType<ISampleClass, SampleClass>(false);

            var sampleClass1 = c.Resolve<ISampleClass>();
            var sampleClass2 = c.Resolve<ISampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void Resolve_InterfaceRegisteredAsSingleton_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(true);
            c.RegisterType<ISampleClass, SampleClass>(true);

            var sampleClass1 = c.Resolve<ISampleClass>();
            var sampleClass2 = c.Resolve<ISampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void Resolve_InterfaceReRegistered_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(true);
            c.RegisterType<ISampleClass, SampleClass>(true);

            var sampleClass1 = c.Resolve<ISampleClass>();
            c.RegisterType<ISampleClass, SampleClass>(true);
            var sampleClass2 = c.Resolve<ISampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void BuildUp_DependencyProperty_Success()
        {
            IContainer c = GetContainer();
            c.RegisterType<EmptyClass>(false);
            var sampleClass = new SampleClassWithDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }
    }
}