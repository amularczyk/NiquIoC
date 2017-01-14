using LightInject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class SingletonTestCaseA : TestCaseA
    {
        public override object Register(object container)
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
    }
}