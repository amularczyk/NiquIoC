﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Transient.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForInterfaceWithDependencyConstrutorWithClassTests
    {
        [TestMethod]
        public void RegisteredInterfaceAsClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClass, SampleClassWithDependencyConstrutor>();

            var sampleClass = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void RegisteredInterfaceAsClassWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<ISampleClass, SampleClassWithTwoDependencyConstrutor>();

            var sampleClass = c.Resolve<ISampleClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void
            RegisteredInterfaceAsClassWithNestedClassAsParameterWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithDependencyConstrutor>();
            c.RegisterType<ISampleClassWithNestedClass, SampleClassWithNestedClassWithDependencyConstrutor>();

            var sampleClass = c.Resolve<ISampleClassWithNestedClass>(ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor.EmptyClass);
        }
    }
}