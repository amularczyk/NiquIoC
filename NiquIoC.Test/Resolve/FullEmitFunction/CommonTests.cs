﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction
{
    [TestClass]
    public class CommonTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void ClassNotRegistered_Fail()
        {
            var c = new Container();

            var sampleClass = c.Resolve<EmptyClass>(ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.IEmptyClass has not been registered.")]
        public void InterfaceNotRegistered_Fail()
        {
            var c = new Container();

            var sampleClass = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongInterfaceRegistrationException), "For interface type NiquIoC.Test.ClassDefinitions.IEmptyClass you must specify a class which implements it.")]
        public void MissingClassThatImplementsInterfaceInRegister_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>();
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void BuildUpClassWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            var sampleClass = new SampleClassWithClassDependencyMethod();

            c.BuildUp(sampleClass, ResolveKind.FullEmitFunction);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void BuildUpClassWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            var sampleClass = new SampleClassWithClassDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.IEmptyClass has not been registered.")]
        public void BuildUpInterfaceWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithInterfaceDependencyMethod();

            c.BuildUp(sampleClass, ResolveKind.FullEmitFunction);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void BuildUpInterfaceWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            c.BuildUp(sampleClass, ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void RegisteredClassWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithClassDependencyMethod>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyMethod>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void RegisteredClassWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyProperty>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.IEmptyClass has not been registered.")]
        public void RegisteredInterfaceWithDependencyMethodWithoutRegisteredNestedClass_Failed()
        {
            var c = new Container();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceMethod>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void RegisteredInterfaceWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }
    }
}