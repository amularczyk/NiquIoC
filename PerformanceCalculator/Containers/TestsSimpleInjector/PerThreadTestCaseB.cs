using SimpleInjector;
using PerformanceCalculator.TestCases;
using SimpleInjector.Extensions.LifetimeScoping;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class PerThreadTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();

            c.Register<ITestB00, TestB00>(Lifestyle.Scoped);
            c.Register<ITestB01, TestB01>(Lifestyle.Scoped);
            c.Register<ITestB02, TestB02>(Lifestyle.Scoped);
            c.Register<ITestB03, TestB03>(Lifestyle.Scoped);
            c.Register<ITestB04, TestB04>(Lifestyle.Scoped);
            c.Register<ITestB05, TestB05>(Lifestyle.Scoped);
            c.Register<ITestB06, TestB06>(Lifestyle.Scoped);
            c.Register<ITestB07, TestB07>(Lifestyle.Scoped);
            c.Register<ITestB08, TestB08>(Lifestyle.Scoped);
            c.Register<ITestB09, TestB09>(Lifestyle.Scoped);

            c.Register<ITestB10, TestB10>(Lifestyle.Scoped);
            c.Register<ITestB11, TestB11>(Lifestyle.Scoped);
            c.Register<ITestB12, TestB12>(Lifestyle.Scoped);
            c.Register<ITestB13, TestB13>(Lifestyle.Scoped);
            c.Register<ITestB14, TestB14>(Lifestyle.Scoped);
            c.Register<ITestB15, TestB15>(Lifestyle.Scoped);
            c.Register<ITestB16, TestB16>(Lifestyle.Scoped);
            c.Register<ITestB17, TestB17>(Lifestyle.Scoped);
            c.Register<ITestB18, TestB18>(Lifestyle.Scoped);
            c.Register<ITestB19, TestB19>(Lifestyle.Scoped);

            c.Register<ITestB20, TestB20>(Lifestyle.Scoped);
            c.Register<ITestB21, TestB21>(Lifestyle.Scoped);
            c.Register<ITestB22, TestB22>(Lifestyle.Scoped);
            c.Register<ITestB23, TestB23>(Lifestyle.Scoped);
            c.Register<ITestB24, TestB24>(Lifestyle.Scoped);
            c.Register<ITestB25, TestB25>(Lifestyle.Scoped);
            c.Register<ITestB26, TestB26>(Lifestyle.Scoped);
            c.Register<ITestB27, TestB27>(Lifestyle.Scoped);
            c.Register<ITestB28, TestB28>(Lifestyle.Scoped);
            c.Register<ITestB29, TestB29>(Lifestyle.Scoped);

            c.Register<ITestB30, TestB30>(Lifestyle.Scoped);
            c.Register<ITestB31, TestB31>(Lifestyle.Scoped);
            c.Register<ITestB32, TestB32>(Lifestyle.Scoped);
            c.Register<ITestB33, TestB33>(Lifestyle.Scoped);
            c.Register<ITestB34, TestB34>(Lifestyle.Scoped);
            c.Register<ITestB35, TestB35>(Lifestyle.Scoped);
            c.Register<ITestB36, TestB36>(Lifestyle.Scoped);
            c.Register<ITestB37, TestB37>(Lifestyle.Scoped);
            c.Register<ITestB38, TestB38>(Lifestyle.Scoped);
            c.Register<ITestB39, TestB39>(Lifestyle.Scoped);

            c.Register<ITestB40, TestB40>(Lifestyle.Scoped);
            c.Register<ITestB41, TestB41>(Lifestyle.Scoped);
            c.Register<ITestB42, TestB42>(Lifestyle.Scoped);
            c.Register<ITestB43, TestB43>(Lifestyle.Scoped);
            c.Register<ITestB44, TestB44>(Lifestyle.Scoped);
            c.Register<ITestB45, TestB45>(Lifestyle.Scoped);
            c.Register<ITestB46, TestB46>(Lifestyle.Scoped);
            c.Register<ITestB47, TestB47>(Lifestyle.Scoped);
            c.Register<ITestB48, TestB48>(Lifestyle.Scoped);
            c.Register<ITestB49, TestB49>(Lifestyle.Scoped);

            c.Register<ITestB, TestB>(Lifestyle.Scoped);

            return c;
        }
    }
}