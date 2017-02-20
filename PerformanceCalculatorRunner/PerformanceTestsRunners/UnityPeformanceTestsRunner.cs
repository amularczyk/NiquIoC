using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class UnityPeformanceTestsRunner : PerformanceTestsRunner
    {
        public UnityPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, string testCase, int testsCount)
        {
            return Run(ContainerName.Unity, registrationKind, testCase, testsCount);
        }
    }
}