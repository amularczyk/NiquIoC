using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction
{
    [TestClass]
    public class RegisterClassWithDependencyMethodTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void RegisteredClassWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithClassDependencyMethod>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyMethod>();
        }

        [TestMethod]
        public void RegisterClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyMethod>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyMethod>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithoutDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithoutClassDependencyMethod>();

            var sampleClass = c.Resolve<SampleClassWithoutClassDependencyMethod>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithDependencyMethodWithReturnType_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyMethodWithReturnType>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyMethodWithReturnType>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();
            c.RegisterType<SampleClassWithManyClassDependencyMethods>();

            var sampleClass = c.Resolve<SampleClassWithManyClassDependencyMethods>();

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void RegisteredClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();
            c.RegisterType<SampleClassWithManyClassParametersInDependencyMethod>();

            var sampleClass = c.Resolve<SampleClassWithManyClassParametersInDependencyMethod>();

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void RegisteredClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyMethod>();
            c.RegisterType<SampleClassWithNestedClassDependencyMethod>();

            var sampleClass = c.Resolve<SampleClassWithNestedClassDependencyMethod>();

            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod.EmptyClass);
        }
    }
}