using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers
{
    public class TestCaseC : ITestCase
    {
        private readonly IRegistration _registration;
        private readonly IResolving _resolving;

        public TestCaseC(IRegistration registration, IResolving resolving)
        {
            _registration = registration;
            _resolving = resolving;
        }

        public object Register(object container)
        {
            _registration.Register<ITestCa0, TestCa0>(container);
            _registration.Register<ITestCa1, TestCa1>(container);
            _registration.Register<ITestCa2, TestCa2>(container);
            _registration.Register<ITestCa3, TestCa3>(container);
            _registration.Register<ITestCa4, TestCa4>(container);
            _registration.Register<ITestCa5, TestCa5>(container);
            _registration.Register<ITestCa6, TestCa6>(container);
            _registration.Register<ITestCa7, TestCa7>(container);
            _registration.Register<ITestCa8, TestCa8>(container);
            _registration.Register<ITestCa9, TestCa9>(container);
            _registration.Register<ITestCa10, TestCa10>(container);

            _registration.Register<ITestCb0, TestCb0>(container);
            _registration.Register<ITestCb1, TestCb1>(container);
            _registration.Register<ITestCb2, TestCb2>(container);
            _registration.Register<ITestCb3, TestCb3>(container);
            _registration.Register<ITestCb4, TestCb4>(container);
            _registration.Register<ITestCb5, TestCb5>(container);
            _registration.Register<ITestCb6, TestCb6>(container);
            _registration.Register<ITestCb7, TestCb7>(container);
            _registration.Register<ITestCb8, TestCb8>(container);
            _registration.Register<ITestCb9, TestCb9>(container);
            _registration.Register<ITestCb10, TestCb10>(container);

            _registration.Register<ITestCc0, TestCc0>(container);
            _registration.Register<ITestCc1, TestCc1>(container);
            _registration.Register<ITestCc2, TestCc2>(container);
            _registration.Register<ITestCc3, TestCc3>(container);
            _registration.Register<ITestCc4, TestCc4>(container);
            _registration.Register<ITestCc5, TestCc5>(container);
            _registration.Register<ITestCc6, TestCc6>(container);
            _registration.Register<ITestCc7, TestCc7>(container);
            _registration.Register<ITestCc8, TestCc8>(container);
            _registration.Register<ITestCc9, TestCc9>(container);
            _registration.Register<ITestCc10, TestCc10>(container);

            _registration.Register<ITestC, TestC>(container);

            return _registration.RegisterCallback(container);
        }

        public void Resolve(object container, int testCasesNumber)
        {
            _resolving.Resolve<ITestC>(container, testCasesNumber);
        }
    }
}