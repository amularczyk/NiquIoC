using System;
using PerformanceCalculator.Common;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator
{
    public class Program
    {
        private static int Main(string[] args)
        {
            var argsCount = 7;
            if (args.Length != argsCount)
            {
                return 1;
            }

            IWriteTestResults writeTestResults = new ConsoleWriteTestResults();

            var arguments = new PerformanceCalculatorArguments(args);
            var performanceTest = PerformanceTestFactory.GetPerformance(arguments.Name);

            var testResult = RunPerformanceTests(performanceTest, arguments.Count, arguments.TestCase, arguments.RegistrationKind);

            writeTestResults.Write(testResult);

            return 0;
        }

        private static TestResult RunPerformanceTests(IPerformanceTest performanceTest, int count, string testCase, RegistrationKind registrationKind)
        {
            WarmUpPerformanceTest(performanceTest, testCase, registrationKind);
            return performanceTest.RunTest(count, testCase, registrationKind);
        }

        private static void WarmUpPerformanceTest(IPerformanceTest performanceTest, string testCase, RegistrationKind registrationKind)
        {
            performanceTest.RunTest(1, testCase, registrationKind);
        }
    }
}