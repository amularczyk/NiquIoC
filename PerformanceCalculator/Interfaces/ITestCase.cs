using PerformanceCalculator.Common;

namespace PerformanceCalculator.Interfaces
{
    public interface ITestCase : IRegistration
    {
        void Resolve(object container, int testCasesNumber);
    }
}