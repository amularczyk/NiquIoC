using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsSimpleInjector;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using SimpleInjector;

namespace PerformanceCalculator.Tests.Containers.TestsSimpleInjector
{
    [TestClass]
    public class TestCaseATests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new SingletonTestCaseA();


            var c = new Container();
            c = (Container)testCase.Register(c);

            var obj1 = c.GetInstance<ITestA>();
            var obj2 = c.GetInstance<ITestA>();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TransientTestCaseA();

            var c = new Container();
            c = (Container)testCase.Register(c);


            var obj1 = c.GetInstance<ITestA>();
            var obj2 = c.GetInstance<ITestA>();


            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            ITestCase testCase = new PerThreadTestCaseA();

            var c = new Container();
            c = (Container)testCase.Register(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            var thread = new Thread(() =>
            {
                using (c.BeginLifetimeScope())
                {
                    obj1 = c.GetInstance<ITestA>();
                    obj2 = c.GetInstance<ITestA>();
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
            ITestCase testCase = new PerThreadTestCaseA();

            var c = new Container();
            c = (Container)testCase.Register(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            var thread1 = new Thread(() =>
            {
                using (c.BeginLifetimeScope())
                {
                    obj1 = c.GetInstance<ITestA>();
                }
            });
            var thread2 = new Thread(() =>
            {
                using (c.BeginLifetimeScope())
                {
                    obj2 = c.GetInstance<ITestA>();
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