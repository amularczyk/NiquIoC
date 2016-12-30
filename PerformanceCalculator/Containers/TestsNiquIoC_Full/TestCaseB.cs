using NiquIoC;
using NiquIoC.Enums;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class TestCaseB : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestB00, TestB00>().AsSingleton();
            c.RegisterType<ITestB01, TestB01>().AsSingleton();
            c.RegisterType<ITestB02, TestB02>().AsSingleton();
            c.RegisterType<ITestB03, TestB03>().AsSingleton();
            c.RegisterType<ITestB04, TestB04>().AsSingleton();
            c.RegisterType<ITestB05, TestB05>().AsSingleton();
            c.RegisterType<ITestB06, TestB06>().AsSingleton();
            c.RegisterType<ITestB07, TestB07>().AsSingleton();
            c.RegisterType<ITestB08, TestB08>().AsSingleton();
            c.RegisterType<ITestB09, TestB09>().AsSingleton();

            c.RegisterType<ITestB10, TestB10>().AsSingleton();
            c.RegisterType<ITestB11, TestB11>().AsSingleton();
            c.RegisterType<ITestB12, TestB12>().AsSingleton();
            c.RegisterType<ITestB13, TestB13>().AsSingleton();
            c.RegisterType<ITestB14, TestB14>().AsSingleton();
            c.RegisterType<ITestB15, TestB15>().AsSingleton();
            c.RegisterType<ITestB16, TestB16>().AsSingleton();
            c.RegisterType<ITestB17, TestB17>().AsSingleton();
            c.RegisterType<ITestB18, TestB18>().AsSingleton();
            c.RegisterType<ITestB19, TestB19>().AsSingleton();

            c.RegisterType<ITestB20, TestB20>().AsSingleton();
            c.RegisterType<ITestB21, TestB21>().AsSingleton();
            c.RegisterType<ITestB22, TestB22>().AsSingleton();
            c.RegisterType<ITestB23, TestB23>().AsSingleton();
            c.RegisterType<ITestB24, TestB24>().AsSingleton();
            c.RegisterType<ITestB25, TestB25>().AsSingleton();
            c.RegisterType<ITestB26, TestB26>().AsSingleton();
            c.RegisterType<ITestB27, TestB27>().AsSingleton();
            c.RegisterType<ITestB28, TestB28>().AsSingleton();
            c.RegisterType<ITestB29, TestB29>().AsSingleton();

            c.RegisterType<ITestB30, TestB30>().AsSingleton();
            c.RegisterType<ITestB31, TestB31>().AsSingleton();
            c.RegisterType<ITestB32, TestB32>().AsSingleton();
            c.RegisterType<ITestB33, TestB33>().AsSingleton();
            c.RegisterType<ITestB34, TestB34>().AsSingleton();
            c.RegisterType<ITestB35, TestB35>().AsSingleton();
            c.RegisterType<ITestB36, TestB36>().AsSingleton();
            c.RegisterType<ITestB37, TestB37>().AsSingleton();
            c.RegisterType<ITestB38, TestB38>().AsSingleton();
            c.RegisterType<ITestB39, TestB39>().AsSingleton();

            c.RegisterType<ITestB40, TestB40>().AsSingleton();
            c.RegisterType<ITestB41, TestB41>().AsSingleton();
            c.RegisterType<ITestB42, TestB42>().AsSingleton();
            c.RegisterType<ITestB43, TestB43>().AsSingleton();
            c.RegisterType<ITestB44, TestB44>().AsSingleton();
            c.RegisterType<ITestB45, TestB45>().AsSingleton();
            c.RegisterType<ITestB46, TestB46>().AsSingleton();
            c.RegisterType<ITestB47, TestB47>().AsSingleton();
            c.RegisterType<ITestB48, TestB48>().AsSingleton();
            c.RegisterType<ITestB49, TestB49>().AsSingleton();

            c.RegisterType<ITestB, TestB>().AsSingleton();

            return c;
        }

        public object TransientRegister(object container)
        {
            var c = (Container)container;

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
            var c = (Container)container;

            c.RegisterType<ITestB00, TestB00>().AsPerThread();
            c.RegisterType<ITestB01, TestB01>().AsPerThread();
            c.RegisterType<ITestB02, TestB02>().AsPerThread();
            c.RegisterType<ITestB03, TestB03>().AsPerThread();
            c.RegisterType<ITestB04, TestB04>().AsPerThread();
            c.RegisterType<ITestB05, TestB05>().AsPerThread();
            c.RegisterType<ITestB06, TestB06>().AsPerThread();
            c.RegisterType<ITestB07, TestB07>().AsPerThread();
            c.RegisterType<ITestB08, TestB08>().AsPerThread();
            c.RegisterType<ITestB09, TestB09>().AsPerThread();

            c.RegisterType<ITestB10, TestB10>().AsPerThread();
            c.RegisterType<ITestB11, TestB11>().AsPerThread();
            c.RegisterType<ITestB12, TestB12>().AsPerThread();
            c.RegisterType<ITestB13, TestB13>().AsPerThread();
            c.RegisterType<ITestB14, TestB14>().AsPerThread();
            c.RegisterType<ITestB15, TestB15>().AsPerThread();
            c.RegisterType<ITestB16, TestB16>().AsPerThread();
            c.RegisterType<ITestB17, TestB17>().AsPerThread();
            c.RegisterType<ITestB18, TestB18>().AsPerThread();
            c.RegisterType<ITestB19, TestB19>().AsPerThread();

            c.RegisterType<ITestB20, TestB20>().AsPerThread();
            c.RegisterType<ITestB21, TestB21>().AsPerThread();
            c.RegisterType<ITestB22, TestB22>().AsPerThread();
            c.RegisterType<ITestB23, TestB23>().AsPerThread();
            c.RegisterType<ITestB24, TestB24>().AsPerThread();
            c.RegisterType<ITestB25, TestB25>().AsPerThread();
            c.RegisterType<ITestB26, TestB26>().AsPerThread();
            c.RegisterType<ITestB27, TestB27>().AsPerThread();
            c.RegisterType<ITestB28, TestB28>().AsPerThread();
            c.RegisterType<ITestB29, TestB29>().AsPerThread();

            c.RegisterType<ITestB30, TestB30>().AsPerThread();
            c.RegisterType<ITestB31, TestB31>().AsPerThread();
            c.RegisterType<ITestB32, TestB32>().AsPerThread();
            c.RegisterType<ITestB33, TestB33>().AsPerThread();
            c.RegisterType<ITestB34, TestB34>().AsPerThread();
            c.RegisterType<ITestB35, TestB35>().AsPerThread();
            c.RegisterType<ITestB36, TestB36>().AsPerThread();
            c.RegisterType<ITestB37, TestB37>().AsPerThread();
            c.RegisterType<ITestB38, TestB38>().AsPerThread();
            c.RegisterType<ITestB39, TestB39>().AsPerThread();

            c.RegisterType<ITestB40, TestB40>().AsPerThread();
            c.RegisterType<ITestB41, TestB41>().AsPerThread();
            c.RegisterType<ITestB42, TestB42>().AsPerThread();
            c.RegisterType<ITestB43, TestB43>().AsPerThread();
            c.RegisterType<ITestB44, TestB44>().AsPerThread();
            c.RegisterType<ITestB45, TestB45>().AsPerThread();
            c.RegisterType<ITestB46, TestB46>().AsPerThread();
            c.RegisterType<ITestB47, TestB47>().AsPerThread();
            c.RegisterType<ITestB48, TestB48>().AsPerThread();
            c.RegisterType<ITestB49, TestB49>().AsPerThread();

            c.RegisterType<ITestB, TestB>().AsPerThread();

            return c;
        }

        public object PerHttpContextRegister(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestB00, TestB00>().AsPerHttpContext();
            c.RegisterType<ITestB01, TestB01>().AsPerHttpContext();
            c.RegisterType<ITestB02, TestB02>().AsPerHttpContext();
            c.RegisterType<ITestB03, TestB03>().AsPerHttpContext();
            c.RegisterType<ITestB04, TestB04>().AsPerHttpContext();
            c.RegisterType<ITestB05, TestB05>().AsPerHttpContext();
            c.RegisterType<ITestB06, TestB06>().AsPerHttpContext();
            c.RegisterType<ITestB07, TestB07>().AsPerHttpContext();
            c.RegisterType<ITestB08, TestB08>().AsPerHttpContext();
            c.RegisterType<ITestB09, TestB09>().AsPerHttpContext();

            c.RegisterType<ITestB10, TestB10>().AsPerHttpContext();
            c.RegisterType<ITestB11, TestB11>().AsPerHttpContext();
            c.RegisterType<ITestB12, TestB12>().AsPerHttpContext();
            c.RegisterType<ITestB13, TestB13>().AsPerHttpContext();
            c.RegisterType<ITestB14, TestB14>().AsPerHttpContext();
            c.RegisterType<ITestB15, TestB15>().AsPerHttpContext();
            c.RegisterType<ITestB16, TestB16>().AsPerHttpContext();
            c.RegisterType<ITestB17, TestB17>().AsPerHttpContext();
            c.RegisterType<ITestB18, TestB18>().AsPerHttpContext();
            c.RegisterType<ITestB19, TestB19>().AsPerHttpContext();

            c.RegisterType<ITestB20, TestB20>().AsPerHttpContext();
            c.RegisterType<ITestB21, TestB21>().AsPerHttpContext();
            c.RegisterType<ITestB22, TestB22>().AsPerHttpContext();
            c.RegisterType<ITestB23, TestB23>().AsPerHttpContext();
            c.RegisterType<ITestB24, TestB24>().AsPerHttpContext();
            c.RegisterType<ITestB25, TestB25>().AsPerHttpContext();
            c.RegisterType<ITestB26, TestB26>().AsPerHttpContext();
            c.RegisterType<ITestB27, TestB27>().AsPerHttpContext();
            c.RegisterType<ITestB28, TestB28>().AsPerHttpContext();
            c.RegisterType<ITestB29, TestB29>().AsPerHttpContext();

            c.RegisterType<ITestB30, TestB30>().AsPerHttpContext();
            c.RegisterType<ITestB31, TestB31>().AsPerHttpContext();
            c.RegisterType<ITestB32, TestB32>().AsPerHttpContext();
            c.RegisterType<ITestB33, TestB33>().AsPerHttpContext();
            c.RegisterType<ITestB34, TestB34>().AsPerHttpContext();
            c.RegisterType<ITestB35, TestB35>().AsPerHttpContext();
            c.RegisterType<ITestB36, TestB36>().AsPerHttpContext();
            c.RegisterType<ITestB37, TestB37>().AsPerHttpContext();
            c.RegisterType<ITestB38, TestB38>().AsPerHttpContext();
            c.RegisterType<ITestB39, TestB39>().AsPerHttpContext();

            c.RegisterType<ITestB40, TestB40>().AsPerHttpContext();
            c.RegisterType<ITestB41, TestB41>().AsPerHttpContext();
            c.RegisterType<ITestB42, TestB42>().AsPerHttpContext();
            c.RegisterType<ITestB43, TestB43>().AsPerHttpContext();
            c.RegisterType<ITestB44, TestB44>().AsPerHttpContext();
            c.RegisterType<ITestB45, TestB45>().AsPerHttpContext();
            c.RegisterType<ITestB46, TestB46>().AsPerHttpContext();
            c.RegisterType<ITestB47, TestB47>().AsPerHttpContext();
            c.RegisterType<ITestB48, TestB48>().AsPerHttpContext();
            c.RegisterType<ITestB49, TestB49>().AsPerHttpContext();

            c.RegisterType<ITestB, TestB>().AsPerHttpContext();

            return c;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestB>(ResolveKind.FullEmitFunction);
            }
        }
    }
}