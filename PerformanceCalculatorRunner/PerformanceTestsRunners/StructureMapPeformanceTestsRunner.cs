using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class StructureMapPeformanceTestsRunner : PerformanceTestsRunner
    {
        public StructureMapPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, string testCase, int testsCount)
        {
            return Run(ContainerName.StructureMap, registrationKind, testCase, testsCount);
        }
    }
}