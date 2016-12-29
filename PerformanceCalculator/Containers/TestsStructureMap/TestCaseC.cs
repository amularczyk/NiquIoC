using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using StructureMap;
using StructureMap.Pipeline;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class TestCaseC : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (Container)container;

            c.Configure(x =>
            {
                x.For<ITestCa0>().Use<TestCa0>().Singleton();
                x.For<ITestCa0>().Use<TestCa0>().Singleton();
                x.For<ITestCa1>().Use<TestCa1>().Singleton();
                x.For<ITestCa2>().Use<TestCa2>().Singleton();
                x.For<ITestCa3>().Use<TestCa3>().Singleton();
                x.For<ITestCa4>().Use<TestCa4>().Singleton();
                x.For<ITestCa5>().Use<TestCa5>().Singleton();
                x.For<ITestCa6>().Use<TestCa6>().Singleton();
                x.For<ITestCa7>().Use<TestCa7>().Singleton();
                x.For<ITestCa8>().Use<TestCa8>().Singleton();
                x.For<ITestCa9>().Use<TestCa9>().Singleton();
                x.For<ITestCa10>().Use<TestCa10>().Singleton();

                x.For<ITestCb0>().Use<TestCb0>().Singleton();
                x.For<ITestCb0>().Use<TestCb0>().Singleton();
                x.For<ITestCb1>().Use<TestCb1>().Singleton();
                x.For<ITestCb2>().Use<TestCb2>().Singleton();
                x.For<ITestCb3>().Use<TestCb3>().Singleton();
                x.For<ITestCb4>().Use<TestCb4>().Singleton();
                x.For<ITestCb5>().Use<TestCb5>().Singleton();
                x.For<ITestCb6>().Use<TestCb6>().Singleton();
                x.For<ITestCb7>().Use<TestCb7>().Singleton();
                x.For<ITestCb8>().Use<TestCb8>().Singleton();
                x.For<ITestCb9>().Use<TestCb9>().Singleton();
                x.For<ITestCb10>().Use<TestCb10>().Singleton();

                x.For<ITestCc0>().Use<TestCc0>().Singleton();
                x.For<ITestCc0>().Use<TestCc0>().Singleton();
                x.For<ITestCc1>().Use<TestCc1>().Singleton();
                x.For<ITestCc2>().Use<TestCc2>().Singleton();
                x.For<ITestCc3>().Use<TestCc3>().Singleton();
                x.For<ITestCc4>().Use<TestCc4>().Singleton();
                x.For<ITestCc5>().Use<TestCc5>().Singleton();
                x.For<ITestCc6>().Use<TestCc6>().Singleton();
                x.For<ITestCc7>().Use<TestCc7>().Singleton();
                x.For<ITestCc8>().Use<TestCc8>().Singleton();
                x.For<ITestCc9>().Use<TestCc9>().Singleton();
                x.For<ITestCc10>().Use<TestCc10>().Singleton();

                x.For<ITestC>().Use<TestC>().Singleton();
            });

            return c;
        }

        public object TransientRegister(object container)
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

        public object PerThreadRegister(object container)
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

        public object PerHttpContextRegister(object container)
        {
            throw new System.NotImplementedException();
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<ITestC>();
            }
        }
    }
}