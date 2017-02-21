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
                x.Export<TestB00>().As<ITestB00>().Lifestyle.SingletonPerScope();
                x.Export<TestB01>().As<ITestB01>().Lifestyle.SingletonPerScope();
                x.Export<TestB02>().As<ITestB02>().Lifestyle.SingletonPerScope();
                x.Export<TestB03>().As<ITestB03>().Lifestyle.SingletonPerScope();
                x.Export<TestB04>().As<ITestB04>().Lifestyle.SingletonPerScope();
                x.Export<TestB05>().As<ITestB05>().Lifestyle.SingletonPerScope();
                x.Export<TestB06>().As<ITestB06>().Lifestyle.SingletonPerScope();
                x.Export<TestB07>().As<ITestB07>().Lifestyle.SingletonPerScope();
                x.Export<TestB08>().As<ITestB08>().Lifestyle.SingletonPerScope();
                x.Export<TestB09>().As<ITestB09>().Lifestyle.SingletonPerScope();

                x.Export<TestB10>().As<ITestB10>().Lifestyle.SingletonPerScope();
                x.Export<TestB11>().As<ITestB11>().Lifestyle.SingletonPerScope();
                x.Export<TestB12>().As<ITestB12>().Lifestyle.SingletonPerScope();
                x.Export<TestB13>().As<ITestB13>().Lifestyle.SingletonPerScope();
                x.Export<TestB14>().As<ITestB14>().Lifestyle.SingletonPerScope();
                x.Export<TestB15>().As<ITestB15>().Lifestyle.SingletonPerScope();
                x.Export<TestB16>().As<ITestB16>().Lifestyle.SingletonPerScope();
                x.Export<TestB17>().As<ITestB17>().Lifestyle.SingletonPerScope();
                x.Export<TestB18>().As<ITestB18>().Lifestyle.SingletonPerScope();
                x.Export<TestB19>().As<ITestB19>().Lifestyle.SingletonPerScope();

                x.Export<TestB20>().As<ITestB20>().Lifestyle.SingletonPerScope();
                x.Export<TestB21>().As<ITestB21>().Lifestyle.SingletonPerScope();
                x.Export<TestB22>().As<ITestB22>().Lifestyle.SingletonPerScope();
                x.Export<TestB23>().As<ITestB23>().Lifestyle.SingletonPerScope();
                x.Export<TestB24>().As<ITestB24>().Lifestyle.SingletonPerScope();
                x.Export<TestB25>().As<ITestB25>().Lifestyle.SingletonPerScope();
                x.Export<TestB26>().As<ITestB26>().Lifestyle.SingletonPerScope();
                x.Export<TestB27>().As<ITestB27>().Lifestyle.SingletonPerScope();
                x.Export<TestB28>().As<ITestB28>().Lifestyle.SingletonPerScope();
                x.Export<TestB29>().As<ITestB29>().Lifestyle.SingletonPerScope();

                x.Export<TestB30>().As<ITestB30>().Lifestyle.SingletonPerScope();
                x.Export<TestB31>().As<ITestB31>().Lifestyle.SingletonPerScope();
                x.Export<TestB32>().As<ITestB32>().Lifestyle.SingletonPerScope();
                x.Export<TestB33>().As<ITestB33>().Lifestyle.SingletonPerScope();
                x.Export<TestB34>().As<ITestB34>().Lifestyle.SingletonPerScope();
                x.Export<TestB35>().As<ITestB35>().Lifestyle.SingletonPerScope();
                x.Export<TestB36>().As<ITestB36>().Lifestyle.SingletonPerScope();
                x.Export<TestB37>().As<ITestB37>().Lifestyle.SingletonPerScope();
                x.Export<TestB38>().As<ITestB38>().Lifestyle.SingletonPerScope();
                x.Export<TestB39>().As<ITestB39>().Lifestyle.SingletonPerScope();

                x.Export<TestB40>().As<ITestB40>().Lifestyle.SingletonPerScope();
                x.Export<TestB41>().As<ITestB41>().Lifestyle.SingletonPerScope();
                x.Export<TestB42>().As<ITestB42>().Lifestyle.SingletonPerScope();
                x.Export<TestB43>().As<ITestB43>().Lifestyle.SingletonPerScope();
                x.Export<TestB44>().As<ITestB44>().Lifestyle.SingletonPerScope();
                x.Export<TestB45>().As<ITestB45>().Lifestyle.SingletonPerScope();
                x.Export<TestB46>().As<ITestB46>().Lifestyle.SingletonPerScope();
                x.Export<TestB47>().As<ITestB47>().Lifestyle.SingletonPerScope();
                x.Export<TestB48>().As<ITestB48>().Lifestyle.SingletonPerScope();
                x.Export<TestB49>().As<ITestB49>().Lifestyle.SingletonPerScope();

                x.Export<TestB>().As<ITestB>().Lifestyle.SingletonPerScope();
            });

            return c;
        }
    }
}