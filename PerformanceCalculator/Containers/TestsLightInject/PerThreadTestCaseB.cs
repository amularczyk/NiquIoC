using LightInject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class PerThreadTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestB00, TestB00>(new PerScopeLifetime());
            c.Register<ITestB01, TestB01>(new PerScopeLifetime());
            c.Register<ITestB02, TestB02>(new PerScopeLifetime());
            c.Register<ITestB03, TestB03>(new PerScopeLifetime());
            c.Register<ITestB04, TestB04>(new PerScopeLifetime());
            c.Register<ITestB05, TestB05>(new PerScopeLifetime());
            c.Register<ITestB06, TestB06>(new PerScopeLifetime());
            c.Register<ITestB07, TestB07>(new PerScopeLifetime());
            c.Register<ITestB08, TestB08>(new PerScopeLifetime());
            c.Register<ITestB09, TestB09>(new PerScopeLifetime());

            c.Register<ITestB10, TestB10>(new PerScopeLifetime());
            c.Register<ITestB11, TestB11>(new PerScopeLifetime());
            c.Register<ITestB12, TestB12>(new PerScopeLifetime());
            c.Register<ITestB13, TestB13>(new PerScopeLifetime());
            c.Register<ITestB14, TestB14>(new PerScopeLifetime());
            c.Register<ITestB15, TestB15>(new PerScopeLifetime());
            c.Register<ITestB16, TestB16>(new PerScopeLifetime());
            c.Register<ITestB17, TestB17>(new PerScopeLifetime());
            c.Register<ITestB18, TestB18>(new PerScopeLifetime());
            c.Register<ITestB19, TestB19>(new PerScopeLifetime());

            c.Register<ITestB20, TestB20>(new PerScopeLifetime());
            c.Register<ITestB21, TestB21>(new PerScopeLifetime());
            c.Register<ITestB22, TestB22>(new PerScopeLifetime());
            c.Register<ITestB23, TestB23>(new PerScopeLifetime());
            c.Register<ITestB24, TestB24>(new PerScopeLifetime());
            c.Register<ITestB25, TestB25>(new PerScopeLifetime());
            c.Register<ITestB26, TestB26>(new PerScopeLifetime());
            c.Register<ITestB27, TestB27>(new PerScopeLifetime());
            c.Register<ITestB28, TestB28>(new PerScopeLifetime());
            c.Register<ITestB29, TestB29>(new PerScopeLifetime());

            c.Register<ITestB30, TestB30>(new PerScopeLifetime());
            c.Register<ITestB31, TestB31>(new PerScopeLifetime());
            c.Register<ITestB32, TestB32>(new PerScopeLifetime());
            c.Register<ITestB33, TestB33>(new PerScopeLifetime());
            c.Register<ITestB34, TestB34>(new PerScopeLifetime());
            c.Register<ITestB35, TestB35>(new PerScopeLifetime());
            c.Register<ITestB36, TestB36>(new PerScopeLifetime());
            c.Register<ITestB37, TestB37>(new PerScopeLifetime());
            c.Register<ITestB38, TestB38>(new PerScopeLifetime());
            c.Register<ITestB39, TestB39>(new PerScopeLifetime());

            c.Register<ITestB40, TestB40>(new PerScopeLifetime());
            c.Register<ITestB41, TestB41>(new PerScopeLifetime());
            c.Register<ITestB42, TestB42>(new PerScopeLifetime());
            c.Register<ITestB43, TestB43>(new PerScopeLifetime());
            c.Register<ITestB44, TestB44>(new PerScopeLifetime());
            c.Register<ITestB45, TestB45>(new PerScopeLifetime());
            c.Register<ITestB46, TestB46>(new PerScopeLifetime());
            c.Register<ITestB47, TestB47>(new PerScopeLifetime());
            c.Register<ITestB48, TestB48>(new PerScopeLifetime());
            c.Register<ITestB49, TestB49>(new PerScopeLifetime());

            c.Register<ITestB, TestB>(new PerScopeLifetime());

            return c;
        }
    }
}