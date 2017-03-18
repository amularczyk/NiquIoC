using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers
{
    public class TestCaseC : TestCase
    {
        public TestCaseC(IRegistration registration, IResolving resolving)
            : base(registration, resolving)
        {
        }

        public override void RegisterClasses(object container)
        {
            _registration.Register<ITestBa0, TestBa0>(container);
            _registration.Register<ITestBa1, TestBa1>(container);
            _registration.Register<ITestBa2, TestBa2>(container);
            _registration.Register<ITestBa3, TestBa3>(container);
            _registration.Register<ITestBa4, TestBa4>(container);
            _registration.Register<ITestBa5, TestBa5>(container);
            _registration.Register<ITestBa6, TestBa6>(container);
            _registration.Register<ITestBa7, TestBa7>(container);
            _registration.Register<ITestBa8, TestBa8>(container);
            _registration.Register<ITestBa9, TestBa9>(container);
            _registration.Register<ITestBa10, TestBa10>(container);

            _registration.Register<ITestBb0, TestBb0>(container);
            _registration.Register<ITestBb1, TestBb1>(container);
            _registration.Register<ITestBb2, TestBb2>(container);
            _registration.Register<ITestBb3, TestBb3>(container);
            _registration.Register<ITestBb4, TestBb4>(container);
            _registration.Register<ITestBb5, TestBb5>(container);
            _registration.Register<ITestBb6, TestBb6>(container);
            _registration.Register<ITestBb7, TestBb7>(container);
            _registration.Register<ITestBb8, TestBb8>(container);
            _registration.Register<ITestBb9, TestBb9>(container);
            _registration.Register<ITestBb10, TestBb10>(container);

            _registration.Register<ITestBc0, TestBc0>(container);
            _registration.Register<ITestBc1, TestBc1>(container);
            _registration.Register<ITestBc2, TestBc2>(container);
            _registration.Register<ITestBc3, TestBc3>(container);
            _registration.Register<ITestBc4, TestBc4>(container);
            _registration.Register<ITestBc5, TestBc5>(container);
            _registration.Register<ITestBc6, TestBc6>(container);
            _registration.Register<ITestBc7, TestBc7>(container);
            _registration.Register<ITestBc8, TestBc8>(container);
            _registration.Register<ITestBc9, TestBc9>(container);
            _registration.Register<ITestBc10, TestBc10>(container);

            _registration.Register<ITestB, TestB>(container);
        }

        public override void Resolve(object container, int testCasesNumber)
        {
            _resolving.Resolve<ITestB>(container, testCasesNumber);
        }
    }
}