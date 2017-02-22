using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerformanceCalculator.Common;
using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Writers
{
    public abstract class CsvVerticalFileWriter : FileWriter
    {
        protected CsvVerticalFileWriter(string resultFile) : base(resultFile)
        {
        }

        public override void Write(Dictionary<string, IEnumerable<FinalTestResult>> results, IEnumerable<PerformanceTestCase> testCases)
        {
            WriteToFile(ProcessResultsDataToCsvFormat(results, testCases));
        }

        private IEnumerable<string> ProcessResultsDataToCsvFormat(Dictionary<string, IEnumerable<FinalTestResult>> results, IEnumerable<PerformanceTestCase> testCases)
        {
            var list = new List<StringBuilder>();

            var hTestCase = new StringBuilder();
            var hRegistrationKind = new StringBuilder();
            var hTestsCount = new StringBuilder();

            hTestCase.Append(";;");
            hRegistrationKind.Append(";;");
            hTestsCount.Append(";;");

            foreach (var testCase in testCases)
            {
                hTestCase.Append(GetTestCaseColumnNameText(testCase.TestCase));
                hRegistrationKind.Append(GetRegistrationKindColumnNameText(testCase.RegistrationKind));
                hTestsCount.Append(GetTestsCountColumnNameText(testCase.TestsCount));
            }

            list.Add(hTestCase);
            list.Add(hRegistrationKind);
            list.Add(hTestsCount);

            foreach (var result in results)
            {
                var sbMin = new StringBuilder();
                var sbMax = new StringBuilder();
                var sbAvg = new StringBuilder();

                sbMin.Append($"{result.Key};min;");
                sbMax.Append($"{result.Key};max;");
                sbAvg.Append($"{result.Key};avg;");

                foreach (var testResult in result.Value)
                {
                    sbMin.Append(GetMinResultText(testResult));
                    sbMax.Append(GetMaxResultText(testResult));
                    sbAvg.Append(GetAvgResultText(testResult));
                }

                list.Add(sbMin);
                list.Add(sbMax);
                list.Add(sbAvg);
            }

            return list.Select(l => l.ToString());
        }

        protected abstract string GetTestCaseColumnNameText(string containerName);

        protected abstract string GetRegistrationKindColumnNameText(RegistrationKind registrationKind);

        protected abstract string GetTestsCountColumnNameText(int testsCount);

        protected abstract string GetMinResultText(FinalTestResult testResult);

        protected abstract string GetMaxResultText(FinalTestResult testResult);

        protected abstract string GetAvgResultText(FinalTestResult testResult);
    }
}