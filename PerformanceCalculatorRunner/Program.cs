using System;
using PerformanceCalculatorRunner.Helpers;
using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner
{
    public class Program
    {
        private static readonly string _processPath = @"C:\study\NiquIoC\PerformanceCalculator\bin\Release\PerformanceCalculator.exe";
        private static readonly string _resultFile = $"PerformanceCalculator_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm")}.csv";

        private static void Main(string[] args)
        {
            var repetitionsNumber = 1;

            var argsCount = 1;
            if (args.Length == argsCount)
            {
                int.TryParse(args[0], out repetitionsNumber);
            }

            var testCases = PerformanceTestCasesCreaterHelper.CreatePerformanceTestCases();
            var results = PerformanceTestCasesRunnerHelper.RunPerformanceTests(repetitionsNumber, testCases, _processPath);
            PerformanceTestCasesWriterHelper.WriteToFile(results, TextFormatterFactory.GetTextFormatter(WriteKind.Resolve), testCases, _resultFile);
        }
    }
}