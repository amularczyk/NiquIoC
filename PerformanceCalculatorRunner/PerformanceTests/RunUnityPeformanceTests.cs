using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTests
{
    public class RunUnityPeformanceTests : RunPerformanceTests
    {
        public RunUnityPeformanceTests(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.Unity, registrationKind, testsCount, testCase);
        }
    }
}