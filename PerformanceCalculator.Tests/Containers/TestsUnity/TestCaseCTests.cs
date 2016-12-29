﻿using System.Threading;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsUnity;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using PerformanceCalculator.Tests.Interfaces;

namespace PerformanceCalculator.Tests.Containers.TestsUnity
{
    [TestClass]
    public class TestCaseCTests : ITestCaseCTests
    {
        [TestMethod]
        public void SingletonRegister_Success()
        {
            ITestCase testCase = new TestCaseC();


            var c = new UnityContainer();
            c = (UnityContainer)testCase.SingletonRegister(c);

            var obj1 = c.Resolve<ITestC>();
            var obj2 = c.Resolve<ITestC>();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void TransientRegister_Success()
        {
            ITestCase testCase = new TestCaseC();


            var c = new UnityContainer();
            c = (UnityContainer)testCase.TransientRegister(c);

            var obj1 = c.Resolve<ITestC>();
            var obj2 = c.Resolve<ITestC>();


            Helper.Check(obj1, false);
            Helper.Check(obj2, false);
            Helper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void PerThreadRegister_SameThread_Success()
        {
            ITestCase testCase = new TestCaseC();

            var c = new UnityContainer();
            c = (UnityContainer)testCase.PerThreadRegister(c);
            ITestC obj1 = null;
            ITestC obj2 = null;


            var thread = new Thread(() =>
            {
                obj1 = c.Resolve<ITestC>();
                obj2 = c.Resolve<ITestC>();
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
            ITestCase testCase = new TestCaseC();

            var c = new UnityContainer();
            c = (UnityContainer)testCase.PerThreadRegister(c);
            ITestC obj1 = null;
            ITestC obj2 = null;


            var thread1 = new Thread(() => { obj1 = c.Resolve<ITestC>(); });
            var thread2 = new Thread(() => { obj2 = c.Resolve<ITestC>(); });
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