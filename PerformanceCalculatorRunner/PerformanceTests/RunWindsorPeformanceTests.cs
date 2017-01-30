using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTests
{
    public class RunWindsorPeformanceTests : RunPerformanceTests
    {
        public RunWindsorPeformanceTests(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.Windsor, registrationKind, testsCount, testCase);
        }
    }
}