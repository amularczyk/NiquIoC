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
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void ClassNotRegistered_Fail()
        {
            var c = new Container();

            var sampleClass = c.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.IEmptyClass has not been registered.")]
        public void InterfaceNotRegistered_Fail()
        {
            var c = new Container();

            var sampleClass = c.Resolve<IEmptyClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongInterfaceRegistrationException),
            "For interface type NiquIoC.Test.Model.IEmptyClass you must specify a class which implements it.")]
        public void MissingClassThatImplementsInterfaceInRegister_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>();
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void BuildUpClassWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            var sampleClass = new SampleClassWithClassDependencyMethod();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void BuildUpClassWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            var sampleClass = new SampleClassWithClassDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.IEmptyClass has not been registered.")]
        public void BuildUpInterfaceWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithInterfaceDependencyMethod();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void BuildUpInterfaceWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void RegisterClassWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithClassDependencyMethod>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyMethod>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void RegisterClassWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyProperty>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.IEmptyClass has not been registered.")]
        public void RegisteredInterfaceWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceMethod>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void RegisteredInterfaceWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void Resolve_Without_Parameter_When_Container_With_ResolveKind_Success()
        {
            var c = new Container(ResolveKind.PartialEmitFunction);
            c.RegisterType<EmptyClass>();

            var emptyClass = c.Resolve<EmptyClass>();

            Assert.IsNotNull(emptyClass);
        }

        [TestMethod]
        public void BuildUp_Without_Parameter_When_Container_With_ResolveKind_Success()
        {
            var c = new Container(ResolveKind.PartialEmitFunction);
            var emptyClass = new EmptyClass();

            c.BuildUp(emptyClass);

            Assert.IsNotNull(emptyClass);
        }

        [TestMethod]
        public void Resolve_With_Type_As_Parameter_And_Register_With_Type_As_Parameter_Success()
        {
            var c = new Container(ResolveKind.PartialEmitFunction);
            c.RegisterType(typeof(EmptyClass));

            var emptyClass = c.Resolve(typeof(EmptyClass));

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is EmptyClass);
        }

        [TestMethod]
        public void Resolve_With_Type_And_ResolveKind_As_Parameter_And_Register_With_Type_As_Parameter_Success()
        {
            var c = new Container();
            c.RegisterType(typeof(EmptyClass));

            var emptyClass = c.Resolve(typeof(EmptyClass), ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is EmptyClass);
        }

        [TestMethod]
        public void Resolve_With_Type_As_Parameter_And_Register_With_TypeFrom_And_TypeTo_As_Parameter_Success()
        {
            var c = new Container(ResolveKind.PartialEmitFunction);
            c.RegisterType(typeof(IEmptyClass), typeof(EmptyClass));

            var emptyClass = c.Resolve(typeof(IEmptyClass));

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is IEmptyClass);
        }

        [TestMethod]
        public void
            Resolve_With_Type_And_ResolveKind_As_Parameter_And_Register_With_TypeFrom_And_TypeTo_As_Parameter_Success()
        {
            var c = new Container(ResolveKind.PartialEmitFunction);
            c.RegisterType(typeof(IEmptyClass), typeof(EmptyClass));

            var emptyClass = c.Resolve(typeof(IEmptyClass), ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is IEmptyClass);
        }

        [TestMethod]
        public void Resolve_With_Type_As_Parameter_And_Register_Object_Factory_With_Type_As_Parameter_Success()
        {
            var c = new Container(ResolveKind.PartialEmitFunction);
            c.RegisterType(typeof(EmptyClass), container => new EmptyClass());

            var emptyClass = c.Resolve(typeof(EmptyClass));

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is EmptyClass);
        }

        [TestMethod]
        public void
            Resolve_With_Type_And_ResolveKind_As_Parameter_And_Register_Object_Factory_With_Type_As_Parameter_Success()
        {
            var c = new Container();
            c.RegisterType(typeof(EmptyClass), container => new EmptyClass());

            var emptyClass = c.Resolve(typeof(EmptyClass), ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(emptyClass);
            Assert.IsTrue(emptyClass is EmptyClass);
        }

        [TestMethod]
        public void
            Resolve_With_Type_As_Parameter_And_Register_Object_Factory_With_Type_As_Parameter_Using_Container_Success()
        {
            var c = new Container(ResolveKind.PartialEmitFunction);
            c.RegisterType<EmptyClass>();
            c.RegisterType(typeof(SampleClass), container => new SampleClass(container.Resolve<EmptyClass>()));

            var sampleClass = c.Resolve(typeof(SampleClass));

            Assert.IsNotNull(sampleClass);
            Assert.IsTrue(sampleClass is SampleClass);
            Assert.IsNotNull((sampleClass as SampleClass).EmptyClass);
        }

        [TestMethod]
        public void
            Resolve_With_Type_And_ResolveKind_As_Parameter_And_Register_Object_Factory_With_Type_As_Parameter_Using_Container_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType(typeof(SampleClass), container => new SampleClass(container.Resolve<EmptyClass>(ResolveKind.PartialEmitFunction)));

            var sampleClass = c.Resolve(typeof(SampleClass), ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsTrue(sampleClass is SampleClass);
            Assert.IsNotNull((sampleClass as SampleClass).EmptyClass);
        }
    }
}