using Microsoft.Practices.Unity;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class TestCaseA : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (UnityContainer)container;

            c.RegisterType<ITestA0, TestA0>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA1, TestA1>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA2, TestA2>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA3, TestA3>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA4, TestA4>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA5, TestA5>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA6, TestA6>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA7, TestA7>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA8, TestA8>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA9, TestA9>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA, TestA>(new ContainerControlledLifetimeManager());

            return c;
        }

        public object TransientRegister(object container)
        {
            var c = (UnityContainer)container;

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
            var c = (UnityContainer)container;

            c.RegisterType<ITestA0, TestA0>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA1, TestA1>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA2, TestA2>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA3, TestA3>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA4, TestA4>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA5, TestA5>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA6, TestA6>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA7, TestA7>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA8, TestA8>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA9, TestA9>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA, TestA>(new PerThreadLifetimeManager());

            return c;
        }

        public object PerHttpContextRegister(object container)
        {
            var c = (UnityContainer)container;

            c.RegisterType<ITestA0, TestA0>(new PerRequestLifetimeManager());
            c.RegisterType<ITestA1, TestA1>(new PerRequestLifetimeManager());
            c.RegisterType<ITestA2, TestA2>(new PerRequestLifetimeManager());
            c.RegisterType<ITestA3, TestA3>(new PerRequestLifetimeManager());
            c.RegisterType<ITestA4, TestA4>(new PerRequestLifetimeManager());
            c.RegisterType<ITestA5, TestA5>(new PerRequestLifetimeManager());
            c.RegisterType<ITestA6, TestA6>(new PerRequestLifetimeManager());
            c.RegisterType<ITestA7, TestA7>(new PerRequestLifetimeManager());
            c.RegisterType<ITestA8, TestA8>(new PerRequestLifetimeManager());
            c.RegisterType<ITestA9, TestA9>(new PerRequestLifetimeManager());
            c.RegisterType<ITestA, TestA>(new PerRequestLifetimeManager());

            return c;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (UnityContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestA>();
            }
        }
    }
}