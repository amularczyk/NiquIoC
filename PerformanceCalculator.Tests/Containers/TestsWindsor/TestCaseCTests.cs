using System.Threading;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers;
using PerformanceCalculator.Containers.TestsWindsor;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsWindsor
{
    [TestClass]
    public class TestCaseCTests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new TestCaseC(new SingletonWindsorRegistration(), new WindsorResolving());


            var c = new WindsorContainer();
            c = (WindsorContainer)testCase.Register(c);

            var obj1 = c.Resolve<ITestC>();
            var obj2 = c.Resolve<ITestC>();


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TestCaseC(new TransientWindsorRegistration(), new WindsorResolving());


            var c = new WindsorContainer();
            c = (WindsorContainer)testCase.Register(c);

            var obj1 = c.Resolve<ITestC>();
            var obj2 = c.Resolve<ITestC>();


            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            ITestCase testCase = new TestCaseC(new PerThreadWindsorRegistration(), new WindsorResolving());

            var c = new WindsorContainer();
            c = (WindsorContainer)testCase.Register(c);
            ITestC obj1 = null;
            ITestC obj2 = null;


            var thread = new Thread(() =>
            {
                obj1 = c.Resolve<ITestC>();
                obj2 = c.Resolve<ITestC>();
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
            ITestCase testCase = new TestCaseC(new PerThreadWindsorRegistration(), new WindsorResolving());

            var c = new WindsorContainer();
            c = (WindsorContainer)testCase.Register(c);
            ITestC obj1 = null;
            ITestC obj2 = null;


            var thread1 = new Thread(() => { obj1 = c.Resolve<ITestC>(); });
            var thread2 = new Thread(() => { obj2 = c.Resolve<ITestC>(); });
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