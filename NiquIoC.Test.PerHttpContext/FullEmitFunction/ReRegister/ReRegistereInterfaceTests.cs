using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.ReRegister
{
    [TestClass]
    public class ReRegistereInterfaceTests
    {
        [TestMethod]
        public void InterfaceReRegisteredFromInstanceToInstance_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            IEmptyClass emptyClass3 = new EmptyClass();
            c.RegisterInstance(emptyClass3).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass4 = objs2.Item1;
            var emptyClass5 = objs2.Item2;


            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreEqual(emptyClass4, emptyClass5);
            Assert.AreNotEqual(emptyClass, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromObjectFactoryToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<IEmptyClass>(() => emptyClass).AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass3 = objs2.Item1;
            var emptyClass4 = objs2.Item2;


            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromInstanceToObjectFactory_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass3 = objs2.Item1;
            var emptyClass4 = objs2.Item2;


            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromObjectFactoryToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass3 = objs2.Item1;
            var emptyClass4 = objs2.Item2;


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromClassToObjectFactory_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass3 = objs2.Item1;
            var emptyClass4 = objs2.Item2;


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromClassToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<IEmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass3 = objs2.Item1;
            var emptyClass4 = objs2.Item2;


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheSameClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClass, SampleClass>().AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var sampleClass1 = httpContextTestsHelper.ResolveObject<ISampleClass>(c, ResolveKind.FullEmitFunction);

            c.RegisterType<ISampleClass, SampleClass>().AsPerHttpContext();
            var sampleClass2 = httpContextTestsHelper.ResolveObject<ISampleClass>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheOther_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClass, SampleClass>().AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<ISampleClass>(c, ResolveKind.FullEmitFunction);
            var sampleClass1 = objs1.Item1;
            var sampleClass2 = objs1.Item2;

            c.RegisterType<ISampleClass, SampleClassOther>().AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<ISampleClass>(c, ResolveKind.FullEmitFunction);
            var sampleClass3 = objs2.Item1;
            var sampleClass4 = objs2.Item2;


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.GetType(), sampleClass2.GetType());
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass3, sampleClass4);
            Assert.AreEqual(sampleClass3.GetType(), sampleClass4.GetType());
            Assert.AreEqual(sampleClass3.EmptyClass, sampleClass4.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass3);
            Assert.AreNotEqual(sampleClass1.GetType(), sampleClass3.GetType());
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass3.EmptyClass);
        }
    }
}