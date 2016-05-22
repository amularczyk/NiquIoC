using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.ManyEmitFunctions
{
    [TestClass]
    public class ContainerBuildUpTests
    {
        [TestMethod]
        public void RegisteredClassWithDependencyPropertyWithoutBuildUp_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyMethodWithoutBuildUp_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithoutDependencyMethod();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithoutDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithoutDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithDependencyPropertyAndDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
        }
    }
}