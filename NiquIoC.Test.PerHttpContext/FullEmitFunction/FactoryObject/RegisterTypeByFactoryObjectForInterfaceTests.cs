using System.IO;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;
using NiquIoC.Test.WebApplication.Controllers;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.FactoryObject
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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass1 = (ISampleClassWithInterfaceAsParameter)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass2 = (ISampleClassWithInterfaceAsParameter)((ViewResult)result2).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass1 = (ISampleClassWithInterfaceAsParameter)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass2 = (ISampleClassWithInterfaceAsParameter)((ViewResult)result2).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass1 = (ISampleClassWithInterfaceAsParameter)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass2 = (ISampleClassWithInterfaceAsParameter)((ViewResult)result2).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass1 = (ISampleClassWithInterfaceAsParameter)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass2 = (ISampleClassWithInterfaceAsParameter)((ViewResult)result2).Model;


            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}