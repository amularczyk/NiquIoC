﻿using System.IO;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using PerformanceCalculator.Tests.WebApp.Controllers;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsAutofac
{
    [TestClass]
    public class TestCaseCTests
    {
        [TestMethod]
        public void PerHttpContextRegister_SameHttpContext_Success()
        {
            ITestCase testCase = new TestCaseC();

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.PerHttpContextRegister(cb);


            var controller = new AutofacController();
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

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.PerHttpContextRegister(cb);


            var controller = new AutofacController();
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