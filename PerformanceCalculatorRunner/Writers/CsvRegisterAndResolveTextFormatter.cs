using PerformanceCalculatorRunner.Interfaces;
using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Writers
{
    public class CsvRegisterAndResolveTextFormatter : ITextFormatter
    {
        public string GetColumnNameText(string containerName)
        {
            return $"{containerName} Register;{containerName} Register;{containerName} Register;" +
                $"{containerName} Resolve;{containerName} Resolve;{containerName} Resolve;";
        }

        public string GetColumnHeaderText()
        {
            return "Min;Max;Avg;Min;Max;Avg;";
        }

        public string GetResultText(FinalTestResult testResult)
        {
            return $"{testResult.MinRegisterTime};{testResult.MaxRegisterTime};{testResult.AvgRegisterTime};" +
                $"{testResult.MinResolveTime};{testResult.MaxResolveTime};{testResult.AvgResolveTime};";
        }
    }
}