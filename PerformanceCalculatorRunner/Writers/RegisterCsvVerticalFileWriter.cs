using PerformanceCalculator.Common;
using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Writers
{
    public class RegisterCsvVerticalFileWriter : CsvVerticalFileWriter
    {
        public RegisterCsvVerticalFileWriter(string resultFile) : base(resultFile)
        {
        }

        protected override string GetTestCaseColumnNameText(string containerName)
        {
            return $"{containerName};";
        }

        protected override string GetRegistrationKindColumnNameText(RegistrationKind registrationKind)
        {
            return $"{registrationKind};";
        }

        protected override string GetTestsCountColumnNameText(int testsCount)
        {
            return $"{testsCount};";
        }

        protected override string GetMinResultText(FinalTestResult testResult)
        {
            return $"{testResult.MinRegisterTime};";
        }

        protected override string GetMaxResultText(FinalTestResult testResult)
        {
            return $"{testResult.MaxRegisterTime};";
        }

        protected override string GetAvgResultText(FinalTestResult testResult)
        {
            return $"{testResult.AvgRegisterTime};";
        }
    }
}