using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class AutofacPerformanceTestsRunner : PerformanceTestsRunner
    {
        public AutofacPerformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, string testCase, int testsCount)
        {
            return Run(ContainerName.Autofac, registrationKind, testCase, testsCount);
        }
    }
}