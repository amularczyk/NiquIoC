using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction
{
    [TestClass]
    public class RegisterInterfaceWithDependencyMethodTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.IEmptyClass has not been registered.")]
        public void RegisteredClassWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceMethod>(Enums.ResolveKind.FullEmitFunction);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceMethod>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithoutDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithoutInterfaceDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceMethod>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyMethodWithReturnType_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceMethodWithReturnType, SampleClassWithInterfaceDependencyMethodWithReturnType>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceMethodWithReturnType>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithManyInterfaceDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c.RegisterType<ISampleClassWithManyInterfaceDependencyMethods, SampleClassWithManyInterfaceDependencyMethods>();

            var sampleClass = c.Resolve<ISampleClassWithManyInterfaceDependencyMethods>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithManyInterfaceParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c.RegisterType<ISampleClassWithManyInterfaceParametersInDependencyMethod, SampleClassWithManyInterfaceParametersInDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithManyInterfaceParametersInDependencyMethod>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithNestedInterfaceDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();
            c.RegisterType<ISampleClassWithNestedInterfaceDependencyMethod, SampleClassWithNestedInterfaceDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithNestedInterfaceDependencyMethod>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyMethod);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyMethod.EmptyClass);
        }
    }
}