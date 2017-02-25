using System.Collections.Generic;
using PerformanceCalculator.Common;
using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Helpers
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


        private static void CreatePerformanceTestCasesB(ICollection<PerformanceTestCase> testCases)
        {
            CreatePerformanceTestCasesBSingleton(testCases);
            CreatePerformanceTestCasesBTransient(testCases);
            CreatePerformanceTestCasesBPerThread(testCases);
        }

        private static void CreatePerformanceTestCasesBSingleton(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 1, TestCase = TestCaseName.B });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 10, TestCase = TestCaseName.B });
        }
        private static void CreatePerformanceTestCasesBTransient(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.B });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 10, TestCase = TestCaseName.B });
        }
        private static void CreatePerformanceTestCasesBPerThread(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.B });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 10, TestCase = TestCaseName.B });
        }

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
    }
}