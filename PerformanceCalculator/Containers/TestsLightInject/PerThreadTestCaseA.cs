using LightInject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class PerThreadTestCaseA : TestCaseA
    {
        public override object Register(object container)
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
    }
}