using System.Threading;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsUnity;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsUnity
{
    [TestClass]
    public class TestCaseATests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new SingletonTestCaseA();


            var c = new UnityContainer();
            c = (UnityContainer)testCase.Register(c);

            var obj1 = c.Resolve<ITestA>();
            var obj2 = c.Resolve<ITestA>();

            
            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TransientTestCaseA();


            var c = new UnityContainer();
            c = (UnityContainer)testCase.Register(c);

            var obj1 = c.Resolve<ITestA>();
            var obj2 = c.Resolve<ITestA>();

            
            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            ITestCase testCase = new PerThreadTestCaseA();

            var c = new UnityContainer();
            c = (UnityContainer)testCase.Register(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            var thread = new Thread(() =>
            {
                obj1 = c.Resolve<ITestA>();
                obj2 = c.Resolve<ITestA>();
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
            ITestCase testCase = new PerThreadTestCaseA();

            var c = new UnityContainer();
            c = (UnityContainer)testCase.Register(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            var thread1 = new Thread(() => { obj1 = c.Resolve<ITestA>(); });
            var thread2 = new Thread(() => { obj2 = c.Resolve<ITestA>(); });
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