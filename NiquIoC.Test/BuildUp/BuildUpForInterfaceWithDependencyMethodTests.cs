using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.BuildUp
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyMethodTests
    {
        [TestMethod]
        public void RegisteredClassWithDependencyMethodWithoutBuildUp_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithoutInterfaceDependencyMethod();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.IEmptyClass has not been registered.")]
        public void RegisteredClassWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithInterfaceDependencyMethod();

            c.BuildUp(sampleClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithInterfaceDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithoutDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithoutInterfaceDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyMethodWithReturnType_Failed()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceMethodWithReturnType sampleClass = new SampleClassWithInterfaceDependencyMethodWithReturnType();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithManyInterfaceDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceDependencyMethods sampleClass = new SampleClassWithManyInterfaceDependencyMethods();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
        }

        [TestMethod]
        public void RegisteredClassWithManyInterfaceParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceParametersInDependencyMethod sampleClass = new SampleClassWithManyInterfaceParametersInDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
        }

        [TestMethod]
        public void RegisteredClassWithNestedInterfaceDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();
            ISampleClassWithNestedInterfaceDependencyMethod sampleClass = new SampleClassWithNestedInterfaceDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyMethod);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyMethod.EmptyClass);
        }
    }
}