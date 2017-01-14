using DryIoc;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class SingletonTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Register<ITestB00, TestB00>(Reuse.Singleton);
            c.Register<ITestB01, TestB01>(Reuse.Singleton);
            c.Register<ITestB02, TestB02>(Reuse.Singleton);
            c.Register<ITestB03, TestB03>(Reuse.Singleton);
            c.Register<ITestB04, TestB04>(Reuse.Singleton);
            c.Register<ITestB05, TestB05>(Reuse.Singleton);
            c.Register<ITestB06, TestB06>(Reuse.Singleton);
            c.Register<ITestB07, TestB07>(Reuse.Singleton);
            c.Register<ITestB08, TestB08>(Reuse.Singleton);
            c.Register<ITestB09, TestB09>(Reuse.Singleton);

            c.Register<ITestB10, TestB10>(Reuse.Singleton);
            c.Register<ITestB11, TestB11>(Reuse.Singleton);
            c.Register<ITestB12, TestB12>(Reuse.Singleton);
            c.Register<ITestB13, TestB13>(Reuse.Singleton);
            c.Register<ITestB14, TestB14>(Reuse.Singleton);
            c.Register<ITestB15, TestB15>(Reuse.Singleton);
            c.Register<ITestB16, TestB16>(Reuse.Singleton);
            c.Register<ITestB17, TestB17>(Reuse.Singleton);
            c.Register<ITestB18, TestB18>(Reuse.Singleton);
            c.Register<ITestB19, TestB19>(Reuse.Singleton);

            c.Register<ITestB20, TestB20>(Reuse.Singleton);
            c.Register<ITestB21, TestB21>(Reuse.Singleton);
            c.Register<ITestB22, TestB22>(Reuse.Singleton);
            c.Register<ITestB23, TestB23>(Reuse.Singleton);
            c.Register<ITestB24, TestB24>(Reuse.Singleton);
            c.Register<ITestB25, TestB25>(Reuse.Singleton);
            c.Register<ITestB26, TestB26>(Reuse.Singleton);
            c.Register<ITestB27, TestB27>(Reuse.Singleton);
            c.Register<ITestB28, TestB28>(Reuse.Singleton);
            c.Register<ITestB29, TestB29>(Reuse.Singleton);

            c.Register<ITestB30, TestB30>(Reuse.Singleton);
            c.Register<ITestB31, TestB31>(Reuse.Singleton);
            c.Register<ITestB32, TestB32>(Reuse.Singleton);
            c.Register<ITestB33, TestB33>(Reuse.Singleton);
            c.Register<ITestB34, TestB34>(Reuse.Singleton);
            c.Register<ITestB35, TestB35>(Reuse.Singleton);
            c.Register<ITestB36, TestB36>(Reuse.Singleton);
            c.Register<ITestB37, TestB37>(Reuse.Singleton);
            c.Register<ITestB38, TestB38>(Reuse.Singleton);
            c.Register<ITestB39, TestB39>(Reuse.Singleton);

            c.Register<ITestB40, TestB40>(Reuse.Singleton);
            c.Register<ITestB41, TestB41>(Reuse.Singleton);
            c.Register<ITestB42, TestB42>(Reuse.Singleton);
            c.Register<ITestB43, TestB43>(Reuse.Singleton);
            c.Register<ITestB44, TestB44>(Reuse.Singleton);
            c.Register<ITestB45, TestB45>(Reuse.Singleton);
            c.Register<ITestB46, TestB46>(Reuse.Singleton);
            c.Register<ITestB47, TestB47>(Reuse.Singleton);
            c.Register<ITestB48, TestB48>(Reuse.Singleton);
            c.Register<ITestB49, TestB49>(Reuse.Singleton);

            c.Register<ITestB, TestB>(Reuse.Singleton);

            return c;
        }
    }
}