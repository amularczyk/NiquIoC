using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Writers
{
    public abstract class CsvHorizontalFileWriter : FileWriter
    {
        protected CsvHorizontalFileWriter(string resultFile) : base(resultFile)
        {
        }

        public override void Write(Dictionary<string, IEnumerable<FinalTestResult>> results, IEnumerable<PerformanceTestCase> testCases)
        {
            WriteToFile(ProcessResultsDataToCsvFormat(results, testCases));
        }

        private IEnumerable<string> ProcessResultsDataToCsvFormat(Dictionary<string, IEnumerable<FinalTestResult>> results, IEnumerable<PerformanceTestCase> testCases)
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
                dict[columnsNames].Append(GetColumnNameText(result.Key));
                dict[columnsHeaders].Append(GetColumnHeaderText());

                foreach (var testResult in result.Value)
                {
                    var name = $"{testResult.TestCaseName};{testResult.RegistrationKind};{testResult.TestCasesCount}";
                    dict[name].Append(GetResultText(testResult));
                }
            }


            return dict.Select(d => d.Value.ToString()).ToList();
        }

        protected abstract string GetColumnNameText(string containerName);

        protected abstract string GetColumnHeaderText();

        protected abstract string GetResultText(FinalTestResult testResult);

        private void WriteToFile(IEnumerable<string> results, string resultFile)
        {
            using (var file = new StreamWriter(resultFile))
            {
                foreach (var result in results)
                {
                    file.WriteLine(result);
                }
            }
        }
    }
}