using System.IO;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;
using NiquIoC.Test.WebApplication.Controllers;

namespace NiquIoC.Test.PerHttpContext.PartialEmitFunction.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForClassWithDependencyConstrutorTests
    {
        [TestMethod]
        public void RegisterClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithDependencyConstrutor>().AsPerHttpContext();
            

            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<SampleClassWithDependencyConstrutor>(c, ResolveKind.PartialEmitFunction);
            var sampleClass = (SampleClassWithDependencyConstrutor)((ViewResult)result).Model;


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void RegisterClassWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithTwoDependencyConstrutor>().AsPerHttpContext();
            

            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<SampleClassWithTwoDependencyConstrutor>(c, ResolveKind.PartialEmitFunction);
            var sampleClass = (SampleClassWithTwoDependencyConstrutor)((ViewResult)result).Model;


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisterClassWithNestedClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithDependencyConstrutor>().AsPerHttpContext();
            c.RegisterType<SampleClassWithNestedClassWithDependencyConstrutor>().AsPerHttpContext();
            

            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<SampleClassWithNestedClassWithDependencyConstrutor>(c, ResolveKind.PartialEmitFunction);
            var sampleClass = (SampleClassWithNestedClassWithDependencyConstrutor)((ViewResult)result).Model;


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor.EmptyClass);
        }
    }
}