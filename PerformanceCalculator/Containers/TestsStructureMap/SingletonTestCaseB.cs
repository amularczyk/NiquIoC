using StructureMap;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class SingletonTestCaseB : TestCaseB
    {
        public override object Register(object container)
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
    }
}