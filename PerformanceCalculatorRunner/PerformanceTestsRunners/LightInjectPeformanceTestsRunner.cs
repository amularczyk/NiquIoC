using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class LightInjectPeformanceTestsRunner : PerformanceTestsRunner
    {
        public LightInjectPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, string testCase, int testsCount)
        {
            return Run(ContainerName.LightInject, registrationKind, testCase, testsCount);
        }
    }
}