using System.IO;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;
using NiquIoC.Test.WebApplication.Controllers;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForInterfaceWithDependencyConstrutorWithClassTests
    {
        [TestMethod]
        public void RegisteredInterfaceAsClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClass, SampleClassWithDependencyConstrutor>().AsPerHttpContext();
            

            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<ISampleClass>(c, ResolveKind.FullEmitFunction);
            var sampleClass = (ISampleClass)((ViewResult)result).Model;


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void RegisteredInterfaceAsClassWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClass, SampleClassWithTwoDependencyConstrutor>().AsPerHttpContext();
            

            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<ISampleClass>(c, ResolveKind.FullEmitFunction);
            var sampleClass = (ISampleClass)((ViewResult)result).Model;


            Assert.IsNull(sampleClass);
        }
        [TestMethod]
        public void RegisteredInterfaceAsClassWithNestedClassAsParameterWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithDependencyConstrutor>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithNestedClass, SampleClassWithNestedClassWithDependencyConstrutor>().AsPerHttpContext();
            

            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<ISampleClassWithNestedClass>(c, ResolveKind.FullEmitFunction);
            var sampleClass = (ISampleClassWithNestedClass)((ViewResult)result).Model;


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor.EmptyClass);
        }
    }
}