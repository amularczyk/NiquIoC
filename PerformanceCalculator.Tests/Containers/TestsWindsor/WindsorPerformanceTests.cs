using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Common;
using PerformanceCalculator.Containers.TestsWindsor;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Tests.Containers.TestsWindsor
{
    [TestClass]
    public class WindsorPerformanceTests
    {
        private IPerformanceTest GetPerformance()
        {
            return new WindsorPerformanceTest();
        }

        [TestMethod]
        public void DoTestA_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.DoTest(1, TestCaseName.A, RegistrationKind.Singleton);
        }

        [TestMethod]
        public void DoTestA_Transient_Success()
        {
            var performance = GetPerformance();
            performance.DoTest(1, TestCaseName.A, RegistrationKind.Transient);
        }

        [TestMethod]
        public void DoTestB_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.DoTest(1, TestCaseName.B, RegistrationKind.Singleton);
        }

        [TestMethod]
        public void DoTestB_Transient_Success()
        {
            var performance = GetPerformance();
            performance.DoTest(1, TestCaseName.B, RegistrationKind.Transient);
        }

        [TestMethod]
        public void DoTestC_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.DoTest(1, TestCaseName.C, RegistrationKind.Singleton);
        }

        [TestMethod]
        public void DoTestC_Transient_Success()
        {
            var performance = GetPerformance();
            performance.DoTest(1, TestCaseName.C, RegistrationKind.Transient);
        }
    }
}
