using SimpleInjector;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class SingletonTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Register<ITestB00, TestB00>(Lifestyle.Singleton);
            c.Register<ITestB01, TestB01>(Lifestyle.Singleton);
            c.Register<ITestB02, TestB02>(Lifestyle.Singleton);
            c.Register<ITestB03, TestB03>(Lifestyle.Singleton);
            c.Register<ITestB04, TestB04>(Lifestyle.Singleton);
            c.Register<ITestB05, TestB05>(Lifestyle.Singleton);
            c.Register<ITestB06, TestB06>(Lifestyle.Singleton);
            c.Register<ITestB07, TestB07>(Lifestyle.Singleton);
            c.Register<ITestB08, TestB08>(Lifestyle.Singleton);
            c.Register<ITestB09, TestB09>(Lifestyle.Singleton);

            c.Register<ITestB10, TestB10>(Lifestyle.Singleton);
            c.Register<ITestB11, TestB11>(Lifestyle.Singleton);
            c.Register<ITestB12, TestB12>(Lifestyle.Singleton);
            c.Register<ITestB13, TestB13>(Lifestyle.Singleton);
            c.Register<ITestB14, TestB14>(Lifestyle.Singleton);
            c.Register<ITestB15, TestB15>(Lifestyle.Singleton);
            c.Register<ITestB16, TestB16>(Lifestyle.Singleton);
            c.Register<ITestB17, TestB17>(Lifestyle.Singleton);
            c.Register<ITestB18, TestB18>(Lifestyle.Singleton);
            c.Register<ITestB19, TestB19>(Lifestyle.Singleton);

            c.Register<ITestB20, TestB20>(Lifestyle.Singleton);
            c.Register<ITestB21, TestB21>(Lifestyle.Singleton);
            c.Register<ITestB22, TestB22>(Lifestyle.Singleton);
            c.Register<ITestB23, TestB23>(Lifestyle.Singleton);
            c.Register<ITestB24, TestB24>(Lifestyle.Singleton);
            c.Register<ITestB25, TestB25>(Lifestyle.Singleton);
            c.Register<ITestB26, TestB26>(Lifestyle.Singleton);
            c.Register<ITestB27, TestB27>(Lifestyle.Singleton);
            c.Register<ITestB28, TestB28>(Lifestyle.Singleton);
            c.Register<ITestB29, TestB29>(Lifestyle.Singleton);

            c.Register<ITestB30, TestB30>(Lifestyle.Singleton);
            c.Register<ITestB31, TestB31>(Lifestyle.Singleton);
            c.Register<ITestB32, TestB32>(Lifestyle.Singleton);
            c.Register<ITestB33, TestB33>(Lifestyle.Singleton);
            c.Register<ITestB34, TestB34>(Lifestyle.Singleton);
            c.Register<ITestB35, TestB35>(Lifestyle.Singleton);
            c.Register<ITestB36, TestB36>(Lifestyle.Singleton);
            c.Register<ITestB37, TestB37>(Lifestyle.Singleton);
            c.Register<ITestB38, TestB38>(Lifestyle.Singleton);
            c.Register<ITestB39, TestB39>(Lifestyle.Singleton);

            c.Register<ITestB40, TestB40>(Lifestyle.Singleton);
            c.Register<ITestB41, TestB41>(Lifestyle.Singleton);
            c.Register<ITestB42, TestB42>(Lifestyle.Singleton);
            c.Register<ITestB43, TestB43>(Lifestyle.Singleton);
            c.Register<ITestB44, TestB44>(Lifestyle.Singleton);
            c.Register<ITestB45, TestB45>(Lifestyle.Singleton);
            c.Register<ITestB46, TestB46>(Lifestyle.Singleton);
            c.Register<ITestB47, TestB47>(Lifestyle.Singleton);
            c.Register<ITestB48, TestB48>(Lifestyle.Singleton);
            c.Register<ITestB49, TestB49>(Lifestyle.Singleton);

            c.Register<ITestB, TestB>(Lifestyle.Singleton);

            return c;
        }
    }
}