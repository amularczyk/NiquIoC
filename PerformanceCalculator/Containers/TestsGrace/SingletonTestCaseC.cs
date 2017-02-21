using Grace.DependencyInjection;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class SingletonTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (DependencyInjectionContainer)container;

            c.Configure(x =>
            {
                x.Export<ITestCa0>().As<TestCa0>().Lifestyle.Singleton();
                x.Export<ITestCa0>().As<TestCa0>().Lifestyle.Singleton();
                x.Export<ITestCa1>().As<TestCa1>().Lifestyle.Singleton();
                x.Export<ITestCa2>().As<TestCa2>().Lifestyle.Singleton();
                x.Export<ITestCa3>().As<TestCa3>().Lifestyle.Singleton();
                x.Export<ITestCa4>().As<TestCa4>().Lifestyle.Singleton();
                x.Export<ITestCa5>().As<TestCa5>().Lifestyle.Singleton();
                x.Export<ITestCa6>().As<TestCa6>().Lifestyle.Singleton();
                x.Export<ITestCa7>().As<TestCa7>().Lifestyle.Singleton();
                x.Export<ITestCa8>().As<TestCa8>().Lifestyle.Singleton();
                x.Export<ITestCa9>().As<TestCa9>().Lifestyle.Singleton();
                x.Export<ITestCa10>().As<TestCa10>().Lifestyle.Singleton();

                x.Export<ITestCb0>().As<TestCb0>().Lifestyle.Singleton();
                x.Export<ITestCb0>().As<TestCb0>().Lifestyle.Singleton();
                x.Export<ITestCb1>().As<TestCb1>().Lifestyle.Singleton();
                x.Export<ITestCb2>().As<TestCb2>().Lifestyle.Singleton();
                x.Export<ITestCb3>().As<TestCb3>().Lifestyle.Singleton();
                x.Export<ITestCb4>().As<TestCb4>().Lifestyle.Singleton();
                x.Export<ITestCb5>().As<TestCb5>().Lifestyle.Singleton();
                x.Export<ITestCb6>().As<TestCb6>().Lifestyle.Singleton();
                x.Export<ITestCb7>().As<TestCb7>().Lifestyle.Singleton();
                x.Export<ITestCb8>().As<TestCb8>().Lifestyle.Singleton();
                x.Export<ITestCb9>().As<TestCb9>().Lifestyle.Singleton();
                x.Export<ITestCb10>().As<TestCb10>().Lifestyle.Singleton();

                x.Export<ITestCc0>().As<TestCc0>().Lifestyle.Singleton();
                x.Export<ITestCc0>().As<TestCc0>().Lifestyle.Singleton();
                x.Export<ITestCc1>().As<TestCc1>().Lifestyle.Singleton();
                x.Export<ITestCc2>().As<TestCc2>().Lifestyle.Singleton();
                x.Export<ITestCc3>().As<TestCc3>().Lifestyle.Singleton();
                x.Export<ITestCc4>().As<TestCc4>().Lifestyle.Singleton();
                x.Export<ITestCc5>().As<TestCc5>().Lifestyle.Singleton();
                x.Export<ITestCc6>().As<TestCc6>().Lifestyle.Singleton();
                x.Export<ITestCc7>().As<TestCc7>().Lifestyle.Singleton();
                x.Export<ITestCc8>().As<TestCc8>().Lifestyle.Singleton();
                x.Export<ITestCc9>().As<TestCc9>().Lifestyle.Singleton();
                x.Export<ITestCc10>().As<TestCc10>().Lifestyle.Singleton();

                x.Export<ITestC>().As<TestC>().Lifestyle.Singleton();
            });

            return c;
        }
    }
}