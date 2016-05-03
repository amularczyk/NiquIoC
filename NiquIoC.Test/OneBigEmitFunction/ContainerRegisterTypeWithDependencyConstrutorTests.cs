using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.OneBigEmitFunction
{
    [TestClass]
    public class ContainerRegisterTypeWithDependencyConstrutorTests
    {
        [TestMethod]
        public void ClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithDependencyConstrutor>();

            var sampleClass = c.Resolve2<SampleClassWithDependencyConstrutor>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void ClassWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithTwoDependencyConstrutor>();

            var sampleClass = c.Resolve2<SampleClassWithTwoDependencyConstrutor>();

            Assert.IsNull(sampleClass);
        }
    }
}