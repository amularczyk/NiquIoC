using SimpleInjector;
using PerformanceCalculator.TestCases;
using SimpleInjector.Extensions.LifetimeScoping;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class PerThreadTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();

            c.Register<ITestA0, TestA0>(Lifestyle.Scoped);
            c.Register<ITestA1, TestA1>(Lifestyle.Scoped);
            c.Register<ITestA2, TestA2>(Lifestyle.Scoped);
            c.Register<ITestA3, TestA3>(Lifestyle.Scoped);
            c.Register<ITestA4, TestA4>(Lifestyle.Scoped);
            c.Register<ITestA5, TestA5>(Lifestyle.Scoped);
            c.Register<ITestA6, TestA6>(Lifestyle.Scoped);
            c.Register<ITestA7, TestA7>(Lifestyle.Scoped);
            c.Register<ITestA8, TestA8>(Lifestyle.Scoped);
            c.Register<ITestA9, TestA9>(Lifestyle.Scoped);
            c.Register<ITestA, TestA>(Lifestyle.Scoped);

            return c;
        }
    }
}