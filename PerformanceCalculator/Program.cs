using System;
using PerformanceCalculator.Common;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Containers.TestsDryIoc;
using PerformanceCalculator.Containers.TestsLightInject;
using PerformanceCalculator.Containers.TestsNiquIoC;
using PerformanceCalculator.Containers.TestsNiquIoC_Full;
using PerformanceCalculator.Containers.TestsSimpleInjector;
using PerformanceCalculator.Containers.TestsStructureMap;
using PerformanceCalculator.Containers.TestsUnity;
using PerformanceCalculator.Containers.TestsWindsor;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator
{
    public class Program
    {
        private static int Main(string[] args)
        {
            var argsCount = 7;

            if (args.Length != argsCount)
            {
                return 1;
            }

            var name = args[0];
            var singleton = false;
            var count = 1;
            var testCase = TestCaseName.A;

            for (var i = 1; i < argsCount; i += 2)
            {
                switch (args[i])
                {
                    case "-r":
                        singleton = args[i + 1] == "s";
                        break;

                    case "-c":
                        count = Convert.ToInt32(args[i + 1]);
                        break;

                    case "-t":
                        testCase = args[i + 1];
                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }

            IPerformance performance;
            switch (name)
            {
                case ContainerName.Autofac:
                    performance = new AutofacPerformance();
                    break;

                case ContainerName.DryIoc:
                    performance = new DryIocPerformance();
                    break;

                case ContainerName.LightInject:
                    performance = new LightInjectPerformance();
                    break;

                case ContainerName.NiquIoC:
                    performance = new NiquIoCPerformance();
                    break;

                case ContainerName.NiquIoCFull:
                    performance = new NiquIoCFullPerformance();
                    break;

                case ContainerName.SimpleInjector:
                    performance = new SimpleInjectorPerformance();
                    break;

                case ContainerName.StructureMap:
                    performance = new StructureMapPerformance();
                    break;

                case ContainerName.Unity:
                    performance = new UnityPerformance();
                    break;

                case ContainerName.Windsor:
                    performance = new WindsorPerformance();
                    break;

                default:
                    throw new InvalidOperationException();
            }

            TestResult testResult;
            switch (testCase)
            {
                case TestCaseName.A:
                    testResult = performance.DoTestA(count, singleton);
                    break;

                case TestCaseName.B:
                    testResult = performance.DoTestB(count, singleton);
                    break;

                case TestCaseName.C:
                    testResult = performance.DoTestC(count, singleton);
                    break;

                default:
                    throw new InvalidOperationException();
            }

            WriteFirstTestResults(testResult);

            return 0;
        }

        private static void WriteFirstTestResults(TestResult testResult)
        {
            var registerType = testResult.Singleton ? "s" : "t";
            Console.Write($"{registerType} {testResult.TestCasesNumber} {testResult.RegisterTime} {testResult.ResolveTime}");
        }
    }
}