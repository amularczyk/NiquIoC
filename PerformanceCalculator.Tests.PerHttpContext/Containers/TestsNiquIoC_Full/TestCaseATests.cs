﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC;
using PerformanceCalculator.Containers.TestsNiquIoC_Full;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsNiquIoC_Full
{
    [TestClass]
    public class TestCaseATests
    {
        [TestMethod]
        public void PerThreadRegister_SameThread_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new Container();
            //c = (Container)testCase.PerThreadRegister(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            //var thread = new Thread(() =>
            //{
            //    obj1 = c.Resolve<ITestA>(ResolveKind.FullEmitFunction);
            //    obj2 = c.Resolve<ITestA>(ResolveKind.FullEmitFunction);
            //});
            //thread.Start();
            //thread.Join();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void PerThreadRegister_DifferentThreads_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new Container();
            //c = (Container)testCase.PerThreadRegister(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            //var thread1 = new Thread(() => { obj1 = c.Resolve<ITestA>(ResolveKind.FullEmitFunction); });
            //var thread2 = new Thread(() => { obj2 = c.Resolve<ITestA>(ResolveKind.FullEmitFunction); });
            //thread1.Start();
            //thread1.Join();
            //thread2.Start();
            //thread2.Join();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            //Helper.Check(obj1, obj2, false);
        }
    }
}