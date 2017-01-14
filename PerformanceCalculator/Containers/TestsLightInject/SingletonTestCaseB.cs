using LightInject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class SingletonTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestB00, TestB00>(new PerContainerLifetime());
            c.Register<ITestB01, TestB01>(new PerContainerLifetime());
            c.Register<ITestB02, TestB02>(new PerContainerLifetime());
            c.Register<ITestB03, TestB03>(new PerContainerLifetime());
            c.Register<ITestB04, TestB04>(new PerContainerLifetime());
            c.Register<ITestB05, TestB05>(new PerContainerLifetime());
            c.Register<ITestB06, TestB06>(new PerContainerLifetime());
            c.Register<ITestB07, TestB07>(new PerContainerLifetime());
            c.Register<ITestB08, TestB08>(new PerContainerLifetime());
            c.Register<ITestB09, TestB09>(new PerContainerLifetime());

            c.Register<ITestB10, TestB10>(new PerContainerLifetime());
            c.Register<ITestB11, TestB11>(new PerContainerLifetime());
            c.Register<ITestB12, TestB12>(new PerContainerLifetime());
            c.Register<ITestB13, TestB13>(new PerContainerLifetime());
            c.Register<ITestB14, TestB14>(new PerContainerLifetime());
            c.Register<ITestB15, TestB15>(new PerContainerLifetime());
            c.Register<ITestB16, TestB16>(new PerContainerLifetime());
            c.Register<ITestB17, TestB17>(new PerContainerLifetime());
            c.Register<ITestB18, TestB18>(new PerContainerLifetime());
            c.Register<ITestB19, TestB19>(new PerContainerLifetime());

            c.Register<ITestB20, TestB20>(new PerContainerLifetime());
            c.Register<ITestB21, TestB21>(new PerContainerLifetime());
            c.Register<ITestB22, TestB22>(new PerContainerLifetime());
            c.Register<ITestB23, TestB23>(new PerContainerLifetime());
            c.Register<ITestB24, TestB24>(new PerContainerLifetime());
            c.Register<ITestB25, TestB25>(new PerContainerLifetime());
            c.Register<ITestB26, TestB26>(new PerContainerLifetime());
            c.Register<ITestB27, TestB27>(new PerContainerLifetime());
            c.Register<ITestB28, TestB28>(new PerContainerLifetime());
            c.Register<ITestB29, TestB29>(new PerContainerLifetime());

            c.Register<ITestB30, TestB30>(new PerContainerLifetime());
            c.Register<ITestB31, TestB31>(new PerContainerLifetime());
            c.Register<ITestB32, TestB32>(new PerContainerLifetime());
            c.Register<ITestB33, TestB33>(new PerContainerLifetime());
            c.Register<ITestB34, TestB34>(new PerContainerLifetime());
            c.Register<ITestB35, TestB35>(new PerContainerLifetime());
            c.Register<ITestB36, TestB36>(new PerContainerLifetime());
            c.Register<ITestB37, TestB37>(new PerContainerLifetime());
            c.Register<ITestB38, TestB38>(new PerContainerLifetime());
            c.Register<ITestB39, TestB39>(new PerContainerLifetime());

            c.Register<ITestB40, TestB40>(new PerContainerLifetime());
            c.Register<ITestB41, TestB41>(new PerContainerLifetime());
            c.Register<ITestB42, TestB42>(new PerContainerLifetime());
            c.Register<ITestB43, TestB43>(new PerContainerLifetime());
            c.Register<ITestB44, TestB44>(new PerContainerLifetime());
            c.Register<ITestB45, TestB45>(new PerContainerLifetime());
            c.Register<ITestB46, TestB46>(new PerContainerLifetime());
            c.Register<ITestB47, TestB47>(new PerContainerLifetime());
            c.Register<ITestB48, TestB48>(new PerContainerLifetime());
            c.Register<ITestB49, TestB49>(new PerContainerLifetime());

            c.Register<ITestB, TestB>(new PerContainerLifetime());

            return c;
        }
    }
}