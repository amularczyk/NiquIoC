using StructureMap;
using PerformanceCalculator.TestCases;
using StructureMap.Pipeline;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class PerThreadTestCaseB : TestCaseB
    {
        public override object Register(object container)
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
    }
}