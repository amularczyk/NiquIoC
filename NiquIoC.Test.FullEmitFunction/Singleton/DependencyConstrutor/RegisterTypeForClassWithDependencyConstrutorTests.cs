using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.Singleton.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForClassWithDependencyConstrutorTests
    {
        [TestMethod]
        public void RegisterClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithDependencyConstrutor>().AsSingleton();

            var sampleClass = c.Resolve<SampleClassWithDependencyConstrutor>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void RegisterClassWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithTwoDependencyConstrutor>().AsSingleton();

            var sampleClass = c.Resolve<SampleClassWithTwoDependencyConstrutor>(ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisterClassWithNestedClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithDependencyConstrutor>().AsSingleton();
            c.RegisterType<SampleClassWithNestedClassWithDependencyConstrutor>().AsSingleton();

            var sampleClass =
                c.Resolve<SampleClassWithNestedClassWithDependencyConstrutor>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor.EmptyClass);
        }
    }
}