using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCasesData;

namespace PerformanceCalculator.TestCase.TestCaseB
{
    public class FactoryMethodTestCaseB : TestCase
    {
        public FactoryMethodTestCaseB(IRegistration registration, IResolving resolving)
            : base(registration, resolving)
        {
        }

        public override void RegisterClasses(object container)
        {
            _registration.RegisterFactoryMethod<ITestB, TestB>(container, c =>
            {
                var testBa0 = new TestBa0();
                var testBa1 = new TestBa1(testBa0);
                var testBa2 = new TestBa2(testBa0, testBa1);
                var testBa3 = new TestBa3(testBa0, testBa1, testBa2);
                var testBa4 = new TestBa4(testBa0, testBa1, testBa2, testBa3);
                var testBa5 = new TestBa5(testBa0, testBa1, testBa2, testBa3, testBa4);
                var testBa6 = new TestBa6(testBa0, testBa1, testBa2, testBa3, testBa4, testBa5);
                var testBa7 = new TestBa7(testBa0, testBa1, testBa2, testBa3, testBa4, testBa5, testBa6);
                var testBa8 = new TestBa8(testBa0, testBa1, testBa2, testBa3, testBa4, testBa5, testBa6, testBa7);
                var testBa9 = new TestBa9(testBa0, testBa1, testBa2, testBa3, testBa4, testBa5, testBa6, testBa7,
                    testBa8);
                var testBa10 = new TestBa10(testBa0, testBa1, testBa2, testBa3, testBa4, testBa5, testBa6, testBa7,
                    testBa8, testBa9);

                var testBb0 = new TestBb0();
                var testBb1 = new TestBb1(testBb0);
                var testBb2 = new TestBb2(testBb0, testBb1);
                var testBb3 = new TestBb3(testBb0, testBb1, testBb2);
                var testBb4 = new TestBb4(testBb0, testBb1, testBb2, testBb3);
                var testBb5 = new TestBb5(testBb0, testBb1, testBb2, testBb3, testBb4);
                var testBb6 = new TestBb6(testBb0, testBb1, testBb2, testBb3, testBb4, testBb5);
                var testBb7 = new TestBb7(testBb0, testBb1, testBb2, testBb3, testBb4, testBb5, testBb6);
                var testBb8 = new TestBb8(testBb0, testBb1, testBb2, testBb3, testBb4, testBb5, testBb6, testBb7);
                var testBb9 = new TestBb9(testBb0, testBb1, testBb2, testBb3, testBb4, testBb5, testBb6, testBb7,
                    testBb8);
                var testBb10 = new TestBb10(testBb0, testBb1, testBb2, testBb3, testBb4, testBb5, testBb6, testBb7,
                    testBb8, testBb9);

                var testBc0 = new TestBc0();
                var testBc1 = new TestBc1(testBc0);
                var testBc2 = new TestBc2(testBc0, testBc1);
                var testBc3 = new TestBc3(testBc0, testBc1, testBc2);
                var testBc4 = new TestBc4(testBc0, testBc1, testBc2, testBc3);
                var testBc5 = new TestBc5(testBc0, testBc1, testBc2, testBc3, testBc4);
                var testBc6 = new TestBc6(testBc0, testBc1, testBc2, testBc3, testBc4, testBc5);
                var testBc7 = new TestBc7(testBc0, testBc1, testBc2, testBc3, testBc4, testBc5, testBc6);
                var testBc8 = new TestBc8(testBc0, testBc1, testBc2, testBc3, testBc4, testBc5, testBc6, testBc7);
                var testBc9 = new TestBc9(testBc0, testBc1, testBc2, testBc3, testBc4, testBc5, testBc6, testBc7,
                    testBc8);
                var testBc10 = new TestBc10(testBc0, testBc1, testBc2, testBc3, testBc4, testBc5, testBc6, testBc7,
                    testBc8, testBc9);

                var testB = new TestB(testBa10, testBb10, testBc10);

                return testB;
            });
        }

        public override void Resolve(object container, int testCasesNumber)
        {
            _resolving.Resolve<ITestB>(container, testCasesNumber);
        }
    }
}