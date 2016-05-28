using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.ManyEmitFunctions
{
    [TestClass]
    public class RegisterTypeWithDependencyMethodTests
    {
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
        public void RegisterInterfaceAsClassWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithClassMethod, SampleClassWithClassDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithClassMethod>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithoutDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithClassMethod, SampleClassWithoutClassDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithClassMethod>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyMethodWithReturnType_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithClassMethodWithReturnType, SampleClassWithClassDependencyMethodWithReturnType>();

            var sampleClass = c.Resolve<ISampleClassWithClassMethodWithReturnType>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }


        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyMethodWithInterface_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithClassMethodWithInterface, SampleClassWithClassDependencyMethodWithInterface>();

            var sampleClass = c.Resolve<ISampleClassWithClassMethodWithInterface>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithoutDependencyMethodWithInterface_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClassWithClassMethodWithInterface, SampleClassWithoutClassDependencyMethodWithInterface>();

            var sampleClass = c.Resolve<ISampleClassWithClassMethodWithInterface>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyMethodWithInterfaceWithReturnType_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithClassMethodWithInterfaceWithReturnType, SampleClassWithClassDependencyMethodWithInterfaceWithReturnType>();

            var sampleClass = c.Resolve<ISampleClassWithClassMethodWithInterfaceWithReturnType>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}