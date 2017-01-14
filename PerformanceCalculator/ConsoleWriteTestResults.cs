using System;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator
{
    public class ConsoleWriteTestResults : IWriteTestResults
    {
        public void Write(TestResult testResult)
        {
            Console.Write($"{(int)testResult.RegistrationKind} {testResult.TestCasesNumber} {testResult.RegisterTime} {testResult.ResolveTime}");
        }
    }
}