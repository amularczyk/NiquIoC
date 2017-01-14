using Autofac;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class TransientTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TestA0>().As<ITestA0>();
            cb.RegisterType<TestA1>().As<ITestA1>();
            cb.RegisterType<TestA2>().As<ITestA2>();
            cb.RegisterType<TestA3>().As<ITestA3>();
            cb.RegisterType<TestA4>().As<ITestA4>();
            cb.RegisterType<TestA5>().As<ITestA5>();
            cb.RegisterType<TestA6>().As<ITestA6>();
            cb.RegisterType<TestA7>().As<ITestA7>();
            cb.RegisterType<TestA8>().As<ITestA8>();
            cb.RegisterType<TestA9>().As<ITestA9>();
            cb.RegisterType<TestA>().As<ITestA>();
            var c = cb.Build();

            return c;
        }
    }
}