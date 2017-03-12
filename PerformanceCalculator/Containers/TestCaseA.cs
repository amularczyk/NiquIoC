using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers
{
    public class TestCaseA : ITestCase
    {
        private readonly IRegistration _registration;
        private readonly IResolving _resolving;

        public TestCaseA(IRegistration registration, IResolving resolving)
        {
            _registration = registration;
            _resolving = resolving;
        }

        public object Register(object container)
        {
            _registration.Register<ITestA0, TestA0>(container);
            _registration.Register<ITestA1, TestA1>(container);
            _registration.Register<ITestA2, TestA2>(container);
            _registration.Register<ITestA3, TestA3>(container);
            _registration.Register<ITestA4, TestA4>(container);
            _registration.Register<ITestA5, TestA5>(container);
            _registration.Register<ITestA6, TestA6>(container);
            _registration.Register<ITestA7, TestA7>(container);
            _registration.Register<ITestA8, TestA8>(container);
            _registration.Register<ITestA9, TestA9>(container);
            _registration.Register<ITestA, TestA>(container);

            return _registration.RegisterCallback(container);
        }

        public void Resolve(object container, int testCasesNumber)
        {
            _resolving.Resolve<ITestA>(container, testCasesNumber);
        }
    }
}