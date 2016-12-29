using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using StructureMap;
using StructureMap.Pipeline;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class TestCaseB : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (Container)container;

            c.Configure(x =>
            {
                x.For<ITestB00>().Use<TestB00>().Singleton();
                x.For<ITestB01>().Use<TestB01>().Singleton();
                x.For<ITestB02>().Use<TestB02>().Singleton();
                x.For<ITestB03>().Use<TestB03>().Singleton();
                x.For<ITestB04>().Use<TestB04>().Singleton();
                x.For<ITestB05>().Use<TestB05>().Singleton();
                x.For<ITestB06>().Use<TestB06>().Singleton();
                x.For<ITestB07>().Use<TestB07>().Singleton();
                x.For<ITestB08>().Use<TestB08>().Singleton();
                x.For<ITestB09>().Use<TestB09>().Singleton();

                x.For<ITestB10>().Use<TestB10>().Singleton();
                x.For<ITestB11>().Use<TestB11>().Singleton();
                x.For<ITestB12>().Use<TestB12>().Singleton();
                x.For<ITestB13>().Use<TestB13>().Singleton();
                x.For<ITestB14>().Use<TestB14>().Singleton();
                x.For<ITestB15>().Use<TestB15>().Singleton();
                x.For<ITestB16>().Use<TestB16>().Singleton();
                x.For<ITestB17>().Use<TestB17>().Singleton();
                x.For<ITestB18>().Use<TestB18>().Singleton();
                x.For<ITestB19>().Use<TestB19>().Singleton();

                x.For<ITestB20>().Use<TestB20>().Singleton();
                x.For<ITestB21>().Use<TestB21>().Singleton();
                x.For<ITestB22>().Use<TestB22>().Singleton();
                x.For<ITestB23>().Use<TestB23>().Singleton();
                x.For<ITestB24>().Use<TestB24>().Singleton();
                x.For<ITestB25>().Use<TestB25>().Singleton();
                x.For<ITestB26>().Use<TestB26>().Singleton();
                x.For<ITestB27>().Use<TestB27>().Singleton();
                x.For<ITestB28>().Use<TestB28>().Singleton();
                x.For<ITestB29>().Use<TestB29>().Singleton();

                x.For<ITestB30>().Use<TestB30>().Singleton();
                x.For<ITestB31>().Use<TestB31>().Singleton();
                x.For<ITestB32>().Use<TestB32>().Singleton();
                x.For<ITestB33>().Use<TestB33>().Singleton();
                x.For<ITestB34>().Use<TestB34>().Singleton();
                x.For<ITestB35>().Use<TestB35>().Singleton();
                x.For<ITestB36>().Use<TestB36>().Singleton();
                x.For<ITestB37>().Use<TestB37>().Singleton();
                x.For<ITestB38>().Use<TestB38>().Singleton();
                x.For<ITestB39>().Use<TestB39>().Singleton();

                x.For<ITestB40>().Use<TestB40>().Singleton();
                x.For<ITestB41>().Use<TestB41>().Singleton();
                x.For<ITestB42>().Use<TestB42>().Singleton();
                x.For<ITestB43>().Use<TestB43>().Singleton();
                x.For<ITestB44>().Use<TestB44>().Singleton();
                x.For<ITestB45>().Use<TestB45>().Singleton();
                x.For<ITestB46>().Use<TestB46>().Singleton();
                x.For<ITestB47>().Use<TestB47>().Singleton();
                x.For<ITestB48>().Use<TestB48>().Singleton();
                x.For<ITestB49>().Use<TestB49>().Singleton();

                x.For<ITestB>().Use<TestB>().Singleton();
            });

            return c;
        }
        
        public object TransientRegister(object container)
        {
            var c = (Container)container;

            c.Configure(x =>
            {
                x.For<ITestB00>().Use<TestB00>().AlwaysUnique();
                x.For<ITestB01>().Use<TestB01>().AlwaysUnique();
                x.For<ITestB02>().Use<TestB02>().AlwaysUnique();
                x.For<ITestB03>().Use<TestB03>().AlwaysUnique();
                x.For<ITestB04>().Use<TestB04>().AlwaysUnique();
                x.For<ITestB05>().Use<TestB05>().AlwaysUnique();
                x.For<ITestB06>().Use<TestB06>().AlwaysUnique();
                x.For<ITestB07>().Use<TestB07>().AlwaysUnique();
                x.For<ITestB08>().Use<TestB08>().AlwaysUnique();
                x.For<ITestB09>().Use<TestB09>().AlwaysUnique();

                x.For<ITestB10>().Use<TestB10>().AlwaysUnique();
                x.For<ITestB11>().Use<TestB11>().AlwaysUnique();
                x.For<ITestB12>().Use<TestB12>().AlwaysUnique();
                x.For<ITestB13>().Use<TestB13>().AlwaysUnique();
                x.For<ITestB14>().Use<TestB14>().AlwaysUnique();
                x.For<ITestB15>().Use<TestB15>().AlwaysUnique();
                x.For<ITestB16>().Use<TestB16>().AlwaysUnique();
                x.For<ITestB17>().Use<TestB17>().AlwaysUnique();
                x.For<ITestB18>().Use<TestB18>().AlwaysUnique();
                x.For<ITestB19>().Use<TestB19>().AlwaysUnique();

                x.For<ITestB20>().Use<TestB20>().AlwaysUnique();
                x.For<ITestB21>().Use<TestB21>().AlwaysUnique();
                x.For<ITestB22>().Use<TestB22>().AlwaysUnique();
                x.For<ITestB23>().Use<TestB23>().AlwaysUnique();
                x.For<ITestB24>().Use<TestB24>().AlwaysUnique();
                x.For<ITestB25>().Use<TestB25>().AlwaysUnique();
                x.For<ITestB26>().Use<TestB26>().AlwaysUnique();
                x.For<ITestB27>().Use<TestB27>().AlwaysUnique();
                x.For<ITestB28>().Use<TestB28>().AlwaysUnique();
                x.For<ITestB29>().Use<TestB29>().AlwaysUnique();

                x.For<ITestB30>().Use<TestB30>().AlwaysUnique();
                x.For<ITestB31>().Use<TestB31>().AlwaysUnique();
                x.For<ITestB32>().Use<TestB32>().AlwaysUnique();
                x.For<ITestB33>().Use<TestB33>().AlwaysUnique();
                x.For<ITestB34>().Use<TestB34>().AlwaysUnique();
                x.For<ITestB35>().Use<TestB35>().AlwaysUnique();
                x.For<ITestB36>().Use<TestB36>().AlwaysUnique();
                x.For<ITestB37>().Use<TestB37>().AlwaysUnique();
                x.For<ITestB38>().Use<TestB38>().AlwaysUnique();
                x.For<ITestB39>().Use<TestB39>().AlwaysUnique();

                x.For<ITestB40>().Use<TestB40>().AlwaysUnique();
                x.For<ITestB41>().Use<TestB41>().AlwaysUnique();
                x.For<ITestB42>().Use<TestB42>().AlwaysUnique();
                x.For<ITestB43>().Use<TestB43>().AlwaysUnique();
                x.For<ITestB44>().Use<TestB44>().AlwaysUnique();
                x.For<ITestB45>().Use<TestB45>().AlwaysUnique();
                x.For<ITestB46>().Use<TestB46>().AlwaysUnique();
                x.For<ITestB47>().Use<TestB47>().AlwaysUnique();
                x.For<ITestB48>().Use<TestB48>().AlwaysUnique();
                x.For<ITestB49>().Use<TestB49>().AlwaysUnique();

                x.For<ITestB>().Use<TestB>().AlwaysUnique();
            });

            return c;
        }

        public object PerThreadRegister(object container)
        {
            var c = (Container)container;

            c.Configure(x =>
            {
                x.For<ITestB00>(Lifecycles.ThreadLocal).Use<TestB00>();
                x.For<ITestB01>(Lifecycles.ThreadLocal).Use<TestB01>();
                x.For<ITestB02>(Lifecycles.ThreadLocal).Use<TestB02>();
                x.For<ITestB03>(Lifecycles.ThreadLocal).Use<TestB03>();
                x.For<ITestB04>(Lifecycles.ThreadLocal).Use<TestB04>();
                x.For<ITestB05>(Lifecycles.ThreadLocal).Use<TestB05>();
                x.For<ITestB06>(Lifecycles.ThreadLocal).Use<TestB06>();
                x.For<ITestB07>(Lifecycles.ThreadLocal).Use<TestB07>();
                x.For<ITestB08>(Lifecycles.ThreadLocal).Use<TestB08>();
                x.For<ITestB09>(Lifecycles.ThreadLocal).Use<TestB09>();

                x.For<ITestB10>(Lifecycles.ThreadLocal).Use<TestB10>();
                x.For<ITestB11>(Lifecycles.ThreadLocal).Use<TestB11>();
                x.For<ITestB12>(Lifecycles.ThreadLocal).Use<TestB12>();
                x.For<ITestB13>(Lifecycles.ThreadLocal).Use<TestB13>();
                x.For<ITestB14>(Lifecycles.ThreadLocal).Use<TestB14>();
                x.For<ITestB15>(Lifecycles.ThreadLocal).Use<TestB15>();
                x.For<ITestB16>(Lifecycles.ThreadLocal).Use<TestB16>();
                x.For<ITestB17>(Lifecycles.ThreadLocal).Use<TestB17>();
                x.For<ITestB18>(Lifecycles.ThreadLocal).Use<TestB18>();
                x.For<ITestB19>(Lifecycles.ThreadLocal).Use<TestB19>();

                x.For<ITestB20>(Lifecycles.ThreadLocal).Use<TestB20>();
                x.For<ITestB21>(Lifecycles.ThreadLocal).Use<TestB21>();
                x.For<ITestB22>(Lifecycles.ThreadLocal).Use<TestB22>();
                x.For<ITestB23>(Lifecycles.ThreadLocal).Use<TestB23>();
                x.For<ITestB24>(Lifecycles.ThreadLocal).Use<TestB24>();
                x.For<ITestB25>(Lifecycles.ThreadLocal).Use<TestB25>();
                x.For<ITestB26>(Lifecycles.ThreadLocal).Use<TestB26>();
                x.For<ITestB27>(Lifecycles.ThreadLocal).Use<TestB27>();
                x.For<ITestB28>(Lifecycles.ThreadLocal).Use<TestB28>();
                x.For<ITestB29>(Lifecycles.ThreadLocal).Use<TestB29>();

                x.For<ITestB30>(Lifecycles.ThreadLocal).Use<TestB30>();
                x.For<ITestB31>(Lifecycles.ThreadLocal).Use<TestB31>();
                x.For<ITestB32>(Lifecycles.ThreadLocal).Use<TestB32>();
                x.For<ITestB33>(Lifecycles.ThreadLocal).Use<TestB33>();
                x.For<ITestB34>(Lifecycles.ThreadLocal).Use<TestB34>();
                x.For<ITestB35>(Lifecycles.ThreadLocal).Use<TestB35>();
                x.For<ITestB36>(Lifecycles.ThreadLocal).Use<TestB36>();
                x.For<ITestB37>(Lifecycles.ThreadLocal).Use<TestB37>();
                x.For<ITestB38>(Lifecycles.ThreadLocal).Use<TestB38>();
                x.For<ITestB39>(Lifecycles.ThreadLocal).Use<TestB39>();

                x.For<ITestB40>(Lifecycles.ThreadLocal).Use<TestB40>();
                x.For<ITestB41>(Lifecycles.ThreadLocal).Use<TestB41>();
                x.For<ITestB42>(Lifecycles.ThreadLocal).Use<TestB42>();
                x.For<ITestB43>(Lifecycles.ThreadLocal).Use<TestB43>();
                x.For<ITestB44>(Lifecycles.ThreadLocal).Use<TestB44>();
                x.For<ITestB45>(Lifecycles.ThreadLocal).Use<TestB45>();
                x.For<ITestB46>(Lifecycles.ThreadLocal).Use<TestB46>();
                x.For<ITestB47>(Lifecycles.ThreadLocal).Use<TestB47>();
                x.For<ITestB48>(Lifecycles.ThreadLocal).Use<TestB48>();
                x.For<ITestB49>(Lifecycles.ThreadLocal).Use<TestB49>();

                x.For<ITestB>(Lifecycles.ThreadLocal).Use<TestB>();
            });

            return c;
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