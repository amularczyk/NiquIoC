using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.BuildUp
{
    [TestClass]
    public class BuildUpForClassWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisteredClassWithDependencyPropertyWithoutBuildUp_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithClassDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithClassDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithoutDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithoutClassDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();
            var sampleClass = new SampleClassWithManyClassDependencyProperties();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void RegisteredClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            var sampleClass = new SampleClassWithNestedClassDependencyProperty();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }
    }
}