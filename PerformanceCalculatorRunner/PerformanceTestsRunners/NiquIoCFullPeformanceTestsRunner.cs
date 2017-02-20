using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class NiquIoCFullPeformanceTestsRunner : PerformanceTestsRunner
    {
        public NiquIoCFullPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, string testCase, int testsCount)
        {
            return Run(ContainerName.NiquIoCFull, registrationKind, testCase, testsCount);
        }
    }
}