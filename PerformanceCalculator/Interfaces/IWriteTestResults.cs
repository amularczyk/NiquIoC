using PerformanceCalculator.Common;

namespace PerformanceCalculator.Interfaces
{
    public interface IWriteTestResults
    {
        void Write(TestResult testResult);
    }
}