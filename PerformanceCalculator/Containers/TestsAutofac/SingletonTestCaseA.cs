using Autofac;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class SingletonTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TestA0>().As<ITestA0>().SingleInstance();
            cb.RegisterType<TestA1>().As<ITestA1>().SingleInstance();
            cb.RegisterType<TestA2>().As<ITestA2>().SingleInstance();
            cb.RegisterType<TestA3>().As<ITestA3>().SingleInstance();
            cb.RegisterType<TestA4>().As<ITestA4>().SingleInstance();
            cb.RegisterType<TestA5>().As<ITestA5>().SingleInstance();
            cb.RegisterType<TestA6>().As<ITestA6>().SingleInstance();
            cb.RegisterType<TestA7>().As<ITestA7>().SingleInstance();
            cb.RegisterType<TestA8>().As<ITestA8>().SingleInstance();
            cb.RegisterType<TestA9>().As<ITestA9>().SingleInstance();
            cb.RegisterType<TestA>().As<ITestA>().SingleInstance();
            var c = cb.Build();

            return c;
        }
    }
}