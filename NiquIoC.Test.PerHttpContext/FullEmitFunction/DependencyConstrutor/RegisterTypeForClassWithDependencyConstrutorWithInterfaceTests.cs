using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForClassWithDependencyConstrutorWithInterfaceTests
    {
        [TestMethod]
        public void
            RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>().AsPerHttpContext();


            var sampleClass =
                TestsHelper.ResolveObject<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>(c,
                    ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void
            RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>().AsPerHttpContext();


            var sampleClass =
                TestsHelper.ResolveObject<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>(c,
                    ResolveKind.FullEmitFunction);


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void
            RegisterClassWithNestedInterfaceAsParameterWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c
                .RegisterType<ISampleClassWithInterfaceAsParameter,
                    SampleClassWithInterfaceAsParameterWithDependencyConstrutor>()
                .AsPerHttpContext();
            c.RegisterType<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>().AsPerHttpContext();


            var sampleClass =
                TestsHelper.ResolveObject<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>(c,
                    ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter.EmptyClass);
        }
    }
}