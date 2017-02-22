using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Writers
{
    public class ResolveCsvHorizontalFileWriter : CsvHorizontalFileWriter
    {
        public ResolveCsvHorizontalFileWriter(string resultFile) : base(resultFile)
        {
        }

        protected override string GetColumnNameText(string containerName)
        {
            return $"{containerName} Resolve;{containerName} Resolve;{containerName} Resolve;";
        }

        protected override string GetColumnHeaderText()
        {
            return "Min;Max;Avg;";
        }

        protected override string GetResultText(FinalTestResult testResult)
        {
            return $"{testResult.MinResolveTime};{testResult.MaxResolveTime};{testResult.AvgResolveTime};";
        }
    }
}