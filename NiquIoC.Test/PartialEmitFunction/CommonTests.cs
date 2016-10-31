using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction
{
    [TestClass]
    public class CommonTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void ClassNotRegistered_Fail()
        {
            var c = new Container();

            var sampleClass = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.IEmptyClass has not been registered.")]
        public void InterfaceNotRegistered_Fail()
        {
            var c = new Container();

            var sampleClass = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongInterfaceRegistrationException), "For interface type NiquIoC.Test.Model.IEmptyClass you must specify a class which implements it.")]
        public void MissingClassThatImplementsInterfaceInRegister_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>();
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void BuildUpClassWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            var sampleClass = new SampleClassWithClassDependencyMethod();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void BuildUpClassWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            var sampleClass = new SampleClassWithClassDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.IEmptyClass has not been registered.")]
        public void BuildUpInterfaceWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithInterfaceDependencyMethod();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void BuildUpInterfaceWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void RegisterClassWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithClassDependencyMethod>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyMethod>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void RegisterClassWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyProperty>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.IEmptyClass has not been registered.")]
        public void RegisteredInterfaceWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceMethod>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void RegisteredInterfaceWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }
    }
}