using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction
{
    [TestClass]
    public class RegisterTypeForClassTests
    {
        [TestMethod]
        public void RegisterClassWithConstructorWithoutParameters_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();


            var emptyClass = TestsHelper.ResolveObject<EmptyClass>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(emptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void InternalClassNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClass>().AsPerHttpContext();


            var sampleClass = TestsHelper.ResolveObject<SampleClass>(c, ResolveKind.FullEmitFunction);


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type System.String has not been registered.")]
        public void InternalStringTypeNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithStringType>().AsPerHttpContext();


            var sampleClass = TestsHelper.ResolveObject<SampleClassWithStringType>(c, ResolveKind.FullEmitFunction);


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type System.Int32 has not been registered.")]
        public void InternalIntTypeNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithIntType>().AsPerHttpContext();


            var sampleClass = TestsHelper.ResolveObject<SampleClassWithIntType>(c, ResolveKind.FullEmitFunction);


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisterClassWithConstructorWithParameter_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();


            var sampleClass = TestsHelper.ResolveObject<SampleClass>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException), "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.FirstClassWithCycleInConstructor")]
        public void RegisterClassWithCycleInConstructor_Fail()
        {
            var c = new Container();
            c.RegisterType<SecondClassWithCycleInConstructor>().AsPerHttpContext();
            c.RegisterType<FirstClassWithCycleInConstructor>().AsPerHttpContext();


            var sampleClass = TestsHelper.ResolveObject<FirstClassWithCycleInConstructor>(c, ResolveKind.FullEmitFunction);


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void SameHttpContext_RegisterClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();


            var objs = TestsHelper.ResolveObjects<SampleClass>(c, ResolveKind.FullEmitFunction);
            var sampleClass1 = objs.Item1;
            var sampleClass2 = objs.Item2;


            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentHttpContext_RegisterClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();


            var sampleClass1 = TestsHelper.ResolveObject<SampleClass>(c, ResolveKind.FullEmitFunction);
            var sampleClass2 = TestsHelper.ResolveObject<SampleClass>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentHttpContextsAndSameHttpContext_RegisterClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();


            var objs1 = TestsHelper.ResolveObjects<SampleClass>(c, ResolveKind.FullEmitFunction);
            var sampleClass11 = objs1.Item1;
            var sampleClass12 = objs1.Item2;
            var objs2 = TestsHelper.ResolveObjects<SampleClass>(c, ResolveKind.FullEmitFunction);
            var sampleClass21 = objs2.Item1;
            var sampleClass22 = objs2.Item2;


            Assert.IsNotNull(sampleClass11);
            Assert.IsNotNull(sampleClass11.EmptyClass);
            Assert.IsNotNull(sampleClass12);
            Assert.IsNotNull(sampleClass12.EmptyClass);
            Assert.IsNotNull(sampleClass21);
            Assert.IsNotNull(sampleClass21.EmptyClass);
            Assert.IsNotNull(sampleClass22);
            Assert.IsNotNull(sampleClass22.EmptyClass);

            Assert.AreEqual(sampleClass11, sampleClass12);
            Assert.AreEqual(sampleClass11.EmptyClass, sampleClass12.EmptyClass);

            Assert.AreNotEqual(sampleClass11, sampleClass21);
            Assert.AreNotEqual(sampleClass11.EmptyClass, sampleClass21.EmptyClass);

            Assert.AreEqual(sampleClass21, sampleClass22);
            Assert.AreEqual(sampleClass21.EmptyClass, sampleClass22.EmptyClass);
        }
    }
}