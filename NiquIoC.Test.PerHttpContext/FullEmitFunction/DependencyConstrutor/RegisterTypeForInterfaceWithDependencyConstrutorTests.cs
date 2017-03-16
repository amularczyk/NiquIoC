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
    public class RegisterTypeForInterfaceWithDependencyConstrutorTests
    {
        [TestMethod]
        public void RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameterWithDependencyConstrutor>().AsPerHttpContext();
            

            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass = (ISampleClassWithInterfaceAsParameter)((ViewResult)result).Model;


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>().AsPerHttpContext();
            

            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<ISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass = (ISampleClassWithInterfaceAsParameter)((ViewResult)result).Model;


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisteredInterfaceAsClassWithNestedInterfaceAsParameterWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameterWithDependencyConstrutor>().AsPerHttpContext();
            c.RegisterType<ISampleClassISampleClassWithInterfaceAsParameter, SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>().AsPerHttpContext();
            

            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<ISampleClassISampleClassWithInterfaceAsParameter>(c, ResolveKind.FullEmitFunction);
            var sampleClass = (ISampleClassISampleClassWithInterfaceAsParameter)((ViewResult)result).Model;


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter.EmptyClass);
        }
    }
}