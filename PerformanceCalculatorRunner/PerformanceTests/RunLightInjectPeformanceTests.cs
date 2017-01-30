using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTests
{
    public class RunLightInjectPeformanceTests : RunPerformanceTests
    {
        public RunLightInjectPeformanceTests(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.LightInject, registrationKind, testsCount, testCase);
        }
    }
}