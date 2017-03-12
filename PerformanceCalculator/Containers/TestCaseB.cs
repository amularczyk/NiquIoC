using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers
{
    public class TestCaseB : TestCase
    {
        public TestCaseB(IRegistration registration, IResolving resolving)
            : base(registration, resolving)
        {
        }

        public override void RegisterClasses(object container)
        {
            _registration.Register<ITestB00, TestB00>(container);
            _registration.Register<ITestB01, TestB01>(container);
            _registration.Register<ITestB02, TestB02>(container);
            _registration.Register<ITestB03, TestB03>(container);
            _registration.Register<ITestB04, TestB04>(container);
            _registration.Register<ITestB05, TestB05>(container);
            _registration.Register<ITestB06, TestB06>(container);
            _registration.Register<ITestB07, TestB07>(container);
            _registration.Register<ITestB08, TestB08>(container);
            _registration.Register<ITestB09, TestB09>(container);

            _registration.Register<ITestB10, TestB10>(container);
            _registration.Register<ITestB11, TestB11>(container);
            _registration.Register<ITestB12, TestB12>(container);
            _registration.Register<ITestB13, TestB13>(container);
            _registration.Register<ITestB14, TestB14>(container);
            _registration.Register<ITestB15, TestB15>(container);
            _registration.Register<ITestB16, TestB16>(container);
            _registration.Register<ITestB17, TestB17>(container);
            _registration.Register<ITestB18, TestB18>(container);
            _registration.Register<ITestB19, TestB19>(container);

            _registration.Register<ITestB20, TestB20>(container);
            _registration.Register<ITestB21, TestB21>(container);
            _registration.Register<ITestB22, TestB22>(container);
            _registration.Register<ITestB23, TestB23>(container);
            _registration.Register<ITestB24, TestB24>(container);
            _registration.Register<ITestB25, TestB25>(container);
            _registration.Register<ITestB26, TestB26>(container);
            _registration.Register<ITestB27, TestB27>(container);
            _registration.Register<ITestB28, TestB28>(container);
            _registration.Register<ITestB29, TestB29>(container);

            _registration.Register<ITestB30, TestB30>(container);
            _registration.Register<ITestB31, TestB31>(container);
            _registration.Register<ITestB32, TestB32>(container);
            _registration.Register<ITestB33, TestB33>(container);
            _registration.Register<ITestB34, TestB34>(container);
            _registration.Register<ITestB35, TestB35>(container);
            _registration.Register<ITestB36, TestB36>(container);
            _registration.Register<ITestB37, TestB37>(container);
            _registration.Register<ITestB38, TestB38>(container);
            _registration.Register<ITestB39, TestB39>(container);

            _registration.Register<ITestB40, TestB40>(container);
            _registration.Register<ITestB41, TestB41>(container);
            _registration.Register<ITestB42, TestB42>(container);
            _registration.Register<ITestB43, TestB43>(container);
            _registration.Register<ITestB44, TestB44>(container);
            _registration.Register<ITestB45, TestB45>(container);
            _registration.Register<ITestB46, TestB46>(container);
            _registration.Register<ITestB47, TestB47>(container);
            _registration.Register<ITestB48, TestB48>(container);
            _registration.Register<ITestB49, TestB49>(container);

            _registration.Register<ITestB, TestB>(container);
        }

        public override void Resolve(object container, int testCasesNumber)
        {
            _resolving.Resolve<ITestB>(container, testCasesNumber);
        }
    }
}