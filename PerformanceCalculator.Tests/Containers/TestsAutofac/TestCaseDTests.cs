using System.Threading;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsAutofac
{
    [TestClass]
    public class TestCaseDTests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new TestCaseD(new SingletonAutofacRegistration(), new AutofacResolving());

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.Register(cb);

            var obj1 = c.Resolve<ITestD>();
            var obj2 = c.Resolve<ITestD>();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TestCaseD(new TransientAutofacRegistration(), new AutofacResolving());

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.Register(cb);

            var obj1 = c.Resolve<ITestD>();
            var obj2 = c.Resolve<ITestD>();


            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            ITestCase testCase = new TestCaseD(new PerThreadAutofacRegistration(), new AutofacResolving());

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.Register(cb);
            ITestD obj1 = null;
            ITestD obj2 = null;


            var thread = new Thread(() =>
            {
                using (var threadLifetime = c.BeginLifetimeScope())
                {
                    obj1 = threadLifetime.Resolve<ITestD>();
                    obj2 = threadLifetime.Resolve<ITestD>();
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
            ITestCase testCase = new TestCaseD(new PerThreadAutofacRegistration(), new AutofacResolving());

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.Register(cb);
            ITestD obj1 = null;
            ITestD obj2 = null;


            var thread1 = new Thread(() =>
            {
                using (var threadLifetime = c.BeginLifetimeScope())
                {
                    obj1 = threadLifetime.Resolve<ITestD>();
                }
            });
            var thread2 = new Thread(() =>
            {
                using (var threadLifetime = c.BeginLifetimeScope())
                {
                    obj2 = threadLifetime.Resolve<ITestD>();
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