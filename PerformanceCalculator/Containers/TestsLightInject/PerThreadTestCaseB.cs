using LightInject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class PerThreadTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestB00, TestB00>(new PerThreadLifetime());
            c.Register<ITestB01, TestB01>(new PerThreadLifetime());
            c.Register<ITestB02, TestB02>(new PerThreadLifetime());
            c.Register<ITestB03, TestB03>(new PerThreadLifetime());
            c.Register<ITestB04, TestB04>(new PerThreadLifetime());
            c.Register<ITestB05, TestB05>(new PerThreadLifetime());
            c.Register<ITestB06, TestB06>(new PerThreadLifetime());
            c.Register<ITestB07, TestB07>(new PerThreadLifetime());
            c.Register<ITestB08, TestB08>(new PerThreadLifetime());
            c.Register<ITestB09, TestB09>(new PerThreadLifetime());

            c.Register<ITestB10, TestB10>(new PerThreadLifetime());
            c.Register<ITestB11, TestB11>(new PerThreadLifetime());
            c.Register<ITestB12, TestB12>(new PerThreadLifetime());
            c.Register<ITestB13, TestB13>(new PerThreadLifetime());
            c.Register<ITestB14, TestB14>(new PerThreadLifetime());
            c.Register<ITestB15, TestB15>(new PerThreadLifetime());
            c.Register<ITestB16, TestB16>(new PerThreadLifetime());
            c.Register<ITestB17, TestB17>(new PerThreadLifetime());
            c.Register<ITestB18, TestB18>(new PerThreadLifetime());
            c.Register<ITestB19, TestB19>(new PerThreadLifetime());

            c.Register<ITestB20, TestB20>(new PerThreadLifetime());
            c.Register<ITestB21, TestB21>(new PerThreadLifetime());
            c.Register<ITestB22, TestB22>(new PerThreadLifetime());
            c.Register<ITestB23, TestB23>(new PerThreadLifetime());
            c.Register<ITestB24, TestB24>(new PerThreadLifetime());
            c.Register<ITestB25, TestB25>(new PerThreadLifetime());
            c.Register<ITestB26, TestB26>(new PerThreadLifetime());
            c.Register<ITestB27, TestB27>(new PerThreadLifetime());
            c.Register<ITestB28, TestB28>(new PerThreadLifetime());
            c.Register<ITestB29, TestB29>(new PerThreadLifetime());

            c.Register<ITestB30, TestB30>(new PerThreadLifetime());
            c.Register<ITestB31, TestB31>(new PerThreadLifetime());
            c.Register<ITestB32, TestB32>(new PerThreadLifetime());
            c.Register<ITestB33, TestB33>(new PerThreadLifetime());
            c.Register<ITestB34, TestB34>(new PerThreadLifetime());
            c.Register<ITestB35, TestB35>(new PerThreadLifetime());
            c.Register<ITestB36, TestB36>(new PerThreadLifetime());
            c.Register<ITestB37, TestB37>(new PerThreadLifetime());
            c.Register<ITestB38, TestB38>(new PerThreadLifetime());
            c.Register<ITestB39, TestB39>(new PerThreadLifetime());

            c.Register<ITestB40, TestB40>(new PerThreadLifetime());
            c.Register<ITestB41, TestB41>(new PerThreadLifetime());
            c.Register<ITestB42, TestB42>(new PerThreadLifetime());
            c.Register<ITestB43, TestB43>(new PerThreadLifetime());
            c.Register<ITestB44, TestB44>(new PerThreadLifetime());
            c.Register<ITestB45, TestB45>(new PerThreadLifetime());
            c.Register<ITestB46, TestB46>(new PerThreadLifetime());
            c.Register<ITestB47, TestB47>(new PerThreadLifetime());
            c.Register<ITestB48, TestB48>(new PerThreadLifetime());
            c.Register<ITestB49, TestB49>(new PerThreadLifetime());

            c.Register<ITestB, TestB>(new PerThreadLifetime());

            return c;
        }
    }
}