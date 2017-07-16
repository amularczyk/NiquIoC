using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.MixObjectsLifeTime.SingletonAndTransient
{
    [TestClass]
    public class RegisterGenericTypeForClassTests
    {
        [TestMethod]
        public void RegisterGenericClassWithManyParameters_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>();
            c.RegisterType<SampleClassOther>();
            c.RegisterType<GenericClassWithManyParameters<SampleClass, SampleClassOther>>();

            var genericClass =
                c.Resolve<GenericClassWithManyParameters<SampleClass, SampleClassOther>>(
                    ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(genericClass.NestedClass1, genericClass.NestedClass2);
            Assert.AreEqual(genericClass.NestedClass1.EmptyClass, genericClass.NestedClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterManyGenericClasses_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>();
            c.RegisterType<SampleClassOther>();
            c.RegisterType<GenericClass<SampleClass>>();
            c.RegisterType<GenericClass<SampleClassOther>>();

            var genericClass1 = c.Resolve<GenericClass<SampleClass>>(ResolveKind.PartialEmitFunction);
            var genericClass2 = c.Resolve<GenericClass<SampleClassOther>>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(genericClass1, genericClass2);
            Assert.AreNotEqual(genericClass1.GetType(), genericClass2.GetType());
            Assert.AreNotEqual(genericClass1.NestedClass, genericClass2.NestedClass);
            Assert.AreNotEqual(genericClass1.NestedClass.GetType(), genericClass2.NestedClass.GetType());
            Assert.AreEqual(genericClass1.NestedClass.EmptyClass, genericClass2.NestedClass.EmptyClass);
            Assert.AreEqual(genericClass1.NestedClass.EmptyClass.GetType(),
                genericClass2.NestedClass.EmptyClass.GetType());
        }
    }
}