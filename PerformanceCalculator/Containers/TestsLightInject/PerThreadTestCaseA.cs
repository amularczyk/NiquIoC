using LightInject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class PerThreadTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestA0, TestA0>(new PerScopeLifetime());
            c.Register<ITestA1, TestA1>(new PerScopeLifetime());
            c.Register<ITestA2, TestA2>(new PerScopeLifetime());
            c.Register<ITestA3, TestA3>(new PerScopeLifetime());
            c.Register<ITestA4, TestA4>(new PerScopeLifetime());
            c.Register<ITestA5, TestA5>(new PerScopeLifetime());
            c.Register<ITestA6, TestA6>(new PerScopeLifetime());
            c.Register<ITestA7, TestA7>(new PerScopeLifetime());
            c.Register<ITestA8, TestA8>(new PerScopeLifetime());
            c.Register<ITestA9, TestA9>(new PerScopeLifetime());
            c.Register<ITestA, TestA>(new PerScopeLifetime());

            return c;
        }
    }
}