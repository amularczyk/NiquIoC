using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Common;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Tests.Containers.TestsAutofac
{
    [TestClass]
    public class AutofacPerformanceTests
    {
        private IPerformanceTest GetPerformance()
        {
            return new AutofacPerformanceTest();
        }

        [TestMethod]
        public void DoTestA_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.A, RegistrationKind.Singleton);
        }

        [TestMethod]
        public void DoTestA_Transient_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.A, RegistrationKind.Transient);
        }

        [TestMethod]
        public void DoTestA_PerThread_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.A, RegistrationKind.PerThread);
        }

        [TestMethod]
        public void DoTestD_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.D, RegistrationKind.Singleton);
        }

        [TestMethod]
        public void DoTestD_Transient_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.D, RegistrationKind.Transient);
        }

        [TestMethod]
        public void DoTestD_PerThread_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.D, RegistrationKind.PerThread);
        }

        [TestMethod]
        public void DoTestB_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.B, RegistrationKind.Singleton);
        }

        [TestMethod]
        public void DoTestB_Transient_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.B, RegistrationKind.Transient);
        }

        [TestMethod]
        public void DoTestB_PerThread_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.B, RegistrationKind.PerThread);
        }
    }
}
