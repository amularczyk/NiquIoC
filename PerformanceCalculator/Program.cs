using System;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator
{
    internal class Program
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
            var testCase = "A";

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
                }
            }

            IPerformance performance;
            switch (name)
            {
                case "Autofac":
                    performance = new AutofacPerformance();
                    break;

                default:
                    throw new InvalidOperationException();
            }

            TestResult testResult;
            switch (testCase)
            {
                case "A":
                    testResult = performance.DoTestA(count, singleton);
                    break;

                case "B":
                    testResult = performance.DoTestB(count, singleton);
                    break;

                case "C":
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