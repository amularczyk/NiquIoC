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

            var performance = GetPerformance(name);

            var testResult = DoPerformanceTests(testCase, performance, count, singleton);

            WriteFirstTestResults(testResult);
            
            return 0;
        }

        private static TestResult DoPerformanceTests(string testCase, IPerformance performance, int count, bool singleton)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    performance.DoTestA(1, singleton);
                    return performance.DoTestA(count, singleton);

                case TestCaseName.B:
                    performance.DoTestB(1, singleton);
                    return performance.DoTestB(count, singleton);

                case TestCaseName.C:
                    performance.DoTestC(1, singleton);
                    return performance.DoTestC(count, singleton);

                default:
                    throw new InvalidOperationException();
            }
        }

        private static IPerformance GetPerformance(string name)
        {
            switch (name)
            {
                case ContainerName.Autofac:
                    return new AutofacPerformance();

                case ContainerName.DryIoc:
                    return new DryIocPerformance();

                case ContainerName.LightInject:
                    return new LightInjectPerformance();

                case ContainerName.NiquIoC:
                    return new NiquIoCPerformance();

                case ContainerName.NiquIoCFull:
                    return new NiquIoCFullPerformance();

                case ContainerName.SimpleInjector:
                    return new SimpleInjectorPerformance();

                case ContainerName.StructureMap:
                    return new StructureMapPerformance();

                case ContainerName.Unity:
                    return new UnityPerformance();

                case ContainerName.Windsor:
                    return new WindsorPerformance();

                default:
                    throw new InvalidOperationException();
            }
        }

        private static void WriteFirstTestResults(TestResult testResult)
        {
            var registerType = testResult.Singleton ? "s" : "t";
            Console.Write($"{registerType} {testResult.TestCasesNumber} {testResult.RegisterTime} {testResult.ResolveTime}");
        }
    }
}