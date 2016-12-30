using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC;
using PerformanceCalculator.Containers.TestsNiquIoC_Partial;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsNiquIoC_Partial
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
            //    obj1 = c.Resolve<ITestA>(ResolveKind.PartialEmitFunction);
            //    obj2 = c.Resolve<ITestA>(ResolveKind.PartialEmitFunction);
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


            //var thread1 = new Thread(() => { obj1 = c.Resolve<ITestA>(ResolveKind.PartialEmitFunction); });
            //var thread2 = new Thread(() => { obj2 = c.Resolve<ITestA>(ResolveKind.PartialEmitFunction); });
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