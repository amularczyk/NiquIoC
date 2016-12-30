using NiquIoC;
using NiquIoC.Enums;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Partial
{
    public class TestCaseC : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestCa0, TestCa0>().AsSingleton();
            c.RegisterType<ITestCa1, TestCa1>().AsSingleton();
            c.RegisterType<ITestCa2, TestCa2>().AsSingleton();
            c.RegisterType<ITestCa3, TestCa3>().AsSingleton();
            c.RegisterType<ITestCa4, TestCa4>().AsSingleton();
            c.RegisterType<ITestCa5, TestCa5>().AsSingleton();
            c.RegisterType<ITestCa6, TestCa6>().AsSingleton();
            c.RegisterType<ITestCa7, TestCa7>().AsSingleton();
            c.RegisterType<ITestCa8, TestCa8>().AsSingleton();
            c.RegisterType<ITestCa9, TestCa9>().AsSingleton();
            c.RegisterType<ITestCa10, TestCa10>().AsSingleton();

            c.RegisterType<ITestCb0, TestCb0>().AsSingleton();
            c.RegisterType<ITestCb1, TestCb1>().AsSingleton();
            c.RegisterType<ITestCb2, TestCb2>().AsSingleton();
            c.RegisterType<ITestCb3, TestCb3>().AsSingleton();
            c.RegisterType<ITestCb4, TestCb4>().AsSingleton();
            c.RegisterType<ITestCb5, TestCb5>().AsSingleton();
            c.RegisterType<ITestCb6, TestCb6>().AsSingleton();
            c.RegisterType<ITestCb7, TestCb7>().AsSingleton();
            c.RegisterType<ITestCb8, TestCb8>().AsSingleton();
            c.RegisterType<ITestCb9, TestCb9>().AsSingleton();
            c.RegisterType<ITestCb10, TestCb10>().AsSingleton();

            c.RegisterType<ITestCc0, TestCc0>().AsSingleton();
            c.RegisterType<ITestCc1, TestCc1>().AsSingleton();
            c.RegisterType<ITestCc2, TestCc2>().AsSingleton();
            c.RegisterType<ITestCc3, TestCc3>().AsSingleton();
            c.RegisterType<ITestCc4, TestCc4>().AsSingleton();
            c.RegisterType<ITestCc5, TestCc5>().AsSingleton();
            c.RegisterType<ITestCc6, TestCc6>().AsSingleton();
            c.RegisterType<ITestCc7, TestCc7>().AsSingleton();
            c.RegisterType<ITestCc8, TestCc8>().AsSingleton();
            c.RegisterType<ITestCc9, TestCc9>().AsSingleton();
            c.RegisterType<ITestCc10, TestCc10>().AsSingleton();

            c.RegisterType<ITestC, TestC>().AsSingleton();

            return c;
        }

        public object TransientRegister(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestCa0, TestCa0>();
            c.RegisterType<ITestCa1, TestCa1>();
            c.RegisterType<ITestCa2, TestCa2>();
            c.RegisterType<ITestCa3, TestCa3>();
            c.RegisterType<ITestCa4, TestCa4>();
            c.RegisterType<ITestCa5, TestCa5>();
            c.RegisterType<ITestCa6, TestCa6>();
            c.RegisterType<ITestCa7, TestCa7>();
            c.RegisterType<ITestCa8, TestCa8>();
            c.RegisterType<ITestCa9, TestCa9>();
            c.RegisterType<ITestCa10, TestCa10>();

            c.RegisterType<ITestCb0, TestCb0>();
            c.RegisterType<ITestCb1, TestCb1>();
            c.RegisterType<ITestCb2, TestCb2>();
            c.RegisterType<ITestCb3, TestCb3>();
            c.RegisterType<ITestCb4, TestCb4>();
            c.RegisterType<ITestCb5, TestCb5>();
            c.RegisterType<ITestCb6, TestCb6>();
            c.RegisterType<ITestCb7, TestCb7>();
            c.RegisterType<ITestCb8, TestCb8>();
            c.RegisterType<ITestCb9, TestCb9>();
            c.RegisterType<ITestCb10, TestCb10>();

            c.RegisterType<ITestCc0, TestCc0>();
            c.RegisterType<ITestCc1, TestCc1>();
            c.RegisterType<ITestCc2, TestCc2>();
            c.RegisterType<ITestCc3, TestCc3>();
            c.RegisterType<ITestCc4, TestCc4>();
            c.RegisterType<ITestCc5, TestCc5>();
            c.RegisterType<ITestCc6, TestCc6>();
            c.RegisterType<ITestCc7, TestCc7>();
            c.RegisterType<ITestCc8, TestCc8>();
            c.RegisterType<ITestCc9, TestCc9>();
            c.RegisterType<ITestCc10, TestCc10>();

            c.RegisterType<ITestC, TestC>();

            return c;
        }

        public object PerThreadRegister(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestCa0, TestCa0>().AsPerThread();
            c.RegisterType<ITestCa1, TestCa1>().AsPerThread();
            c.RegisterType<ITestCa2, TestCa2>().AsPerThread();
            c.RegisterType<ITestCa3, TestCa3>().AsPerThread();
            c.RegisterType<ITestCa4, TestCa4>().AsPerThread();
            c.RegisterType<ITestCa5, TestCa5>().AsPerThread();
            c.RegisterType<ITestCa6, TestCa6>().AsPerThread();
            c.RegisterType<ITestCa7, TestCa7>().AsPerThread();
            c.RegisterType<ITestCa8, TestCa8>().AsPerThread();
            c.RegisterType<ITestCa9, TestCa9>().AsPerThread();
            c.RegisterType<ITestCa10, TestCa10>().AsPerThread();

            c.RegisterType<ITestCb0, TestCb0>().AsPerThread();
            c.RegisterType<ITestCb1, TestCb1>().AsPerThread();
            c.RegisterType<ITestCb2, TestCb2>().AsPerThread();
            c.RegisterType<ITestCb3, TestCb3>().AsPerThread();
            c.RegisterType<ITestCb4, TestCb4>().AsPerThread();
            c.RegisterType<ITestCb5, TestCb5>().AsPerThread();
            c.RegisterType<ITestCb6, TestCb6>().AsPerThread();
            c.RegisterType<ITestCb7, TestCb7>().AsPerThread();
            c.RegisterType<ITestCb8, TestCb8>().AsPerThread();
            c.RegisterType<ITestCb9, TestCb9>().AsPerThread();
            c.RegisterType<ITestCb10, TestCb10>().AsPerThread();

            c.RegisterType<ITestCc0, TestCc0>().AsPerThread();
            c.RegisterType<ITestCc1, TestCc1>().AsPerThread();
            c.RegisterType<ITestCc2, TestCc2>().AsPerThread();
            c.RegisterType<ITestCc3, TestCc3>().AsPerThread();
            c.RegisterType<ITestCc4, TestCc4>().AsPerThread();
            c.RegisterType<ITestCc5, TestCc5>().AsPerThread();
            c.RegisterType<ITestCc6, TestCc6>().AsPerThread();
            c.RegisterType<ITestCc7, TestCc7>().AsPerThread();
            c.RegisterType<ITestCc8, TestCc8>().AsPerThread();
            c.RegisterType<ITestCc9, TestCc9>().AsPerThread();
            c.RegisterType<ITestCc10, TestCc10>().AsPerThread();

            c.RegisterType<ITestC, TestC>().AsPerThread();

            return c;
        }

        public object PerHttpContextRegister(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestCa0, TestCa0>().AsPerHttpContext();
            c.RegisterType<ITestCa1, TestCa1>().AsPerHttpContext();
            c.RegisterType<ITestCa2, TestCa2>().AsPerHttpContext();
            c.RegisterType<ITestCa3, TestCa3>().AsPerHttpContext();
            c.RegisterType<ITestCa4, TestCa4>().AsPerHttpContext();
            c.RegisterType<ITestCa5, TestCa5>().AsPerHttpContext();
            c.RegisterType<ITestCa6, TestCa6>().AsPerHttpContext();
            c.RegisterType<ITestCa7, TestCa7>().AsPerHttpContext();
            c.RegisterType<ITestCa8, TestCa8>().AsPerHttpContext();
            c.RegisterType<ITestCa9, TestCa9>().AsPerHttpContext();
            c.RegisterType<ITestCa10, TestCa10>().AsPerHttpContext();

            c.RegisterType<ITestCb0, TestCb0>().AsPerHttpContext();
            c.RegisterType<ITestCb1, TestCb1>().AsPerHttpContext();
            c.RegisterType<ITestCb2, TestCb2>().AsPerHttpContext();
            c.RegisterType<ITestCb3, TestCb3>().AsPerHttpContext();
            c.RegisterType<ITestCb4, TestCb4>().AsPerHttpContext();
            c.RegisterType<ITestCb5, TestCb5>().AsPerHttpContext();
            c.RegisterType<ITestCb6, TestCb6>().AsPerHttpContext();
            c.RegisterType<ITestCb7, TestCb7>().AsPerHttpContext();
            c.RegisterType<ITestCb8, TestCb8>().AsPerHttpContext();
            c.RegisterType<ITestCb9, TestCb9>().AsPerHttpContext();
            c.RegisterType<ITestCb10, TestCb10>().AsPerHttpContext();

            c.RegisterType<ITestCc0, TestCc0>().AsPerHttpContext();
            c.RegisterType<ITestCc1, TestCc1>().AsPerHttpContext();
            c.RegisterType<ITestCc2, TestCc2>().AsPerHttpContext();
            c.RegisterType<ITestCc3, TestCc3>().AsPerHttpContext();
            c.RegisterType<ITestCc4, TestCc4>().AsPerHttpContext();
            c.RegisterType<ITestCc5, TestCc5>().AsPerHttpContext();
            c.RegisterType<ITestCc6, TestCc6>().AsPerHttpContext();
            c.RegisterType<ITestCc7, TestCc7>().AsPerHttpContext();
            c.RegisterType<ITestCc8, TestCc8>().AsPerHttpContext();
            c.RegisterType<ITestCc9, TestCc9>().AsPerHttpContext();
            c.RegisterType<ITestCc10, TestCc10>().AsPerHttpContext();

            c.RegisterType<ITestC, TestC>().AsPerHttpContext();

            return c;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestC>(ResolveKind.PartialEmitFunction);
            }
        }
    }
}