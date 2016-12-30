using DryIoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsDryIoc;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsDryIoc
{
    [TestClass]
    public class TestCaseCTests
    {
        [TestMethod]
        public void PerHttpContextRegister_SameHttpContext_Success()
        {
            ITestCase testCase = new TestCaseC();

            var c = new Container(scopeContext: new ThreadScopeContext());
            c = (Container)testCase.PerHttpContextRegister(c);
            ITestC obj1 = null;
            ITestC obj2 = null;


            //var thread = new Thread(() =>
            //{
            //    using (var s = c.OpenScope())
            //    {
            //        obj1 = c.Resolve<ITestC>();
            //        obj2 = c.Resolve<ITestC>();
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

            var c = new Container(scopeContext: new ThreadScopeContext());
            c = (Container)testCase.PerHttpContextRegister(c);
            ITestC obj1 = null;
            ITestC obj2 = null;


            //var thread1 = new Thread(() =>
            //{
            //    using (var s = c.OpenScope())
            //    {
            //        obj1 = c.Resolve<ITestC>();
            //    }
            //});
            //var thread2 = new Thread(() =>
            //{
            //    using (var s = c.OpenScope())
            //    {
            //        obj2 = c.Resolve<ITestC>();
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