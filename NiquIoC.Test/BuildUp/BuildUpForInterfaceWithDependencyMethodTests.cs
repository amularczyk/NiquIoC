using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var sampleClass = new SampleClassWithoutInterfaceDependencyMethod();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            var sampleClass = new SampleClassWithInterfaceDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithoutDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            var sampleClass = new SampleClassWithoutInterfaceDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyMethodWithReturnType_Failed()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            var sampleClass = new SampleClassWithInterfaceDependencyMethodWithReturnType();

            c.BuildUp(sampleClass);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithManyInterfaceDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            var sampleClass = new SampleClassWithManyInterfaceDependencyMethods();

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
            var sampleClass = new SampleClassWithManyInterfaceParametersInDependencyMethod();

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
            var sampleClass = new SampleClassWithNestedInterfaceDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyMethod);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyMethod.EmptyClass);
        }
    }
}