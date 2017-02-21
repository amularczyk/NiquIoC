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
                x.Export<ITestB00>().As<TestB00>();
                x.Export<ITestB01>().As<TestB01>();
                x.Export<ITestB02>().As<TestB02>();
                x.Export<ITestB03>().As<TestB03>();
                x.Export<ITestB04>().As<TestB04>();
                x.Export<ITestB05>().As<TestB05>();
                x.Export<ITestB06>().As<TestB06>();
                x.Export<ITestB07>().As<TestB07>();
                x.Export<ITestB08>().As<TestB08>();
                x.Export<ITestB09>().As<TestB09>();

                x.Export<ITestB10>().As<TestB10>();
                x.Export<ITestB11>().As<TestB11>();
                x.Export<ITestB12>().As<TestB12>();
                x.Export<ITestB13>().As<TestB13>();
                x.Export<ITestB14>().As<TestB14>();
                x.Export<ITestB15>().As<TestB15>();
                x.Export<ITestB16>().As<TestB16>();
                x.Export<ITestB17>().As<TestB17>();
                x.Export<ITestB18>().As<TestB18>();
                x.Export<ITestB19>().As<TestB19>();

                x.Export<ITestB20>().As<TestB20>();
                x.Export<ITestB21>().As<TestB21>();
                x.Export<ITestB22>().As<TestB22>();
                x.Export<ITestB23>().As<TestB23>();
                x.Export<ITestB24>().As<TestB24>();
                x.Export<ITestB25>().As<TestB25>();
                x.Export<ITestB26>().As<TestB26>();
                x.Export<ITestB27>().As<TestB27>();
                x.Export<ITestB28>().As<TestB28>();
                x.Export<ITestB29>().As<TestB29>();

                x.Export<ITestB30>().As<TestB30>();
                x.Export<ITestB31>().As<TestB31>();
                x.Export<ITestB32>().As<TestB32>();
                x.Export<ITestB33>().As<TestB33>();
                x.Export<ITestB34>().As<TestB34>();
                x.Export<ITestB35>().As<TestB35>();
                x.Export<ITestB36>().As<TestB36>();
                x.Export<ITestB37>().As<TestB37>();
                x.Export<ITestB38>().As<TestB38>();
                x.Export<ITestB39>().As<TestB39>();

                x.Export<ITestB40>().As<TestB40>();
                x.Export<ITestB41>().As<TestB41>();
                x.Export<ITestB42>().As<TestB42>();
                x.Export<ITestB43>().As<TestB43>();
                x.Export<ITestB44>().As<TestB44>();
                x.Export<ITestB45>().As<TestB45>();
                x.Export<ITestB46>().As<TestB46>();
                x.Export<ITestB47>().As<TestB47>();
                x.Export<ITestB48>().As<TestB48>();
                x.Export<ITestB49>().As<TestB49>();

                x.Export<ITestB>().As<TestB>();
            });

            return c;
        }
    }
}