using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class UnityPeformanceTestsRunner : PerformanceTestsRunner
    {
        public UnityPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.Unity, registrationKind, testsCount, testCase);
        }
    }
}