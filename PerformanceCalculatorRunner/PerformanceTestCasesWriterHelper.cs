using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PerformanceCalculatorRunner
{
    public static class PerformanceTestCasesWriterHelper
    {
        public static void WriteToFile(Dictionary<string, List<FinalTestResult>> results, WriteKind writeKind, string resultFile)
        {
            WriteToFile(ProcessResultsDataToCsvFormat(results, writeKind), resultFile);
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

        private static IEnumerable<string> ProcessResultsDataToCsvFormat(Dictionary<string, List<FinalTestResult>> results, WriteKind writeKind)
        {
            var header = new StringBuilder();
            var header2 = new StringBuilder();

            var body1 = new StringBuilder();
            var body2 = new StringBuilder();
            var body3 = new StringBuilder();
            var body4 = new StringBuilder();
            var body5 = new StringBuilder();

            var body6 = new StringBuilder();
            var body7 = new StringBuilder();
            var body8 = new StringBuilder();

            var body9 = new StringBuilder();
            var body10 = new StringBuilder();
            var body11 = new StringBuilder();
            var body12 = new StringBuilder();
            var body13 = new StringBuilder();

            header.Append("Test Case;Registration Kind;Resolve Count;");
            header2.Append(";;;");

            body1.Append("Test A;registrationKind;100;");
            body2.Append("Test A;Transient;1;");
            body3.Append("Test A;Transient;10;");
            body4.Append("Test A;Transient;100;");
            body5.Append("Test A;Transient;1000;");

            body6.Append("Test B;registrationKind;1;");
            body7.Append("Test B;Transient;1;");
            body8.Append("Test B;Transient;10;");

            body9.Append("Test C;registrationKind;100;");
            body10.Append("Test C;Transient;1;");
            body11.Append("Test C;Transient;10;");
            body12.Append("Test C;Transient;100;");
            body13.Append("Test C;Transient;1000;");

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

                body1.Append((string)GetResultInCsvFormat(result, 0, writeKind));
                body2.Append((string)GetResultInCsvFormat(result, 1, writeKind));
                body3.Append((string)GetResultInCsvFormat(result, 2, writeKind));
                body4.Append((string)GetResultInCsvFormat(result, 3, writeKind));
                body5.Append((string)GetResultInCsvFormat(result, 4, writeKind));
                body6.Append((string)GetResultInCsvFormat(result, 5, writeKind));
                body7.Append((string)GetResultInCsvFormat(result, 6, writeKind));
                body8.Append((string)GetResultInCsvFormat(result, 7, writeKind));
                body9.Append((string)GetResultInCsvFormat(result, 8, writeKind));
                body10.Append((string)GetResultInCsvFormat(result, 9, writeKind));
                body11.Append((string)GetResultInCsvFormat(result, 10, writeKind));
                body12.Append((string)GetResultInCsvFormat(result, 11, writeKind));
                body13.Append((string)GetResultInCsvFormat(result, 12, writeKind));
            }

            return new List<string>
            {
                header.ToString(),
                header2.ToString(),
                body1.ToString(),
                body2.ToString(),
                body3.ToString(),
                body4.ToString(),
                body5.ToString(),
                body6.ToString(),
                body7.ToString(),
                body8.ToString(),
                body9.ToString(),
                body10.ToString(),
                body11.ToString(),
                body12.ToString(),
                body13.ToString()
            };
        }

        private static string GetResultInCsvFormat(KeyValuePair<string, List<FinalTestResult>> result, int index, WriteKind writeKind)
        {
            switch (writeKind)
            {
                case WriteKind.Both:
                    return $"{result.Value[index].MinRegisterTime};{result.Value[index].MaxRegisterTime};{result.Value[index].AvgRegisterTime};" +
                           $"{result.Value[index].MinResolveTime};{result.Value[index].MaxResolveTime};{result.Value[index].AvgResolveTime};";

                case WriteKind.Register:
                    return $"{result.Value[index].MinRegisterTime};{result.Value[index].MaxRegisterTime};{result.Value[index].AvgRegisterTime};";

                case WriteKind.Resolve:
                    return $"{result.Value[index].MinResolveTime};{result.Value[index].MaxResolveTime};{result.Value[index].AvgResolveTime};";

                default:
                    throw new ArgumentOutOfRangeException(nameof(writeKind), writeKind, null);
            }
        }
    }
}