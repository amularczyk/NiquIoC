using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class SimpleInjectorPeformanceTestsRunner : PerformanceTestsRunner
    {
        public SimpleInjectorPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, string testCase, int testsCount)
        {
            return Run(ContainerName.SimpleInjector, registrationKind, testCase, testsCount);
        }
    }
}