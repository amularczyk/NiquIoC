using System.Collections.Generic;
using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.Interfaces
{
    public interface IRunPerformanceTests
    {
        List<List<TestResult>> RunTests(int repetitionsNumber);
    }
}