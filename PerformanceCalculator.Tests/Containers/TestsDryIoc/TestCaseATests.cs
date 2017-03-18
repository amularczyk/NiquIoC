﻿using System.Threading;
using DryIoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers;
using PerformanceCalculator.Containers.TestsDryIoc;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCase.TestCaseA;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsDryIoc
{
    [TestClass]
    public class TestCaseATests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new SingletonTestCaseA(new DryIocRegistration(), new DryIocResolving());


            var c = new Container();
            c = (Container)testCase.Register(c);

            var obj1 = c.Resolve<ITestA>();
            var obj2 = c.Resolve<ITestA>();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TransientTestCaseA(new DryIocRegistration(), new DryIocResolving());


            var c = new Container();
            c = (Container)testCase.Register(c);

            var obj1 = c.Resolve<ITestA>();
            var obj2 = c.Resolve<ITestA>();


            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            ITestCase testCase = new PerThreadTestCaseA(new DryIocRegistration(), new DryIocResolving());

            var c = new Container(scopeContext: new ThreadScopeContext());
            c = (Container)testCase.Register(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            var thread = new Thread(() =>
            {
                using (c.OpenScope())
                {
                    obj1 = c.Resolve<ITestA>();
                    obj2 = c.Resolve<ITestA>();
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
            ITestCase testCase = new PerThreadTestCaseA(new DryIocRegistration(), new DryIocResolving());

            var c = new Container(scopeContext: new ThreadScopeContext());
            c = (Container)testCase.Register(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            var thread1 = new Thread(() =>
            {
                using (c.OpenScope())
                {
                    obj1 = c.Resolve<ITestA>();
                }
            });
            var thread2 = new Thread(() =>
            {
                using (c.OpenScope())
                {
                    obj2 = c.Resolve<ITestA>();
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