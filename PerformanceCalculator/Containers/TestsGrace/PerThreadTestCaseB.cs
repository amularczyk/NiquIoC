using Grace.DependencyInjection;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class PerThreadTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (DependencyInjectionContainer)container;

            c.Configure(x =>
            {
                x.Export<ITestB00>().As<TestB00>().Lifestyle.SingletonPerScope();
                x.Export<ITestB01>().As<TestB01>().Lifestyle.SingletonPerScope();
                x.Export<ITestB02>().As<TestB02>().Lifestyle.SingletonPerScope();
                x.Export<ITestB03>().As<TestB03>().Lifestyle.SingletonPerScope();
                x.Export<ITestB04>().As<TestB04>().Lifestyle.SingletonPerScope();
                x.Export<ITestB05>().As<TestB05>().Lifestyle.SingletonPerScope();
                x.Export<ITestB06>().As<TestB06>().Lifestyle.SingletonPerScope();
                x.Export<ITestB07>().As<TestB07>().Lifestyle.SingletonPerScope();
                x.Export<ITestB08>().As<TestB08>().Lifestyle.SingletonPerScope();
                x.Export<ITestB09>().As<TestB09>().Lifestyle.SingletonPerScope();

                x.Export<ITestB10>().As<TestB10>().Lifestyle.SingletonPerScope();
                x.Export<ITestB11>().As<TestB11>().Lifestyle.SingletonPerScope();
                x.Export<ITestB12>().As<TestB12>().Lifestyle.SingletonPerScope();
                x.Export<ITestB13>().As<TestB13>().Lifestyle.SingletonPerScope();
                x.Export<ITestB14>().As<TestB14>().Lifestyle.SingletonPerScope();
                x.Export<ITestB15>().As<TestB15>().Lifestyle.SingletonPerScope();
                x.Export<ITestB16>().As<TestB16>().Lifestyle.SingletonPerScope();
                x.Export<ITestB17>().As<TestB17>().Lifestyle.SingletonPerScope();
                x.Export<ITestB18>().As<TestB18>().Lifestyle.SingletonPerScope();
                x.Export<ITestB19>().As<TestB19>().Lifestyle.SingletonPerScope();

                x.Export<ITestB20>().As<TestB20>().Lifestyle.SingletonPerScope();
                x.Export<ITestB21>().As<TestB21>().Lifestyle.SingletonPerScope();
                x.Export<ITestB22>().As<TestB22>().Lifestyle.SingletonPerScope();
                x.Export<ITestB23>().As<TestB23>().Lifestyle.SingletonPerScope();
                x.Export<ITestB24>().As<TestB24>().Lifestyle.SingletonPerScope();
                x.Export<ITestB25>().As<TestB25>().Lifestyle.SingletonPerScope();
                x.Export<ITestB26>().As<TestB26>().Lifestyle.SingletonPerScope();
                x.Export<ITestB27>().As<TestB27>().Lifestyle.SingletonPerScope();
                x.Export<ITestB28>().As<TestB28>().Lifestyle.SingletonPerScope();
                x.Export<ITestB29>().As<TestB29>().Lifestyle.SingletonPerScope();

                x.Export<ITestB30>().As<TestB30>().Lifestyle.SingletonPerScope();
                x.Export<ITestB31>().As<TestB31>().Lifestyle.SingletonPerScope();
                x.Export<ITestB32>().As<TestB32>().Lifestyle.SingletonPerScope();
                x.Export<ITestB33>().As<TestB33>().Lifestyle.SingletonPerScope();
                x.Export<ITestB34>().As<TestB34>().Lifestyle.SingletonPerScope();
                x.Export<ITestB35>().As<TestB35>().Lifestyle.SingletonPerScope();
                x.Export<ITestB36>().As<TestB36>().Lifestyle.SingletonPerScope();
                x.Export<ITestB37>().As<TestB37>().Lifestyle.SingletonPerScope();
                x.Export<ITestB38>().As<TestB38>().Lifestyle.SingletonPerScope();
                x.Export<ITestB39>().As<TestB39>().Lifestyle.SingletonPerScope();

                x.Export<ITestB40>().As<TestB40>().Lifestyle.SingletonPerScope();
                x.Export<ITestB41>().As<TestB41>().Lifestyle.SingletonPerScope();
                x.Export<ITestB42>().As<TestB42>().Lifestyle.SingletonPerScope();
                x.Export<ITestB43>().As<TestB43>().Lifestyle.SingletonPerScope();
                x.Export<ITestB44>().As<TestB44>().Lifestyle.SingletonPerScope();
                x.Export<ITestB45>().As<TestB45>().Lifestyle.SingletonPerScope();
                x.Export<ITestB46>().As<TestB46>().Lifestyle.SingletonPerScope();
                x.Export<ITestB47>().As<TestB47>().Lifestyle.SingletonPerScope();
                x.Export<ITestB48>().As<TestB48>().Lifestyle.SingletonPerScope();
                x.Export<ITestB49>().As<TestB49>().Lifestyle.SingletonPerScope();

                x.Export<ITestB>().As<TestB>().Lifestyle.SingletonPerScope();
            });

            return c;
        }
    }
}