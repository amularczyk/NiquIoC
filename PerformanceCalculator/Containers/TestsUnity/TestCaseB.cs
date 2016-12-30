using Microsoft.Practices.Unity;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class TestCaseB : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (UnityContainer)container;

            c.RegisterType<ITestB00, TestB00>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB01, TestB01>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB02, TestB02>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB03, TestB03>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB04, TestB04>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB05, TestB05>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB06, TestB06>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB07, TestB07>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB08, TestB08>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB09, TestB09>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB10, TestB10>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB11, TestB11>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB12, TestB12>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB13, TestB13>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB14, TestB14>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB15, TestB15>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB16, TestB16>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB17, TestB17>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB18, TestB18>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB19, TestB19>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB20, TestB20>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB21, TestB21>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB22, TestB22>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB23, TestB23>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB24, TestB24>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB25, TestB25>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB26, TestB26>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB27, TestB27>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB28, TestB28>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB29, TestB29>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB30, TestB30>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB31, TestB31>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB32, TestB32>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB33, TestB33>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB34, TestB34>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB35, TestB35>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB36, TestB36>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB37, TestB37>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB38, TestB38>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB39, TestB39>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB40, TestB40>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB41, TestB41>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB42, TestB42>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB43, TestB43>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB44, TestB44>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB45, TestB45>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB46, TestB46>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB47, TestB47>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB48, TestB48>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB49, TestB49>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB, TestB>(new ContainerControlledLifetimeManager());

            return c;
        }

        public object TransientRegister(object container)
        {
            var c = (UnityContainer)container;

            c.RegisterType<ITestB00, TestB00>();
            c.RegisterType<ITestB01, TestB01>();
            c.RegisterType<ITestB02, TestB02>();
            c.RegisterType<ITestB03, TestB03>();
            c.RegisterType<ITestB04, TestB04>();
            c.RegisterType<ITestB05, TestB05>();
            c.RegisterType<ITestB06, TestB06>();
            c.RegisterType<ITestB07, TestB07>();
            c.RegisterType<ITestB08, TestB08>();
            c.RegisterType<ITestB09, TestB09>();

            c.RegisterType<ITestB10, TestB10>();
            c.RegisterType<ITestB11, TestB11>();
            c.RegisterType<ITestB12, TestB12>();
            c.RegisterType<ITestB13, TestB13>();
            c.RegisterType<ITestB14, TestB14>();
            c.RegisterType<ITestB15, TestB15>();
            c.RegisterType<ITestB16, TestB16>();
            c.RegisterType<ITestB17, TestB17>();
            c.RegisterType<ITestB18, TestB18>();
            c.RegisterType<ITestB19, TestB19>();

            c.RegisterType<ITestB20, TestB20>();
            c.RegisterType<ITestB21, TestB21>();
            c.RegisterType<ITestB22, TestB22>();
            c.RegisterType<ITestB23, TestB23>();
            c.RegisterType<ITestB24, TestB24>();
            c.RegisterType<ITestB25, TestB25>();
            c.RegisterType<ITestB26, TestB26>();
            c.RegisterType<ITestB27, TestB27>();
            c.RegisterType<ITestB28, TestB28>();
            c.RegisterType<ITestB29, TestB29>();

            c.RegisterType<ITestB30, TestB30>();
            c.RegisterType<ITestB31, TestB31>();
            c.RegisterType<ITestB32, TestB32>();
            c.RegisterType<ITestB33, TestB33>();
            c.RegisterType<ITestB34, TestB34>();
            c.RegisterType<ITestB35, TestB35>();
            c.RegisterType<ITestB36, TestB36>();
            c.RegisterType<ITestB37, TestB37>();
            c.RegisterType<ITestB38, TestB38>();
            c.RegisterType<ITestB39, TestB39>();

            c.RegisterType<ITestB40, TestB40>();
            c.RegisterType<ITestB41, TestB41>();
            c.RegisterType<ITestB42, TestB42>();
            c.RegisterType<ITestB43, TestB43>();
            c.RegisterType<ITestB44, TestB44>();
            c.RegisterType<ITestB45, TestB45>();
            c.RegisterType<ITestB46, TestB46>();
            c.RegisterType<ITestB47, TestB47>();
            c.RegisterType<ITestB48, TestB48>();
            c.RegisterType<ITestB49, TestB49>();

            c.RegisterType<ITestB, TestB>();

            return c;
        }

        public object PerThreadRegister(object container)
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

        public object PerHttpContextRegister(object container)
        {
            var c = (UnityContainer)container;

            c.RegisterType<ITestB00, TestB00>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB01, TestB01>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB02, TestB02>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB03, TestB03>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB04, TestB04>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB05, TestB05>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB06, TestB06>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB07, TestB07>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB08, TestB08>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB09, TestB09>(new PerRequestLifetimeManager());

            c.RegisterType<ITestB10, TestB10>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB11, TestB11>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB12, TestB12>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB13, TestB13>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB14, TestB14>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB15, TestB15>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB16, TestB16>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB17, TestB17>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB18, TestB18>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB19, TestB19>(new PerRequestLifetimeManager());

            c.RegisterType<ITestB20, TestB20>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB21, TestB21>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB22, TestB22>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB23, TestB23>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB24, TestB24>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB25, TestB25>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB26, TestB26>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB27, TestB27>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB28, TestB28>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB29, TestB29>(new PerRequestLifetimeManager());

            c.RegisterType<ITestB30, TestB30>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB31, TestB31>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB32, TestB32>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB33, TestB33>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB34, TestB34>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB35, TestB35>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB36, TestB36>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB37, TestB37>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB38, TestB38>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB39, TestB39>(new PerRequestLifetimeManager());

            c.RegisterType<ITestB40, TestB40>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB41, TestB41>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB42, TestB42>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB43, TestB43>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB44, TestB44>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB45, TestB45>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB46, TestB46>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB47, TestB47>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB48, TestB48>(new PerRequestLifetimeManager());
            c.RegisterType<ITestB49, TestB49>(new PerRequestLifetimeManager());

            c.RegisterType<ITestB, TestB>(new PerRequestLifetimeManager());

            return c;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (UnityContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestB>();
            }
        }
    }
}