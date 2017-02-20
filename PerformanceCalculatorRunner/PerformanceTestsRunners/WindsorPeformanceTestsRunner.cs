using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class WindsorPeformanceTestsRunner : PerformanceTestsRunner
    {
        public WindsorPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, string testCase, int testsCount)
        {
            return Run(ContainerName.Windsor, registrationKind, testCase, testsCount);
        }
    }
}