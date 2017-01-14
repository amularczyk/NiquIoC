using PerformanceCalculator.Common;

namespace PerformanceCalculator.Interfaces
{
    public interface IPerformanceTest
    {
        TestResult DoTest(int count, string testCase, RegistrationKind registrationKind);
    }
}