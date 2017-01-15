using System;
using System.Collections.Generic;
using PerformanceCalculator.Common;
using PerformanceCalculatorRunner.Interfaces;

namespace PerformanceCalculatorRunner
{
    public abstract class RunPerformanceTests : IRunPerformanceTests
    {
        private readonly string _processPath;

        protected RunPerformanceTests(string processPath)
        {
            _processPath = processPath;
        }

        public abstract List<List<TestResult>> RunTests(int repetitionsNumber);

        protected string Run(string containerName, RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return ProcessHelper.StartProcess(_processPath, $"{containerName} -r {registrationKind} -c {testsCount} -t {testCase}");
        }

        protected TestResult ConvertToTestResult(string result)
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