using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsSimpleInjector;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using SimpleInjector;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsSimpleInjector
{
    [TestClass]
    public class TestCaseATests
    {
        [TestMethod]
        public void PerHttpContextRegister_SameHttpContext_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new Container();
            c = (Container)testCase.PerHttpContextRegister(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            //var thread = new Thread(() =>
            //{
            //    using (c.BeginLifetimeScope())
            //    {
            //        obj1 = c.GetInstance<ITestA>();
            //        obj2 = c.GetInstance<ITestA>();
            //    }
            //});
            //thread.Start();
            //thread.Join();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void PerHttpContextRegister_DifferentThreads_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new Container();
            c = (Container)testCase.PerHttpContextRegister(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            //var thread1 = new Thread(() =>
            //{
            //    using (c.BeginLifetimeScope())
            //    {
            //        obj1 = c.GetInstance<ITestA>();
            //    }
            //});
            //var thread2 = new Thread(() =>
            //{
            //    using (c.BeginLifetimeScope())
            //    {
            //        obj2 = c.GetInstance<ITestA>();
            //    }
            //});
            //thread1.Start();
            //thread1.Join();
            //thread2.Start();
            //thread2.Join();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, false);
        }
    }
}