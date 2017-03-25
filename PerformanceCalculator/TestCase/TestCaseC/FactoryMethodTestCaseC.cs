using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCasesData;

namespace PerformanceCalculator.TestCase.TestCaseC
{
    public class FactoryMethodTestCaseC : TestCase
    {
        public FactoryMethodTestCaseC(IRegistration registration, IResolving resolving)
            : base(registration, resolving)
        {
        }

        public override void RegisterClasses(object container)
        {
            _registration.RegisterFactoryMethod<ITestC, TestC>(container, c =>
            {
                var testC00 = new TestC00();
                var testC01 = new TestC01();
                var testC02 = new TestC02();
                var testC03 = new TestC03();
                var testC04 = new TestC04();

                var testC10 = new TestC10(testC00, testC01, testC02, testC03, testC04);
                var testC11 = new TestC11(testC00, testC01, testC02, testC03, testC04);
                var testC12 = new TestC12(testC00, testC01, testC02, testC03, testC04);
                var testC13 = new TestC13(testC00, testC01, testC02, testC03, testC04);
                var testC14 = new TestC14(testC00, testC01, testC02, testC03, testC04);

                var testC20 = new TestC20(testC10, testC11, testC12, testC13, testC14);
                var testC21 = new TestC21(testC10, testC11, testC12, testC13, testC14);
                var testC22 = new TestC22(testC10, testC11, testC12, testC13, testC14);
                var testC23 = new TestC23(testC10, testC11, testC12, testC13, testC14);
                var testC24 = new TestC24(testC10, testC11, testC12, testC13, testC14);

                var testC30 = new TestC30(testC20, testC21, testC22, testC23, testC24);
                var testC31 = new TestC31(testC20, testC21, testC22, testC23, testC24);
                var testC32 = new TestC32(testC20, testC21, testC22, testC23, testC24);
                var testC33 = new TestC33(testC20, testC21, testC22, testC23, testC24);
                var testC34 = new TestC34(testC20, testC21, testC22, testC23, testC24);

                var testC40 = new TestC40(testC30, testC31, testC32, testC33, testC34);
                var testC41 = new TestC41(testC30, testC31, testC32, testC33, testC34);
                var testC42 = new TestC42(testC30, testC31, testC32, testC33, testC34);
                var testC43 = new TestC43(testC30, testC31, testC32, testC33, testC34);
                var testC44 = new TestC44(testC30, testC31, testC32, testC33, testC34);

                var testC = new TestC(testC40, testC41, testC42, testC43, testC44);

                return testC;
            });
        }

        public override void Resolve(object container, int testCasesNumber)
        {
            _resolving.Resolve<ITestC>(container, testCasesNumber);
        }
    }
}