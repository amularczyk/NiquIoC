using Grace.DependencyInjection;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class TransientTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (DependencyInjectionContainer)container;

            c.Configure(x =>
            {
                x.Export<TestCa0>().As<ITestCa0>();
                x.Export<TestCa0>().As<ITestCa0>();
                x.Export<TestCa1>().As<ITestCa1>();
                x.Export<TestCa2>().As<ITestCa2>();
                x.Export<TestCa3>().As<ITestCa3>();
                x.Export<TestCa4>().As<ITestCa4>();
                x.Export<TestCa5>().As<ITestCa5>();
                x.Export<TestCa6>().As<ITestCa6>();
                x.Export<TestCa7>().As<ITestCa7>();
                x.Export<TestCa8>().As<ITestCa8>();
                x.Export<TestCa9>().As<ITestCa9>();
                x.Export<TestCa10>().As<ITestCa10>();

                x.Export<TestCb0>().As<ITestCb0>();
                x.Export<TestCb0>().As<ITestCb0>();
                x.Export<TestCb1>().As<ITestCb1>();
                x.Export<TestCb2>().As<ITestCb2>();
                x.Export<TestCb3>().As<ITestCb3>();
                x.Export<TestCb4>().As<ITestCb4>();
                x.Export<TestCb5>().As<ITestCb5>();
                x.Export<TestCb6>().As<ITestCb6>();
                x.Export<TestCb7>().As<ITestCb7>();
                x.Export<TestCb8>().As<ITestCb8>();
                x.Export<TestCb9>().As<ITestCb9>();
                x.Export<TestCb10>().As<ITestCb10>();

                x.Export<TestCc0>().As<ITestCc0>();
                x.Export<TestCc0>().As<ITestCc0>();
                x.Export<TestCc1>().As<ITestCc1>();
                x.Export<TestCc2>().As<ITestCc2>();
                x.Export<TestCc3>().As<ITestCc3>();
                x.Export<TestCc4>().As<ITestCc4>();
                x.Export<TestCc5>().As<ITestCc5>();
                x.Export<TestCc6>().As<ITestCc6>();
                x.Export<TestCc7>().As<ITestCc7>();
                x.Export<TestCc8>().As<ITestCc8>();
                x.Export<TestCc9>().As<ITestCc9>();
                x.Export<TestCc10>().As<ITestCc10>();

                x.Export<TestC>().As<ITestC>();
            });

            return c;
        }
    }
}