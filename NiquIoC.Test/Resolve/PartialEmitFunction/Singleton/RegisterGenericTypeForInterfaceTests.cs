using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.Singleton
{
    [TestClass]
    public class RegisterGenericTypeForInterfaceTests
    {
        [TestMethod]
        public void RegisterSimpleGenericClass_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<IGenericClass<IEmptyClass>, GenericClass<IEmptyClass>>().AsSingleton();

            var genericClass = c.Resolve<IGenericClass<IEmptyClass>>();

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithClassWithNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();
            c.RegisterType<IGenericClass<ISampleClassWithInterfaceAsParameter>, GenericClass<ISampleClassWithInterfaceAsParameter>>().AsSingleton();

            var genericClass = c.Resolve<IGenericClass<ISampleClassWithInterfaceAsParameter>>();

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
            Assert.IsNotNull(genericClass.NestedClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithManyParameters_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();
            c.RegisterType<IGenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>,
                GenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>>().AsSingleton();

            var genericClass = c.Resolve<IGenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>>();

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass1);
            Assert.IsNotNull(genericClass.NestedClass2);
            Assert.IsNotNull(genericClass.NestedClass2.EmptyClass);
            Assert.AreEqual(genericClass.NestedClass1, genericClass.NestedClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterManyGenericClasses_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();
            c.RegisterType<IGenericClass<IEmptyClass>, GenericClass<IEmptyClass>>().AsSingleton();
            c.RegisterType<IGenericClass<ISampleClassWithInterfaceAsParameter>, GenericClass<ISampleClassWithInterfaceAsParameter>>().AsSingleton();

            var genericClass1 = c.Resolve<IGenericClass<IEmptyClass>>();
            var genericClass2 = c.Resolve<IGenericClass<ISampleClassWithInterfaceAsParameter>>();
            
            Assert.AreNotEqual(genericClass1, genericClass2);
            Assert.AreNotEqual(genericClass1.GetType(), genericClass2.GetType());
            Assert.AreEqual(genericClass1.NestedClass, genericClass2.NestedClass.EmptyClass);
            Assert.AreEqual(genericClass1.NestedClass.GetType(), genericClass2.NestedClass.EmptyClass.GetType());
        }
    }
}
