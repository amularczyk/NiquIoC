using Autofac;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class PerThreadTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TestCa0>().As<ITestCa0>().InstancePerLifetimeScope();
            cb.RegisterType<TestCa1>().As<ITestCa1>().InstancePerLifetimeScope();
            cb.RegisterType<TestCa2>().As<ITestCa2>().InstancePerLifetimeScope();
            cb.RegisterType<TestCa3>().As<ITestCa3>().InstancePerLifetimeScope();
            cb.RegisterType<TestCa4>().As<ITestCa4>().InstancePerLifetimeScope();
            cb.RegisterType<TestCa5>().As<ITestCa5>().InstancePerLifetimeScope();
            cb.RegisterType<TestCa6>().As<ITestCa6>().InstancePerLifetimeScope();
            cb.RegisterType<TestCa7>().As<ITestCa7>().InstancePerLifetimeScope();
            cb.RegisterType<TestCa8>().As<ITestCa8>().InstancePerLifetimeScope();
            cb.RegisterType<TestCa9>().As<ITestCa9>().InstancePerLifetimeScope();
            cb.RegisterType<TestCa10>().As<ITestCa10>().InstancePerLifetimeScope();

            cb.RegisterType<TestCb0>().As<ITestCb0>().InstancePerLifetimeScope();
            cb.RegisterType<TestCb1>().As<ITestCb1>().InstancePerLifetimeScope();
            cb.RegisterType<TestCb2>().As<ITestCb2>().InstancePerLifetimeScope();
            cb.RegisterType<TestCb3>().As<ITestCb3>().InstancePerLifetimeScope();
            cb.RegisterType<TestCb4>().As<ITestCb4>().InstancePerLifetimeScope();
            cb.RegisterType<TestCb5>().As<ITestCb5>().InstancePerLifetimeScope();
            cb.RegisterType<TestCb6>().As<ITestCb6>().InstancePerLifetimeScope();
            cb.RegisterType<TestCb7>().As<ITestCb7>().InstancePerLifetimeScope();
            cb.RegisterType<TestCb8>().As<ITestCb8>().InstancePerLifetimeScope();
            cb.RegisterType<TestCb9>().As<ITestCb9>().InstancePerLifetimeScope();
            cb.RegisterType<TestCb10>().As<ITestCb10>().InstancePerLifetimeScope();

            cb.RegisterType<TestCc0>().As<ITestCc0>().InstancePerLifetimeScope();
            cb.RegisterType<TestCc1>().As<ITestCc1>().InstancePerLifetimeScope();
            cb.RegisterType<TestCc2>().As<ITestCc2>().InstancePerLifetimeScope();
            cb.RegisterType<TestCc3>().As<ITestCc3>().InstancePerLifetimeScope();
            cb.RegisterType<TestCc4>().As<ITestCc4>().InstancePerLifetimeScope();
            cb.RegisterType<TestCc5>().As<ITestCc5>().InstancePerLifetimeScope();
            cb.RegisterType<TestCc6>().As<ITestCc6>().InstancePerLifetimeScope();
            cb.RegisterType<TestCc7>().As<ITestCc7>().InstancePerLifetimeScope();
            cb.RegisterType<TestCc8>().As<ITestCc8>().InstancePerLifetimeScope();
            cb.RegisterType<TestCc9>().As<ITestCc9>().InstancePerLifetimeScope();
            cb.RegisterType<TestCc10>().As<ITestCc10>().InstancePerLifetimeScope();

            cb.RegisterType<TestC>().As<ITestC>().InstancePerLifetimeScope();
            var c = cb.Build();

            return c;
        }
    }
}