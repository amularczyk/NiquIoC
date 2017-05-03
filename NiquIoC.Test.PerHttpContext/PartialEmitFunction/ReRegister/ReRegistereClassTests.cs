using System.IO;
using System.Web;
using System.Web.Mvc;
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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (EmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (EmptyClass)((ViewResult)result2).Model;

            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var result3 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = (EmptyClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (EmptyClass)((ViewResult)result4).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (EmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (EmptyClass)((ViewResult)result2).Model;

            var emptyClass3 = new EmptyClass();
            c.RegisterInstance(emptyClass3).AsPerHttpContext();
            var result4 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (EmptyClass)((ViewResult)result4).Model;
            var result5 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass5 = (EmptyClass)((ViewResult)result5).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (EmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (EmptyClass)((ViewResult)result2).Model;

            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var result3 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = (EmptyClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (EmptyClass)((ViewResult)result4).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (EmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (EmptyClass)((ViewResult)result2).Model;

            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var result3 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = (EmptyClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (EmptyClass)((ViewResult)result4).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (EmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (EmptyClass)((ViewResult)result2).Model;

            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();
            var result3 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = (EmptyClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (EmptyClass)((ViewResult)result4).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (EmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (EmptyClass)((ViewResult)result2).Model;

            c.RegisterType<EmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var result3 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = (EmptyClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (EmptyClass)((ViewResult)result4).Model;


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromClassToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (EmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (EmptyClass)((ViewResult)result2).Model;

            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();
            var result3 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = (EmptyClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<EmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (EmptyClass)((ViewResult)result4).Model;


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass);
        }
    }
}