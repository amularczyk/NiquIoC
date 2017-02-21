using Grace.DependencyInjection;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class PerThreadTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (DependencyInjectionContainer)container;

            c.Configure(x =>
            {
                x.Export<TestA0>().As<ITestA0>().Lifestyle.SingletonPerScope();
                x.Export<TestA0>().As<ITestA0>().Lifestyle.SingletonPerScope();
                x.Export<TestA1>().As<ITestA1>().Lifestyle.SingletonPerScope();
                x.Export<TestA2>().As<ITestA2>().Lifestyle.SingletonPerScope();
                x.Export<TestA3>().As<ITestA3>().Lifestyle.SingletonPerScope();
                x.Export<TestA4>().As<ITestA4>().Lifestyle.SingletonPerScope();
                x.Export<TestA5>().As<ITestA5>().Lifestyle.SingletonPerScope();
                x.Export<TestA6>().As<ITestA6>().Lifestyle.SingletonPerScope();
                x.Export<TestA7>().As<ITestA7>().Lifestyle.SingletonPerScope();
                x.Export<TestA8>().As<ITestA8>().Lifestyle.SingletonPerScope();
                x.Export<TestA9>().As<ITestA9>().Lifestyle.SingletonPerScope();
                x.Export<TestA>().As<ITestA>().Lifestyle.SingletonPerScope();
            });

            return c;
        }
    }
}