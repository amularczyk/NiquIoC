using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction
{
    [TestClass]
    public class RegisterGenericTypeForInterfaceTests
    {
        [TestMethod]
        public void RegisterSimpleGenericClass_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<IGenericClass<IEmptyClass>, GenericClass<IEmptyClass>>().AsPerHttpContext();


            var genericClass =
                HttpContextTestsHelper.Initialize().ResolveObject<IGenericClass<IEmptyClass>>(c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithClassWithNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>()
                .AsPerHttpContext();
            c.RegisterType<IGenericClass<ISampleClassWithInterfaceAsParameter>,
                    GenericClass<ISampleClassWithInterfaceAsParameter>>()
                .AsPerHttpContext();


            var genericClass =
                HttpContextTestsHelper.Initialize().ResolveObject<IGenericClass<ISampleClassWithInterfaceAsParameter>>(c,
                    ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
            Assert.IsNotNull(genericClass.NestedClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithManyParameters_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>()
                .AsPerHttpContext();
            c.RegisterType<IGenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>,
                    GenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>>()
                .AsPerHttpContext();


            var genericClass =
                HttpContextTestsHelper.Initialize()
                    .ResolveObject<IGenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>>(
                        c, ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass1);
            Assert.IsNotNull(genericClass.NestedClass2);
            Assert.IsNotNull(genericClass.NestedClass2.EmptyClass);
            Assert.AreEqual(genericClass.NestedClass1, genericClass.NestedClass2.EmptyClass);
        }

        [TestMethod]
        public void SameHttpContext_RegisterManyGenericClasses_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>()
                .AsPerHttpContext();
            c.RegisterType<IGenericClass<IEmptyClass>, GenericClass<IEmptyClass>>().AsPerHttpContext();
            c.RegisterType<IGenericClass<ISampleClassWithInterfaceAsParameter>,
                    GenericClass<ISampleClassWithInterfaceAsParameter>>()
                .AsPerHttpContext();


            var objs1 =
                HttpContextTestsHelper.Initialize()
                    .ResolveObjects<IGenericClass<IEmptyClass>, IGenericClass<ISampleClassWithInterfaceAsParameter>>(c,
                        ResolveKind.PartialEmitFunction);
            var genericClass1 = objs1.Item1;
            var genericClass2 = objs1.Item2;


            Assert.AreNotEqual(genericClass1, genericClass2);
            Assert.AreNotEqual(genericClass1.GetType(), genericClass2.GetType());
            Assert.AreEqual(genericClass1.NestedClass, genericClass2.NestedClass.EmptyClass);
            Assert.AreEqual(genericClass1.NestedClass.GetType(), genericClass2.NestedClass.EmptyClass.GetType());
        }

        [TestMethod]
        public void DifferentHttpContexts_RegisterManyGenericClasses_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>()
                .AsPerHttpContext();
            c.RegisterType<IGenericClass<IEmptyClass>, GenericClass<IEmptyClass>>().AsPerHttpContext();
            c.RegisterType<IGenericClass<ISampleClassWithInterfaceAsParameter>,
                    GenericClass<ISampleClassWithInterfaceAsParameter>>()
                .AsPerHttpContext();


            var genericClass1 =
                HttpContextTestsHelper.Initialize().ResolveObject<IGenericClass<IEmptyClass>>(c, ResolveKind.PartialEmitFunction);
            var genericClass2 =
                HttpContextTestsHelper.Initialize().ResolveObject<IGenericClass<ISampleClassWithInterfaceAsParameter>>(c,
                    ResolveKind.PartialEmitFunction);


            Assert.AreNotEqual(genericClass1, genericClass2);
            Assert.AreNotEqual(genericClass1.GetType(), genericClass2.GetType());
            Assert.AreNotEqual(genericClass1.NestedClass, genericClass2.NestedClass.EmptyClass);
            Assert.AreEqual(genericClass1.NestedClass.GetType(), genericClass2.NestedClass.EmptyClass.GetType());
        }
    }
}