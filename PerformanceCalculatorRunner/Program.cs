using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PerformanceCalculator;
using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner
{
    internal class Program
    {
        private static void Main()
        {
            var repetitionsNumber = 10;

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

            WriteToFile(results);
        }

        private static void WriteToFile(Dictionary<string, List<FinalTestResult>> results)
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

            body1.Append("Test A;Singleton;100;");
            body2.Append("Test A;Transient;1;");
            body3.Append("Test A;Transient;10;");
            body4.Append("Test A;Transient;100;");
            body5.Append("Test A;Transient;1000;");

            body6.Append("Test B;Singleton;1;");
            body7.Append("Test B;Transient;1;");
            body8.Append("Test B;Transient;10;");

            body9.Append("Test C;Singleton;100;");
            body10.Append("Test C;Transient;1;");
            body11.Append("Test C;Transient;10;");
            body12.Append("Test C;Transient;100;");
            body13.Append("Test C;Transient;1000;");

            foreach (var result in results)
            {
                header.Append($"{result.Key} Register;{result.Key} Register;{result.Key} Register;{result.Key} Resolve;{result.Key} Resolve;{result.Key} Resolve;");
                header2.Append("Min;Max;Avg;Min;Max;Avg;");

                body1.Append(ReturnStringResult(result, 0));
                body2.Append(ReturnStringResult(result, 1));
                body3.Append(ReturnStringResult(result, 2));
                body4.Append(ReturnStringResult(result, 3));
                body5.Append(ReturnStringResult(result, 4));
                body6.Append(ReturnStringResult(result, 5));
                body7.Append(ReturnStringResult(result, 6));
                body8.Append(ReturnStringResult(result, 7));
                body9.Append(ReturnStringResult(result, 8));
                body10.Append(ReturnStringResult(result, 9));
                body11.Append(ReturnStringResult(result, 10));
                body12.Append(ReturnStringResult(result, 11));
                body13.Append(ReturnStringResult(result, 12));
            }
            
            using (var file = new StreamWriter("TestResults.csv"))
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

        private static string ReturnStringResult(KeyValuePair<string, List<FinalTestResult>> result, int index)
        {
            return $"{result.Value[index].MinRegisterTime};{result.Value[index].MaxRegisterTime};{result.Value[index].AvgRegisterTime};{result.Value[index].MinResolveTime};{result.Value[index].MaxResolveTime};{result.Value[index].AvgResolveTime};";
        }

        private static List<List<TestResult>> RunAutofacPeformanceTests(int repetitionsNumber)
        {
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
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

            return testResults;
        }

        private static string RunAutofacPeformanceTests(bool singleton, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.Autofac, singleton, testsCount, testCase);
        }

        private static List<List<TestResult>> RunDryIocPeformanceTests(int repetitionsNumber)
        {
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
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

            return testResults;
        }

        private static string RunDryIocPeformanceTests(bool singleton, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.DryIoc, singleton, testsCount, testCase);
        }

        private static List<List<TestResult>> RunLightInjectPeformanceTests(int repetitionsNumber)
        {
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
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

            return testResults;
        }

        private static string RunLightInjectPeformanceTests(bool singleton, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.LightInject, singleton, testsCount, testCase);
        }

        private static List<List<TestResult>> RunNiquIoCPeformanceTests(int repetitionsNumber)
        {
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
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

            return testResults;
        }

        private static string RunNiquIoCPeformanceTests(bool singleton, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.NiquIoC, singleton, testsCount, testCase);
        }

        private static List<List<TestResult>> RunNiquIoCFullPeformanceTests(int repetitionsNumber)
        {
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
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

            return testResults;
        }

        private static string RunNiquIoCFullPeformanceTests(bool singleton, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.NiquIoCFull, singleton, testsCount, testCase);
        }

        private static List<List<TestResult>> RunSimpleInjectorPeformanceTests(int repetitionsNumber)
        {
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
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

            return testResults;
        }

        private static string RunSimpleInjectorPeformanceTests(bool singleton, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.SimpleInjector, singleton, testsCount, testCase);
        }

        private static List<List<TestResult>> RunStructureMapPeformanceTests(int repetitionsNumber)
        {
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
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

            return testResults;
        }

        private static string RunStructureMapPeformanceTests(bool singleton, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.StructureMap, singleton, testsCount, testCase);
        }

        private static List<List<TestResult>> RunUnityPeformanceTests(int repetitionsNumber)
        {
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
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

            return testResults;
        }

        private static string RunUnityPeformanceTests(bool singleton, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.Unity, singleton, testsCount, testCase);
        }

        private static List<List<TestResult>> RunWindsorPeformanceTests(int repetitionsNumber)
        {
            var testResults = new List<List<TestResult>>
            {
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),

                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
                new List<TestResult>(),
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

            return testResults;
        }

        private static string RunWindsorPeformanceTests(bool singleton, int testsCount, string testCase)
        {
            return RunPerformanceTests(ContainerName.Windsor, singleton, testsCount, testCase);
        }

        private static string RunPerformanceTests(string containerName, bool singleton, int testsCount, string testCase)
        {
            var registerKind = singleton ? "s" : "t";
            return ProcessHelper.StartProcess(@"C:\study\NiquIoC\PerformanceCalculator\bin\Debug\PerformanceCalculator.exe", $"{containerName} -r {registerKind} -c {testsCount} -t {testCase}");
        }

        private static TestResult ConvertToTestResult(string result)
        {
            var results = result.Split(' ');
            var testResult = new TestResult
            {
                Singleton = results[0] == "s" ? true : false,
                TestCasesNumber = Convert.ToInt32(results[1]),
                RegisterTime = Convert.ToInt64(results[2]),
                ResolveTime = Convert.ToInt64(results[3])
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
                    Singleton = testResult[0].Singleton,
                    TestCasesNumber = testResult[0].TestCasesNumber,
                    MinRegisterTime = testResult.Min(t => t.RegisterTime),
                    MinResolveTime = testResult.Min(t => t.ResolveTime),
                    MaxRegisterTime = testResult.Max(t => t.RegisterTime),
                    MaxResolveTime = testResult.Max(t => t.ResolveTime),
                    AvgRegisterTime = (long)Math.Round(testResult.Average(t => t.RegisterTime), 0),
                    AvgResolveTime = (long)Math.Round(testResult.Average(t => t.ResolveTime), 0),
                });
            }

            return finalTestResults;
        }
    }
}
