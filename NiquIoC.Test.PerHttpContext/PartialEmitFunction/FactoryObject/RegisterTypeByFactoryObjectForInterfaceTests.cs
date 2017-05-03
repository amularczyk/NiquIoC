using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.FactoryObject
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForInterfaceTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<ISampleClassWithInterfaceAsParameter>(() => new SampleClassWithInterfaceAsParameter(emptyClass)).AsPerHttpContext();
            

            var objs1 = TestsHelper.ResolveObjects<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.PartialEmitFunction);
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
            ISampleClassWithInterfaceAsParameter sampleClass = new SampleClassWithInterfaceAsParameter(emptyClass);
            c.RegisterType<ISampleClassWithInterfaceAsParameter>(() => sampleClass).AsPerHttpContext();
            

            var objs1 = TestsHelper.ResolveObjects<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.PartialEmitFunction);
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
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            

            var objs1 = TestsHelper.ResolveObjects<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.PartialEmitFunction);
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
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerHttpContext();
            

            var objs1 = TestsHelper.ResolveObjects<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = objs1.Item1;
            var sampleClass2 = objs1.Item2;


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}