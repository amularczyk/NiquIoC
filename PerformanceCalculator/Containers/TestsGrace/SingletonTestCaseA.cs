using Grace.DependencyInjection;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class SingletonTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (DependencyInjectionContainer)container;

            c.Configure(x =>
            {
                x.Export<ITestA0>().As<TestA0>().Lifestyle.Singleton();
                x.Export<ITestA0>().As<TestA0>().Lifestyle.Singleton();
                x.Export<ITestA1>().As<TestA1>().Lifestyle.Singleton();
                x.Export<ITestA2>().As<TestA2>().Lifestyle.Singleton();
                x.Export<ITestA3>().As<TestA3>().Lifestyle.Singleton();
                x.Export<ITestA4>().As<TestA4>().Lifestyle.Singleton();
                x.Export<ITestA5>().As<TestA5>().Lifestyle.Singleton();
                x.Export<ITestA6>().As<TestA6>().Lifestyle.Singleton();
                x.Export<ITestA7>().As<TestA7>().Lifestyle.Singleton();
                x.Export<ITestA8>().As<TestA8>().Lifestyle.Singleton();
                x.Export<ITestA9>().As<TestA9>().Lifestyle.Singleton();
                x.Export<ITestA>().As<TestA>().Lifestyle.Singleton();
            });

            return c;
        }
    }
}