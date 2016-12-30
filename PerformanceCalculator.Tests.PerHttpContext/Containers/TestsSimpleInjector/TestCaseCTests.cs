using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsSimpleInjector;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using SimpleInjector;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsSimpleInjector
{
    [TestClass]
    public class TestCaseCTests
    {
        [TestMethod]
        public void PerHttpContextRegister_SameHttpContext_Success()
        {
            ITestCase testCase = new TestCaseC();

            var c = new Container();
            c = (Container)testCase.PerHttpContextRegister(c);
            ITestC obj1 = null;
            ITestC obj2 = null;


            //var thread = new Thread(() =>
            //{
            //    using (c.BeginLifetimeScope())
            //    {
            //        obj1 = c.GetInstance<ITestC>();
            //        obj2 = c.GetInstance<ITestC>();
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
            ITestCase testCase = new TestCaseC();

            var c = new Container();
            c = (Container)testCase.PerHttpContextRegister(c);
            ITestC obj1 = null;
            ITestC obj2 = null;


            //var thread1 = new Thread(() =>
            //{
            //    using (c.BeginLifetimeScope())
            //    {
            //        obj1 = c.GetInstance<ITestC>();
            //    }
            //});
            //var thread2 = new Thread(() =>
            //{
            //    using (c.BeginLifetimeScope())
            //    {
            //        obj2 = c.GetInstance<ITestC>();
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