using System;
using System.Threading;
using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsLightInject;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using PerformanceCalculator.Tests.Interfaces;

namespace PerformanceCalculator.Tests.Containers.TestsLightInject
{
    [TestClass]
    public class TestCaseBTests : ITestCaseBTests
    {
        [TestMethod]
        public void SingletonRegister_Success()
        {
            ITestCase testCase = new TestCaseB();


            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.SingletonRegister(c);

            var obj1 = c.GetInstance<ITestB>();
            var obj2 = c.GetInstance<ITestB>();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void TransientRegister_Success()
        {
            ITestCase testCase = new TestCaseB();


            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.TransientRegister(c);

            var obj1 = c.GetInstance<ITestB>();
            var obj2 = c.GetInstance<ITestB>();


            Helper.Check(obj1, false);
            Helper.Check(obj2, false);
            Helper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void PerThreadRegister_SameThread_Success()
        {
            throw new NotImplementedException("Process not ending - need to investigate it");
            ITestCase testCase = new TestCaseB();

            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.PerThreadRegister(c);
            ITestB obj1 = null;
            ITestB obj2 = null;


            var thread = new Thread(() =>
            {
                obj1 = c.GetInstance<ITestB>();
                obj2 = c.GetInstance<ITestB>();
            });
            thread.Start();
            thread.Join();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void PerThreadRegister_DifferentThreads_Success()
        {
            throw new NotImplementedException("Process not ending - need to investigate it");
            ITestCase testCase = new TestCaseB();

            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.PerThreadRegister(c);
            ITestB obj1 = null;
            ITestB obj2 = null;


            var thread1 = new Thread(() => { obj1 = c.GetInstance<ITestB>(); });
            var thread2 = new Thread(() => { obj2 = c.GetInstance<ITestB>(); });
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, false);
        }
    }
}