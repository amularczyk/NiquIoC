using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsStructureMap;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using PerformanceCalculator.Tests.Interfaces;
using StructureMap;

namespace PerformanceCalculator.Tests.Containers.TestsStructureMap
{
    [TestClass]
    public class TestCaseATests : ITestCaseATests
    {
        [TestMethod]
        public void SingletonRegister_Success()
        {
            ITestCase testCase = new TestCaseA();


            var c = new Container();
            c = (Container)testCase.SingletonRegister(c);

            var obj1 = c.GetInstance<ITestA>();
            var obj2 = c.GetInstance<ITestA>();

            
            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void TransientRegister_Success()
        {
            ITestCase testCase = new TestCaseA();


            var c = new Container();
            c = (Container)testCase.TransientRegister(c);

            var obj1 = c.GetInstance<ITestA>();
            var obj2 = c.GetInstance<ITestA>();

            
            Helper.Check(obj1, false);
            Helper.Check(obj2, false);
            Helper.Check(obj1, obj2, false);
        }

        [TestMethod]
        public void PerThreadRegister_SameThread_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new Container();
            c = (Container)testCase.PerThreadRegister(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            var thread = new Thread(() =>
            {
                obj1 = c.GetInstance<ITestA>();
                obj2 = c.GetInstance<ITestA>();
            });
            thread.Start();
            thread.Join();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, true);
        }

        [TestMethod]
        public void PerThreadRegister_DifferentThreads_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new Container();
            c = (Container)testCase.PerThreadRegister(c);
            ITestA obj1 = null;
            ITestA obj2 = null;


            var thread1 = new Thread(() => { obj1 = c.GetInstance<ITestA>(); });
            var thread2 = new Thread(() => { obj2 = c.GetInstance<ITestA>(); });
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();


            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
            Helper.Check(obj1, obj2, false);
        }
    }
}