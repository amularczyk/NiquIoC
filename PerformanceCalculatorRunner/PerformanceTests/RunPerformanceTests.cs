using System;
using System.Collections.Generic;
using System.Linq;
using PerformanceCalculator.Common;
using PerformanceCalculatorRunner.Interfaces;

namespace PerformanceCalculatorRunner.PerformanceTests
{
    public abstract class RunPerformanceTests : IRunPerformanceTests
    {
        private readonly string _processPath;

        protected RunPerformanceTests(string processPath)
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
                    testResult.Add(ConvertToTestResult(RunTests(performanceTestCase.RegistrationKind, performanceTestCase.TestsCount, performanceTestCase.TestCase)));
                }
                testResults.Add(testResult);
            }
            
            return testResults;
        }

        public abstract string RunTests(RegistrationKind registrationKind, int testsCount, string testCase);

        protected string Run(string containerName, RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return ProcessHelper.StartProcess(_processPath, $"{containerName} -r {registrationKind} -c {testsCount} -t {testCase}");
        }

        private TestResult ConvertToTestResult(string result)
        {
            var results = result.Split(' ');
            var testResult = new TestResult
            {
                RegistrationKind = (RegistrationKind)Convert.ToInt32(results[0]), TestCasesNumber = Convert.ToInt32(results[1]), RegisterTime = Convert.ToInt64(results[2]), ResolveTime = Convert.ToInt64(results[3])
            };

            return testResult;
        }
    }
}