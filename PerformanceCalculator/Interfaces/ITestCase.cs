namespace PerformanceCalculator.Interfaces
{
    public interface ITestCase
    {
        object SingletonRegister(object container);

        object TransientRegister(object container);

        object PerThreadRegister(object container);

        object PerHttpContextRegister(object container);

        void Resolve(object container, int testCasesNumber, bool singleton);
    }
}