using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class DryIocPeformanceTestsRunner : PerformanceTestsRunner
    {
        public DryIocPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.DryIoc, registrationKind, testsCount, testCase);
        }
    }
}