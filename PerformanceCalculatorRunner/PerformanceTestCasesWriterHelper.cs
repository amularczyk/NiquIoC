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
                rowHeader.Append($"{testCase.TestCase};{testCase.RegistrationKind};");
                dict.Add(testCase.TestCase, rowHeader);
            }

            foreach (var result in results)
            {
                foreach (var testResult in result.Value)
                {
                    dict[testResult.TestCase].Append(GetResultInCsvFormat(testResult, writeKind));
                }
            }


            return null;
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

        private static IEnumerable<string> ProcessResultsDataToCsvFormat(Dictionary<string, IEnumerable<FinalTestResult>> results, WriteKind writeKind)
        {
            var header = new StringBuilder();
            var header2 = new StringBuilder();

            var bodyAS100 = new StringBuilder();
            var bodyAT1 = new StringBuilder();
            var bodyAT10 = new StringBuilder();
            var bodyAT100 = new StringBuilder();
            var bodyAT1000 = new StringBuilder();
            var bodyAPt100 = new StringBuilder();

            var bodyBS1 = new StringBuilder();
            var bodyBT1 = new StringBuilder();
            var bodyBT10 = new StringBuilder();
            var bodyBPt1 = new StringBuilder();

            var bodyCS100 = new StringBuilder();
            var bodyCT1 = new StringBuilder();
            var bodyCT10 = new StringBuilder();
            var bodyCT100 = new StringBuilder();
            var bodyCT1000 = new StringBuilder();
            var bodyCPt100 = new StringBuilder();

            header.Append("Test Case;Registration Kind;Resolve Count;");
            header2.Append(";;;");

            bodyAS100.Append("Test A;Singleton;100;");
            bodyAT1.Append("Test A;Transient;1;");
            bodyAT10.Append("Test A;Transient;10;");
            bodyAT100.Append("Test A;Transient;100;");
            bodyAT1000.Append("Test A;Transient;1000;");
            bodyAPt100.Append("Test A;PerThread;100;");

            bodyBS1.Append("Test B;Singleton;1;");
            bodyBT1.Append("Test B;Transient;1;");
            bodyBT10.Append("Test B;Transient;10;");
            bodyBPt1.Append("Test B;PerThread;1;");

            bodyCS100.Append("Test C;Singleton;100;");
            bodyCT1.Append("Test C;Transient;1;");
            bodyCT10.Append("Test C;Transient;10;");
            bodyCT100.Append("Test C;Transient;100;");
            bodyCT1000.Append("Test C;Transient;1000;");
            bodyCPt100.Append("Test C;PerThread;100;");

            foreach (var result in results)
            {
                switch (writeKind)
                {
                    case WriteKind.Both:
                        header.Append($"{result.Key} Register;{result.Key} Register;{result.Key} Register;" +
                                      $"{result.Key} Resolve;{result.Key} Resolve;{result.Key} Resolve;");
                        header2.Append("Min;Max;Avg;Min;Max;Avg;");
                        break;

                    case WriteKind.Register:
                        header.Append($"{result.Key} Register;{result.Key} Register;{result.Key} Register;");
                        header2.Append("Min;Max;Avg;");
                        break;

                    case WriteKind.Resolve:
                        header.Append($"{result.Key} Resolve;{result.Key} Resolve;{result.Key} Resolve;");
                        header2.Append("Min;Max;Avg;");
                        break;
                }

                bodyAS100.Append(GetResultInCsvFormat(result, 0, writeKind));
                bodyAT1.Append(GetResultInCsvFormat(result, 1, writeKind));
                bodyAT10.Append(GetResultInCsvFormat(result, 2, writeKind));
                bodyAT100.Append(GetResultInCsvFormat(result, 3, writeKind));
                bodyAT1000.Append(GetResultInCsvFormat(result, 4, writeKind));
                bodyAPt100.Append(GetResultInCsvFormat(result, 5, writeKind));
                bodyBS1.Append(GetResultInCsvFormat(result, 6, writeKind));
                bodyBT1.Append(GetResultInCsvFormat(result, 7, writeKind));
                bodyBT10.Append(GetResultInCsvFormat(result, 8, writeKind));
                bodyBPt1.Append(GetResultInCsvFormat(result, 9, writeKind));
                bodyCS100.Append(GetResultInCsvFormat(result, 10, writeKind));
                bodyCT1.Append(GetResultInCsvFormat(result, 11, writeKind));
                bodyCT10.Append(GetResultInCsvFormat(result, 12, writeKind));
                bodyCT100.Append(GetResultInCsvFormat(result, 13, writeKind));
                bodyCT1000.Append(GetResultInCsvFormat(result, 14, writeKind));
                bodyCPt100.Append(GetResultInCsvFormat(result, 15, writeKind));
            }

            return new List<string>
            {
                header.ToString(),
                header2.ToString(),
                bodyAS100.ToString(),
                bodyAT1.ToString(),
                bodyAT10.ToString(),
                bodyAT100.ToString(),
                bodyAT1000.ToString(),
                bodyAPt100.ToString(),
                bodyBS1.ToString(),
                bodyBT1.ToString(),
                bodyBT10.ToString(),
                bodyBPt1.ToString(),
                bodyCS100.ToString(),
                bodyCT1.ToString(),
                bodyCT10.ToString(),
                bodyCT100.ToString(),
                bodyCT1000.ToString(),
                bodyCPt100.ToString()
            };
        }

        private static string GetResultInCsvFormat(KeyValuePair<string, IEnumerable<FinalTestResult>> result, int index, WriteKind writeKind)
        {
            switch (writeKind)
            {
                case WriteKind.Both:
                    return $"{result.Value.ElementAt(index).MinRegisterTime};{result.Value.ElementAt(index).MaxRegisterTime};{result.Value.ElementAt(index).AvgRegisterTime};" +
                           $"{result.Value.ElementAt(index).MinResolveTime};{result.Value.ElementAt(index).MaxResolveTime};{result.Value.ElementAt(index).AvgResolveTime};";

                case WriteKind.Register:
                    return $"{result.Value.ElementAt(index).MinRegisterTime};{result.Value.ElementAt(index).MaxRegisterTime};{result.Value.ElementAt(index).AvgRegisterTime};";

                case WriteKind.Resolve:
                    return $"{result.Value.ElementAt(index).MinResolveTime};{result.Value.ElementAt(index).MaxResolveTime};{result.Value.ElementAt(index).AvgResolveTime};";

                default:
                    throw new ArgumentOutOfRangeException(nameof(writeKind), writeKind, null);
            }
        }
    }
}