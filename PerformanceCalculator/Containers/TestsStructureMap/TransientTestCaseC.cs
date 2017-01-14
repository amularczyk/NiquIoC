using StructureMap;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class TransientTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Configure(x =>
            {
                x.For<ITestCa0>().Use<TestCa0>().AlwaysUnique();
                x.For<ITestCa0>().Use<TestCa0>().AlwaysUnique();
                x.For<ITestCa1>().Use<TestCa1>().AlwaysUnique();
                x.For<ITestCa2>().Use<TestCa2>().AlwaysUnique();
                x.For<ITestCa3>().Use<TestCa3>().AlwaysUnique();
                x.For<ITestCa4>().Use<TestCa4>().AlwaysUnique();
                x.For<ITestCa5>().Use<TestCa5>().AlwaysUnique();
                x.For<ITestCa6>().Use<TestCa6>().AlwaysUnique();
                x.For<ITestCa7>().Use<TestCa7>().AlwaysUnique();
                x.For<ITestCa8>().Use<TestCa8>().AlwaysUnique();
                x.For<ITestCa9>().Use<TestCa9>().AlwaysUnique();
                x.For<ITestCa10>().Use<TestCa10>().AlwaysUnique();

                x.For<ITestCb0>().Use<TestCb0>().AlwaysUnique();
                x.For<ITestCb0>().Use<TestCb0>().AlwaysUnique();
                x.For<ITestCb1>().Use<TestCb1>().AlwaysUnique();
                x.For<ITestCb2>().Use<TestCb2>().AlwaysUnique();
                x.For<ITestCb3>().Use<TestCb3>().AlwaysUnique();
                x.For<ITestCb4>().Use<TestCb4>().AlwaysUnique();
                x.For<ITestCb5>().Use<TestCb5>().AlwaysUnique();
                x.For<ITestCb6>().Use<TestCb6>().AlwaysUnique();
                x.For<ITestCb7>().Use<TestCb7>().AlwaysUnique();
                x.For<ITestCb8>().Use<TestCb8>().AlwaysUnique();
                x.For<ITestCb9>().Use<TestCb9>().AlwaysUnique();
                x.For<ITestCb10>().Use<TestCb10>().AlwaysUnique();

                x.For<ITestCc0>().Use<TestCc0>().AlwaysUnique();
                x.For<ITestCc0>().Use<TestCc0>().AlwaysUnique();
                x.For<ITestCc1>().Use<TestCc1>().AlwaysUnique();
                x.For<ITestCc2>().Use<TestCc2>().AlwaysUnique();
                x.For<ITestCc3>().Use<TestCc3>().AlwaysUnique();
                x.For<ITestCc4>().Use<TestCc4>().AlwaysUnique();
                x.For<ITestCc5>().Use<TestCc5>().AlwaysUnique();
                x.For<ITestCc6>().Use<TestCc6>().AlwaysUnique();
                x.For<ITestCc7>().Use<TestCc7>().AlwaysUnique();
                x.For<ITestCc8>().Use<TestCc8>().AlwaysUnique();
                x.For<ITestCc9>().Use<TestCc9>().AlwaysUnique();
                x.For<ITestCc10>().Use<TestCc10>().AlwaysUnique();

                x.For<ITestC>().Use<TestC>().AlwaysUnique();
            });

            return c;
        }
    }
}