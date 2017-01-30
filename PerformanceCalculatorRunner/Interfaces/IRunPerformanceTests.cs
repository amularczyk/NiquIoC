using System.Collections.Generic;
using PerformanceCalculator.Common;
using PerformanceCalculatorRunner.PerformanceTests;

namespace PerformanceCalculatorRunner.Interfaces
{
    public interface IRunPerformanceTests
    {
        List<List<TestResult>> RunTests(int repetitionsNumber, IEnumerable<PerformanceTestCase> testCases);
    }
}