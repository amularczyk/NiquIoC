using StructureMap;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class TransientTestCaseB : TestCaseB
    {
        public override object Register(object container)
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
    }
}