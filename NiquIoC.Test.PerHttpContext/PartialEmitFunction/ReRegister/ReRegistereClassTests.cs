using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.ReRegister
{
    [TestClass]
    public class ReRegistereClassTests
    {
        [TestMethod]
        public void ClassReRegisteredFromClassToTheSameClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = objs2.Item1;
            var emptyClass4 = objs2.Item2;


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromInstanceToInstance_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            var emptyClass3 = new EmptyClass();
            c.RegisterInstance(emptyClass3).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = objs2.Item1;
            var emptyClass5 = objs2.Item2;


            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreEqual(emptyClass4, emptyClass5);
            Assert.AreNotEqual(emptyClass, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromObjectFactoryToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<EmptyClass>(() => emptyClass).AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = objs2.Item1;
            var emptyClass4 = objs2.Item2;


            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass2, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromInstanceToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = objs2.Item1;
            var emptyClass4 = objs2.Item2;


            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void ClassReRegisteredFromObjectFactoryToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = objs2.Item1;
            var emptyClass4 = objs2.Item2;


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass);
        }

        [TestMethod]
        public void ClassReRegisteredFromClassToObjectFactory_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = objs2.Item1;
            var emptyClass4 = objs2.Item2;


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromClassToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();


            var httpContextTestsHelper = HttpContextTestsHelper.Initialize();
            var objs1 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = objs1.Item1;
            var emptyClass2 = objs1.Item2;

            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();
            var objs2 = httpContextTestsHelper.ResolveObjects<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = objs2.Item1;
            var emptyClass4 = objs2.Item2;


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass);
        }
    }
}