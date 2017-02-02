using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class WindsorPeformanceTestsRunner : PerformanceTestsRunner
    {
        public WindsorPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.Windsor, registrationKind, testsCount, testCase);
        }
    }
}