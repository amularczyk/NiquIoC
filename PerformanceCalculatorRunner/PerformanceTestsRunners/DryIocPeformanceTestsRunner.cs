using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class DryIocPeformanceTestsRunner : PerformanceTestsRunner
    {
        public DryIocPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, string testCase, int testsCount)
        {
            return Run(ContainerName.DryIoc, registrationKind, testCase, testsCount);
        }
    }
}