using LightInject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class PerThreadTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<ITestCa0, TestCa0>(new PerScopeLifetime());
            c.Register<ITestCa1, TestCa1>(new PerScopeLifetime());
            c.Register<ITestCa2, TestCa2>(new PerScopeLifetime());
            c.Register<ITestCa3, TestCa3>(new PerScopeLifetime());
            c.Register<ITestCa4, TestCa4>(new PerScopeLifetime());
            c.Register<ITestCa5, TestCa5>(new PerScopeLifetime());
            c.Register<ITestCa6, TestCa6>(new PerScopeLifetime());
            c.Register<ITestCa7, TestCa7>(new PerScopeLifetime());
            c.Register<ITestCa8, TestCa8>(new PerScopeLifetime());
            c.Register<ITestCa9, TestCa9>(new PerScopeLifetime());
            c.Register<ITestCa10, TestCa10>(new PerScopeLifetime());

            c.Register<ITestCb0, TestCb0>(new PerScopeLifetime());
            c.Register<ITestCb1, TestCb1>(new PerScopeLifetime());
            c.Register<ITestCb2, TestCb2>(new PerScopeLifetime());
            c.Register<ITestCb3, TestCb3>(new PerScopeLifetime());
            c.Register<ITestCb4, TestCb4>(new PerScopeLifetime());
            c.Register<ITestCb5, TestCb5>(new PerScopeLifetime());
            c.Register<ITestCb6, TestCb6>(new PerScopeLifetime());
            c.Register<ITestCb7, TestCb7>(new PerScopeLifetime());
            c.Register<ITestCb8, TestCb8>(new PerScopeLifetime());
            c.Register<ITestCb9, TestCb9>(new PerScopeLifetime());
            c.Register<ITestCb10, TestCb10>(new PerScopeLifetime());

            c.Register<ITestCc0, TestCc0>(new PerScopeLifetime());
            c.Register<ITestCc1, TestCc1>(new PerScopeLifetime());
            c.Register<ITestCc2, TestCc2>(new PerScopeLifetime());
            c.Register<ITestCc3, TestCc3>(new PerScopeLifetime());
            c.Register<ITestCc4, TestCc4>(new PerScopeLifetime());
            c.Register<ITestCc5, TestCc5>(new PerScopeLifetime());
            c.Register<ITestCc6, TestCc6>(new PerScopeLifetime());
            c.Register<ITestCc7, TestCc7>(new PerScopeLifetime());
            c.Register<ITestCc8, TestCc8>(new PerScopeLifetime());
            c.Register<ITestCc9, TestCc9>(new PerScopeLifetime());
            c.Register<ITestCc10, TestCc10>(new PerScopeLifetime());

            c.Register<ITestC, TestC>(new PerScopeLifetime());

            return c;
        }
    }
}