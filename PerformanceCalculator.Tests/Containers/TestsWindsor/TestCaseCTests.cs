using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsWindsor;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsWindsor
{
    [TestClass]
    public class TestCaseCTests
    {
        [TestMethod]
        public void SingletonRegister_Success()
        {
            ITestCase testCase = new TestCaseC();

            var c = new WindsorContainer();
            c = (WindsorContainer)testCase.SingletonRegister(c);

            var obj1 = c.Resolve<ITestC>();
            var obj2 = c.Resolve<ITestC>();

            Assert.AreEqual(obj1, obj2);
            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
        }

        [TestMethod]
        public void TransientRegister_Success()
        {
            ITestCase testCase = new TestCaseC();

            var c = new WindsorContainer();
            c = (WindsorContainer)testCase.TransientRegister(c);

            var obj1 = c.Resolve<ITestC>();
            var obj2 = c.Resolve<ITestC>();

            Assert.AreNotEqual(obj1, obj2);
            Helper.Check(obj1, false);
            Helper.Check(obj2, false);
        }
    }
}