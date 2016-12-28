using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using StructureMap;

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