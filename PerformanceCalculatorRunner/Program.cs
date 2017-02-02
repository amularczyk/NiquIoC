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

            var testCases = new List<PerformanceTestCase>();
            CreatePerformanceTestCasesA(testCases);
//            CreatePerformanceTestCasesB(testCases);
//            CreatePerformanceTestCasesC(testCases);

            var results = RunPerformanceTests(repetitionsNumber, testCases);

            WriteToFile(ProcessResultsDataToCsvFormat(results, WriteKind.Resolve));
        }

        private static Dictionary<string, List<FinalTestResult>> RunPerformanceTests(int repetitionsNumber, IReadOnlyCollection<PerformanceTestCase> testCases)
        {
            var results = new Dictionary<string, List<FinalTestResult>>();

            results.Add(ContainerName.Autofac, RunPerformanceTests(ContainerName.Autofac, new AutofacPerformanceTestsRunner(_processPath), repetitionsNumber, testCases));
            results.Add(ContainerName.DryIoc, RunPerformanceTests(ContainerName.DryIoc, new DryIocPeformanceTestsRunner(_processPath), repetitionsNumber, testCases));
            results.Add(ContainerName.LightInject, RunPerformanceTests(ContainerName.LightInject, new LightInjectPeformanceTestsRunner(_processPath), repetitionsNumber, testCases));
            results.Add(ContainerName.NiquIoC, RunPerformanceTests(ContainerName.NiquIoC, new NiquIoCPeformanceTestsRunner(_processPath), repetitionsNumber, testCases));
            results.Add(ContainerName.NiquIoCFull, RunPerformanceTests(ContainerName.NiquIoCFull, new NiquIoCFullPeformanceTestsRunner(_processPath), repetitionsNumber, testCases));
            results.Add(ContainerName.SimpleInjector, RunPerformanceTests(ContainerName.SimpleInjector, new SimpleInjectorPeformanceTestsRunner(_processPath), repetitionsNumber, testCases));
            results.Add(ContainerName.StructureMap, RunPerformanceTests(ContainerName.StructureMap, new StructureMapPeformanceTestsRunner(_processPath), repetitionsNumber, testCases));
            results.Add(ContainerName.Unity, RunPerformanceTests(ContainerName.Unity, new UnityPeformanceTestsRunner(_processPath), repetitionsNumber, testCases));
            results.Add(ContainerName.Windsor, RunPerformanceTests(ContainerName.Windsor, new WindsorPeformanceTestsRunner(_processPath), repetitionsNumber, testCases));

            return results;
        }

        private static List<FinalTestResult> RunPerformanceTests(string containerName, IPerformanceTestsRunner performanceTestsRunner, int repetitionsNumber, IReadOnlyCollection<PerformanceTestCase> testCases)
        {
            Console.WriteLine($"{containerName} start");
            var result = ProcessTestResults(performanceTestsRunner.RunTests(repetitionsNumber, testCases));
            Console.WriteLine($"{containerName} end");

            return result;
        }

        private static void CreatePerformanceTestCasesA(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 100, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 10, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 100, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1000, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 10, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 100, TestCase = TestCaseName.A });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1000, TestCase = TestCaseName.A });
        }

        private static void CreatePerformanceTestCasesB(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 1, TestCase = TestCaseName.B });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.B });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 10, TestCase = TestCaseName.B });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.B });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 10, TestCase = TestCaseName.B });
        }

        private static void CreatePerformanceTestCasesC(ICollection<PerformanceTestCase> testCases)
        {
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Singleton, TestsCount = 100, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 10, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 100, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.Transient, TestsCount = 1000, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 10, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 100, TestCase = TestCaseName.C });
            testCases.Add(new PerformanceTestCase { RegistrationKind = RegistrationKind.PerThread, TestsCount = 1000, TestCase = TestCaseName.C });
        }

        private static void WriteToFile(IEnumerable<string> results)
        {
            using (var file = new StreamWriter(_resultFile))
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

                body1.Append(GetResultInCsvFormat(result, 0, writeKind));
                body2.Append(GetResultInCsvFormat(result, 1, writeKind));
                body3.Append(GetResultInCsvFormat(result, 2, writeKind));
                body4.Append(GetResultInCsvFormat(result, 3, writeKind));
                body5.Append(GetResultInCsvFormat(result, 4, writeKind));
                body6.Append(GetResultInCsvFormat(result, 5, writeKind));
                body7.Append(GetResultInCsvFormat(result, 6, writeKind));
                body8.Append(GetResultInCsvFormat(result, 7, writeKind));
                body9.Append(GetResultInCsvFormat(result, 8, writeKind));
                body10.Append(GetResultInCsvFormat(result, 9, writeKind));
                body11.Append(GetResultInCsvFormat(result, 10, writeKind));
                body12.Append(GetResultInCsvFormat(result, 11, writeKind));
                body13.Append(GetResultInCsvFormat(result, 12, writeKind));
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

        private static List<FinalTestResult> ProcessTestResults(IEnumerable<List<TestResult>> testResults)
        {
            var finalTestResults = new List<FinalTestResult>();

            foreach (var testResult in testResults)
            {
                finalTestResults.Add(new FinalTestResult
                {
                    RegistrationKind = testResult[0].RegistrationKind,
                    TestCasesNumber = testResult[0].TestCasesNumber,
                    MinRegisterTime = testResult.Min(t => t.RegisterTime),
                    MinResolveTime = testResult.Min(t => t.ResolveTime),
                    MaxRegisterTime = testResult.Max(t => t.RegisterTime),
                    MaxResolveTime = testResult.Max(t => t.ResolveTime),
                    AvgRegisterTime = (long)Math.Round(testResult.Average(t => t.RegisterTime), 0),
                    AvgResolveTime = (long)Math.Round(testResult.Average(t => t.ResolveTime), 0)
                });
            }

            return finalTestResults;
        }
    }
}