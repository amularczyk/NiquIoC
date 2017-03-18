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
            _registration.Register<ITestC00, TestC00>(container);
            _registration.Register<ITestC01, TestC01>(container);
            _registration.Register<ITestC02, TestC02>(container);
            _registration.Register<ITestC03, TestC03>(container);
            _registration.Register<ITestC04, TestC04>(container);

            _registration.Register<ITestC10, TestC10>(container);
            _registration.Register<ITestC11, TestC11>(container);
            _registration.Register<ITestC12, TestC12>(container);
            _registration.Register<ITestC13, TestC13>(container);
            _registration.Register<ITestC14, TestC14>(container);

            _registration.Register<ITestC20, TestC20>(container);
            _registration.Register<ITestC21, TestC21>(container);
            _registration.Register<ITestC22, TestC22>(container);
            _registration.Register<ITestC23, TestC23>(container);
            _registration.Register<ITestC24, TestC24>(container);

            _registration.Register<ITestC30, TestC30>(container);
            _registration.Register<ITestC31, TestC31>(container);
            _registration.Register<ITestC32, TestC32>(container);
            _registration.Register<ITestC33, TestC33>(container);
            _registration.Register<ITestC34, TestC34>(container);

            _registration.Register<ITestC40, TestC40>(container);
            _registration.Register<ITestC41, TestC41>(container);
            _registration.Register<ITestC42, TestC42>(container);
            _registration.Register<ITestC43, TestC43>(container);
            _registration.Register<ITestC44, TestC44>(container);

            _registration.Register<ITestC, TestC>(container);
        }

        public override void Resolve(object container, int testCasesNumber)
        {
            _resolving.Resolve<ITestC>(container, testCasesNumber);
        }
    }
}