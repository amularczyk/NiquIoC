using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTests
{
    public class RunAutofacPerformanceTests : RunPerformanceTests
    {
        public RunAutofacPerformanceTests(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.Autofac, registrationKind, testsCount, testCase);
        }
    }
}