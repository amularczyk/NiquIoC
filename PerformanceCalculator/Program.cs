using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PerformanceCalculator.TestsAutofac;

namespace PerformanceCalculator
{
    internal class Program
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsAutofac" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        private static void Main(string[] args)
        {
            AutofacPerformance(10);
            Console.ReadLine();
        }

        private static void AutofacPerformance(int count)
        {
            var testsResults = new List<IEnumerable<TestResult>>();

            var foo = new AutofacPerformance();
            for (var i = 0; i < count; i++)
            {
                testsResults.Add(foo.DoTests());
            }

            WriteFirstTestResults(_fileName, testsResults.First());
            WriteTestsResults(_fileName, testsResults.Skip(1));
        }

        private static void WriteFirstTestResults(string fileName, IEnumerable<TestResult> testResults)
        {
            foreach (var testResult in testResults)
            {
                Helper.WriteLine(fileName, $"{testResult.Singleton}\t{testResult.TestCasesNumber}\t{testResult.RegisterTime}\t{testResult.ResolveTime}");
            }
        }

        private static void WriteTestsResults(string fileName, IEnumerable<IEnumerable<TestResult>> testsResults)
        {
            foreach (var groupedTestResults in testsResults.SelectMany(t => t).GroupBy(t => new { Singleton = t.Singleton, TestCasesNumber = t.TestCasesNumber }))
            {
                Helper.WriteLine(fileName, $"{groupedTestResults.Key.Singleton}\t{groupedTestResults.Key.TestCasesNumber}\t{groupedTestResults.Average(t => t.RegisterTime)}\t{groupedTestResults.Average(t => t.ResolveTime)}");
            }
        }
    }
}