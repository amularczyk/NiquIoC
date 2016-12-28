using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using StructureMap;
using StructureMap.Pipeline;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class TestCaseA : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (Container)container;

            c.Configure(x =>
            {
                x.For<ITestA0>().Use<TestA0>().Singleton();
                x.For<ITestA0>().Use<TestA0>().Singleton();
                x.For<ITestA1>().Use<TestA1>().Singleton();
                x.For<ITestA2>().Use<TestA2>().Singleton();
                x.For<ITestA3>().Use<TestA3>().Singleton();
                x.For<ITestA4>().Use<TestA4>().Singleton();
                x.For<ITestA5>().Use<TestA5>().Singleton();
                x.For<ITestA6>().Use<TestA6>().Singleton();
                x.For<ITestA7>().Use<TestA7>().Singleton();
                x.For<ITestA8>().Use<TestA8>().Singleton();
                x.For<ITestA9>().Use<TestA9>().Singleton();
                x.For<ITestA>().Use<TestA>().Singleton();
            });

            return c;
        }
        
        public object TransientRegister(object container)
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

        public object PerThreadRegister(object container)
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

        public object PerHttpContextRegister(object container)
        {
            var c = (Container)container;

            c.Configure(x =>
            {
                //x.For<ITestA0>().Use<TestA0>().();
                //x.For<ITestA0>().Use<TestA0>().AlwaysUnique();
                //x.For<ITestA1>().Use<TestA1>().AlwaysUnique();
                //x.For<ITestA2>().Use<TestA2>().AlwaysUnique();
                //x.For<ITestA3>().Use<TestA3>().AlwaysUnique();
                //x.For<ITestA4>().Use<TestA4>().AlwaysUnique();
                //x.For<ITestA5>().Use<TestA5>().AlwaysUnique();
                //x.For<ITestA6>().Use<TestA6>().AlwaysUnique();
                //x.For<ITestA7>().Use<TestA7>().AlwaysUnique();
                //x.For<ITestA8>().Use<TestA8>().AlwaysUnique();
                //x.For<ITestA9>().Use<TestA9>().AlwaysUnique();
                //x.For<ITestA>().Use<TestA>().AlwaysUnique();
            });

            return c;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<ITestA>();
            }
        }
    }
}