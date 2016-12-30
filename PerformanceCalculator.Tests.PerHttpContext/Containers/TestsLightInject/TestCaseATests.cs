using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsLightInject;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsLightInject
{
    [TestClass]
    public class TestCaseATests
    {
        [TestMethod]
        public void PerThreadRegister_SameThread_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new ServiceContainer();
            //c = (ServiceContainer)testCase.PerThreadRegister(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            //var thread = new Thread(() =>
            //{
            //    obj1 = c.GetInstance<ITestA>();
            //    obj2 = c.GetInstance<ITestA>();
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

            var c = new ServiceContainer();
            //c = (ServiceContainer)testCase.PerThreadRegister(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            //var thread1 = new Thread(() => { obj1 = c.GetInstance<ITestA>(); });
            //var thread2 = new Thread(() => { obj2 = c.GetInstance<ITestA>(); });
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