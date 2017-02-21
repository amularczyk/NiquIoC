using PerformanceCalculatorRunner.Interfaces;
using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Writers
{
    public class CsvResolveTextFormatter : ITextFormatter
    {
        public string GetColumnNameText(string containerName)
        {
            return $"{containerName} Resolve;{containerName} Resolve;{containerName} Resolve;";
        }

        public string GetColumnHeaderText()
        {
            return "Min;Max;Avg;";
        }

        public string GetResultText(FinalTestResult testResult)
        {
            return $"{testResult.MinResolveTime};{testResult.MaxResolveTime};{testResult.AvgResolveTime};";
        }
    }
}