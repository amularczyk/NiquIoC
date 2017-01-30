using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTests
{
    public class RunStructureMapPeformanceTests : RunPerformanceTests
    {
        public RunStructureMapPeformanceTests(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.StructureMap, registrationKind, testsCount, testCase);
        }
    }
}