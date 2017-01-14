using StructureMap;
using PerformanceCalculator.TestCases;
using StructureMap.Pipeline;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class PerThreadTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Configure(x =>
            {
                x.For<ITestCa0>(Lifecycles.ThreadLocal).Use<TestCa0>();
                x.For<ITestCa0>(Lifecycles.ThreadLocal).Use<TestCa0>();
                x.For<ITestCa1>(Lifecycles.ThreadLocal).Use<TestCa1>();
                x.For<ITestCa2>(Lifecycles.ThreadLocal).Use<TestCa2>();
                x.For<ITestCa3>(Lifecycles.ThreadLocal).Use<TestCa3>();
                x.For<ITestCa4>(Lifecycles.ThreadLocal).Use<TestCa4>();
                x.For<ITestCa5>(Lifecycles.ThreadLocal).Use<TestCa5>();
                x.For<ITestCa6>(Lifecycles.ThreadLocal).Use<TestCa6>();
                x.For<ITestCa7>(Lifecycles.ThreadLocal).Use<TestCa7>();
                x.For<ITestCa8>(Lifecycles.ThreadLocal).Use<TestCa8>();
                x.For<ITestCa9>(Lifecycles.ThreadLocal).Use<TestCa9>();
                x.For<ITestCa10>(Lifecycles.ThreadLocal).Use<TestCa10>();

                x.For<ITestCb0>(Lifecycles.ThreadLocal).Use<TestCb0>();
                x.For<ITestCb0>(Lifecycles.ThreadLocal).Use<TestCb0>();
                x.For<ITestCb1>(Lifecycles.ThreadLocal).Use<TestCb1>();
                x.For<ITestCb2>(Lifecycles.ThreadLocal).Use<TestCb2>();
                x.For<ITestCb3>(Lifecycles.ThreadLocal).Use<TestCb3>();
                x.For<ITestCb4>(Lifecycles.ThreadLocal).Use<TestCb4>();
                x.For<ITestCb5>(Lifecycles.ThreadLocal).Use<TestCb5>();
                x.For<ITestCb6>(Lifecycles.ThreadLocal).Use<TestCb6>();
                x.For<ITestCb7>(Lifecycles.ThreadLocal).Use<TestCb7>();
                x.For<ITestCb8>(Lifecycles.ThreadLocal).Use<TestCb8>();
                x.For<ITestCb9>(Lifecycles.ThreadLocal).Use<TestCb9>();
                x.For<ITestCb10>(Lifecycles.ThreadLocal).Use<TestCb10>();

                x.For<ITestCc0>(Lifecycles.ThreadLocal).Use<TestCc0>();
                x.For<ITestCc0>(Lifecycles.ThreadLocal).Use<TestCc0>();
                x.For<ITestCc1>(Lifecycles.ThreadLocal).Use<TestCc1>();
                x.For<ITestCc2>(Lifecycles.ThreadLocal).Use<TestCc2>();
                x.For<ITestCc3>(Lifecycles.ThreadLocal).Use<TestCc3>();
                x.For<ITestCc4>(Lifecycles.ThreadLocal).Use<TestCc4>();
                x.For<ITestCc5>(Lifecycles.ThreadLocal).Use<TestCc5>();
                x.For<ITestCc6>(Lifecycles.ThreadLocal).Use<TestCc6>();
                x.For<ITestCc7>(Lifecycles.ThreadLocal).Use<TestCc7>();
                x.For<ITestCc8>(Lifecycles.ThreadLocal).Use<TestCc8>();
                x.For<ITestCc9>(Lifecycles.ThreadLocal).Use<TestCc9>();
                x.For<ITestCc10>(Lifecycles.ThreadLocal).Use<TestCc10>();

                x.For<ITestC>(Lifecycles.ThreadLocal).Use<TestC>();
            });

            return c;
        }
    }
}