using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC;
using NiquIoC.Enums;
using PerformanceCalculator.Containers;
using PerformanceCalculator.Containers.TestsNiquIoC_Full;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsNiquIoC_Full
{
    [TestClass]
    public class TestCaseDTests
    {
        [TestMethod]
        public void RegisterSingleton_Success()
        {
            ITestCase testCase = new TestCaseD(new SingletonNiquIoCFullRegistration(), new NiquIoCFullResolving());


            var c = new Container();
            c = (Container)testCase.Register(c);

            var obj1 = c.Resolve<ITestD>(ResolveKind.FullEmitFunction);
            var obj2 = c.Resolve<ITestD>(ResolveKind.FullEmitFunction);


            CheckHelper.Check(obj1, true);
            CheckHelper.Check(obj2, true);
            CheckHelper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void RegisterTransient_Success()
        {
            ITestCase testCase = new TestCaseD(new TransientNiquIoCFullRegistration(), new NiquIoCFullResolving());


            var c = new Container();
            c = (Container)testCase.Register(c);

            var obj1 = c.Resolve<ITestD>(ResolveKind.FullEmitFunction);
            var obj2 = c.Resolve<ITestD>(ResolveKind.FullEmitFunction);


            CheckHelper.Check(obj1, false);
            CheckHelper.Check(obj2, false);
            CheckHelper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void RegisterPerThread_SameThread_Success()
        {
            ITestCase testCase = new TestCaseD(new PerThreadNiquIoCFullRegistration(), new NiquIoCFullResolving());

            var c = new Container();
            c = (Container)testCase.Register(c);
            ITestD obj1 = null;
            ITestD obj2 = null;


            var thread = new Thread(() =>
            {
                obj1 = c.Resolve<ITestD>(ResolveKind.FullEmitFunction);
                obj2 = c.Resolve<ITestD>(ResolveKind.FullEmitFunction);
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
            ITestCase testCase = new TestCaseD(new PerThreadNiquIoCFullRegistration(), new NiquIoCFullResolving());

            var c = new Container();
            c = (Container)testCase.Register(c);
            ITestD obj1 = null;
            ITestD obj2 = null;


            var thread1 = new Thread(() => { obj1 = c.Resolve<ITestD>(ResolveKind.FullEmitFunction); });
            var thread2 = new Thread(() => { obj2 = c.Resolve<ITestD>(ResolveKind.FullEmitFunction); });
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