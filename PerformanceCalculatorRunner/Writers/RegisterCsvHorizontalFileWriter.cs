using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Writers
{
    public class RegisterCsvHorizontalFileWriter : CsvHorizontalFileWriter
    {
        public RegisterCsvHorizontalFileWriter(string resultFile) : base(resultFile)
        {
        }

        protected override string GetColumnNameText(string containerName)
        {
            return $"{containerName} Register;{containerName} Register;{containerName} Register;";
        }

        protected override string GetColumnHeaderText()
        {
            return "Min;Max;Avg;";
        }

        protected override string GetResultText(FinalTestResult testResult)
        {
            return $"{testResult.MinRegisterTime};{testResult.MaxRegisterTime};{testResult.AvgRegisterTime};";
        }
    }
}