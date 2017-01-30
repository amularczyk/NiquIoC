using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTests
{
    public class RunNiquIoCFullPeformanceTests : RunPerformanceTests
    {
        public RunNiquIoCFullPeformanceTests(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.NiquIoCFull, registrationKind, testsCount, testCase);
        }
    }
}