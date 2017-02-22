using PerformanceCalculator.Common;
using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Writers
{
    public class RegisterAndResolveCsvVerticalFileWriter : CsvVerticalFileWriter
    {
        public RegisterAndResolveCsvVerticalFileWriter(string resultFile) : base(resultFile)
        {
        }

        protected override string GetTestCaseColumnNameText(string containerName)
        {
            return $"{containerName} Register;{containerName} Resolve;";
        }

        protected override string GetRegistrationKindColumnNameText(RegistrationKind registrationKind)
        {
            return $"{registrationKind};{registrationKind};";
        }

        protected override string GetTestsCountColumnNameText(int testsCount)
        {
            return $"{testsCount};{testsCount};";
        }

        protected override string GetMinResultText(FinalTestResult testResult)
        {
            return $"{testResult.MinRegisterTime};{testResult.MinResolveTime};";
        }

        protected override string GetMaxResultText(FinalTestResult testResult)
        {
            return $"{testResult.MaxRegisterTime};{testResult.MaxResolveTime};";
        }

        protected override string GetAvgResultText(FinalTestResult testResult)
        {
            return $"{testResult.AvgRegisterTime};{testResult.AvgResolveTime};";
        }
    }
}