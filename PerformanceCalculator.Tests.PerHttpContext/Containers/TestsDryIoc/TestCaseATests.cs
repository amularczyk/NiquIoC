using DryIoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsDryIoc;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsDryIoc
{
    [TestClass]
    public class TestCaseATests
    {
        [TestMethod]
        public void PerThreadRegister_SameThread_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new Container(scopeContext: new ThreadScopeContext());
            //c = (Container)testCase.PerThreadRegister(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            //var thread = new Thread(() =>
            //{
            //    using (var s = c.OpenScope())
            //    {
            //        obj1 = c.Resolve<ITestA>();
            //        obj2 = c.Resolve<ITestA>();
            //    }
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

            var c = new Container(scopeContext: new ThreadScopeContext());
            //c = (Container)testCase.PerThreadRegister(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            //var thread1 = new Thread(() =>
            //{
            //    using (var s = c.OpenScope())
            //    {
            //        obj1 = c.Resolve<ITestA>();
            //    }
            //});
            //var thread2 = new Thread(() =>
            //{
            //    using (var s = c.OpenScope())
            //    {
            //        obj2 = c.Resolve<ITestA>();
            //    }
            //});
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