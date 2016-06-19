using NiquIoC;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNiquIoC
{
    internal class TestCaseA : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestA0, TestA0>().AsSingleton();
            c.RegisterType<ITestA1, TestA1>().AsSingleton();
            c.RegisterType<ITestA2, TestA2>().AsSingleton();
            c.RegisterType<ITestA3, TestA3>().AsSingleton();
            c.RegisterType<ITestA4, TestA4>().AsSingleton();
            c.RegisterType<ITestA5, TestA5>().AsSingleton();
            c.RegisterType<ITestA6, TestA6>().AsSingleton();
            c.RegisterType<ITestA7, TestA7>().AsSingleton();
            c.RegisterType<ITestA8, TestA8>().AsSingleton();
            c.RegisterType<ITestA9, TestA9>().AsSingleton();
            c.RegisterType<ITestA, TestA>().AsSingleton();

            return c;
        }

        public object TransientRegister(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestA0, TestA0>();
            c.RegisterType<ITestA1, TestA1>();
            c.RegisterType<ITestA2, TestA2>();
            c.RegisterType<ITestA3, TestA3>();
            c.RegisterType<ITestA4, TestA4>();
            c.RegisterType<ITestA5, TestA5>();
            c.RegisterType<ITestA6, TestA6>();
            c.RegisterType<ITestA7, TestA7>();
            c.RegisterType<ITestA8, TestA8>();
            c.RegisterType<ITestA9, TestA9>();
            c.RegisterType<ITestA, TestA>();

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