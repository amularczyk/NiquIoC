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
                x.Export<ITestA0>().As<TestA0>().Lifestyle.SingletonPerScope();
                x.Export<ITestA0>().As<TestA0>().Lifestyle.SingletonPerScope();
                x.Export<ITestA1>().As<TestA1>().Lifestyle.SingletonPerScope();
                x.Export<ITestA2>().As<TestA2>().Lifestyle.SingletonPerScope();
                x.Export<ITestA3>().As<TestA3>().Lifestyle.SingletonPerScope();
                x.Export<ITestA4>().As<TestA4>().Lifestyle.SingletonPerScope();
                x.Export<ITestA5>().As<TestA5>().Lifestyle.SingletonPerScope();
                x.Export<ITestA6>().As<TestA6>().Lifestyle.SingletonPerScope();
                x.Export<ITestA7>().As<TestA7>().Lifestyle.SingletonPerScope();
                x.Export<ITestA8>().As<TestA8>().Lifestyle.SingletonPerScope();
                x.Export<ITestA9>().As<TestA9>().Lifestyle.SingletonPerScope();
                x.Export<ITestA>().As<TestA>().Lifestyle.SingletonPerScope();
            });

            return c;
        }
    }
}