﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.Singleton
{
    [TestClass]
    public class RegisterTypeForClassWithInterfaceTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void InternalInterfaceNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithInterfaceAsParameter>().AsSingleton();

            var sampleClass = c.Resolve<SampleClassWithInterfaceAsParameter>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisteredInterfaceAsClassWithConstructorWithInterfaceAsParameter_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithInterfaceAsParameter>().AsSingleton();

            var sampleClass = c.Resolve<SampleClassWithInterfaceAsParameter>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException), "Appeared cycle when resolving constructor for object of type NiquIoC.Test.ClassDefinitions.FirstClassWithCycleInConstructorInRegisteredType")]
        public void RegisteredInterfaceAsClassWithCycleInConstructor_Fail()
        {
            var c = new Container();
            c.RegisterType<ISecondClassWithCycleInConstructor, SecondClassWithCycleInConstructorInRegisteredType>().AsSingleton();
            c.RegisterType<IFirstClassWithCycleInConstructor, FirstClassWithCycleInConstructorInRegisteredType>().AsSingleton();
            c.RegisterType<InterfaceWithCycleInConstructorInRegisteredType>().AsSingleton();

            var sampleClass = c.Resolve<InterfaceWithCycleInConstructorInRegisteredType>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void SameObjects_RegisteredClassWithInterface_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithInterfaceAsParameter>().AsSingleton();

            var sampleClass1 = c.Resolve<SampleClassWithInterfaceAsParameter>();
            var sampleClass2 = c.Resolve<SampleClassWithInterfaceAsParameter>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}