using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForInterfaceWithDependencyConstrutorTests
    {
        [TestMethod]
        public void
            RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c
                .RegisterType<ISampleClassWithInterfaceAsParameter,
                    SampleClassWithInterfaceAsParameterWithDependencyConstrutor>()
                .AsPerHttpContext();


            var sampleClass =
                HttpContextTestsHelper.Initialize()
                    .ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);


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
            c
                .RegisterType<ISampleClassWithInterfaceAsParameter,
                    SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>()
                .AsPerHttpContext();


            var sampleClass =
                HttpContextTestsHelper.Initialize()
                    .ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void
            RegisteredInterfaceAsClassWithNestedInterfaceAsParameterWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c
                .RegisterType<ISampleClassWithInterfaceAsParameter,
                    SampleClassWithInterfaceAsParameterWithDependencyConstrutor>()
                .AsPerHttpContext();
            c
                .RegisterType<ISampleClassISampleClassWithInterfaceAsParameter,
                    SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>()
                .AsPerHttpContext();


            var sampleClass =
                HttpContextTestsHelper.Initialize()
                    .ResolveObject<ISampleClassISampleClassWithInterfaceAsParameter>(c,
                        ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter.EmptyClass);
        }
    }
}