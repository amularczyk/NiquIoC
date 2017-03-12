using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Common;
using PerformanceCalculator.Containers.TestsSimpleInjector;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Tests.Containers.TestsSimpleInjector
{
    [TestClass]
    public class SimpleInjectorTestCaseFactoryTests
    {
        public class FakeSimpleInjectorPerformanceTest : SimpleInjectorPerformanceTest
        {
            public ITestCase CaseFactoryMock(string testCase, RegistrationKind registrationKind)
            {
                return GetTestCase(testCase, registrationKind);
            }
        }

        private FakeSimpleInjectorPerformanceTest GetPerformance()
        {
            return new FakeSimpleInjectorPerformanceTest();
        }

        [TestMethod]
        public void TestCaseFactory_TestCaseA_Singleton_Success()
        {
            var performance = GetPerformance();

            var testCase = performance.CaseFactoryMock(TestCaseName.A, RegistrationKind.Singleton);

            Assert.IsInstanceOfType(testCase, typeof(SingletonTestCaseA));
        }

        [TestMethod]
        public void TestCaseFactory_TestCaseA_Transient_Success()
        {
            var performance = GetPerformance();

            var testCase = performance.CaseFactoryMock(TestCaseName.A, RegistrationKind.Transient);

            Assert.IsInstanceOfType(testCase, typeof(TransientTestCaseA));
        }

        [TestMethod]
        public void TestCaseFactory_TestCaseA_PerThread_Success()
        {
            var performance = GetPerformance();

            var testCase = performance.CaseFactoryMock(TestCaseName.A, RegistrationKind.PerThread);

            Assert.IsInstanceOfType(testCase, typeof(PerThreadTestCaseA));
        }

        [TestMethod]
        public void TestCaseFactory_TestCaseB_Singleton_Success()
        {
            var performance = GetPerformance();

            var testCase = performance.CaseFactoryMock(TestCaseName.B, RegistrationKind.Singleton);

            Assert.IsInstanceOfType(testCase, typeof(SingletonTestCaseB));
        }

        [TestMethod]
        public void TestCaseFactory_TestCaseB_Transient_Success()
        {
            var performance = GetPerformance();

            var testCase = performance.CaseFactoryMock(TestCaseName.B, RegistrationKind.Transient);

            Assert.IsInstanceOfType(testCase, typeof(TransientTestCaseB));
        }

        [TestMethod]
        public void TestCaseFactory_TestCaseB_PerThread_Success()
        {
            var performance = GetPerformance();

            var testCase = performance.CaseFactoryMock(TestCaseName.B, RegistrationKind.PerThread);

            Assert.IsInstanceOfType(testCase, typeof(PerThreadTestCaseB));
        }

        [TestMethod]
        public void TestCaseFactory_TestCaseC_Singleton_Success()
        {
            var performance = GetPerformance();

            var testCase = performance.CaseFactoryMock(TestCaseName.C, RegistrationKind.Singleton);

            Assert.IsInstanceOfType(testCase, typeof(SingletonTestCaseC));
        }

        [TestMethod]
        public void TestCaseFactory_TestCaseC_Transient_Success()
        {
            var performance = GetPerformance();

            var testCase = performance.CaseFactoryMock(TestCaseName.C, RegistrationKind.Transient);

            Assert.IsInstanceOfType(testCase, typeof(TransientTestCaseC));
        }

        [TestMethod]
        public void TestCaseFactory_TestCaseC_PerThread_Success()
        {
            var performance = GetPerformance();

            var testCase = performance.CaseFactoryMock(TestCaseName.C, RegistrationKind.PerThread);

            Assert.IsInstanceOfType(testCase, typeof(PerThreadTestCaseC));
        }
    }
}