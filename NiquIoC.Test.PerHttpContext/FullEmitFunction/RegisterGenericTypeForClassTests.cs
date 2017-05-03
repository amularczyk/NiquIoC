using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction
{
    [TestClass]
    public class RegisterGenericTypeForClassTests
    {
        [TestMethod]
        public void RegisterSimpleGenericClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<GenericClass<EmptyClass>>().AsPerHttpContext();
            

            var genericClass = HttpContextTestsHelper.Initialize().ResolveObject<GenericClass<EmptyClass>>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithClassWithNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<GenericClass<SampleClass>>().AsPerHttpContext();

            
            var genericClass = HttpContextTestsHelper.Initialize().ResolveObject<GenericClass<SampleClass>>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
            Assert.IsNotNull(genericClass.NestedClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithManyParameters_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<GenericClassWithManyParameters<EmptyClass, SampleClass>>().AsPerHttpContext();
            
            
            var genericClass = HttpContextTestsHelper.Initialize().ResolveObject<GenericClassWithManyParameters<EmptyClass, SampleClass>>(c, ResolveKind.FullEmitFunction);


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
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<GenericClass<EmptyClass>>().AsPerHttpContext();
            c.RegisterType<GenericClass<SampleClass>>().AsPerHttpContext();

            
            var objs1 =
                HttpContextTestsHelper.Initialize()
                    .ResolveObjects<GenericClass<EmptyClass>, GenericClass<SampleClass>>(c,
                        ResolveKind.FullEmitFunction);
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
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();
            c.RegisterType<GenericClass<EmptyClass>>().AsPerHttpContext();
            c.RegisterType<GenericClass<SampleClass>>().AsPerHttpContext();

            
            var genericClass1 = HttpContextTestsHelper.Initialize().ResolveObject<GenericClass<EmptyClass>>(c, ResolveKind.FullEmitFunction);
            var genericClass2 = HttpContextTestsHelper.Initialize().ResolveObject<GenericClass<SampleClass>>(c, ResolveKind.FullEmitFunction);


            Assert.AreNotEqual(genericClass1, genericClass2);
            Assert.AreNotEqual(genericClass1.GetType(), genericClass2.GetType());
            Assert.AreNotEqual(genericClass1.NestedClass, genericClass2.NestedClass.EmptyClass);
            Assert.AreEqual(genericClass1.NestedClass.GetType(), genericClass2.NestedClass.EmptyClass.GetType());
        }
    }
}