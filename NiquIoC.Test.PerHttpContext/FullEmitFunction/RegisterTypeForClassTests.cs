using System.IO;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;
using NiquIoC.Test.WebApplication.Controllers;

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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<EmptyClass>(c, ResolveKind.FullEmitFunction);
            var emptyClass = (EmptyClass)((ViewResult)result).Model;


            Assert.IsNotNull(emptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void InternalClassNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClass>().AsPerHttpContext();


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<SampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass = (SampleClass)((ViewResult)result).Model;


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type System.String has not been registered.")]
        public void InternalStringTypeNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithStringType>().AsPerHttpContext();


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<SampleClassWithStringType>(c, ResolveKind.PartialEmitFunction);
            var sampleClassWithSimpleType = (SampleClassWithStringType)((ViewResult)result).Model;


            Assert.IsNull(sampleClassWithSimpleType);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type System.Int32 has not been registered.")]
        public void InternalIntTypeNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithIntType>().AsPerHttpContext();


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<SampleClassWithIntType>(c, ResolveKind.PartialEmitFunction);
            var sampleClassWithSimpleType = (SampleClassWithIntType)((ViewResult)result).Model;


            Assert.IsNull(sampleClassWithSimpleType);
        }

        [TestMethod]
        public void RegisterClassWithConstructorWithParameter_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<SampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass = (SampleClass)((ViewResult)result).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<FirstClassWithCycleInConstructor>(c, ResolveKind.PartialEmitFunction);
            var sampleClass = (FirstClassWithCycleInConstructor)((ViewResult)result).Model;


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void SameHttpContext_RegisterClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClass>().AsPerHttpContext();


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<SampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = (SampleClass)((ViewResult)result1).Model;
            var result2 = controller.ResolveObject<SampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = (SampleClass)((ViewResult)result2).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.ResolveObject<SampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass1 = (SampleClass)((ViewResult)result1).Model;
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result2 = controller.ResolveObject<SampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass2 = (SampleClass)((ViewResult)result2).Model;


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


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result11 = controller.ResolveObject<SampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass11 = (SampleClass)((ViewResult)result11).Model;
            var result12 = controller.ResolveObject<SampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass12 = (SampleClass)((ViewResult)result12).Model;
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result21 = controller.ResolveObject<SampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass21 = (SampleClass)((ViewResult)result21).Model;
            var result22 = controller.ResolveObject<SampleClass>(c, ResolveKind.PartialEmitFunction);
            var sampleClass22 = (SampleClass)((ViewResult)result22).Model;


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