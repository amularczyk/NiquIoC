using SimpleInjector;
using PerformanceCalculator.TestCases;
using SimpleInjector.Extensions.LifetimeScoping;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class PerThreadTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();

            c.Register<ITestCa0, TestCa0>(Lifestyle.Scoped);
            c.Register<ITestCa1, TestCa1>(Lifestyle.Scoped);
            c.Register<ITestCa2, TestCa2>(Lifestyle.Scoped);
            c.Register<ITestCa3, TestCa3>(Lifestyle.Scoped);
            c.Register<ITestCa4, TestCa4>(Lifestyle.Scoped);
            c.Register<ITestCa5, TestCa5>(Lifestyle.Scoped);
            c.Register<ITestCa6, TestCa6>(Lifestyle.Scoped);
            c.Register<ITestCa7, TestCa7>(Lifestyle.Scoped);
            c.Register<ITestCa8, TestCa8>(Lifestyle.Scoped);
            c.Register<ITestCa9, TestCa9>(Lifestyle.Scoped);
            c.Register<ITestCa10, TestCa10>(Lifestyle.Scoped);

            c.Register<ITestCb0, TestCb0>(Lifestyle.Scoped);
            c.Register<ITestCb1, TestCb1>(Lifestyle.Scoped);
            c.Register<ITestCb2, TestCb2>(Lifestyle.Scoped);
            c.Register<ITestCb3, TestCb3>(Lifestyle.Scoped);
            c.Register<ITestCb4, TestCb4>(Lifestyle.Scoped);
            c.Register<ITestCb5, TestCb5>(Lifestyle.Scoped);
            c.Register<ITestCb6, TestCb6>(Lifestyle.Scoped);
            c.Register<ITestCb7, TestCb7>(Lifestyle.Scoped);
            c.Register<ITestCb8, TestCb8>(Lifestyle.Scoped);
            c.Register<ITestCb9, TestCb9>(Lifestyle.Scoped);
            c.Register<ITestCb10, TestCb10>(Lifestyle.Scoped);

            c.Register<ITestCc0, TestCc0>(Lifestyle.Scoped);
            c.Register<ITestCc1, TestCc1>(Lifestyle.Scoped);
            c.Register<ITestCc2, TestCc2>(Lifestyle.Scoped);
            c.Register<ITestCc3, TestCc3>(Lifestyle.Scoped);
            c.Register<ITestCc4, TestCc4>(Lifestyle.Scoped);
            c.Register<ITestCc5, TestCc5>(Lifestyle.Scoped);
            c.Register<ITestCc6, TestCc6>(Lifestyle.Scoped);
            c.Register<ITestCc7, TestCc7>(Lifestyle.Scoped);
            c.Register<ITestCc8, TestCc8>(Lifestyle.Scoped);
            c.Register<ITestCc9, TestCc9>(Lifestyle.Scoped);
            c.Register<ITestCc10, TestCc10>(Lifestyle.Scoped);

            c.Register<ITestC, TestC>(Lifestyle.Scoped);

            return c;
        }
    }
}