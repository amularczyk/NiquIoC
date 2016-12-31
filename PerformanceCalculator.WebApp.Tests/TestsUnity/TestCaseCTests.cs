using System.IO;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsUnity;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using PerformanceCalculator.WebApp.Unity.Controllers;

namespace PerformanceCalculator.WebApp.Tests.TestsUnity
{
    [TestClass]
    public class TestCaseCTests
    {
        [TestMethod]
        public void PerHttpContextRegister_SameHttpContext_Success()
        {
            ITestCase testCase = new TestCaseC();

            var c = new UnityContainer();
            c = (UnityContainer)testCase.PerHttpContextRegister(c);


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.Resolve<ITestC>(c);
            var obj1 = (ITestC)((ViewResult)result1).Model;
            var result2 = controller.Resolve<ITestC>(c);
            var obj2 = (ITestC)((ViewResult)result2).Model;


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void PerHttpContextRegister_DifferentThreads_Success()
        {
            ITestCase testCase = new TestCaseC();

            var c = new UnityContainer();
            c = (UnityContainer)testCase.PerHttpContextRegister(c);


            var controller = new DefaultController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.Resolve<ITestC>(c);
            var obj1 = (ITestC)((ViewResult)result1).Model;
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result2 = controller.Resolve<ITestC>(c);
            var obj2 = (ITestC)((ViewResult)result2).Model;


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, false);
        }
    }
}