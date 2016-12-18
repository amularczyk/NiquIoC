using NiquIoC;
using NiquIoC.Enums;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Partial
{
    public class TestCaseA : ITestCase
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

        public object PerThreadRegister(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestA0, TestA0>().AsPerThread();
            c.RegisterType<ITestA1, TestA1>().AsPerThread();
            c.RegisterType<ITestA2, TestA2>().AsPerThread();
            c.RegisterType<ITestA3, TestA3>().AsPerThread();
            c.RegisterType<ITestA4, TestA4>().AsPerThread();
            c.RegisterType<ITestA5, TestA5>().AsPerThread();
            c.RegisterType<ITestA6, TestA6>().AsPerThread();
            c.RegisterType<ITestA7, TestA7>().AsPerThread();
            c.RegisterType<ITestA8, TestA8>().AsPerThread();
            c.RegisterType<ITestA9, TestA9>().AsPerThread();
            c.RegisterType<ITestA, TestA>().AsPerThread();

            return c;
        }

        public object PerHttpContextRegister(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestA0, TestA0>().AsPerHttpContext();
            c.RegisterType<ITestA1, TestA1>().AsPerHttpContext();
            c.RegisterType<ITestA2, TestA2>().AsPerHttpContext();
            c.RegisterType<ITestA3, TestA3>().AsPerHttpContext();
            c.RegisterType<ITestA4, TestA4>().AsPerHttpContext();
            c.RegisterType<ITestA5, TestA5>().AsPerHttpContext();
            c.RegisterType<ITestA6, TestA6>().AsPerHttpContext();
            c.RegisterType<ITestA7, TestA7>().AsPerHttpContext();
            c.RegisterType<ITestA8, TestA8>().AsPerHttpContext();
            c.RegisterType<ITestA9, TestA9>().AsPerHttpContext();
            c.RegisterType<ITestA, TestA>().AsPerHttpContext();

            return c;
        }

        public object FactoryObjectRegister(object container)
        {
            var c = (Container)container;

            var testA0 = new TestA0();
            c.RegisterType<ITestA0>(() => testA0);
            var testA1 = new TestA1(testA0);
            c.RegisterType<ITestA1>(() => testA1);
            var testA2 = new TestA2(testA0, testA1);
            c.RegisterType<ITestA2>(() => testA2);
            var testA3 = new TestA3(testA0, testA1, testA2);
            c.RegisterType<ITestA3>(() => testA3);
            var testA4 = new TestA4(testA0, testA1, testA2, testA3);
            c.RegisterType<ITestA4>(() => testA4);
            var testA5 = new TestA5(testA0, testA1, testA2, testA3, testA4);
            c.RegisterType<ITestA5>(() => testA5);
            var testA6 = new TestA6(testA0, testA1, testA2, testA3, testA4, testA5);
            c.RegisterType<ITestA6>(() => testA6);
            var testA7 = new TestA7(testA0, testA1, testA2, testA3, testA4, testA5, testA6);
            c.RegisterType<ITestA7>(() => testA7);
            var testA8 = new TestA8(testA0, testA1, testA2, testA3, testA4, testA5, testA6, testA7);
            c.RegisterType<ITestA8>(() => testA8);
            var testA9 = new TestA9(testA0, testA1, testA2, testA3, testA4, testA5, testA6, testA7, testA8);
            c.RegisterType<ITestA9>(() => testA9);
            c.RegisterType<ITestA, TestA>();

            return c;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestA>(ResolveKind.PartialEmitFunction);
            }
        }
    }
}