﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction.Transient.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForInterfaceWithDependencyConstrutorTests
    {
        [TestMethod]
        public void RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameterWithDependencyConstrutor>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceAsParameter>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceAsParameter>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisteredInterfaceAsClassWithNestedInterfaceAsParameterWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameterWithDependencyConstrutor>();
            c.RegisterType<ISampleClassISampleClassWithInterfaceAsParameter, SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>();

            var sampleClass = c.Resolve<ISampleClassISampleClassWithInterfaceAsParameter>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter.EmptyClass);
        }
    }
}