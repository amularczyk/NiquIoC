using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsAutofac
{
    [TestClass]
    public class TestCaseBTests
    {
        [TestMethod]
        public void PerThreadRegister_SameThread_Success()
        {
            ITestCase testCase = new TestCaseB();

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.PerThreadRegister(cb);
            ITestB obj1 = null;
            ITestB obj2 = null;


            //var thread = new Thread(() =>
            //{
            //    using (var threadLifetime = c.BeginLifetimeScope())
            //    {
            //        obj1 = threadLifetime.Resolve<ITestB>();
            //        obj2 = threadLifetime.Resolve<ITestB>();
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
            ITestCase testCase = new TestCaseB();

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.PerThreadRegister(cb);
            ITestB obj1 = null;
            ITestB obj2 = null;


            //var thread1 = new Thread(() =>
            //{
            //    using (var threadLifetime = c.BeginLifetimeScope())
            //    {
            //        obj1 = threadLifetime.Resolve<ITestB>();
            //    }
            //});
            //var thread2 = new Thread(() =>
            //{
            //    using (var threadLifetime = c.BeginLifetimeScope())
            //    {
            //        obj2 = threadLifetime.Resolve<ITestB>();
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