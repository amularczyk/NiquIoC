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
                x.Export<ITestCa0>().As<TestCa0>();
                x.Export<ITestCa0>().As<TestCa0>();
                x.Export<ITestCa1>().As<TestCa1>();
                x.Export<ITestCa2>().As<TestCa2>();
                x.Export<ITestCa3>().As<TestCa3>();
                x.Export<ITestCa4>().As<TestCa4>();
                x.Export<ITestCa5>().As<TestCa5>();
                x.Export<ITestCa6>().As<TestCa6>();
                x.Export<ITestCa7>().As<TestCa7>();
                x.Export<ITestCa8>().As<TestCa8>();
                x.Export<ITestCa9>().As<TestCa9>();
                x.Export<ITestCa10>().As<TestCa10>();

                x.Export<ITestCb0>().As<TestCb0>();
                x.Export<ITestCb0>().As<TestCb0>();
                x.Export<ITestCb1>().As<TestCb1>();
                x.Export<ITestCb2>().As<TestCb2>();
                x.Export<ITestCb3>().As<TestCb3>();
                x.Export<ITestCb4>().As<TestCb4>();
                x.Export<ITestCb5>().As<TestCb5>();
                x.Export<ITestCb6>().As<TestCb6>();
                x.Export<ITestCb7>().As<TestCb7>();
                x.Export<ITestCb8>().As<TestCb8>();
                x.Export<ITestCb9>().As<TestCb9>();
                x.Export<ITestCb10>().As<TestCb10>();

                x.Export<ITestCc0>().As<TestCc0>();
                x.Export<ITestCc0>().As<TestCc0>();
                x.Export<ITestCc1>().As<TestCc1>();
                x.Export<ITestCc2>().As<TestCc2>();
                x.Export<ITestCc3>().As<TestCc3>();
                x.Export<ITestCc4>().As<TestCc4>();
                x.Export<ITestCc5>().As<TestCc5>();
                x.Export<ITestCc6>().As<TestCc6>();
                x.Export<ITestCc7>().As<TestCc7>();
                x.Export<ITestCc8>().As<TestCc8>();
                x.Export<ITestCc9>().As<TestCc9>();
                x.Export<ITestCc10>().As<TestCc10>();

                x.Export<ITestC>().As<TestC>();
            });

            return c;
        }
    }
}