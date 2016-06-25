using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using SimpleInjector;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class TestCaseA : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (Container)container;

            c.Register<ITestA0, TestA0>(Lifestyle.Singleton);
            c.Register<ITestA1, TestA1>(Lifestyle.Singleton);
            c.Register<ITestA2, TestA2>(Lifestyle.Singleton);
            c.Register<ITestA3, TestA3>(Lifestyle.Singleton);
            c.Register<ITestA4, TestA4>(Lifestyle.Singleton);
            c.Register<ITestA5, TestA5>(Lifestyle.Singleton);
            c.Register<ITestA6, TestA6>(Lifestyle.Singleton);
            c.Register<ITestA7, TestA7>(Lifestyle.Singleton);
            c.Register<ITestA8, TestA8>(Lifestyle.Singleton);
            c.Register<ITestA9, TestA9>(Lifestyle.Singleton);
            c.Register<ITestA, TestA>(Lifestyle.Singleton);

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
                c.GetInstance<ITestA>();
            }
        }
    }
}