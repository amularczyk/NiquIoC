using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC;
using NiquIoC.Enums;
using PerformanceCalculator.Containers.TestsNiquIoC_Partial;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsNiquIoC_Partial
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

            var obj1 = c.Resolve<ITestB>(ResolveKind.PartialEmitFunction);
            var obj2 = c.Resolve<ITestB>(ResolveKind.PartialEmitFunction);

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

            var obj1 = c.Resolve<ITestB>(ResolveKind.PartialEmitFunction);
            var obj2 = c.Resolve<ITestB>(ResolveKind.PartialEmitFunction);

            Assert.AreNotEqual(obj1, obj2);
            Helper.Check(obj1, false);
            Helper.Check(obj2, false);
        }
    }
}