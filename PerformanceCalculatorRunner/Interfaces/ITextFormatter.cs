using PerformanceCalculatorRunner.Models;

namespace PerformanceCalculatorRunner.Interfaces
{
    public interface ITextFormatter
    {
        string GetColumnNameText(string containerName);

        string GetColumnHeaderText();

        string GetResultText(FinalTestResult testResult);
    }
}