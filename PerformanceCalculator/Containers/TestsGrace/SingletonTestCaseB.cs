using Grace.DependencyInjection;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class SingletonTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (DependencyInjectionContainer)container;

            c.Configure(x =>
            {
                x.Export<TestB00>().As<ITestB00>().Lifestyle.Singleton();
                x.Export<TestB01>().As<ITestB01>().Lifestyle.Singleton();
                x.Export<TestB02>().As<ITestB02>().Lifestyle.Singleton();
                x.Export<TestB03>().As<ITestB03>().Lifestyle.Singleton();
                x.Export<TestB04>().As<ITestB04>().Lifestyle.Singleton();
                x.Export<TestB05>().As<ITestB05>().Lifestyle.Singleton();
                x.Export<TestB06>().As<ITestB06>().Lifestyle.Singleton();
                x.Export<TestB07>().As<ITestB07>().Lifestyle.Singleton();
                x.Export<TestB08>().As<ITestB08>().Lifestyle.Singleton();
                x.Export<TestB09>().As<ITestB09>().Lifestyle.Singleton();

                x.Export<TestB10>().As<ITestB10>().Lifestyle.Singleton();
                x.Export<TestB11>().As<ITestB11>().Lifestyle.Singleton();
                x.Export<TestB12>().As<ITestB12>().Lifestyle.Singleton();
                x.Export<TestB13>().As<ITestB13>().Lifestyle.Singleton();
                x.Export<TestB14>().As<ITestB14>().Lifestyle.Singleton();
                x.Export<TestB15>().As<ITestB15>().Lifestyle.Singleton();
                x.Export<TestB16>().As<ITestB16>().Lifestyle.Singleton();
                x.Export<TestB17>().As<ITestB17>().Lifestyle.Singleton();
                x.Export<TestB18>().As<ITestB18>().Lifestyle.Singleton();
                x.Export<TestB19>().As<ITestB19>().Lifestyle.Singleton();

                x.Export<TestB20>().As<ITestB20>().Lifestyle.Singleton();
                x.Export<TestB21>().As<ITestB21>().Lifestyle.Singleton();
                x.Export<TestB22>().As<ITestB22>().Lifestyle.Singleton();
                x.Export<TestB23>().As<ITestB23>().Lifestyle.Singleton();
                x.Export<TestB24>().As<ITestB24>().Lifestyle.Singleton();
                x.Export<TestB25>().As<ITestB25>().Lifestyle.Singleton();
                x.Export<TestB26>().As<ITestB26>().Lifestyle.Singleton();
                x.Export<TestB27>().As<ITestB27>().Lifestyle.Singleton();
                x.Export<TestB28>().As<ITestB28>().Lifestyle.Singleton();
                x.Export<TestB29>().As<ITestB29>().Lifestyle.Singleton();

                x.Export<TestB30>().As<ITestB30>().Lifestyle.Singleton();
                x.Export<TestB31>().As<ITestB31>().Lifestyle.Singleton();
                x.Export<TestB32>().As<ITestB32>().Lifestyle.Singleton();
                x.Export<TestB33>().As<ITestB33>().Lifestyle.Singleton();
                x.Export<TestB34>().As<ITestB34>().Lifestyle.Singleton();
                x.Export<TestB35>().As<ITestB35>().Lifestyle.Singleton();
                x.Export<TestB36>().As<ITestB36>().Lifestyle.Singleton();
                x.Export<TestB37>().As<ITestB37>().Lifestyle.Singleton();
                x.Export<TestB38>().As<ITestB38>().Lifestyle.Singleton();
                x.Export<TestB39>().As<ITestB39>().Lifestyle.Singleton();

                x.Export<TestB40>().As<ITestB40>().Lifestyle.Singleton();
                x.Export<TestB41>().As<ITestB41>().Lifestyle.Singleton();
                x.Export<TestB42>().As<ITestB42>().Lifestyle.Singleton();
                x.Export<TestB43>().As<ITestB43>().Lifestyle.Singleton();
                x.Export<TestB44>().As<ITestB44>().Lifestyle.Singleton();
                x.Export<TestB45>().As<ITestB45>().Lifestyle.Singleton();
                x.Export<TestB46>().As<ITestB46>().Lifestyle.Singleton();
                x.Export<TestB47>().As<ITestB47>().Lifestyle.Singleton();
                x.Export<TestB48>().As<ITestB48>().Lifestyle.Singleton();
                x.Export<TestB49>().As<ITestB49>().Lifestyle.Singleton();

                x.Export<TestB>().As<ITestB>().Lifestyle.Singleton();
            });

            return c;
        }
    }
}