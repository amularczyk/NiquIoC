using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsLightInject;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsLightInject
{
    [TestClass]
    public class TestCaseATests
    {
        [TestMethod]
        public void SingletonRegister_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.SingletonRegister(c);

            var obj1 = c.GetInstance<ITestA>();
            var obj2 = c.GetInstance<ITestA>();

            Assert.AreEqual(obj1, obj2);
            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
        }

        [TestMethod]
        public void TransientRegister_Success()
        {
            ITestCase testCase = new TestCaseA();

            var c = new ServiceContainer();
            c = (ServiceContainer)testCase.TransientRegister(c);

            var obj1 = c.GetInstance<ITestA>();
            var obj2 = c.GetInstance<ITestA>();

            Assert.AreNotEqual(obj1, obj2);
            Helper.Check(obj1, false);
            Helper.Check(obj2, false);
        }
    }
}