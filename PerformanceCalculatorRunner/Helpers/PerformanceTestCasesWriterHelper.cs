using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PerformanceCalculatorRunner.Interfaces;
using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Helpers
{
    public static class PerformanceTestCasesWriterHelper
    {
        public static void WriteToFile(Dictionary<string, IEnumerable<FinalTestResult>> results, ITextFormatter textFormatter, IEnumerable<PerformanceTestCase> testCases, string resultFile)
        {
            WriteToFile(ProcessResultsDataToCsvFormat(results, textFormatter, testCases), resultFile);
        }

        private static void WriteToFile(IEnumerable<string> results, string resultFile)
        {
            using (var file = new StreamWriter(resultFile))
            {
                foreach (var result in results)
                {
                    file.WriteLine(result);
                }
            }
        }

        private static IEnumerable<string> ProcessResultsDataToCsvFormat(Dictionary<string, IEnumerable<FinalTestResult>> results, ITextFormatter textFormatter, IEnumerable<PerformanceTestCase> testCases)
        {
            var dict = new Dictionary<string, StringBuilder>();

            var columnsNames = "cn";
            var columnsNamesSb = new StringBuilder();
            columnsNamesSb.Append("Test Case;Registration Kind;Resolve Count;");
            dict.Add(columnsNames, columnsNamesSb);

            var columnsHeaders = "ch";
            var columnsHeadersSb = new StringBuilder();
            columnsHeadersSb.Append(";;;");
            dict.Add(columnsHeaders, columnsHeadersSb);

            foreach (var testCase in testCases)
            {
                var rowHeader = new StringBuilder();
                var name = $"{testCase.TestCase};{testCase.RegistrationKind};{testCase.TestsCount}";
                rowHeader.Append($"Test {name};");
                dict.Add(name, rowHeader);
            }

            foreach (var result in results)
            {
                dict[columnsNames].Append(textFormatter.GetColumnNameText(result.Key));
                dict[columnsHeaders].Append(textFormatter.GetColumnHeaderText());

                foreach (var testResult in result.Value)
                {
                    var name = $"{testResult.TestCaseName};{testResult.RegistrationKind};{testResult.TestCasesCount}";
                    dict[name].Append(textFormatter.GetResultText(testResult));
                }
            }


            return dict.Select(d => d.Value.ToString()).ToList();
        }
    }
}