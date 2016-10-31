using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Singleton.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForClassWithDependencyConstrutorWithInterfaceTests
    {
        [TestMethod]
        public void RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>().AsSingleton();

            var sampleClass = c.Resolve<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>().AsSingleton();

            var sampleClass = c.Resolve<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisterClassWithNestedInterfaceAsParameterWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameterWithDependencyConstrutor>().AsSingleton();
            c.RegisterType<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>().AsSingleton();

            var sampleClass = c.Resolve<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter.EmptyClass);
        }
    }
}