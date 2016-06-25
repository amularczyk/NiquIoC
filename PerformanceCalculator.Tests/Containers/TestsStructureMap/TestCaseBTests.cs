using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsStructureMap;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using StructureMap;

namespace PerformanceCalculator.Tests.Containers.TestsStructureMap
{
    [TestClass]
    public class TestCaseBTests
    {
        [TestMethod]
        public void SingletonRegister_Success()
        {
            ITestCase testCase = new TestCaseB();

            var c = new Container();
            c = (Container)testCase.SingletonRegister(c);

            var obj1 = c.GetInstance<ITestB>();
            var obj2 = c.GetInstance<ITestB>();

            Assert.AreEqual(obj1, obj2);
            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
        }

        [TestMethod]
        public void TransientRegister_Success()
        {
            ITestCase testCase = new TestCaseB();

            var c = new Container();
            c = (Container)testCase.TransientRegister(c);

            var obj1 = c.GetInstance<ITestB>();
            var obj2 = c.GetInstance<ITestB>();

            Assert.AreNotEqual(obj1, obj2);
            Helper.Check(obj1, false);
            Helper.Check(obj2, false);
        }
    }
}