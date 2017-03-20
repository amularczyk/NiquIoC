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
            var testA1 = new TestA1(testA0);
            var testA2 = new TestA2(testA0, testA1);
            var testA3 = new TestA3(testA0, testA1, testA2);
            var testA4 = new TestA4(testA0, testA1, testA2, testA3);
            var testA5 = new TestA5(testA0, testA1, testA2, testA3, testA4);
            var testA6 = new TestA6(testA0, testA1, testA2, testA3, testA4, testA5);
            var testA7 = new TestA7(testA0, testA1, testA2, testA3, testA4, testA5, testA6);
            var testA8 = new TestA8(testA0, testA1, testA2, testA3, testA4, testA5, testA6, testA7);
            var testA9 = new TestA9(testA0, testA1, testA2, testA3, testA4, testA5, testA6, testA7, testA8);

            var testA = new TestA(testA0, testA1, testA2, testA3, testA4, testA5, testA6, testA7, testA8, testA9);

            _registration.RegisterFactoryMethod<ITestA, TestA>(container, testA);
        }

        public override void Resolve(object container, int testCasesNumber)
        {
            _resolving.Resolve<ITestA>(container, testCasesNumber);
        }
    }
}