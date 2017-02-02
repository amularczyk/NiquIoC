using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class AutofacPerformanceTestsRunner : PerformanceTestsRunner
    {
        public AutofacPerformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.Autofac, registrationKind, testsCount, testCase);
        }
    }
}