using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers
{
    public class TestCaseD : TestCase
    {
        public TestCaseD(IRegistration registration, IResolving resolving)
            : base(registration, resolving)
        {
        }

        public override void RegisterClasses(object container)
        {
            _registration.Register<ITestD00, TestD00>(container);
            _registration.Register<ITestD01, TestD01>(container);
            _registration.Register<ITestD02, TestD02>(container);
            _registration.Register<ITestD03, TestD03>(container);
            _registration.Register<ITestD04, TestD04>(container);
            _registration.Register<ITestD05, TestD05>(container);
            _registration.Register<ITestD06, TestD06>(container);
            _registration.Register<ITestD07, TestD07>(container);
            _registration.Register<ITestD08, TestD08>(container);
            _registration.Register<ITestD09, TestD09>(container);

            _registration.Register<ITestD10, TestD10>(container);
            _registration.Register<ITestD11, TestD11>(container);
            _registration.Register<ITestD12, TestD12>(container);
            _registration.Register<ITestD13, TestD13>(container);
            _registration.Register<ITestD14, TestD14>(container);
            _registration.Register<ITestD15, TestD15>(container);
            _registration.Register<ITestD16, TestD16>(container);
            _registration.Register<ITestD17, TestD17>(container);
            _registration.Register<ITestD18, TestD18>(container);
            _registration.Register<ITestD19, TestD19>(container);

            _registration.Register<ITestD20, TestD20>(container);
            _registration.Register<ITestD21, TestD21>(container);
            _registration.Register<ITestD22, TestD22>(container);
            _registration.Register<ITestD23, TestD23>(container);
            _registration.Register<ITestD24, TestD24>(container);
            _registration.Register<ITestD25, TestD25>(container);
            _registration.Register<ITestD26, TestD26>(container);
            _registration.Register<ITestD27, TestD27>(container);
            _registration.Register<ITestD28, TestD28>(container);
            _registration.Register<ITestD29, TestD29>(container);

            _registration.Register<ITestD30, TestD30>(container);
            _registration.Register<ITestD31, TestD31>(container);
            _registration.Register<ITestD32, TestD32>(container);
            _registration.Register<ITestD33, TestD33>(container);
            _registration.Register<ITestD34, TestD34>(container);
            _registration.Register<ITestD35, TestD35>(container);
            _registration.Register<ITestD36, TestD36>(container);
            _registration.Register<ITestD37, TestD37>(container);
            _registration.Register<ITestD38, TestD38>(container);
            _registration.Register<ITestD39, TestD39>(container);

            _registration.Register<ITestD40, TestD40>(container);
            _registration.Register<ITestD41, TestD41>(container);
            _registration.Register<ITestD42, TestD42>(container);
            _registration.Register<ITestD43, TestD43>(container);
            _registration.Register<ITestD44, TestD44>(container);
            _registration.Register<ITestD45, TestD45>(container);
            _registration.Register<ITestD46, TestD46>(container);
            _registration.Register<ITestD47, TestD47>(container);
            _registration.Register<ITestD48, TestD48>(container);
            _registration.Register<ITestD49, TestD49>(container);

            _registration.Register<ITestD, TestD>(container);
        }

        public override void Resolve(object container, int testCasesNumber)
        {
            _resolving.Resolve<ITestD>(container, testCasesNumber);
        }
    }
}