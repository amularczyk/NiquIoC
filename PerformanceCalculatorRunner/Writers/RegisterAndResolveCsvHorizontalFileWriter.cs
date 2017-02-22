using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Writers
{
    public class RegisterAndResolveCsvHorizontalFileWriter : CsvHorizontalFileWriter
    {
        public RegisterAndResolveCsvHorizontalFileWriter(string resultFile) : base(resultFile)
        {
        }

        protected override string GetColumnNameText(string containerName)
        {
            return $"{containerName} Register;{containerName} Register;{containerName} Register;" +
                   $"{containerName} Resolve;{containerName} Resolve;{containerName} Resolve;";
        }

        protected override string GetColumnHeaderText()
        {
            return "Min;Max;Avg;Min;Max;Avg;";
        }

        protected override string GetResultText(FinalTestResult testResult)
        {
            return $"{testResult.MinRegisterTime};{testResult.MaxRegisterTime};{testResult.AvgRegisterTime};" +
                   $"{testResult.MinResolveTime};{testResult.MaxResolveTime};{testResult.AvgResolveTime};";
        }
    }
}