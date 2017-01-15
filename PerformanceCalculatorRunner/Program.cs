using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner
{
    public enum WriteKind
    {
        Both = 0,
        Register = 1,
        Resolve = 2
    }

    public class Program
    {
        private static readonly string _processPath = @"C:\study\NiquIoC\PerformanceCalculator\bin\Release\PerformanceCalculator.exe";
        private static readonly string _resultFile = $"PerformanceCalculator_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm")}.csv";

        private static void Main()
        {
            var repetitionsNumber = 1;

            var results = new Dictionary<string, List<FinalTestResult>>
            {
                { ContainerName.Autofac, ConvertToListFinalTestResult(new RunAutofacPerformanceTests(_processPath).RunTests(repetitionsNumber)) },
                { ContainerName.DryIoc, ConvertToListFinalTestResult(new RunDryIocPeformanceTests(_processPath).RunTests(repetitionsNumber)) },
                { ContainerName.LightInject, ConvertToListFinalTestResult(new RunLightInjectPeformanceTests(_processPath).RunTests(repetitionsNumber)) },
                { ContainerName.NiquIoC, ConvertToListFinalTestResult(new RunNiquIoCPeformanceTests(_processPath).RunTests(repetitionsNumber)) },
                { ContainerName.NiquIoCFull, ConvertToListFinalTestResult(new RunNiquIoCFullPeformanceTests(_processPath).RunTests(repetitionsNumber)) },
                { ContainerName.SimpleInjector, ConvertToListFinalTestResult(new RunSimpleInjectorPeformanceTests(_processPath).RunTests(repetitionsNumber)) },
                { ContainerName.StructureMap, ConvertToListFinalTestResult(new RunStructureMapPeformanceTests(_processPath).RunTests(repetitionsNumber)) },
                { ContainerName.Unity, ConvertToListFinalTestResult(new RunUnityPeformanceTests(_processPath).RunTests(repetitionsNumber)) },
                { ContainerName.Windsor, ConvertToListFinalTestResult(new RunWindsorPeformanceTests(_processPath).RunTests(repetitionsNumber)) }
            };

            WriteToFile(results, WriteKind.Resolve);
        }

        private static void WriteToFile(Dictionary<string, List<FinalTestResult>> results, WriteKind writeKind)
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

                body1.Append(ReturnStringResult(result, 0, writeKind));
                body2.Append(ReturnStringResult(result, 1, writeKind));
                body3.Append(ReturnStringResult(result, 2, writeKind));
                body4.Append(ReturnStringResult(result, 3, writeKind));
                body5.Append(ReturnStringResult(result, 4, writeKind));
                body6.Append(ReturnStringResult(result, 5, writeKind));
                body7.Append(ReturnStringResult(result, 6, writeKind));
                body8.Append(ReturnStringResult(result, 7, writeKind));
                body9.Append(ReturnStringResult(result, 8, writeKind));
                body10.Append(ReturnStringResult(result, 9, writeKind));
                body11.Append(ReturnStringResult(result, 10, writeKind));
                body12.Append(ReturnStringResult(result, 11, writeKind));
                body13.Append(ReturnStringResult(result, 12, writeKind));
            }

            using (var file = new StreamWriter(_resultFile))
            {
                file.WriteLine(header);
                file.WriteLine(header2);
                file.WriteLine(body1);
                file.WriteLine(body2);
                file.WriteLine(body3);
                file.WriteLine(body4);
                file.WriteLine(body5);
                file.WriteLine(body6);
                file.WriteLine(body7);
                file.WriteLine(body8);
                file.WriteLine(body9);
                file.WriteLine(body10);
                file.WriteLine(body11);
                file.WriteLine(body12);
                file.WriteLine(body13);
            }
        }

        private static string ReturnStringResult(KeyValuePair<string, List<FinalTestResult>> result, int index, WriteKind writeKind)
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

        private static List<FinalTestResult> ConvertToListFinalTestResult(List<List<TestResult>> testResults)
        {
            var finalTestResults = new List<FinalTestResult>();

            foreach (var testResult in testResults)
            {
                finalTestResults.Add(new FinalTestResult
                {
                    RegistrationKind = testResult[0].RegistrationKind, TestCasesNumber = testResult[0].TestCasesNumber, MinRegisterTime = testResult.Min(t => t.RegisterTime), MinResolveTime = testResult.Min(t => t.ResolveTime), MaxRegisterTime = testResult.Max(t => t.RegisterTime), MaxResolveTime = testResult.Max(t => t.ResolveTime), AvgRegisterTime = (long)Math.Round(testResult.Average(t => t.RegisterTime), 0), AvgResolveTime = (long)Math.Round(testResult.Average(t => t.ResolveTime), 0)
                });
            }

            return finalTestResults;
        }
    }
}