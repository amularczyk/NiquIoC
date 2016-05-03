using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.ManyEmitFunctions
{
    [TestClass]
    public class ContainerBuildUpTests
    {
        [TestMethod]
        public void ClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void ClassWithDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithoutDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void ClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithDependencyMethod();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void ClassWithDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithoutDependencyMethod();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}