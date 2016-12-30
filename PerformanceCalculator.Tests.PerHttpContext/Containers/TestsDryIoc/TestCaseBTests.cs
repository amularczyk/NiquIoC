﻿using System.IO;
using System.Web;
using System.Web.Mvc;
using DryIoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsDryIoc;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using PerformanceCalculator.Tests.WebApp.Controllers;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsDryIoc
{
    [TestClass]
    public class TestCaseBTests
    {
        [TestMethod]
        public void PerHttpContextRegister_SameHttpContext_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new Container(scopeContext: new ThreadScopeContext());
            c = (Container)testCase.PerHttpContextRegister(c);


            var controller = new DryIocController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.Resolve<ITestB>(c);
            var obj1 = (ITestB)((ViewResult)result1).Model;
            var result2 = controller.Resolve<ITestB>(c);
            var obj2 = (ITestB)((ViewResult)result2).Model;


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void PerHttpContextRegister_DifferentThreads_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new Container(scopeContext: new ThreadScopeContext());
            c = (Container)testCase.PerHttpContextRegister(c);


            var controller = new DryIocController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result1 = controller.Resolve<ITestB>(c);
            var obj1 = (ITestB)((ViewResult)result1).Model;
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            var result2 = controller.Resolve<ITestB>(c);
            var obj2 = (ITestB)((ViewResult)result2).Model;


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, false);
        }
    }
}