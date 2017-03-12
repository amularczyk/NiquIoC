using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers
{
    public class TestCaseA : TestCase
    {
        public TestCaseA(IRegistration registration, IResolving resolving)
            : base(registration, resolving)
        {
        }

        public override void RegisterClasses(object container)
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
        }

        public override void Resolve(object container, int testCasesNumber)
        {
            _resolving.Resolve<ITestA>(container, testCasesNumber);
        }
    }
}