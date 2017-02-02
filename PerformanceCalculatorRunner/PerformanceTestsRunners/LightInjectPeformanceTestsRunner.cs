using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class LightInjectPeformanceTestsRunner : PerformanceTestsRunner
    {
        public LightInjectPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.LightInject, registrationKind, testsCount, testCase);
        }
    }
}