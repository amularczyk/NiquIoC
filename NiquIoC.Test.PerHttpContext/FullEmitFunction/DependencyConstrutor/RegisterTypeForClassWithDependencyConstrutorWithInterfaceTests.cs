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
    public class RegisterTypeForClassWithDependencyConstrutorWithInterfaceTests
    {
        [TestMethod]
        public void RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>().AsPerHttpContext();
            

            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>(c, ResolveKind.FullEmitFunction);
            var sampleClass = (SampleClassWithInterfaceAsParameterWithDependencyConstrutor)((ViewResult)result).Model;


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>().AsPerHttpContext();
            
            
            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>(c, ResolveKind.FullEmitFunction);
            var sampleClass = (SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor)((ViewResult)result).Model;


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void RegisterClassWithNestedInterfaceAsParameterWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameterWithDependencyConstrutor>().AsPerHttpContext();
            c.RegisterType<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>().AsPerHttpContext();
            

            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result = controller.ResolveObject<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>(c, ResolveKind.FullEmitFunction);
            var sampleClass = (SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor)((ViewResult)result).Model;


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter.EmptyClass);
        }
    }
}