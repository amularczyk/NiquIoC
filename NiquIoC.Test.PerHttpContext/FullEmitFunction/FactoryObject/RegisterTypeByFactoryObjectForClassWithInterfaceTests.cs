using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.FactoryObject
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForClassWithInterfaceTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<SampleClassWithInterfaceAsParameter>(() => new SampleClassWithInterfaceAsParameter(emptyClass)).AsPerHttpContext();
            

            var objs1 = TestsHelper.ResolveObjects<SampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass1 = objs1.Item1;
            var sampleClass2 = objs1.Item2;


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void FactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            var sampleClass = new SampleClassWithInterfaceAsParameter(emptyClass);
            c.RegisterType<SampleClassWithInterfaceAsParameter>(() => sampleClass).AsPerHttpContext();
            

            var objs1 = TestsHelper.ResolveObjects<SampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass1 = objs1.Item1;
            var sampleClass2 = objs1.Item2;


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            c.RegisterType<SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            

            var objs1 = TestsHelper.ResolveObjects<SampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass1 = objs1.Item1;
            var sampleClass2 = objs1.Item2;


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<IEmptyClass>(() => emptyClass).AsPerHttpContext();
            c.RegisterType<SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            

            var objs1 = TestsHelper.ResolveObjects<SampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass1 = objs1.Item1;
            var sampleClass2 = objs1.Item2;


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}