using StructureMap;
using PerformanceCalculator.TestCases;
using StructureMap.Pipeline;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class PerThreadTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Configure(x =>
            {
                x.For<ITestA0>(Lifecycles.ThreadLocal).Use<TestA0>();
                x.For<ITestA0>(Lifecycles.ThreadLocal).Use<TestA0>();
                x.For<ITestA1>(Lifecycles.ThreadLocal).Use<TestA1>();
                x.For<ITestA2>(Lifecycles.ThreadLocal).Use<TestA2>();
                x.For<ITestA3>(Lifecycles.ThreadLocal).Use<TestA3>();
                x.For<ITestA4>(Lifecycles.ThreadLocal).Use<TestA4>();
                x.For<ITestA5>(Lifecycles.ThreadLocal).Use<TestA5>();
                x.For<ITestA6>(Lifecycles.ThreadLocal).Use<TestA6>();
                x.For<ITestA7>(Lifecycles.ThreadLocal).Use<TestA7>();
                x.For<ITestA8>(Lifecycles.ThreadLocal).Use<TestA8>();
                x.For<ITestA9>(Lifecycles.ThreadLocal).Use<TestA9>();
                x.For<ITestA>(Lifecycles.ThreadLocal).Use<TestA>();
            });

            return c;
        }
    }
}