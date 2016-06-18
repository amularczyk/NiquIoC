using System;

namespace PerformanceCalculatorRunner
{
    internal class Program
    {
        private static void Main()
        {
            var repetitionsNumber = 3;

            for (var i = 0; i < repetitionsNumber; i++)
            {
                var standardOutput = RunAutofacPeformanceTests(true, 100, 'A');
                Console.WriteLine(standardOutput);
            }
            for (var i = 0; i < repetitionsNumber; i++)
            {
                var standardOutput = RunAutofacPeformanceTests(false, 100, 'A');
                Console.WriteLine(standardOutput);
            }

            Console.ReadLine();
        }

        private static string RunAutofacPeformanceTests(bool singleton, int testsCount, char testCase)
        {
            return RunPerformanceTests("Autofac", singleton, testsCount, testCase);
        }

        private static string RunPerformanceTests(string containerName, bool singleton, int testsCount, char testCase)
        {
            var registerKind = singleton ? "s" : "t";
            return ProcessHelper.StartProcess(@"C:\study\NiquIoC\PerformanceCalculator\bin\Debug\PerformanceCalculator.exe", $"{containerName} -r {registerKind} -c {testsCount} -t {testCase}");
        }
    }
}
