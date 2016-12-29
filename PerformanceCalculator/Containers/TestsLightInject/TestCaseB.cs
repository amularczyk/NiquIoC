using LightInject;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class TestCaseB : ITestCase
    {
        public object SingletonRegister(object container)
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

        public object TransientRegister(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestB00, TestB00>();
            c.Register<ITestB01, TestB01>();
            c.Register<ITestB02, TestB02>();
            c.Register<ITestB03, TestB03>();
            c.Register<ITestB04, TestB04>();
            c.Register<ITestB05, TestB05>();
            c.Register<ITestB06, TestB06>();
            c.Register<ITestB07, TestB07>();
            c.Register<ITestB08, TestB08>();
            c.Register<ITestB09, TestB09>();

            c.Register<ITestB10, TestB10>();
            c.Register<ITestB11, TestB11>();
            c.Register<ITestB12, TestB12>();
            c.Register<ITestB13, TestB13>();
            c.Register<ITestB14, TestB14>();
            c.Register<ITestB15, TestB15>();
            c.Register<ITestB16, TestB16>();
            c.Register<ITestB17, TestB17>();
            c.Register<ITestB18, TestB18>();
            c.Register<ITestB19, TestB19>();

            c.Register<ITestB20, TestB20>();
            c.Register<ITestB21, TestB21>();
            c.Register<ITestB22, TestB22>();
            c.Register<ITestB23, TestB23>();
            c.Register<ITestB24, TestB24>();
            c.Register<ITestB25, TestB25>();
            c.Register<ITestB26, TestB26>();
            c.Register<ITestB27, TestB27>();
            c.Register<ITestB28, TestB28>();
            c.Register<ITestB29, TestB29>();

            c.Register<ITestB30, TestB30>();
            c.Register<ITestB31, TestB31>();
            c.Register<ITestB32, TestB32>();
            c.Register<ITestB33, TestB33>();
            c.Register<ITestB34, TestB34>();
            c.Register<ITestB35, TestB35>();
            c.Register<ITestB36, TestB36>();
            c.Register<ITestB37, TestB37>();
            c.Register<ITestB38, TestB38>();
            c.Register<ITestB39, TestB39>();

            c.Register<ITestB40, TestB40>();
            c.Register<ITestB41, TestB41>();
            c.Register<ITestB42, TestB42>();
            c.Register<ITestB43, TestB43>();
            c.Register<ITestB44, TestB44>();
            c.Register<ITestB45, TestB45>();
            c.Register<ITestB46, TestB46>();
            c.Register<ITestB47, TestB47>();
            c.Register<ITestB48, TestB48>();
            c.Register<ITestB49, TestB49>();

            c.Register<ITestB, TestB>();

            return c;
        }

        public object PerThreadRegister(object container)
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

        public object PerHttpContextRegister(object container)
        {
            throw new System.NotImplementedException();
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (ServiceContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<ITestB>();
            }
        }
    }
}