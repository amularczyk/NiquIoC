using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTests
{
    public class RunSimpleInjectorPeformanceTests : RunPerformanceTests
    {
        public RunSimpleInjectorPeformanceTests(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.SimpleInjector, registrationKind, testsCount, testCase);
        }
    }
}