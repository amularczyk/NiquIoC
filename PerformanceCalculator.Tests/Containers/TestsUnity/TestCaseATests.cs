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
        public void SingletonRegister_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new UnityContainer();
            c = (UnityContainer)testCase.SingletonRegister(c);

            var obj1 = c.Resolve<ITestA>();
            var obj2 = c.Resolve<ITestA>();

            Assert.AreEqual(obj1, obj2);
            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
        }

        [TestMethod]
        public void TransientRegister_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new UnityContainer();
            c = (UnityContainer)testCase.TransientRegister(c);

            var obj1 = c.Resolve<ITestA>();
            var obj2 = c.Resolve<ITestA>();

            Assert.AreNotEqual(obj1, obj2);
            Helper.Check(obj1, false);
            Helper.Check(obj2, false);
        }
    }
}