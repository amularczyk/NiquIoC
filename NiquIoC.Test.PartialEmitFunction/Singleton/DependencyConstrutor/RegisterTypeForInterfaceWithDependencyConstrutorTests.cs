using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Singleton.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForInterfaceWithDependencyConstrutorTests
    {
        [TestMethod]
        public void
            RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c
                .RegisterType<ISampleClassWithInterfaceAsParameter,
                    SampleClassWithInterfaceAsParameterWithDependencyConstrutor>()
                .AsSingleton();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void
            RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c
                .RegisterType<ISampleClassWithInterfaceAsParameter,
                    SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>()
                .AsSingleton();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void
            RegisteredInterfaceAsClassWithNestedInterfaceAsParameterWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c
                .RegisterType<ISampleClassWithInterfaceAsParameter,
                    SampleClassWithInterfaceAsParameterWithDependencyConstrutor>()
                .AsSingleton();
            c
                .RegisterType<ISampleClassISampleClassWithInterfaceAsParameter,
                    SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>()
                .AsSingleton();

            var sampleClass =
                c.Resolve<ISampleClassISampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter.EmptyClass);
        }
    }
}