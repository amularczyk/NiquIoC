using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.MixObjectsLifeTime
{
    [TestClass]
    public class RegisterGenericTypeForInterfaceTests
    {
        [TestMethod]
        public void RegisterGenericClassWithManyParameters_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c.RegisterType<ISampleClassOtherWithInterfaceAsParameter, SampleClassOtherWithInterfaceAsParameter>();
            c.RegisterType<IGenericClassWithManyParameters<ISampleClassWithInterfaceAsParameter, ISampleClassOtherWithInterfaceAsParameter>,
                GenericClassWithManyParameters<ISampleClassWithInterfaceAsParameter, ISampleClassOtherWithInterfaceAsParameter>>();

            var genericClass = c.Resolve<IGenericClassWithManyParameters<ISampleClassWithInterfaceAsParameter,
                ISampleClassOtherWithInterfaceAsParameter>>(ResolveKind.FullEmitFunction);

            Assert.AreNotEqual(genericClass.NestedClass1, genericClass.NestedClass2);
            Assert.AreEqual(genericClass.NestedClass1.EmptyClass, genericClass.NestedClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterManyGenericClasses_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c.RegisterType<ISampleClassOtherWithInterfaceAsParameter, SampleClassOtherWithInterfaceAsParameter>();
            c.RegisterType<IGenericClass<ISampleClassWithInterfaceAsParameter>, GenericClass<ISampleClassWithInterfaceAsParameter>>();
            c.RegisterType<IGenericClass<ISampleClassOtherWithInterfaceAsParameter>, GenericClass<ISampleClassOtherWithInterfaceAsParameter>>();

            var genericClass1 = c.Resolve<IGenericClass<ISampleClassWithInterfaceAsParameter>>(ResolveKind.FullEmitFunction);
            var genericClass2 = c.Resolve<IGenericClass<ISampleClassOtherWithInterfaceAsParameter>>(ResolveKind.FullEmitFunction);
            
            Assert.AreNotEqual(genericClass1, genericClass2);
            Assert.AreNotEqual(genericClass1.GetType(), genericClass2.GetType());
            Assert.AreNotEqual(genericClass1.NestedClass, genericClass2.NestedClass);
            Assert.AreNotEqual(genericClass1.NestedClass.GetType(), genericClass2.NestedClass.GetType());
            Assert.AreEqual(genericClass1.NestedClass.EmptyClass, genericClass2.NestedClass.EmptyClass);
            Assert.AreEqual(genericClass1.NestedClass.EmptyClass.GetType(), genericClass2.NestedClass.EmptyClass.GetType());
        }
    }
}
