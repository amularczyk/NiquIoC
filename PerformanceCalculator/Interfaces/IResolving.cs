namespace PerformanceCalculator.Interfaces
{
    public interface IResolving
    {
        void Resolve<T>(object container, int TestCasesNumber)
            where T : class;
    }
}