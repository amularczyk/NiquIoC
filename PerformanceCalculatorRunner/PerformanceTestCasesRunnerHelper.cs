using System;
using System.Collections.Generic;
using System.Linq;
using PerformanceCalculator.Common;
using PerformanceCalculatorRunner.Interfaces;
using PerformanceCalculatorRunner.PerformanceTestsRunners;

namespace PerformanceCalculatorRunner
{
    public static class PerformanceTestCasesRunnerHelper
    {
        public static Dictionary<string, IEnumerable<FinalTestResult>> RunPerformanceTests(int repetitionsNumber, IReadOnlyCollection<PerformanceTestCase> testCases, string processPath)
        {
            var results = new Dictionary<string, IEnumerable<FinalTestResult>>();

            AddPerformanceTests(results, ContainerName.Autofac, new AutofacPerformanceTestsRunner(processPath), repetitionsNumber, testCases);
            AddPerformanceTests(results, ContainerName.DryIoc, new DryIocPeformanceTestsRunner(processPath), repetitionsNumber, testCases);
            AddPerformanceTests(results, ContainerName.LightInject, new LightInjectPeformanceTestsRunner(processPath), repetitionsNumber, testCases);
            AddPerformanceTests(results, ContainerName.NiquIoC, new NiquIoCPeformanceTestsRunner(processPath), repetitionsNumber, testCases);
            AddPerformanceTests(results, ContainerName.NiquIoCFull, new NiquIoCFullPeformanceTestsRunner(processPath), repetitionsNumber, testCases);
            AddPerformanceTests(results, ContainerName.SimpleInjector, new SimpleInjectorPeformanceTestsRunner(processPath), repetitionsNumber, testCases);
            AddPerformanceTests(results, ContainerName.StructureMap, new StructureMapPeformanceTestsRunner(processPath), repetitionsNumber, testCases);
            AddPerformanceTests(results, ContainerName.Unity, new UnityPeformanceTestsRunner(processPath), repetitionsNumber, testCases);
            AddPerformanceTests(results, ContainerName.Windsor, new WindsorPeformanceTestsRunner(processPath), repetitionsNumber, testCases);

            return results;
        }

        private static void AddPerformanceTests(IDictionary<string, IEnumerable<FinalTestResult>> dict, string containerName, IPerformanceTestsRunner performanceTestsRunner, int repetitionsNumber, IEnumerable<PerformanceTestCase> testCases)
        {
            dict.Add(containerName, RunPerformanceTests(containerName, performanceTestsRunner, repetitionsNumber, testCases));
        }

        private static IEnumerable<FinalTestResult> RunPerformanceTests(string containerName, IPerformanceTestsRunner performanceTestsRunner, int repetitionsNumber, IEnumerable<PerformanceTestCase> testCases)
        {
            Console.WriteLine($"{containerName} start");
            var result = ProcessTestResults(performanceTestsRunner.RunTests(repetitionsNumber, testCases));
            Console.WriteLine($"{containerName} end");

            return result;
        }

        private static IEnumerable<FinalTestResult> ProcessTestResults(IEnumerable<List<TestResult>> testResults)
        {
            var finalTestResults = new List<FinalTestResult>();

            foreach (var testResult in testResults)
            {
                finalTestResults.Add(new FinalTestResult
                {
                    RegistrationKind = testResult[0].RegistrationKind,
                    TestCase = testResult[0].TestCaseName,
                    TestCasesCount = testResult[0].TestCasesCount,
                    MinRegisterTime = testResult.Min(t => t.RegisterTime),
                    MinResolveTime = testResult.Min(t => t.ResolveTime),
                    MaxRegisterTime = testResult.Max(t => t.RegisterTime),
                    MaxResolveTime = testResult.Max(t => t.ResolveTime),
                    AvgRegisterTime = (long)Math.Round(testResult.Average(t => t.RegisterTime), 0),
                    AvgResolveTime = (long)Math.Round(testResult.Average(t => t.ResolveTime), 0)
                });
            }

            return finalTestResults;
        }
    }
}