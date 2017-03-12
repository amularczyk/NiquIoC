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
    public class TestCaseATests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new TestCaseA(new SingletonGraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);


            var obj1 = c.Locate<ITestA>();
            var obj2 = c.Locate<ITestA>();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TestCaseA(new TransientGraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);


            var obj1 = c.Locate<ITestA>();
            var obj2 = c.Locate<ITestA>();


            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            ITestCase testCase = new TestCaseA(new PerThreadGraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            var thread = new Thread(() =>
            {
                using (var scope = c.BeginLifetimeScope())
                {
                    obj1 = scope.Locate<ITestA>();
                    obj2 = scope.Locate<ITestA>();
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
            ITestCase testCase = new TestCaseA(new PerThreadGraceRegistration(), new GraceResolving());

            var c = new DependencyInjectionContainer();
            c = (DependencyInjectionContainer)testCase.Register(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            var thread1 = new Thread(() =>
            {
                using (var scope = c.BeginLifetimeScope())
                {
                    obj1 = scope.Locate<ITestA>();
                }
            });
            var thread2 = new Thread(() =>
            {
                using (var scope = c.BeginLifetimeScope())
                {
                    obj2 = scope.Locate<ITestA>();
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