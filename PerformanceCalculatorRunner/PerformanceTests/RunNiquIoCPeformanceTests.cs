using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTests
{
    public class RunNiquIoCPeformanceTests : RunPerformanceTests
    {
        public RunNiquIoCPeformanceTests(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.NiquIoC, registrationKind, testsCount, testCase);
        }
    }
}