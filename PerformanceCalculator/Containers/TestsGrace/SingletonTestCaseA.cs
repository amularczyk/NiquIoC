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
                x.Export<TestA0>().As<ITestA0>().Lifestyle.Singleton();
                x.Export<TestA0>().As<ITestA0>().Lifestyle.Singleton();
                x.Export<TestA1>().As<ITestA1>().Lifestyle.Singleton();
                x.Export<TestA2>().As<ITestA2>().Lifestyle.Singleton();
                x.Export<TestA3>().As<ITestA3>().Lifestyle.Singleton();
                x.Export<TestA4>().As<ITestA4>().Lifestyle.Singleton();
                x.Export<TestA5>().As<ITestA5>().Lifestyle.Singleton();
                x.Export<TestA6>().As<ITestA6>().Lifestyle.Singleton();
                x.Export<TestA7>().As<ITestA7>().Lifestyle.Singleton();
                x.Export<TestA8>().As<ITestA8>().Lifestyle.Singleton();
                x.Export<TestA9>().As<ITestA9>().Lifestyle.Singleton();
                x.Export<TestA>().As<ITestA>().Lifestyle.Singleton();
            });

            return c;
        }
    }
}