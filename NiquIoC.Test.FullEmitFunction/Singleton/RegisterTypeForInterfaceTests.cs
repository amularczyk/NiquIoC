using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.Singleton
{
    [TestClass]
    public class RegisterTypeForInterfaceTests
    {
        [TestMethod]
        public void RegisteredInterfaceAsClassWithConstructorWithoutParameters_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();

            var sampleClass = c.Resolve<IEmptyClass>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void InternalInterfaceNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type System.String has not been registered.")]
        public void InternalStringTypeNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<ISampleClassWithStringType, SampleClassWithStringType>().AsSingleton();

            var sampleClassWithSimpleType = c.Resolve<ISampleClassWithStringType>(ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClassWithSimpleType);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type System.Int32 has not been registered.")]
        public void InternalIntTypeNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<ISampleClassWithIntType, SampleClassWithIntType>().AsSingleton();

            var sampleClassWithSimpleType = c.Resolve<ISampleClassWithIntType>(ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClassWithSimpleType);
        }

        [TestMethod]
        public void RegisteredInterfaceAsClassWithConstructorWithInterfaceAsParameter_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException),
            "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.FirstClassWithCycleInConstructorInRegisteredType")]
        public void RegisteredInterfaceAsClassWithCycleInConstructor_Fail()
        {
            var c = new Container();
            c.RegisterType<ISecondClassWithCycleInConstructor, SecondClassWithCycleInConstructorInRegisteredType>()
                .AsSingleton();
            c.RegisterType<IFirstClassWithCycleInConstructor, FirstClassWithCycleInConstructorInRegisteredType>()
                .AsSingleton();

            var sampleClass = c.Resolve<IFirstClassWithCycleInConstructor>(ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void SameObjects_RegisteredInterface_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();

            var sampleClass1 = c.Resolve<ISampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<ISampleClassWithInterfaceAsParameter>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}