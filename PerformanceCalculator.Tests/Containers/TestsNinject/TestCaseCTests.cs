﻿using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using PerformanceCalculator.Containers;
using PerformanceCalculator.Containers.TestsNinject;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCase.TestCaseC;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsNinject
{
    [TestClass]
    public class TestCaseCTests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new SingletonTestCaseC(new NinjectRegistration(), new NinjectResolving());


            var c = new StandardKernel();
            c = (StandardKernel)testCase.Register(c);

            var obj1 = c.Get<ITestC>();
            var obj2 = c.Get<ITestC>();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TransientTestCaseC(new NinjectRegistration(), new NinjectResolving());


            var c = new StandardKernel();
            c = (StandardKernel)testCase.Register(c);

            var obj1 = c.Get<ITestC>();
            var obj2 = c.Get<ITestC>();


            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            ITestCase testCase = new PerThreadTestCaseC(new NinjectRegistration(), new NinjectResolving());

            var c = new StandardKernel();
            c = (StandardKernel)testCase.Register(c);
            ITestC obj1 = null;
            ITestC obj2 = null;


            var thread = new Thread(() =>
            {
                obj1 = c.Get<ITestC>();
                obj2 = c.Get<ITestC>();
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
            ITestCase testCase = new PerThreadTestCaseC(new NinjectRegistration(), new NinjectResolving());

            var c = new StandardKernel();
            c = (StandardKernel)testCase.Register(c);
            ITestC obj1 = null;
            ITestC obj2 = null;


            var thread1 = new Thread(() => { obj1 = c.Get<ITestC>(); });
            var thread2 = new Thread(() => { obj2 = c.Get<ITestC>(); });
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