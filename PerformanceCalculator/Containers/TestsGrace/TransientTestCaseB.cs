using Grace.DependencyInjection;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class TransientTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (DependencyInjectionContainer)container;

            c.Configure(x =>
            {
                x.Export<TestB00>().As<ITestB00>();
                x.Export<TestB01>().As<ITestB01>();
                x.Export<TestB02>().As<ITestB02>();
                x.Export<TestB03>().As<ITestB03>();
                x.Export<TestB04>().As<ITestB04>();
                x.Export<TestB05>().As<ITestB05>();
                x.Export<TestB06>().As<ITestB06>();
                x.Export<TestB07>().As<ITestB07>();
                x.Export<TestB08>().As<ITestB08>();
                x.Export<TestB09>().As<ITestB09>();

                x.Export<TestB10>().As<ITestB10>();
                x.Export<TestB11>().As<ITestB11>();
                x.Export<TestB12>().As<ITestB12>();
                x.Export<TestB13>().As<ITestB13>();
                x.Export<TestB14>().As<ITestB14>();
                x.Export<TestB15>().As<ITestB15>();
                x.Export<TestB16>().As<ITestB16>();
                x.Export<TestB17>().As<ITestB17>();
                x.Export<TestB18>().As<ITestB18>();
                x.Export<TestB19>().As<ITestB19>();

                x.Export<TestB20>().As<ITestB20>();
                x.Export<TestB21>().As<ITestB21>();
                x.Export<TestB22>().As<ITestB22>();
                x.Export<TestB23>().As<ITestB23>();
                x.Export<TestB24>().As<ITestB24>();
                x.Export<TestB25>().As<ITestB25>();
                x.Export<TestB26>().As<ITestB26>();
                x.Export<TestB27>().As<ITestB27>();
                x.Export<TestB28>().As<ITestB28>();
                x.Export<TestB29>().As<ITestB29>();

                x.Export<TestB30>().As<ITestB30>();
                x.Export<TestB31>().As<ITestB31>();
                x.Export<TestB32>().As<ITestB32>();
                x.Export<TestB33>().As<ITestB33>();
                x.Export<TestB34>().As<ITestB34>();
                x.Export<TestB35>().As<ITestB35>();
                x.Export<TestB36>().As<ITestB36>();
                x.Export<TestB37>().As<ITestB37>();
                x.Export<TestB38>().As<ITestB38>();
                x.Export<TestB39>().As<ITestB39>();

                x.Export<TestB40>().As<ITestB40>();
                x.Export<TestB41>().As<ITestB41>();
                x.Export<TestB42>().As<ITestB42>();
                x.Export<TestB43>().As<ITestB43>();
                x.Export<TestB44>().As<ITestB44>();
                x.Export<TestB45>().As<ITestB45>();
                x.Export<TestB46>().As<ITestB46>();
                x.Export<TestB47>().As<ITestB47>();
                x.Export<TestB48>().As<ITestB48>();
                x.Export<TestB49>().As<ITestB49>();

                x.Export<TestB>().As<ITestB>();
            });

            return c;
        }
    }
}