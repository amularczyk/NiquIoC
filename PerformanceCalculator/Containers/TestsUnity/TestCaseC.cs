using Microsoft.Practices.Unity;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class TestCaseC : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (UnityContainer)container;

            c.RegisterType<ITestCa0, TestCa0>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa1, TestCa1>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa2, TestCa2>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa3, TestCa3>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa4, TestCa4>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa5, TestCa5>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa6, TestCa6>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa7, TestCa7>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa8, TestCa8>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa9, TestCa9>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa10, TestCa10>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestCb0, TestCb0>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb1, TestCb1>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb2, TestCb2>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb3, TestCb3>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb4, TestCb4>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb5, TestCb5>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb6, TestCb6>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb7, TestCb7>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb8, TestCb8>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb9, TestCb9>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb10, TestCb10>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestCc0, TestCc0>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc1, TestCc1>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc2, TestCc2>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc3, TestCc3>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc4, TestCc4>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc5, TestCc5>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc6, TestCc6>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc7, TestCc7>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc8, TestCc8>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc9, TestCc9>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc10, TestCc10>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestC, TestC>(new ContainerControlledLifetimeManager());

            return c;
        }

        public object TransientRegister(object container)
        {
            var c = (UnityContainer)container;

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
        
        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (UnityContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestC>();
            }
        }
    }
}