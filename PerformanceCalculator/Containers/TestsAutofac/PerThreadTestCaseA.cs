using Autofac;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class PerThreadTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TestA0>().As<ITestA0>().InstancePerLifetimeScope();
            cb.RegisterType<TestA1>().As<ITestA1>().InstancePerLifetimeScope();
            cb.RegisterType<TestA2>().As<ITestA2>().InstancePerLifetimeScope();
            cb.RegisterType<TestA3>().As<ITestA3>().InstancePerLifetimeScope();
            cb.RegisterType<TestA4>().As<ITestA4>().InstancePerLifetimeScope();
            cb.RegisterType<TestA5>().As<ITestA5>().InstancePerLifetimeScope();
            cb.RegisterType<TestA6>().As<ITestA6>().InstancePerLifetimeScope();
            cb.RegisterType<TestA7>().As<ITestA7>().InstancePerLifetimeScope();
            cb.RegisterType<TestA8>().As<ITestA8>().InstancePerLifetimeScope();
            cb.RegisterType<TestA9>().As<ITestA9>().InstancePerLifetimeScope();
            cb.RegisterType<TestA>().As<ITestA>().InstancePerLifetimeScope();
            var c = cb.Build();

            return c;
        }
    }
}