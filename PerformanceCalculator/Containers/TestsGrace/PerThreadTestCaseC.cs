using Grace.DependencyInjection;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class PerThreadTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (DependencyInjectionContainer)container;

            c.Configure(x =>
            {
                x.Export<TestCa0>().As<ITestCa0>().Lifestyle.SingletonPerScope();
                x.Export<TestCa0>().As<ITestCa0>().Lifestyle.SingletonPerScope();
                x.Export<TestCa1>().As<ITestCa1>().Lifestyle.SingletonPerScope();
                x.Export<TestCa2>().As<ITestCa2>().Lifestyle.SingletonPerScope();
                x.Export<TestCa3>().As<ITestCa3>().Lifestyle.SingletonPerScope();
                x.Export<TestCa4>().As<ITestCa4>().Lifestyle.SingletonPerScope();
                x.Export<TestCa5>().As<ITestCa5>().Lifestyle.SingletonPerScope();
                x.Export<TestCa6>().As<ITestCa6>().Lifestyle.SingletonPerScope();
                x.Export<TestCa7>().As<ITestCa7>().Lifestyle.SingletonPerScope();
                x.Export<TestCa8>().As<ITestCa8>().Lifestyle.SingletonPerScope();
                x.Export<TestCa9>().As<ITestCa9>().Lifestyle.SingletonPerScope();
                x.Export<TestCa10>().As<ITestCa10>().Lifestyle.SingletonPerScope();

                x.Export<TestCb0>().As<ITestCb0>().Lifestyle.SingletonPerScope();
                x.Export<TestCb0>().As<ITestCb0>().Lifestyle.SingletonPerScope();
                x.Export<TestCb1>().As<ITestCb1>().Lifestyle.SingletonPerScope();
                x.Export<TestCb2>().As<ITestCb2>().Lifestyle.SingletonPerScope();
                x.Export<TestCb3>().As<ITestCb3>().Lifestyle.SingletonPerScope();
                x.Export<TestCb4>().As<ITestCb4>().Lifestyle.SingletonPerScope();
                x.Export<TestCb5>().As<ITestCb5>().Lifestyle.SingletonPerScope();
                x.Export<TestCb6>().As<ITestCb6>().Lifestyle.SingletonPerScope();
                x.Export<TestCb7>().As<ITestCb7>().Lifestyle.SingletonPerScope();
                x.Export<TestCb8>().As<ITestCb8>().Lifestyle.SingletonPerScope();
                x.Export<TestCb9>().As<ITestCb9>().Lifestyle.SingletonPerScope();
                x.Export<TestCb10>().As<ITestCb10>().Lifestyle.SingletonPerScope();

                x.Export<TestCc0>().As<ITestCc0>().Lifestyle.SingletonPerScope();
                x.Export<TestCc0>().As<ITestCc0>().Lifestyle.SingletonPerScope();
                x.Export<TestCc1>().As<ITestCc1>().Lifestyle.SingletonPerScope();
                x.Export<TestCc2>().As<ITestCc2>().Lifestyle.SingletonPerScope();
                x.Export<TestCc3>().As<ITestCc3>().Lifestyle.SingletonPerScope();
                x.Export<TestCc4>().As<ITestCc4>().Lifestyle.SingletonPerScope();
                x.Export<TestCc5>().As<ITestCc5>().Lifestyle.SingletonPerScope();
                x.Export<TestCc6>().As<ITestCc6>().Lifestyle.SingletonPerScope();
                x.Export<TestCc7>().As<ITestCc7>().Lifestyle.SingletonPerScope();
                x.Export<TestCc8>().As<ITestCc8>().Lifestyle.SingletonPerScope();
                x.Export<TestCc9>().As<ITestCc9>().Lifestyle.SingletonPerScope();
                x.Export<TestCc10>().As<ITestCc10>().Lifestyle.SingletonPerScope();

                x.Export<TestC>().As<ITestC>().Lifestyle.SingletonPerScope();
            });

            return c;
        }
    }
}