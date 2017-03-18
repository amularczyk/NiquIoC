using System.Collections.Generic;
using PerformanceCalculator.Common;
using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Helpers
{
    public static class PerformanceTestCasesCreaterHelper
    {
        public static List<PerformanceTestCase> CreatePerformanceTestCasesForRegister()
        {
            var testCases = new List<PerformanceTestCase>();

            CreatePerformanceTestCasesAForRegister(testCases);
            CreatePerformanceTestCasesDForRegister(testCases);
            CreatePerformanceTestCasesCForRegister(testCases);

            return testCases;
        }

        #region CreatePerformanceTestCasesForRegister
        private static void CreatePerformanceTestCasesAForRegister(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 1, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.A });
        }

        private static void CreatePerformanceTestCasesCForRegister(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 1, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.C });
        }

        private static void CreatePerformanceTestCasesDForRegister(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 1, TestCase = TestCaseName.D });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.D });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.D });
        }
        #endregion CreatePerformanceTestCasesForRegister

        public static List<PerformanceTestCase> CreatePerformanceTestCases()
        {
            var testCases = new List<PerformanceTestCase>();

            CreatePerformanceTestCasesA(testCases);
            CreatePerformanceTestCasesD(testCases);
            CreatePerformanceTestCasesC(testCases);

            return testCases;
        }

        #region CreatePerformanceTestCasesA
        private static void CreatePerformanceTestCasesA(ICollection<PerformanceTestCase> testCases)
        {
            CreatePerformanceTestCasesASingleton(testCases);
            CreatePerformanceTestCasesATransient(testCases);
            CreatePerformanceTestCasesAPerThread(testCases);
        }

        private static void CreatePerformanceTestCasesASingleton(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 1, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 10, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 100, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 1000, TestCase = TestCaseName.A });
        }

        private static void CreatePerformanceTestCasesATransient(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 10, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 100, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1000, TestCase = TestCaseName.A });
        }

        private static void CreatePerformanceTestCasesAPerThread(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 10, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 100, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1009, TestCase = TestCaseName.A });
        }
        #endregion CreatePerformanceTestCasesA

        #region CreatePerformanceTestCasesC
        private static void CreatePerformanceTestCasesC(ICollection<PerformanceTestCase> testCases)
        {
            CreatePerformanceTestCasesCSingleton(testCases);
            CreatePerformanceTestCasesCTransient(testCases);
            CreatePerformanceTestCasesCPerThread(testCases);
        }

        private static void CreatePerformanceTestCasesCSingleton(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 1, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 10, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 100, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 1000, TestCase = TestCaseName.C });
        }

        private static void CreatePerformanceTestCasesCTransient(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 10, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 100, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1000, TestCase = TestCaseName.C });
        }

        private static void CreatePerformanceTestCasesCPerThread(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 10, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 100, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1000, TestCase = TestCaseName.C });
        }
        #endregion CreatePerformanceTestCasesC

        #region CreatePerformanceTestCasesD
        private static void CreatePerformanceTestCasesD(ICollection<PerformanceTestCase> testCases)
        {
            CreatePerformanceTestCasesDSingleton(testCases);
            CreatePerformanceTestCasesDTransient(testCases);
            CreatePerformanceTestCasesDPerThread(testCases);
        }

        private static void CreatePerformanceTestCasesDSingleton(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 1, TestCase = TestCaseName.D });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 10, TestCase = TestCaseName.D });
        }

        private static void CreatePerformanceTestCasesDTransient(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.D });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 10, TestCase = TestCaseName.D });
        }

        private static void CreatePerformanceTestCasesDPerThread(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.D });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 10, TestCase = TestCaseName.D });
        }
        #endregion CreatePerformanceTestCasesD
    }
}