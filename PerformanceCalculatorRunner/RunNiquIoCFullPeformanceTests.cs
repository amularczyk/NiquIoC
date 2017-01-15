using System;
using System.Collections.Generic;
using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner
{
    public class RunNiquIoCFullPeformanceTests : RunPerformanceTests
    {
        public RunNiquIoCFullPeformanceTests(string processPath)
            : base(processPath)
        {
        }

        public override List<List<TestResult>> RunTests(int repetitionsNumber)
        {
            Console.WriteLine("NiquIoCFull - Start");
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>()
            };

            for (var i = 0; i < repetitionsNumber; i++)
            {
                testResults[0].Add(ConvertToTestResult(RunTests(RegistrationKind.Singleton, 100, TestCaseName.A)));
                testResults[1].Add(ConvertToTestResult(RunTests(RegistrationKind.Transient, 1, TestCaseName.A)));
                testResults[2].Add(ConvertToTestResult(RunTests(RegistrationKind.Transient, 10, TestCaseName.A)));
                testResults[3].Add(ConvertToTestResult(RunTests(RegistrationKind.Transient, 100, TestCaseName.A)));
                testResults[4].Add(ConvertToTestResult(RunTests(RegistrationKind.Transient, 1000, TestCaseName.A)));

                testResults[5].Add(ConvertToTestResult(RunTests(RegistrationKind.Singleton, 1, TestCaseName.B)));
                testResults[6].Add(ConvertToTestResult(RunTests(RegistrationKind.Transient, 1, TestCaseName.B)));
                testResults[7].Add(ConvertToTestResult(RunTests(RegistrationKind.Transient, 10, TestCaseName.B)));

                testResults[8].Add(ConvertToTestResult(RunTests(RegistrationKind.Singleton, 100, TestCaseName.C)));
                testResults[9].Add(ConvertToTestResult(RunTests(RegistrationKind.Transient, 1, TestCaseName.C)));
                testResults[10].Add(ConvertToTestResult(RunTests(RegistrationKind.Transient, 10, TestCaseName.C)));
                testResults[11].Add(ConvertToTestResult(RunTests(RegistrationKind.Transient, 100, TestCaseName.C)));
                testResults[12].Add(ConvertToTestResult(RunTests(RegistrationKind.Transient, 1000, TestCaseName.C)));
            }

            Console.WriteLine("NiquIoCFull - End");
            return testResults;
        }

        public string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.NiquIoCFull, registrationKind, testsCount, testCase);
        }
    }
}