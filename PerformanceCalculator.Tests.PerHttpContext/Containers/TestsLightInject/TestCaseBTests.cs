using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsLightInject;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsLightInject
{
    [TestClass]
    public class TestCaseBTests
    {
        [TestMethod]
        public void PerHttpContextRegister_SameHttpContext_Success()
        {
            //throw new NotImplementedException("Process not ending - need to investigate it");
            ITestCase testCase = new TestCaseB();

            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.PerHttpContextRegister(c);
            ITestB obj1 = null;
            ITestB obj2 = null;


            //var thread = new Thread(() =>
            //{
            //    obj1 = c.GetInstance<ITestB>();
            //    obj2 = c.GetInstance<ITestB>();
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
            //throw new NotImplementedException("Process not ending - need to investigate it");
            ITestCase testCase = new TestCaseB();

            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.PerHttpContextRegister(c);
            ITestB obj1 = null;
            ITestB obj2 = null;


            //var thread1 = new Thread(() => { obj1 = c.GetInstance<ITestB>(); });
            //var thread2 = new Thread(() => { obj2 = c.GetInstance<ITestB>(); });
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