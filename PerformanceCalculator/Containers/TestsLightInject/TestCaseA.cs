using LightInject;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class TestCaseA : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestA0, TestA0>(new PerContainerLifetime());
            c.Register<ITestA1, TestA1>(new PerContainerLifetime());
            c.Register<ITestA2, TestA2>(new PerContainerLifetime());
            c.Register<ITestA3, TestA3>(new PerContainerLifetime());
            c.Register<ITestA4, TestA4>(new PerContainerLifetime());
            c.Register<ITestA5, TestA5>(new PerContainerLifetime());
            c.Register<ITestA6, TestA6>(new PerContainerLifetime());
            c.Register<ITestA7, TestA7>(new PerContainerLifetime());
            c.Register<ITestA8, TestA8>(new PerContainerLifetime());
            c.Register<ITestA9, TestA9>(new PerContainerLifetime());
            c.Register<ITestA, TestA>(new PerContainerLifetime());

            return c;
        }
        
        public object TransientRegister(object container)
        {
            var c = (ServiceContainer)container;

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

        public object PerThreadRegister(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestA0, TestA0>(new PerThreadLifetime());
            c.Register<ITestA1, TestA1>(new PerThreadLifetime());
            c.Register<ITestA2, TestA2>(new PerThreadLifetime());
            c.Register<ITestA3, TestA3>(new PerThreadLifetime());
            c.Register<ITestA4, TestA4>(new PerThreadLifetime());
            c.Register<ITestA5, TestA5>(new PerThreadLifetime());
            c.Register<ITestA6, TestA6>(new PerThreadLifetime());
            c.Register<ITestA7, TestA7>(new PerThreadLifetime());
            c.Register<ITestA8, TestA8>(new PerThreadLifetime());
            c.Register<ITestA9, TestA9>(new PerThreadLifetime());
            c.Register<ITestA, TestA>(new PerThreadLifetime());

            return c;
        }

        public object PerHttpContextRegister(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestA0, TestA0>(new PerRequestLifeTime());
            c.Register<ITestA1, TestA1>(new PerRequestLifeTime());
            c.Register<ITestA2, TestA2>(new PerRequestLifeTime());
            c.Register<ITestA3, TestA3>(new PerRequestLifeTime());
            c.Register<ITestA4, TestA4>(new PerRequestLifeTime());
            c.Register<ITestA5, TestA5>(new PerRequestLifeTime());
            c.Register<ITestA6, TestA6>(new PerRequestLifeTime());
            c.Register<ITestA7, TestA7>(new PerRequestLifeTime());
            c.Register<ITestA8, TestA8>(new PerRequestLifeTime());
            c.Register<ITestA9, TestA9>(new PerRequestLifeTime());
            c.Register<ITestA, TestA>(new PerRequestLifeTime());

            return c;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (ServiceContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<ITestA>();
            }
        }
    }
}