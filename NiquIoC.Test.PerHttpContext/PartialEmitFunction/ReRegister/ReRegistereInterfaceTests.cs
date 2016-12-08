using System.IO;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;
using NiquIoC.Test.WebApplication.Controllers;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.ReRegister
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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (IEmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (IEmptyClass)((ViewResult)result2).Model;

            IEmptyClass emptyClass3 = new EmptyClass();
            c.RegisterInstance(emptyClass3).AsPerHttpContext();
            var result4 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (IEmptyClass)((ViewResult)result4).Model;
            var result5 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass5 = (IEmptyClass)((ViewResult)result5).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (IEmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (IEmptyClass)((ViewResult)result2).Model;

            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var result3 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = (IEmptyClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (IEmptyClass)((ViewResult)result4).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (IEmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (IEmptyClass)((ViewResult)result2).Model;

            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var result3 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = (IEmptyClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (IEmptyClass)((ViewResult)result4).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (IEmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (IEmptyClass)((ViewResult)result2).Model;

            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();
            var result3 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = (IEmptyClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (IEmptyClass)((ViewResult)result4).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (IEmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (IEmptyClass)((ViewResult)result2).Model;

            c.RegisterType<IEmptyClass>(() => new EmptyClass()).AsPerHttpContext();
            var result3 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = (IEmptyClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (IEmptyClass)((ViewResult)result4).Model;


            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromClassToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass1 = (IEmptyClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass2 = (IEmptyClass)((ViewResult)result2).Model;

            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass).AsPerHttpContext();
            var result3 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass3 = (IEmptyClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<IEmptyClass>(c, ResolveKind.PartialEmitFunction);
            var emptyClass4 = (IEmptyClass)((ViewResult)result4).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<ISampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = (ISampleClass)((ViewResult)result1).Model;

            c.RegisterType<ISampleClass, SampleClass>().AsPerHttpContext();
            var result2 = controller.ResolveObject<ISampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = (ISampleClass)((ViewResult)result2).Model;
            

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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<ISampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = (ISampleClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<ISampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = (ISampleClass)((ViewResult)result2).Model;

            c.RegisterType<ISampleClass, SampleClassOther>().AsPerHttpContext();
            var result3 = controller.ResolveObject<ISampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass3 = (ISampleClass)((ViewResult)result3).Model;
            var result4 = controller.ResolveObject<ISampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass4 = (ISampleClass)((ViewResult)result4).Model;


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