using Microsoft.Practices.Unity;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class PerThreadTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (UnityContainer)container;

            c.RegisterType<ITestB00, TestB00>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB01, TestB01>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB02, TestB02>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB03, TestB03>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB04, TestB04>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB05, TestB05>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB06, TestB06>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB07, TestB07>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB08, TestB08>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB09, TestB09>(new PerThreadLifetimeManager());

            c.RegisterType<ITestB10, TestB10>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB11, TestB11>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB12, TestB12>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB13, TestB13>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB14, TestB14>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB15, TestB15>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB16, TestB16>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB17, TestB17>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB18, TestB18>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB19, TestB19>(new PerThreadLifetimeManager());

            c.RegisterType<ITestB20, TestB20>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB21, TestB21>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB22, TestB22>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB23, TestB23>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB24, TestB24>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB25, TestB25>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB26, TestB26>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB27, TestB27>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB28, TestB28>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB29, TestB29>(new PerThreadLifetimeManager());

            c.RegisterType<ITestB30, TestB30>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB31, TestB31>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB32, TestB32>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB33, TestB33>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB34, TestB34>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB35, TestB35>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB36, TestB36>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB37, TestB37>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB38, TestB38>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB39, TestB39>(new PerThreadLifetimeManager());

            c.RegisterType<ITestB40, TestB40>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB41, TestB41>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB42, TestB42>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB43, TestB43>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB44, TestB44>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB45, TestB45>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB46, TestB46>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB47, TestB47>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB48, TestB48>(new PerThreadLifetimeManager());
            c.RegisterType<ITestB49, TestB49>(new PerThreadLifetimeManager());

            c.RegisterType<ITestB, TestB>(new PerThreadLifetimeManager());

            return c;
        }
    }
}