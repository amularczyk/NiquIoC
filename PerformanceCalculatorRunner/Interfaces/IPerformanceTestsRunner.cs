using System.Collections.Generic;
using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.Interfaces
{
    public interface IPerformanceTestsRunner
    {
        List<List<TestResult>> RunTests(int repetitionsNumber, IEnumerable<PerformanceTestCase> testCases);
    }
}