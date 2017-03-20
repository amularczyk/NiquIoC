using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCasesData;

namespace PerformanceCalculator.TestCase.TestCaseA
{
    public class FactoryMethodTestCaseA : TestCase
    {
        public FactoryMethodTestCaseA(IRegistration registration, IResolving resolving)
            : base(registration, resolving)
        {
        }

        public override void RegisterClasses(object container)
        {
            var testA0 = new TestA0();
            _registration.RegisterFactoryMethod<ITestA0, TestA0>(container, testA0);
            var testA1 = new TestA1(testA0);
            _registration.RegisterFactoryMethod<ITestA1, TestA1>(container, testA1);
            var testA2 = new TestA2(testA0, testA1);
            _registration.RegisterFactoryMethod<ITestA2, TestA2>(container, testA2);
            var testA3 = new TestA3(testA0, testA1, testA2);
            _registration.RegisterFactoryMethod<ITestA3, TestA3>(container, testA3);
            var testA4 = new TestA4(testA0, testA1, testA2, testA3);
            _registration.RegisterFactoryMethod<ITestA4, TestA4>(container, testA4);
            var testA5 = new TestA5(testA0, testA1, testA2, testA3, testA4);
            _registration.RegisterFactoryMethod<ITestA5, TestA5>(container, testA5);
            var testA6 = new TestA6(testA0, testA1, testA2, testA3, testA4, testA5);
            _registration.RegisterFactoryMethod<ITestA6, TestA6>(container, testA6);
            var testA7 = new TestA7(testA0, testA1, testA2, testA3, testA4, testA5, testA6);
            _registration.RegisterFactoryMethod<ITestA7, TestA7>(container, testA7);
            var testA8 = new TestA8(testA0, testA1, testA2, testA3, testA4, testA5, testA6, testA7);
            _registration.RegisterFactoryMethod<ITestA8, TestA8>(container, testA8);
            var testA9 = new TestA9(testA0, testA1, testA2, testA3, testA4, testA5, testA6, testA7, testA8);
            _registration.RegisterFactoryMethod<ITestA9, TestA9>(container, testA9);
            var testA = new TestA(testA0, testA1, testA2, testA3, testA4, testA5, testA6, testA7, testA8, testA9);
            _registration.RegisterFactoryMethod<ITestA, TestA>(container, testA);
        }

        public override void Resolve(object container, int testCasesNumber)
        {
            _resolving.Resolve<ITestA>(container, testCasesNumber);
        }
    }
}