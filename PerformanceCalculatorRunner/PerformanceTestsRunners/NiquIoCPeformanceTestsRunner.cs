using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class NiquIoCPeformanceTestsRunner : PerformanceTestsRunner
    {
        public NiquIoCPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.NiquIoC, registrationKind, testsCount, testCase);
        }
    }
}