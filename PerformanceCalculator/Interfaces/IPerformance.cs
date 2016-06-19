namespace PerformanceCalculator.Interfaces
{
    public interface IPerformance
    {
        TestResult DoTest(ITestCase testCase, int testCasesNumber, bool singleton);

        TestResult DoTestA(int testCasesNumber, bool singleton);

        TestResult DoTestB(int testCasesNumber, bool singleton);

        TestResult DoTestC(int testCasesNumber, bool singleton);
    }
}