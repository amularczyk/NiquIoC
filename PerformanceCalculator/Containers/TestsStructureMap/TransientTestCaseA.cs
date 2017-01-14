using StructureMap;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class TransientTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Configure(x =>
            {
                x.For<ITestA0>().Use<TestA0>().AlwaysUnique();
                x.For<ITestA0>().Use<TestA0>().AlwaysUnique();
                x.For<ITestA1>().Use<TestA1>().AlwaysUnique();
                x.For<ITestA2>().Use<TestA2>().AlwaysUnique();
                x.For<ITestA3>().Use<TestA3>().AlwaysUnique();
                x.For<ITestA4>().Use<TestA4>().AlwaysUnique();
                x.For<ITestA5>().Use<TestA5>().AlwaysUnique();
                x.For<ITestA6>().Use<TestA6>().AlwaysUnique();
                x.For<ITestA7>().Use<TestA7>().AlwaysUnique();
                x.For<ITestA8>().Use<TestA8>().AlwaysUnique();
                x.For<ITestA9>().Use<TestA9>().AlwaysUnique();
                x.For<ITestA>().Use<TestA>().AlwaysUnique();
            });

            return c;
        }
    }
}