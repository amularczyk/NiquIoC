using DryIoc;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class TestCaseA : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (Container)container;

            c.Register<ITestA0, TestA0>(Reuse.Singleton);
            c.Register<ITestA1, TestA1>(Reuse.Singleton);
            c.Register<ITestA2, TestA2>(Reuse.Singleton);
            c.Register<ITestA3, TestA3>(Reuse.Singleton);
            c.Register<ITestA4, TestA4>(Reuse.Singleton);
            c.Register<ITestA5, TestA5>(Reuse.Singleton);
            c.Register<ITestA6, TestA6>(Reuse.Singleton);
            c.Register<ITestA7, TestA7>(Reuse.Singleton);
            c.Register<ITestA8, TestA8>(Reuse.Singleton);
            c.Register<ITestA9, TestA9>(Reuse.Singleton);
            c.Register<ITestA, TestA>(Reuse.Singleton);

            return c;
        }
        
        public object TransientRegister(object container)
        {
            var c = (Container)container;

            c.Register<ITestA0, TestA0>();
            c.Register<ITestA1, TestA1>();
            c.Register<ITestA2, TestA2>();
            c.Register<ITestA3, TestA3>();
            c.Register<ITestA4, TestA4>();
            c.Register<ITestA5, TestA5>();
            c.Register<ITestA6, TestA6>();
            c.Register<ITestA7, TestA7>();
            c.Register<ITestA8, TestA8>();
            c.Register<ITestA9, TestA9>();
            c.Register<ITestA, TestA>();

            return c;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestA>();
            }
        }
    }
}