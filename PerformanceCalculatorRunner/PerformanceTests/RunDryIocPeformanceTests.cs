using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTests
{
    public class RunDryIocPeformanceTests : RunPerformanceTests
    {
        public RunDryIocPeformanceTests(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.DryIoc, registrationKind, testsCount, testCase);
        }
    }
}