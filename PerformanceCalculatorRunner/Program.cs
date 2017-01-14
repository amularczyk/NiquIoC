using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner
{
    internal enum WriteKind
    {
        Both = 0,
        Register = 1,
        Resolve = 2
    }

    internal class Program
    {
        private static readonly string _processPath = @"C:\study\NiquIoC\PerformanceCalculator\bin\Release\PerformanceCalculator.exe";
        private static readonly string _resultFile = $"PerformanceCalculator_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm")}.csv";

        private static void Main()
        {
            var repetitionsNumber = 1;

            var results = new Dictionary<string, List<FinalTestResult>>
            {
                { ContainerName.Autofac, ConvertToListFinalTestResult(RunAutofacPeformanceTests(repetitionsNumber)) },
                { ContainerName.DryIoc, ConvertToListFinalTestResult(RunDryIocPeformanceTests(repetitionsNumber)) },
                { ContainerName.LightInject, ConvertToListFinalTestResult(RunLightInjectPeformanceTests(repetitionsNumber)) },
                { ContainerName.NiquIoC, ConvertToListFinalTestResult(RunNiquIoCPeformanceTests(repetitionsNumber)) },
                { ContainerName.NiquIoCFull, ConvertToListFinalTestResult(RunNiquIoCFullPeformanceTests(repetitionsNumber)) },
                { ContainerName.SimpleInjector, ConvertToListFinalTestResult(RunSimpleInjectorPeformanceTests(repetitionsNumber)) },
                { ContainerName.StructureMap, ConvertToListFinalTestResult(RunStructureMapPeformanceTests(repetitionsNumber)) },
                { ContainerName.Unity, ConvertToListFinalTestResult(RunUnityPeformanceTests(repetitionsNumber)) },
                { ContainerName.Windsor, ConvertToListFinalTestResult(RunWindsorPeformanceTests(repetitionsNumber)) }
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

        #region RunPerformanceTests
        private static List<List<TestResult>> RunAutofacPeformanceTests(int repetitionsNumber)
        {
            Console.WriteLine("Autofac - Start");
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>()
            };

            for (var i = 0; i < repetitionsNumber; i++)
            {
                testResults[0].Add(ConvertToTestResult(RunAutofacPeformanceTests(true, 100, TestCaseName.A)));
                testResults[1].Add(ConvertToTestResult(RunAutofacPeformanceTests(false, 1, TestCaseName.A)));
                testResults[2].Add(ConvertToTestResult(RunAutofacPeformanceTests(false, 10, TestCaseName.A)));
                testResults[3].Add(ConvertToTestResult(RunAutofacPeformanceTests(false, 100, TestCaseName.A)));
                testResults[4].Add(ConvertToTestResult(RunAutofacPeformanceTests(false, 1000, TestCaseName.A)));

                testResults[5].Add(ConvertToTestResult(RunAutofacPeformanceTests(true, 1, TestCaseName.B)));
                testResults[6].Add(ConvertToTestResult(RunAutofacPeformanceTests(false, 1, TestCaseName.B)));
                testResults[7].Add(ConvertToTestResult(RunAutofacPeformanceTests(false, 10, TestCaseName.B)));

                testResults[8].Add(ConvertToTestResult(RunAutofacPeformanceTests(true, 100, TestCaseName.C)));
                testResults[9].Add(ConvertToTestResult(RunAutofacPeformanceTests(false, 1, TestCaseName.C)));
                testResults[10].Add(ConvertToTestResult(RunAutofacPeformanceTests(false, 10, TestCaseName.C)));
                testResults[11].Add(ConvertToTestResult(RunAutofacPeformanceTests(false, 100, TestCaseName.C)));
                testResults[12].Add(ConvertToTestResult(RunAutofacPeformanceTests(false, 1000, TestCaseName.C)));
            }

            Console.WriteLine("Autofac - End");
            return testResults;
        }

        private static string RunAutofacPeformanceTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.Autofac, registrationKind, testsCount, testCase);
        }

        private static List<List<TestResult>> RunDryIocPeformanceTests(int repetitionsNumber)
        {
            Console.WriteLine("DryIoc - Start");
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>()
            };

            for (var i = 0; i < repetitionsNumber; i++)
            {
                testResults[0].Add(ConvertToTestResult(RunDryIocPeformanceTests(true, 100, TestCaseName.A)));
                testResults[1].Add(ConvertToTestResult(RunDryIocPeformanceTests(false, 1, TestCaseName.A)));
                testResults[2].Add(ConvertToTestResult(RunDryIocPeformanceTests(false, 10, TestCaseName.A)));
                testResults[3].Add(ConvertToTestResult(RunDryIocPeformanceTests(false, 100, TestCaseName.A)));
                testResults[4].Add(ConvertToTestResult(RunDryIocPeformanceTests(false, 1000, TestCaseName.A)));

                testResults[5].Add(ConvertToTestResult(RunDryIocPeformanceTests(true, 1, TestCaseName.B)));
                testResults[6].Add(ConvertToTestResult(RunDryIocPeformanceTests(false, 1, TestCaseName.B)));
                testResults[7].Add(ConvertToTestResult(RunDryIocPeformanceTests(false, 10, TestCaseName.B)));

                testResults[8].Add(ConvertToTestResult(RunDryIocPeformanceTests(true, 100, TestCaseName.C)));
                testResults[9].Add(ConvertToTestResult(RunDryIocPeformanceTests(false, 1, TestCaseName.C)));
                testResults[10].Add(ConvertToTestResult(RunDryIocPeformanceTests(false, 10, TestCaseName.C)));
                testResults[11].Add(ConvertToTestResult(RunDryIocPeformanceTests(false, 100, TestCaseName.C)));
                testResults[12].Add(ConvertToTestResult(RunDryIocPeformanceTests(false, 1000, TestCaseName.C)));
            }

            Console.WriteLine("DryIoc - End");
            return testResults;
        }

        private static string RunDryIocPeformanceTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.DryIoc, registrationKind, testsCount, testCase);
        }

        private static List<List<TestResult>> RunLightInjectPeformanceTests(int repetitionsNumber)
        {
            Console.WriteLine("LightInject - Start");
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>()
            };

            for (var i = 0; i < repetitionsNumber; i++)
            {
                testResults[0].Add(ConvertToTestResult(RunLightInjectPeformanceTests(true, 100, TestCaseName.A)));
                testResults[1].Add(ConvertToTestResult(RunLightInjectPeformanceTests(false, 1, TestCaseName.A)));
                testResults[2].Add(ConvertToTestResult(RunLightInjectPeformanceTests(false, 10, TestCaseName.A)));
                testResults[3].Add(ConvertToTestResult(RunLightInjectPeformanceTests(false, 100, TestCaseName.A)));
                testResults[4].Add(ConvertToTestResult(RunLightInjectPeformanceTests(false, 1000, TestCaseName.A)));

                testResults[5].Add(ConvertToTestResult(RunLightInjectPeformanceTests(true, 1, TestCaseName.B)));
                testResults[6].Add(ConvertToTestResult(RunLightInjectPeformanceTests(false, 1, TestCaseName.B)));
                testResults[7].Add(ConvertToTestResult(RunLightInjectPeformanceTests(false, 10, TestCaseName.B)));

                testResults[8].Add(ConvertToTestResult(RunLightInjectPeformanceTests(true, 100, TestCaseName.C)));
                testResults[9].Add(ConvertToTestResult(RunLightInjectPeformanceTests(false, 1, TestCaseName.C)));
                testResults[10].Add(ConvertToTestResult(RunLightInjectPeformanceTests(false, 10, TestCaseName.C)));
                testResults[11].Add(ConvertToTestResult(RunLightInjectPeformanceTests(false, 100, TestCaseName.C)));
                testResults[12].Add(ConvertToTestResult(RunLightInjectPeformanceTests(false, 1000, TestCaseName.C)));
            }

            Console.WriteLine("LightInject - End");
            return testResults;
        }

        private static string RunLightInjectPeformanceTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.LightInject, registrationKind, testsCount, testCase);
        }

        private static List<List<TestResult>> RunNiquIoCPeformanceTests(int repetitionsNumber)
        {
            Console.WriteLine("NiquIoC - Start");
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>()
            };

            for (var i = 0; i < repetitionsNumber; i++)
            {
                testResults[0].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(true, 100, TestCaseName.A)));
                testResults[1].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(false, 1, TestCaseName.A)));
                testResults[2].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(false, 10, TestCaseName.A)));
                testResults[3].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(false, 100, TestCaseName.A)));
                testResults[4].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(false, 1000, TestCaseName.A)));

                testResults[5].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(true, 1, TestCaseName.B)));
                testResults[6].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(false, 1, TestCaseName.B)));
                testResults[7].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(false, 10, TestCaseName.B)));

                testResults[8].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(true, 100, TestCaseName.C)));
                testResults[9].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(false, 1, TestCaseName.C)));
                testResults[10].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(false, 10, TestCaseName.C)));
                testResults[11].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(false, 100, TestCaseName.C)));
                testResults[12].Add(ConvertToTestResult(RunNiquIoCPeformanceTests(false, 1000, TestCaseName.C)));
            }

            Console.WriteLine("NiquIoC - End");
            return testResults;
        }

        private static string RunNiquIoCPeformanceTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.NiquIoC, registrationKind, testsCount, testCase);
        }

        private static List<List<TestResult>> RunNiquIoCFullPeformanceTests(int repetitionsNumber)
        {
            Console.WriteLine("NiquIoCFull - Start");
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>()
            };

            for (var i = 0; i < repetitionsNumber; i++)
            {
                testResults[0].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(true, 100, TestCaseName.A)));
                testResults[1].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(false, 1, TestCaseName.A)));
                testResults[2].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(false, 10, TestCaseName.A)));
                testResults[3].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(false, 100, TestCaseName.A)));
                testResults[4].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(false, 1000, TestCaseName.A)));

                testResults[5].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(true, 1, TestCaseName.B)));
                testResults[6].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(false, 1, TestCaseName.B)));
                testResults[7].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(false, 10, TestCaseName.B)));

                testResults[8].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(true, 100, TestCaseName.C)));
                testResults[9].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(false, 1, TestCaseName.C)));
                testResults[10].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(false, 10, TestCaseName.C)));
                testResults[11].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(false, 100, TestCaseName.C)));
                testResults[12].Add(ConvertToTestResult(RunNiquIoCFullPeformanceTests(false, 1000, TestCaseName.C)));
            }

            Console.WriteLine("NiquIoCFull - End");
            return testResults;
        }

        private static string RunNiquIoCFullPeformanceTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.NiquIoCFull, registrationKind, testsCount, testCase);
        }

        private static List<List<TestResult>> RunSimpleInjectorPeformanceTests(int repetitionsNumber)
        {
            Console.WriteLine("SimpleInjector - Start");
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>()
            };

            for (var i = 0; i < repetitionsNumber; i++)
            {
                testResults[0].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(true, 100, TestCaseName.A)));
                testResults[1].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(false, 1, TestCaseName.A)));
                testResults[2].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(false, 10, TestCaseName.A)));
                testResults[3].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(false, 100, TestCaseName.A)));
                testResults[4].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(false, 1000, TestCaseName.A)));

                testResults[5].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(true, 1, TestCaseName.B)));
                testResults[6].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(false, 1, TestCaseName.B)));
                testResults[7].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(false, 10, TestCaseName.B)));

                testResults[8].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(true, 100, TestCaseName.C)));
                testResults[9].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(false, 1, TestCaseName.C)));
                testResults[10].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(false, 10, TestCaseName.C)));
                testResults[11].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(false, 100, TestCaseName.C)));
                testResults[12].Add(ConvertToTestResult(RunSimpleInjectorPeformanceTests(false, 1000, TestCaseName.C)));
            }

            Console.WriteLine("SimpleInjector - End");
            return testResults;
        }

        private static string RunSimpleInjectorPeformanceTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.SimpleInjector, registrationKind, testsCount, testCase);
        }

        private static List<List<TestResult>> RunStructureMapPeformanceTests(int repetitionsNumber)
        {
            Console.WriteLine("StructureMap - Start");
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>()
            };

            for (var i = 0; i < repetitionsNumber; i++)
            {
                testResults[0].Add(ConvertToTestResult(RunStructureMapPeformanceTests(true, 100, TestCaseName.A)));
                testResults[1].Add(ConvertToTestResult(RunStructureMapPeformanceTests(false, 1, TestCaseName.A)));
                testResults[2].Add(ConvertToTestResult(RunStructureMapPeformanceTests(false, 10, TestCaseName.A)));
                testResults[3].Add(ConvertToTestResult(RunStructureMapPeformanceTests(false, 100, TestCaseName.A)));
                testResults[4].Add(ConvertToTestResult(RunStructureMapPeformanceTests(false, 1000, TestCaseName.A)));

                testResults[5].Add(ConvertToTestResult(RunStructureMapPeformanceTests(true, 1, TestCaseName.B)));
                testResults[6].Add(ConvertToTestResult(RunStructureMapPeformanceTests(false, 1, TestCaseName.B)));
                testResults[7].Add(ConvertToTestResult(RunStructureMapPeformanceTests(false, 10, TestCaseName.B)));

                testResults[8].Add(ConvertToTestResult(RunStructureMapPeformanceTests(true, 100, TestCaseName.C)));
                testResults[9].Add(ConvertToTestResult(RunStructureMapPeformanceTests(false, 1, TestCaseName.C)));
                testResults[10].Add(ConvertToTestResult(RunStructureMapPeformanceTests(false, 10, TestCaseName.C)));
                testResults[11].Add(ConvertToTestResult(RunStructureMapPeformanceTests(false, 100, TestCaseName.C)));
                testResults[12].Add(ConvertToTestResult(RunStructureMapPeformanceTests(false, 1000, TestCaseName.C)));
            }

            Console.WriteLine("StructureMap - End");
            return testResults;
        }

        private static string RunStructureMapPeformanceTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.StructureMap, registrationKind, testsCount, testCase);
        }

        private static List<List<TestResult>> RunUnityPeformanceTests(int repetitionsNumber)
        {
            Console.WriteLine("Unity - Start");
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>()
            };

            for (var i = 0; i < repetitionsNumber; i++)
            {
                testResults[0].Add(ConvertToTestResult(RunUnityPeformanceTests(true, 100, TestCaseName.A)));
                testResults[1].Add(ConvertToTestResult(RunUnityPeformanceTests(false, 1, TestCaseName.A)));
                testResults[2].Add(ConvertToTestResult(RunUnityPeformanceTests(false, 10, TestCaseName.A)));
                testResults[3].Add(ConvertToTestResult(RunUnityPeformanceTests(false, 100, TestCaseName.A)));
                testResults[4].Add(ConvertToTestResult(RunUnityPeformanceTests(false, 1000, TestCaseName.A)));

                testResults[5].Add(ConvertToTestResult(RunUnityPeformanceTests(true, 1, TestCaseName.B)));
                testResults[6].Add(ConvertToTestResult(RunUnityPeformanceTests(false, 1, TestCaseName.B)));
                testResults[7].Add(ConvertToTestResult(RunUnityPeformanceTests(false, 10, TestCaseName.B)));

                testResults[8].Add(ConvertToTestResult(RunUnityPeformanceTests(true, 100, TestCaseName.C)));
                testResults[9].Add(ConvertToTestResult(RunUnityPeformanceTests(false, 1, TestCaseName.C)));
                testResults[10].Add(ConvertToTestResult(RunUnityPeformanceTests(false, 10, TestCaseName.C)));
                testResults[11].Add(ConvertToTestResult(RunUnityPeformanceTests(false, 100, TestCaseName.C)));
                testResults[12].Add(ConvertToTestResult(RunUnityPeformanceTests(false, 1000, TestCaseName.C)));
            }

            Console.WriteLine("Unity - End");
            return testResults;
        }

        private static string RunUnityPeformanceTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.Unity, registrationKind, testsCount, testCase);
        }

        private static List<List<TestResult>> RunWindsorPeformanceTests(int repetitionsNumber)
        {
            Console.WriteLine("Windsor - Start");
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>(), new List<TestResult>()
            };

            for (var i = 0; i < repetitionsNumber; i++)
            {
                testResults[0].Add(ConvertToTestResult(RunWindsorPeformanceTests(true, 100, TestCaseName.A)));
                testResults[1].Add(ConvertToTestResult(RunWindsorPeformanceTests(false, 1, TestCaseName.A)));
                testResults[2].Add(ConvertToTestResult(RunWindsorPeformanceTests(false, 10, TestCaseName.A)));
                testResults[3].Add(ConvertToTestResult(RunWindsorPeformanceTests(false, 100, TestCaseName.A)));
                testResults[4].Add(ConvertToTestResult(RunWindsorPeformanceTests(false, 1000, TestCaseName.A)));

                testResults[5].Add(ConvertToTestResult(RunWindsorPeformanceTests(true, 1, TestCaseName.B)));
                testResults[6].Add(ConvertToTestResult(RunWindsorPeformanceTests(false, 1, TestCaseName.B)));
                testResults[7].Add(ConvertToTestResult(RunWindsorPeformanceTests(false, 10, TestCaseName.B)));

                testResults[8].Add(ConvertToTestResult(RunWindsorPeformanceTests(true, 100, TestCaseName.C)));
                testResults[9].Add(ConvertToTestResult(RunWindsorPeformanceTests(false, 1, TestCaseName.C)));
                testResults[10].Add(ConvertToTestResult(RunWindsorPeformanceTests(false, 10, TestCaseName.C)));
                testResults[11].Add(ConvertToTestResult(RunWindsorPeformanceTests(false, 100, TestCaseName.C)));
                testResults[12].Add(ConvertToTestResult(RunWindsorPeformanceTests(false, 1000, TestCaseName.C)));
            }

            Console.WriteLine("Windsor - End");
            return testResults;
        }

        private static string RunWindsorPeformanceTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.Windsor, registrationKind, testsCount, testCase);
        }
        #endregion

        private static string RunPerformanceTests(string containerName, RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return ProcessHelper.StartProcess(_processPath, $"{containerName} -r {registrationKind} -c {testsCount} -t {testCase}");
        }

        private static TestResult ConvertToTestResult(string result)
        {
            var results = result.Split(' ');
            var testResult = new TestResult
            {
                RegistrationKind = (RegistrationKind)Convert.ToInt32(results[0]), TestCasesNumber = Convert.ToInt32(results[1]), RegisterTime = Convert.ToInt64(results[2]), ResolveTime = Convert.ToInt64(results[3])
            };

            return testResult;
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