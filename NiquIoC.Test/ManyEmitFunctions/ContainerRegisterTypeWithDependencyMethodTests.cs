using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.ManyEmitFunctions
{
    [TestClass]
    public class ContainerRegisterTypeWithDependencyMethodTests
    {
        [TestMethod]
        public void ClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithMethod, SampleClassWithDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithMethod>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void ClassWithoutDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithMethod, SampleClassWithoutDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithMethod>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void ClassWithDependencyMethodWithReturnType_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithMethodWithReturnType, SampleClassWithDependencyMethodWithReturnType>();

            var sampleClass = c.Resolve<ISampleClassWithMethodWithReturnType>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}