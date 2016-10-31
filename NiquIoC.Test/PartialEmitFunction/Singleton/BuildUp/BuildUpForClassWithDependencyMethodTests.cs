using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Singleton.BuildUp
{
    [TestClass]
    public class BuildUpForClassWithDependencyMethodTests
    {
        [TestMethod]
        public void ClassWithoutBuildUpWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var sampleClass = new SampleClassWithoutClassDependencyMethod();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var sampleClass = new SampleClassWithClassDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var sampleClass1 = new SampleClassWithClassDependencyMethod();
            var sampleClass2 = new SampleClassWithClassDependencyMethod();

            c.BuildUp(sampleClass1);
            c.BuildUp(sampleClass2);
            
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException), "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.SampleClassWithCycleInConstructorWithClassDependencyMethod")]
        public void ResolveClassWithCycleInConstructorWithClassDependencyMethodAfterBuildUpObjectOfThisClass_Failed()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithCycleInConstructorWithClassDependencyMethod>();
            var sampleClass1 = new SampleClassWithCycleInConstructorWithClassDependencyMethod(null);

            c.BuildUp(sampleClass1);
            var sampleClass2 = c.Resolve<SampleClassWithCycleInConstructorWithClassDependencyMethod>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNull(sampleClass2);
        }

        [TestMethod]
        public void BuildUpClassWithoutDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var sampleClass = new SampleClassWithoutClassDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithDependencyMethodWithReturnType_Failed()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var sampleClass = new SampleClassWithClassDependencyMethodWithReturnType();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            var sampleClass = new SampleClassWithManyClassDependencyMethods();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            var sampleClass1 = new SampleClassWithManyClassDependencyMethods();
            var sampleClass2 = new SampleClassWithManyClassDependencyMethods();

            c.BuildUp(sampleClass1);
            c.BuildUp(sampleClass2);
            
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void BuildUpClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            var sampleClass = new SampleClassWithManyClassParametersInDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            var sampleClass1 = new SampleClassWithManyClassParametersInDependencyMethod();
            var sampleClass2 = new SampleClassWithManyClassParametersInDependencyMethod();

            c.BuildUp(sampleClass1);
            c.BuildUp(sampleClass2);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
        }

        [TestMethod]
        public void BuildUpClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyMethod>();
            var sampleClass = new SampleClassWithNestedClassDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyMethod>().AsSingleton();
            var sampleClass1 = new SampleClassWithNestedClassDependencyMethod();
            var sampleClass2 = new SampleClassWithNestedClassDependencyMethod();

            c.BuildUp(sampleClass1);
            c.BuildUp(sampleClass2);

            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyMethod, sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass, sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);
        }
    }
}