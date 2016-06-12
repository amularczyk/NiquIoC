namespace PerformanceCalculator
{
    public interface ITestCase
    {
        object SingletonRegister(object container);

        object TransientRegister(object container);

        void Resolve(object container, int testCasesNumber, bool singleton);
    }
}