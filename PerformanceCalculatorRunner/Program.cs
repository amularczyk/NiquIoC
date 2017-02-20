using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PerformanceCalculator.Common;
using PerformanceCalculatorRunner.Interfaces;
using PerformanceCalculatorRunner.PerformanceTestsRunners;

namespace PerformanceCalculatorRunner
{
    public class Program
    {
        private static readonly string _processPath = @"C:\study\NiquIoC\PerformanceCalculator\bin\Release\PerformanceCalculator.exe";
        private static readonly string _resultFile = $"PerformanceCalculator_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm")}.csv";

        private static void Main()
        {
            var repetitionsNumber = 1;

            var testCases = PerformanceTestCasesCreaterHelper.CreatePerformanceTestCases();
            var results = PerformanceTestCasesRunnerHelper.RunPerformanceTests(repetitionsNumber, testCases, _processPath);
            PerformanceTestCasesWriterHelper.WriteToFile(results, WriteKind.Resolve, _resultFile);
        }
    }
}