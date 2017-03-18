using System.Threading;
using Grace.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers;
using PerformanceCalculator.Containers.TestsGrace;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCase.TestCaseD;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsGrace
{
    [TestClass]
    public class TestCaseDTests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new SingletonTestCaseD(new GraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);


            var obj1 = c.Locate<ITestD>();
            var obj2 = c.Locate<ITestD>();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TransientTestCaseD(new GraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);


            var obj1 = c.Locate<ITestD>();
            var obj2 = c.Locate<ITestD>();


            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            ITestCase testCase = new PerThreadTestCaseD(new GraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);
            ITestD obj1 = null;
            ITestD obj2 = null;


            var thread = new Thread(() =>
            {
                using (var scope = c.BeginLifetimeScope())
                {
                    obj1 = scope.Locate<ITestD>();
                    obj2 = scope.Locate<ITestD>();
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
            ITestCase testCase = new PerThreadTestCaseD(new GraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);
            ITestD obj1 = null;
            ITestD obj2 = null;


            var thread1 = new Thread(() =>
            {
                using (var scope = c.BeginLifetimeScope())
                {
                    obj1 = scope.Locate<ITestD>();
                }
            });
            var thread2 = new Thread(() =>
            {
                using (var scope = c.BeginLifetimeScope())
                {
                    obj2 = scope.Locate<ITestD>();
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