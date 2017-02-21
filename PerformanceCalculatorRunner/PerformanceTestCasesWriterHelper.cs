using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PerformanceCalculatorRunner
{
    public static class PerformanceTestCasesWriterHelper
    {
        public static void WriteToFile(Dictionary<string, IEnumerable<FinalTestResult>> results, WriteKind writeKind, IEnumerable<PerformanceTestCase> testCases, string resultFile)
        {
            WriteToFile(ProcessResultsDataToCsvFormat(results, writeKind, testCases), resultFile);
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

        private static IEnumerable<string> ProcessResultsDataToCsvFormat(Dictionary<string, IEnumerable<FinalTestResult>> results, WriteKind writeKind, IEnumerable<PerformanceTestCase> testCases)
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
                AppendColumnsNamesAndHeaders(writeKind, dict[columnsNames], dict[columnsHeaders], result.Key);

                foreach (var testResult in result.Value)
                {
                    var name = $"{testResult.TestCase};{testResult.RegistrationKind};{testResult.TestCasesCount}";
                    dict[name].Append(GetResultInCsvFormat(testResult, writeKind));
                }
            }


            return dict.Select(d => d.Value.ToString()).ToList();
        }

        private static void AppendColumnsNamesAndHeaders(WriteKind writeKind, StringBuilder columnsNames, StringBuilder columnsHeaders, string containerName)
        {
            switch (writeKind)
            {
                case WriteKind.Both:
                    columnsNames.Append($"{containerName} Register;{containerName} Register;{containerName} Register;" +
                                        $"{containerName} Resolve;{containerName} Resolve;{containerName} Resolve;");
                    columnsHeaders.Append("Min;Max;Avg;Min;Max;Avg;");
                    break;

                case WriteKind.Register:
                    columnsNames.Append($"{containerName} Register;{containerName} Register;{containerName} Register;");
                    columnsHeaders.Append("Min;Max;Avg;");
                    break;

                case WriteKind.Resolve:
                    columnsNames.Append($"{containerName} Resolve;{containerName} Resolve;{containerName} Resolve;");
                    columnsHeaders.Append("Min;Max;Avg;");
                    break;
            }
        }

        private static string GetResultInCsvFormat(FinalTestResult testResult, WriteKind writeKind)
        {
            switch (writeKind)
            {
                case WriteKind.Both:
                    return $"{testResult.MinRegisterTime};{testResult.MaxRegisterTime};{testResult.AvgRegisterTime};" +
                           $"{testResult.MinResolveTime};{testResult.MaxResolveTime};{testResult.AvgResolveTime};";

                case WriteKind.Register:
                    return $"{testResult.MinRegisterTime};{testResult.MaxRegisterTime};{testResult.AvgRegisterTime};";

                case WriteKind.Resolve:
                    return $"{testResult.MinResolveTime};{testResult.MaxResolveTime};{testResult.AvgResolveTime};";

                default:
                    throw new ArgumentOutOfRangeException(nameof(writeKind), writeKind, null);
            }
        }
    }
}