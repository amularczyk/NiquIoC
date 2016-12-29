using LightInject;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class TestCaseC : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestCa0, TestCa0>(new PerContainerLifetime());
            c.Register<ITestCa1, TestCa1>(new PerContainerLifetime());
            c.Register<ITestCa2, TestCa2>(new PerContainerLifetime());
            c.Register<ITestCa3, TestCa3>(new PerContainerLifetime());
            c.Register<ITestCa4, TestCa4>(new PerContainerLifetime());
            c.Register<ITestCa5, TestCa5>(new PerContainerLifetime());
            c.Register<ITestCa6, TestCa6>(new PerContainerLifetime());
            c.Register<ITestCa7, TestCa7>(new PerContainerLifetime());
            c.Register<ITestCa8, TestCa8>(new PerContainerLifetime());
            c.Register<ITestCa9, TestCa9>(new PerContainerLifetime());
            c.Register<ITestCa10, TestCa10>(new PerContainerLifetime());

            c.Register<ITestCb0, TestCb0>(new PerContainerLifetime());
            c.Register<ITestCb1, TestCb1>(new PerContainerLifetime());
            c.Register<ITestCb2, TestCb2>(new PerContainerLifetime());
            c.Register<ITestCb3, TestCb3>(new PerContainerLifetime());
            c.Register<ITestCb4, TestCb4>(new PerContainerLifetime());
            c.Register<ITestCb5, TestCb5>(new PerContainerLifetime());
            c.Register<ITestCb6, TestCb6>(new PerContainerLifetime());
            c.Register<ITestCb7, TestCb7>(new PerContainerLifetime());
            c.Register<ITestCb8, TestCb8>(new PerContainerLifetime());
            c.Register<ITestCb9, TestCb9>(new PerContainerLifetime());
            c.Register<ITestCb10, TestCb10>(new PerContainerLifetime());

            c.Register<ITestCc0, TestCc0>(new PerContainerLifetime());
            c.Register<ITestCc1, TestCc1>(new PerContainerLifetime());
            c.Register<ITestCc2, TestCc2>(new PerContainerLifetime());
            c.Register<ITestCc3, TestCc3>(new PerContainerLifetime());
            c.Register<ITestCc4, TestCc4>(new PerContainerLifetime());
            c.Register<ITestCc5, TestCc5>(new PerContainerLifetime());
            c.Register<ITestCc6, TestCc6>(new PerContainerLifetime());
            c.Register<ITestCc7, TestCc7>(new PerContainerLifetime());
            c.Register<ITestCc8, TestCc8>(new PerContainerLifetime());
            c.Register<ITestCc9, TestCc9>(new PerContainerLifetime());
            c.Register<ITestCc10, TestCc10>(new PerContainerLifetime());

            c.Register<ITestC, TestC>(new PerContainerLifetime());

            return c;
        }

        public object TransientRegister(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestCa0, TestCa0>();
            c.Register<ITestCa1, TestCa1>();
            c.Register<ITestCa2, TestCa2>();
            c.Register<ITestCa3, TestCa3>();
            c.Register<ITestCa4, TestCa4>();
            c.Register<ITestCa5, TestCa5>();
            c.Register<ITestCa6, TestCa6>();
            c.Register<ITestCa7, TestCa7>();
            c.Register<ITestCa8, TestCa8>();
            c.Register<ITestCa9, TestCa9>();
            c.Register<ITestCa10, TestCa10>();

            c.Register<ITestCb0, TestCb0>();
            c.Register<ITestCb1, TestCb1>();
            c.Register<ITestCb2, TestCb2>();
            c.Register<ITestCb3, TestCb3>();
            c.Register<ITestCb4, TestCb4>();
            c.Register<ITestCb5, TestCb5>();
            c.Register<ITestCb6, TestCb6>();
            c.Register<ITestCb7, TestCb7>();
            c.Register<ITestCb8, TestCb8>();
            c.Register<ITestCb9, TestCb9>();
            c.Register<ITestCb10, TestCb10>();

            c.Register<ITestCc0, TestCc0>();
            c.Register<ITestCc1, TestCc1>();
            c.Register<ITestCc2, TestCc2>();
            c.Register<ITestCc3, TestCc3>();
            c.Register<ITestCc4, TestCc4>();
            c.Register<ITestCc5, TestCc5>();
            c.Register<ITestCc6, TestCc6>();
            c.Register<ITestCc7, TestCc7>();
            c.Register<ITestCc8, TestCc8>();
            c.Register<ITestCc9, TestCc9>();
            c.Register<ITestCc10, TestCc10>();

            c.Register<ITestC, TestC>();

            return c;
        }

        public object PerThreadRegister(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestCa0, TestCa0>(new PerThreadLifetime());
            c.Register<ITestCa1, TestCa1>(new PerThreadLifetime());
            c.Register<ITestCa2, TestCa2>(new PerThreadLifetime());
            c.Register<ITestCa3, TestCa3>(new PerThreadLifetime());
            c.Register<ITestCa4, TestCa4>(new PerThreadLifetime());
            c.Register<ITestCa5, TestCa5>(new PerThreadLifetime());
            c.Register<ITestCa6, TestCa6>(new PerThreadLifetime());
            c.Register<ITestCa7, TestCa7>(new PerThreadLifetime());
            c.Register<ITestCa8, TestCa8>(new PerThreadLifetime());
            c.Register<ITestCa9, TestCa9>(new PerThreadLifetime());
            c.Register<ITestCa10, TestCa10>(new PerThreadLifetime());

            c.Register<ITestCb0, TestCb0>(new PerThreadLifetime());
            c.Register<ITestCb1, TestCb1>(new PerThreadLifetime());
            c.Register<ITestCb2, TestCb2>(new PerThreadLifetime());
            c.Register<ITestCb3, TestCb3>(new PerThreadLifetime());
            c.Register<ITestCb4, TestCb4>(new PerThreadLifetime());
            c.Register<ITestCb5, TestCb5>(new PerThreadLifetime());
            c.Register<ITestCb6, TestCb6>(new PerThreadLifetime());
            c.Register<ITestCb7, TestCb7>(new PerThreadLifetime());
            c.Register<ITestCb8, TestCb8>(new PerThreadLifetime());
            c.Register<ITestCb9, TestCb9>(new PerThreadLifetime());
            c.Register<ITestCb10, TestCb10>(new PerThreadLifetime());

            c.Register<ITestCc0, TestCc0>(new PerThreadLifetime());
            c.Register<ITestCc1, TestCc1>(new PerThreadLifetime());
            c.Register<ITestCc2, TestCc2>(new PerThreadLifetime());
            c.Register<ITestCc3, TestCc3>(new PerThreadLifetime());
            c.Register<ITestCc4, TestCc4>(new PerThreadLifetime());
            c.Register<ITestCc5, TestCc5>(new PerThreadLifetime());
            c.Register<ITestCc6, TestCc6>(new PerThreadLifetime());
            c.Register<ITestCc7, TestCc7>(new PerThreadLifetime());
            c.Register<ITestCc8, TestCc8>(new PerThreadLifetime());
            c.Register<ITestCc9, TestCc9>(new PerThreadLifetime());
            c.Register<ITestCc10, TestCc10>(new PerThreadLifetime());

            c.Register<ITestC, TestC>(new PerThreadLifetime());

            return c;
        }

        public object PerHttpContextRegister(object container)
        {
            throw new System.NotImplementedException();
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (ServiceContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<ITestC>();
            }
        }
    }
}