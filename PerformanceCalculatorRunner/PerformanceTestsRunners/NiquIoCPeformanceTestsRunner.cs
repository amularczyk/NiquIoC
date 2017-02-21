using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class NiquIoCPeformanceTestsRunner : PerformanceTestsRunner
    {
        public NiquIoCPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, string testCase, int testsCount)
        {
            return Run(ContainerName.NiquIoCPartial, registrationKind, testCase, testsCount);
        }
    }
}