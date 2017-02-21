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
                x.Export<ITestCa0>().As<TestCa0>().Lifestyle.SingletonPerScope();
                x.Export<ITestCa0>().As<TestCa0>().Lifestyle.SingletonPerScope();
                x.Export<ITestCa1>().As<TestCa1>().Lifestyle.SingletonPerScope();
                x.Export<ITestCa2>().As<TestCa2>().Lifestyle.SingletonPerScope();
                x.Export<ITestCa3>().As<TestCa3>().Lifestyle.SingletonPerScope();
                x.Export<ITestCa4>().As<TestCa4>().Lifestyle.SingletonPerScope();
                x.Export<ITestCa5>().As<TestCa5>().Lifestyle.SingletonPerScope();
                x.Export<ITestCa6>().As<TestCa6>().Lifestyle.SingletonPerScope();
                x.Export<ITestCa7>().As<TestCa7>().Lifestyle.SingletonPerScope();
                x.Export<ITestCa8>().As<TestCa8>().Lifestyle.SingletonPerScope();
                x.Export<ITestCa9>().As<TestCa9>().Lifestyle.SingletonPerScope();
                x.Export<ITestCa10>().As<TestCa10>().Lifestyle.SingletonPerScope();

                x.Export<ITestCb0>().As<TestCb0>().Lifestyle.SingletonPerScope();
                x.Export<ITestCb0>().As<TestCb0>().Lifestyle.SingletonPerScope();
                x.Export<ITestCb1>().As<TestCb1>().Lifestyle.SingletonPerScope();
                x.Export<ITestCb2>().As<TestCb2>().Lifestyle.SingletonPerScope();
                x.Export<ITestCb3>().As<TestCb3>().Lifestyle.SingletonPerScope();
                x.Export<ITestCb4>().As<TestCb4>().Lifestyle.SingletonPerScope();
                x.Export<ITestCb5>().As<TestCb5>().Lifestyle.SingletonPerScope();
                x.Export<ITestCb6>().As<TestCb6>().Lifestyle.SingletonPerScope();
                x.Export<ITestCb7>().As<TestCb7>().Lifestyle.SingletonPerScope();
                x.Export<ITestCb8>().As<TestCb8>().Lifestyle.SingletonPerScope();
                x.Export<ITestCb9>().As<TestCb9>().Lifestyle.SingletonPerScope();
                x.Export<ITestCb10>().As<TestCb10>().Lifestyle.SingletonPerScope();

                x.Export<ITestCc0>().As<TestCc0>().Lifestyle.SingletonPerScope();
                x.Export<ITestCc0>().As<TestCc0>().Lifestyle.SingletonPerScope();
                x.Export<ITestCc1>().As<TestCc1>().Lifestyle.SingletonPerScope();
                x.Export<ITestCc2>().As<TestCc2>().Lifestyle.SingletonPerScope();
                x.Export<ITestCc3>().As<TestCc3>().Lifestyle.SingletonPerScope();
                x.Export<ITestCc4>().As<TestCc4>().Lifestyle.SingletonPerScope();
                x.Export<ITestCc5>().As<TestCc5>().Lifestyle.SingletonPerScope();
                x.Export<ITestCc6>().As<TestCc6>().Lifestyle.SingletonPerScope();
                x.Export<ITestCc7>().As<TestCc7>().Lifestyle.SingletonPerScope();
                x.Export<ITestCc8>().As<TestCc8>().Lifestyle.SingletonPerScope();
                x.Export<ITestCc9>().As<TestCc9>().Lifestyle.SingletonPerScope();
                x.Export<ITestCc10>().As<TestCc10>().Lifestyle.SingletonPerScope();

                x.Export<ITestC>().As<TestC>().Lifestyle.SingletonPerScope();
            });

            return c;
        }
    }
}