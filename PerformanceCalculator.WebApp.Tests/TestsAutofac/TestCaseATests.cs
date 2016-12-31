using System.IO;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using PerformanceCalculator.WebApp.Autofac.Controllers;

namespace PerformanceCalculator.WebApp.Tests.TestsAutofac
{
    [TestClass]
    public class TestCaseATests
    {
        [TestMethod]
        public void PerHttpContextRegister_SameHttpContext_Success()
        {
            ITestCase testCase = new TestCaseA();

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.PerHttpContextRegister(cb);


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.Resolve<ITestA>(c);
            var obj1 = (ITestA)((ViewResult)result1).Model;
            var result2 = controller.Resolve<ITestA>(c);
            var obj2 = (ITestA)((ViewResult)result2).Model;


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void PerHttpContextRegister_DifferentThreads_Success()
        {
            ITestCase testCase = new TestCaseA();

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.PerHttpContextRegister(cb);


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.Resolve<ITestA>(c);
            var obj1 = (ITestA)((ViewResult)result1).Model;
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result2 = controller.Resolve<ITestA>(c);
            var obj2 = (ITestA)((ViewResult)result2).Model;


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, false);
        }
    }
}