using System.Collections.Generic;

namespace PerformanceCalculator
{
    public interface IPerformance
    {
        IEnumerable<TestResult> DoTests();

        TestResult DoTest(ITestCase testCase, int testCasesNumber, bool singleton);
    }
}