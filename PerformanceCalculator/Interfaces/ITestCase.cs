namespace PerformanceCalculator.Interfaces
{
    public interface ITestCase
    {
        object Register(object container);

        void Resolve(object container, int testCasesNumber);
    }
}