using System;
using System.Collections.Generic;
using System.Linq;
using PerformanceCalculator.Common;
using PerformanceCalculatorRunner.Interfaces;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public abstract class PerformanceTestsRunner : IPerformanceTestsRunner
    {
        private readonly string _processPath;

        protected PerformanceTestsRunner(string processPath)
        {
            _processPath = processPath;
        }

        public List<List<TestResult>> RunTests(int repetitionsNumber, IEnumerable<PerformanceTestCase> testCases)
        {
            var testResults = new List<List<TestResult>>();

            var performanceTestCases = testCases as IList<PerformanceTestCase> ?? testCases.ToList();
            foreach (var performanceTestCase in performanceTestCases)
            {
                var testResult = new List<TestResult>();
                for (var i = 0; i < repetitionsNumber; i++)
                {
                    testResult.Add(ConvertToTestResult(RunTests(performanceTestCase.RegistrationKind, performanceTestCase.TestCase, performanceTestCase.TestsCount)));
                }
                testResults.Add(testResult);
            }
            
            return testResults;
        }

        public abstract string RunTests(RegistrationKind registrationKind, string testCase, int testsCount);

        protected string Run(string containerName, RegistrationKind registrationKind, string testCase, int testsCount)
        {
            return ProcessHelper.StartProcess(_processPath, $"{containerName} -r {(int)registrationKind} -t {testCase} -c {testsCount}");
        }

        private TestResult ConvertToTestResult(string result)
        {
            var results = result.Split(' ');
            var testResult = new TestResult();

            for (var i = 1; i < results.Length; i += 2)
            {
                switch (results[i])
                {
                    case "-r":
                        testResult.RegistrationKind = (RegistrationKind)Convert.ToInt32(results[i + 1]);
                        break;

                    case "-t":
                        testResult.TestCase = results[i + 1];
                        break;

                    case "-c":
                        testResult.TestCasesCount = Convert.ToInt32(results[i + 1]);
                        break;

                    case "-reg":
                        testResult.RegisterTime = Convert.ToInt32(results[i + 1]);
                        break;

                    case "-res":
                        testResult.ResolveTime = Convert.ToInt32(results[i + 1]);
                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }

            return testResult;
        }
    }
}