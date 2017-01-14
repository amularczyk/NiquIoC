using DryIoc;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class PerThreadTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Register<ITestB00, TestB00>(Reuse.InThread);
            c.Register<ITestB01, TestB01>(Reuse.InThread);
            c.Register<ITestB02, TestB02>(Reuse.InThread);
            c.Register<ITestB03, TestB03>(Reuse.InThread);
            c.Register<ITestB04, TestB04>(Reuse.InThread);
            c.Register<ITestB05, TestB05>(Reuse.InThread);
            c.Register<ITestB06, TestB06>(Reuse.InThread);
            c.Register<ITestB07, TestB07>(Reuse.InThread);
            c.Register<ITestB08, TestB08>(Reuse.InThread);
            c.Register<ITestB09, TestB09>(Reuse.InThread);

            c.Register<ITestB10, TestB10>(Reuse.InThread);
            c.Register<ITestB11, TestB11>(Reuse.InThread);
            c.Register<ITestB12, TestB12>(Reuse.InThread);
            c.Register<ITestB13, TestB13>(Reuse.InThread);
            c.Register<ITestB14, TestB14>(Reuse.InThread);
            c.Register<ITestB15, TestB15>(Reuse.InThread);
            c.Register<ITestB16, TestB16>(Reuse.InThread);
            c.Register<ITestB17, TestB17>(Reuse.InThread);
            c.Register<ITestB18, TestB18>(Reuse.InThread);
            c.Register<ITestB19, TestB19>(Reuse.InThread);

            c.Register<ITestB20, TestB20>(Reuse.InThread);
            c.Register<ITestB21, TestB21>(Reuse.InThread);
            c.Register<ITestB22, TestB22>(Reuse.InThread);
            c.Register<ITestB23, TestB23>(Reuse.InThread);
            c.Register<ITestB24, TestB24>(Reuse.InThread);
            c.Register<ITestB25, TestB25>(Reuse.InThread);
            c.Register<ITestB26, TestB26>(Reuse.InThread);
            c.Register<ITestB27, TestB27>(Reuse.InThread);
            c.Register<ITestB28, TestB28>(Reuse.InThread);
            c.Register<ITestB29, TestB29>(Reuse.InThread);

            c.Register<ITestB30, TestB30>(Reuse.InThread);
            c.Register<ITestB31, TestB31>(Reuse.InThread);
            c.Register<ITestB32, TestB32>(Reuse.InThread);
            c.Register<ITestB33, TestB33>(Reuse.InThread);
            c.Register<ITestB34, TestB34>(Reuse.InThread);
            c.Register<ITestB35, TestB35>(Reuse.InThread);
            c.Register<ITestB36, TestB36>(Reuse.InThread);
            c.Register<ITestB37, TestB37>(Reuse.InThread);
            c.Register<ITestB38, TestB38>(Reuse.InThread);
            c.Register<ITestB39, TestB39>(Reuse.InThread);

            c.Register<ITestB40, TestB40>(Reuse.InThread);
            c.Register<ITestB41, TestB41>(Reuse.InThread);
            c.Register<ITestB42, TestB42>(Reuse.InThread);
            c.Register<ITestB43, TestB43>(Reuse.InThread);
            c.Register<ITestB44, TestB44>(Reuse.InThread);
            c.Register<ITestB45, TestB45>(Reuse.InThread);
            c.Register<ITestB46, TestB46>(Reuse.InThread);
            c.Register<ITestB47, TestB47>(Reuse.InThread);
            c.Register<ITestB48, TestB48>(Reuse.InThread);
            c.Register<ITestB49, TestB49>(Reuse.InThread);

            c.Register<ITestB, TestB>(Reuse.InThread);

            return c;
        }
    }
}