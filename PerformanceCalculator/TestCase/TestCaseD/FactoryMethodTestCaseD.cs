using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCasesData;

namespace PerformanceCalculator.TestCase.TestCaseD
{
    public class FactoryMethodTestCaseD : TestCase
    {
        public FactoryMethodTestCaseD(IRegistration registration, IResolving resolving)
            : base(registration, resolving)
        {
        }

        public override void RegisterClasses(object container)
        {
            _registration.RegisterFactoryMethod<ITestD, TestD>(container, c =>
            {
                var testD00 = new TestD00();
                var testD01 = new TestD01();
                var testD02 = new TestD02();
                var testD03 = new TestD03();
                var testD04 = new TestD04();
                var testD05 = new TestD05();
                var testD06 = new TestD06();
                var testD07 = new TestD07();
                var testD08 = new TestD08();
                var testD09 = new TestD09();

                var testD10 = new TestD10(testD00, testD01, testD02, testD03, testD04, testD05, testD06, testD07,
                    testD08, testD09);
                var testD11 = new TestD11(testD00, testD01, testD02, testD03, testD04, testD05, testD06, testD07,
                    testD08, testD09);
                var testD12 = new TestD12(testD00, testD01, testD02, testD03, testD04, testD05, testD06, testD07,
                    testD08, testD09);
                var testD13 = new TestD13(testD00, testD01, testD02, testD03, testD04, testD05, testD06, testD07,
                    testD08, testD09);
                var testD14 = new TestD14(testD00, testD01, testD02, testD03, testD04, testD05, testD06, testD07,
                    testD08, testD09);
                var testD15 = new TestD15(testD00, testD01, testD02, testD03, testD04, testD05, testD06, testD07,
                    testD08, testD09);
                var testD16 = new TestD16(testD00, testD01, testD02, testD03, testD04, testD05, testD06, testD07,
                    testD08, testD09);
                var testD17 = new TestD17(testD00, testD01, testD02, testD03, testD04, testD05, testD06, testD07,
                    testD08, testD09);
                var testD18 = new TestD18(testD00, testD01, testD02, testD03, testD04, testD05, testD06, testD07,
                    testD08, testD09);
                var testD19 = new TestD19(testD00, testD01, testD02, testD03, testD04, testD05, testD06, testD07,
                    testD08, testD09);

                var testD20 = new TestD20(testD10, testD11, testD12, testD13, testD14, testD15, testD16, testD17,
                    testD18, testD19);
                var testD21 = new TestD21(testD10, testD11, testD12, testD13, testD14, testD15, testD16, testD17,
                    testD18, testD19);
                var testD22 = new TestD22(testD10, testD11, testD12, testD13, testD14, testD15, testD16, testD17,
                    testD18, testD19);
                var testD23 = new TestD23(testD10, testD11, testD12, testD13, testD14, testD15, testD16, testD17,
                    testD18, testD19);
                var testD24 = new TestD24(testD10, testD11, testD12, testD13, testD14, testD15, testD16, testD17,
                    testD18, testD19);
                var testD25 = new TestD25(testD10, testD11, testD12, testD13, testD14, testD15, testD16, testD17,
                    testD18, testD19);
                var testD26 = new TestD26(testD10, testD11, testD12, testD13, testD14, testD15, testD16, testD17,
                    testD18, testD19);
                var testD27 = new TestD27(testD10, testD11, testD12, testD13, testD14, testD15, testD16, testD17,
                    testD18, testD19);
                var testD28 = new TestD28(testD10, testD11, testD12, testD13, testD14, testD15, testD16, testD17,
                    testD18, testD19);
                var testD29 = new TestD29(testD10, testD11, testD12, testD13, testD14, testD15, testD16, testD17,
                    testD18, testD19);

                var testD30 = new TestD30(testD20, testD21, testD22, testD23, testD24, testD25, testD26, testD27,
                    testD28, testD29);
                var testD31 = new TestD31(testD20, testD21, testD22, testD23, testD24, testD25, testD26, testD27,
                    testD28, testD29);
                var testD32 = new TestD32(testD20, testD21, testD22, testD23, testD24, testD25, testD26, testD27,
                    testD28, testD29);
                var testD33 = new TestD33(testD20, testD21, testD22, testD23, testD24, testD25, testD26, testD27,
                    testD28, testD29);
                var testD34 = new TestD34(testD20, testD21, testD22, testD23, testD24, testD25, testD26, testD27,
                    testD28, testD29);
                var testD35 = new TestD35(testD20, testD21, testD22, testD23, testD24, testD25, testD26, testD27,
                    testD28, testD29);
                var testD36 = new TestD36(testD20, testD21, testD22, testD23, testD24, testD25, testD26, testD27,
                    testD28, testD29);
                var testD37 = new TestD37(testD20, testD21, testD22, testD23, testD24, testD25, testD26, testD27,
                    testD28, testD29);
                var testD38 = new TestD38(testD20, testD21, testD22, testD23, testD24, testD25, testD26, testD27,
                    testD28, testD29);
                var testD39 = new TestD39(testD20, testD21, testD22, testD23, testD24, testD25, testD26, testD27,
                    testD28, testD29);

                var testD40 = new TestD40(testD30, testD31, testD32, testD33, testD34, testD35, testD36, testD37,
                    testD38, testD39);
                var testD41 = new TestD41(testD30, testD31, testD32, testD33, testD34, testD35, testD36, testD37,
                    testD38, testD39);
                var testD42 = new TestD42(testD30, testD31, testD32, testD33, testD34, testD35, testD36, testD37,
                    testD38, testD39);
                var testD43 = new TestD43(testD30, testD31, testD32, testD33, testD34, testD35, testD36, testD37,
                    testD38, testD39);
                var testD44 = new TestD44(testD30, testD31, testD32, testD33, testD34, testD35, testD36, testD37,
                    testD38, testD39);
                var testD45 = new TestD45(testD30, testD31, testD32, testD33, testD34, testD35, testD36, testD37,
                    testD38, testD39);
                var testD46 = new TestD46(testD30, testD31, testD32, testD33, testD34, testD35, testD36, testD37,
                    testD38, testD39);
                var testD47 = new TestD47(testD30, testD31, testD32, testD33, testD34, testD35, testD36, testD37,
                    testD38, testD39);
                var testD48 = new TestD48(testD30, testD31, testD32, testD33, testD34, testD35, testD36, testD37,
                    testD38, testD39);
                var testD49 = new TestD49(testD30, testD31, testD32, testD33, testD34, testD35, testD36, testD37,
                    testD38, testD39);

                var testD = new TestD(testD40, testD41, testD42, testD43, testD44, testD45, testD46, testD47, testD48,
                    testD49);

                return testD;
            });
        }

        public override void Resolve(object container, int testDasesNumber)
        {
            _resolving.Resolve<ITestD>(container, testDasesNumber);
        }
    }
}