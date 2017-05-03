using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForClassWithDependencyConstrutorTests
    {
        [TestMethod]
        public void RegisterClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithDependencyConstrutor>().AsPerHttpContext();


            var sampleClass =
                HttpContextTestsHelper.Initialize().ResolveObject<SampleClassWithDependencyConstrutor>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void RegisterClassWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithTwoDependencyConstrutor>().AsPerHttpContext();


            var sampleClass =
                HttpContextTestsHelper.Initialize().ResolveObject<SampleClassWithTwoDependencyConstrutor>(c, ResolveKind.FullEmitFunction);


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisterClassWithNestedClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithDependencyConstrutor>().AsPerHttpContext();
            c.RegisterType<SampleClassWithNestedClassWithDependencyConstrutor>().AsPerHttpContext();


            var sampleClass =
                HttpContextTestsHelper.Initialize().ResolveObject<SampleClassWithNestedClassWithDependencyConstrutor>(c,
                    ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor.EmptyClass);
        }
    }
}