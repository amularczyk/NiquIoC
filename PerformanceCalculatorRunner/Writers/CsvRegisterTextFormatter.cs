using PerformanceCalculatorRunner.Interfaces;
using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Writers
{
    public class CsvRegisterTextFormatter : ITextFormatter
    {
        public string GetColumnNameText(string containerName)
        {
            return $"{containerName} Register;{containerName} Register;{containerName} Register;";
        }

        public string GetColumnHeaderText()
        {
            return "Min;Max;Avg;";
        }

        public string GetResultText(FinalTestResult testResult)
        {
            return $"{testResult.MinRegisterTime};{testResult.MaxRegisterTime};{testResult.AvgRegisterTime};";
        }
    }
}