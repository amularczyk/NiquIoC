using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Transient.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForClassWithDependencyConstrutorWithInterfaceTests
    {
        [TestMethod]
        public void
            RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>();

            var sampleClass =
                c.Resolve<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void
            RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>();

            var sampleClass =
                c.Resolve<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>(ResolveKind
                    .PartialEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void
            RegisterClassWithNestedInterfaceAsParameterWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c
                .RegisterType<ISampleClassWithInterfaceAsParameter,
                    SampleClassWithInterfaceAsParameterWithDependencyConstrutor>();
            c.RegisterType<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>();

            var sampleClass =
                c.Resolve<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>(ResolveKind
                    .PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter.EmptyClass);
        }
    }
}