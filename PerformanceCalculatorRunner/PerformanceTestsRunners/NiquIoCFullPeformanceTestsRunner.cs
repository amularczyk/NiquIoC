using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class NiquIoCFullPeformanceTestsRunner : PerformanceTestsRunner
    {
        public NiquIoCFullPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.NiquIoCFull, registrationKind, testsCount, testCase);
        }
    }
}