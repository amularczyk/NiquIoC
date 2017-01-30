using PerformanceCalculator.Common;

namespace PerformanceCalculator.Interfaces
{
    public interface IPerformanceTest
    {
        TestResult RunTest(int count, string testCase, RegistrationKind registrationKind);
    }
}