using Autofac;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class TransientTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TestCa0>().As<ITestCa0>();
            cb.RegisterType<TestCa1>().As<ITestCa1>();
            cb.RegisterType<TestCa2>().As<ITestCa2>();
            cb.RegisterType<TestCa3>().As<ITestCa3>();
            cb.RegisterType<TestCa4>().As<ITestCa4>();
            cb.RegisterType<TestCa5>().As<ITestCa5>();
            cb.RegisterType<TestCa6>().As<ITestCa6>();
            cb.RegisterType<TestCa7>().As<ITestCa7>();
            cb.RegisterType<TestCa8>().As<ITestCa8>();
            cb.RegisterType<TestCa9>().As<ITestCa9>();
            cb.RegisterType<TestCa10>().As<ITestCa10>();

            cb.RegisterType<TestCb0>().As<ITestCb0>();
            cb.RegisterType<TestCb1>().As<ITestCb1>();
            cb.RegisterType<TestCb2>().As<ITestCb2>();
            cb.RegisterType<TestCb3>().As<ITestCb3>();
            cb.RegisterType<TestCb4>().As<ITestCb4>();
            cb.RegisterType<TestCb5>().As<ITestCb5>();
            cb.RegisterType<TestCb6>().As<ITestCb6>();
            cb.RegisterType<TestCb7>().As<ITestCb7>();
            cb.RegisterType<TestCb8>().As<ITestCb8>();
            cb.RegisterType<TestCb9>().As<ITestCb9>();
            cb.RegisterType<TestCb10>().As<ITestCb10>();

            cb.RegisterType<TestCc0>().As<ITestCc0>();
            cb.RegisterType<TestCc1>().As<ITestCc1>();
            cb.RegisterType<TestCc2>().As<ITestCc2>();
            cb.RegisterType<TestCc3>().As<ITestCc3>();
            cb.RegisterType<TestCc4>().As<ITestCc4>();
            cb.RegisterType<TestCc5>().As<ITestCc5>();
            cb.RegisterType<TestCc6>().As<ITestCc6>();
            cb.RegisterType<TestCc7>().As<ITestCc7>();
            cb.RegisterType<TestCc8>().As<ITestCc8>();
            cb.RegisterType<TestCc9>().As<ITestCc9>();
            cb.RegisterType<TestCc10>().As<ITestCc10>();

            cb.RegisterType<TestC>().As<ITestC>();
            var c = cb.Build();

            return c;
        }
    }
}