using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class SimpleInjectorPeformanceTestsRunner : PerformanceTestsRunner
    {
        public SimpleInjectorPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.SimpleInjector, registrationKind, testsCount, testCase);
        }
    }
}