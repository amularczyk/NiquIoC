using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Interfaces;

namespace NiquIoC.Test
{
    [TestClass]
    public class ContainerBuildUpTests
    {
        [TestMethod]
        public void ClassWithDependencyProperty_Success()
        {
            IContainer c = new Container();
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
            IContainer c = new Container();
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
            IContainer c = new Container();
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
            IContainer c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithoutDependencyMethod();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}