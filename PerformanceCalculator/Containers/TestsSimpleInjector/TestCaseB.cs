using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using SimpleInjector;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class TestCaseB : ITestCase
    {
        public object SingletonRegister(object container)
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

        public object TransientRegister(object container)
        {
            var c = (Container)container;

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
            throw new System.NotImplementedException();
        }

        public object PerHttpContextRegister(object container)
        {
            throw new System.NotImplementedException();
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<ITestB>();
            }
        }
    }
}