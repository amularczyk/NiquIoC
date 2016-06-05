using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction.Transient
{
    [TestClass]
    public class RegisterGenericTypeForInterfaceTests
    {
        [TestMethod]
        public void RegisterSimpleGenericClass_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<IGenericClass<IEmptyClass>, GenericClass<IEmptyClass>>();

            var genericClass = c.Resolve<IGenericClass<IEmptyClass>>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithClassWithNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c.RegisterType<IGenericClass<ISampleClassWithInterfaceAsParameter>, GenericClass<ISampleClassWithInterfaceAsParameter>>();

            var genericClass = c.Resolve<IGenericClass<ISampleClassWithInterfaceAsParameter>>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
            Assert.IsNotNull(genericClass.NestedClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithManyParameters_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c.RegisterType<IGenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>, GenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>>();

            var genericClass = c.Resolve<IGenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass1);
            Assert.IsNotNull(genericClass.NestedClass2);
            Assert.IsNotNull(genericClass.NestedClass2.EmptyClass);
            Assert.AreNotEqual(genericClass.NestedClass1, genericClass.NestedClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterManyGenericClasses_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c.RegisterType<IGenericClass<IEmptyClass>, GenericClass<IEmptyClass>>();
            c.RegisterType<IGenericClass<ISampleClassWithInterfaceAsParameter>, GenericClass<ISampleClassWithInterfaceAsParameter>>();

            var genericClass1 = c.Resolve<IGenericClass<IEmptyClass>>(Enums.ResolveKind.FullEmitFunction);
            var genericClass2 = c.Resolve<IGenericClass<ISampleClassWithInterfaceAsParameter>>(Enums.ResolveKind.FullEmitFunction);
            
            Assert.AreNotEqual(genericClass1, genericClass2);
            Assert.AreNotEqual(genericClass1.GetType(), genericClass2.GetType());
            Assert.AreNotEqual(genericClass1.NestedClass, genericClass2.NestedClass.EmptyClass);
            Assert.AreEqual(genericClass1.NestedClass.GetType(), genericClass2.NestedClass.EmptyClass.GetType());
        }
    }
}
