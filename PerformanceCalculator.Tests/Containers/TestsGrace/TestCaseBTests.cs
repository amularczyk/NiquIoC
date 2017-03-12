using System.Threading;
using Grace.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers;
using PerformanceCalculator.Containers.TestsGrace;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsGrace
{
    [TestClass]
    public class TestCaseBTests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new TestCaseB(new SingletonGraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);


            var obj1 = c.Locate<ITestB>();
            var obj2 = c.Locate<ITestB>();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TestCaseB(new TransientGraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);


            var obj1 = c.Locate<ITestB>();
            var obj2 = c.Locate<ITestB>();


            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            ITestCase testCase = new TestCaseB(new PerThreadGraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);
            ITestB obj1 = null;
            ITestB obj2 = null;


            var thread = new Thread(() =>
            {
                using (var scope = c.BeginLifetimeScope())
                {
                    obj1 = scope.Locate<ITestB>();
                    obj2 = scope.Locate<ITestB>();
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
            ITestCase testCase = new TestCaseB(new PerThreadGraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);
            ITestB obj1 = null;
            ITestB obj2 = null;


            var thread1 = new Thread(() =>
            {
                using (var scope = c.BeginLifetimeScope())
                {
                    obj1 = scope.Locate<ITestB>();
                }
            });
            var thread2 = new Thread(() =>
            {
                using (var scope = c.BeginLifetimeScope())
                {
                    obj2 = scope.Locate<ITestB>();
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