using LightInject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class SingletonTestCaseC : TestCaseC
    {
        public override object Register(object container)
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
    }
}