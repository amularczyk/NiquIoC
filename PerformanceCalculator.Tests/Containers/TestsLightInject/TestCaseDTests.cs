using System;
using System.Threading;
using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers;
using PerformanceCalculator.Containers.TestsLightInject;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsLightInject
{
    [TestClass]
    public class TestCaseDTests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new TestCaseD(new SingletonLightInjectRegistration(), new LightInjectResolving());


            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.Register(c);

            var obj1 = c.GetInstance<ITestD>();
            var obj2 = c.GetInstance<ITestD>();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TestCaseD(new TransientLightInjectRegistration(), new LightInjectResolving());


            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.Register(c);

            var obj1 = c.GetInstance<ITestD>();
            var obj2 = c.GetInstance<ITestD>();


            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            throw new OutOfMemoryException("Process takes more than 20 minutes!");
            ITestCase testCase = new TestCaseD(new PerThreadLightInjectRegistration(), new LightInjectResolving());

            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.Register(c);
            ITestD obj1 = null;
            ITestD obj2 = null;


            var thread = new Thread(() =>
            {
                using (c.BeginScope())
                {
                    obj1 = c.GetInstance<ITestD>();
                    obj2 = c.GetInstance<ITestD>();
                }
            });
            thread.Start();
            thread.Join();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterPerThread_DifferentThreads_Success()
        {
            throw new OutOfMemoryException("Process takes more than 20 minutes!");
            ITestCase testCase = new TestCaseD(new PerThreadLightInjectRegistration(), new LightInjectResolving());

            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.Register(c);
            ITestD obj1 = null;
            ITestD obj2 = null;


            var thread1 = new Thread(() =>
            {
                using (c.BeginScope())
                {
                    obj1 = c.GetInstance<ITestD>();
                }
            });
            var thread2 = new Thread(() =>
            {
                using (c.BeginScope())
                {
                    obj2 = c.GetInstance<ITestD>();
                }
            });
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, false);
        }
    }
}