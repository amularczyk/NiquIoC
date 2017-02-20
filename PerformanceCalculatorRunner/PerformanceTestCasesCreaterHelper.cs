using System.Collections.Generic;
using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner
{
    public static class PerformanceTestCasesCreaterHelper
    {
        public static List<PerformanceTestCase> CreatePerformanceTestCases()
        {
            var testCases = new List<PerformanceTestCase>();

            CreatePerformanceTestCasesA(testCases);
            CreatePerformanceTestCasesB(testCases);
            CreatePerformanceTestCasesC(testCases);

            return testCases;
        }

        private static void CreatePerformanceTestCasesA(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 100, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 10, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 100, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1000, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 10, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 100, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1000, TestCase = TestCaseName.A });
        }

        private static void CreatePerformanceTestCasesB(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 1, TestCase = TestCaseName.B });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.B });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 10, TestCase = TestCaseName.B });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.B });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 10, TestCase = TestCaseName.B });
        }

        private static void CreatePerformanceTestCasesC(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 100, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 10, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 100, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1000, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 10, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 100, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1000, TestCase = TestCaseName.C });
        }
    }
}