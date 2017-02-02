using PerformanceCalculator.Common;

namespace PerformanceCalculatorRunner.PerformanceTestsRunners
{
    public class StructureMapPeformanceTestsRunner : PerformanceTestsRunner
    {
        public StructureMapPeformanceTestsRunner(string processPath)
            : base(processPath)
        {
        }

        public override string RunTests(RegistrationKind registrationKind, int testsCount, string testCase)
        {
            return Run(ContainerName.StructureMap, registrationKind, testsCount, testCase);
        }
    }
}