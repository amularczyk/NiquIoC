using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Interfaces;

namespace NiquIoC.Test
{
    [TestClass]
    public class ContainerRegisterTypeWithDependencyConstrutorTests
    {
        [TestMethod]
        public void ClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            IContainer c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithDependencyConstrutor>();

            var sampleClass = c.Resolve<SampleClassWithDependencyConstrutor>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof (NoProperConstructorException))]
        public void ClassWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            IContainer c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithTwoDependencyConstrutor>();

            var sampleClass = c.Resolve<SampleClassWithTwoDependencyConstrutor>();

            Assert.IsNull(sampleClass);
        }
    }
}