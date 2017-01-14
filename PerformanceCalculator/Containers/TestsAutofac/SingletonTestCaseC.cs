using Autofac;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class SingletonTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TestCa0>().As<ITestCa0>().SingleInstance();
            cb.RegisterType<TestCa1>().As<ITestCa1>().SingleInstance();
            cb.RegisterType<TestCa2>().As<ITestCa2>().SingleInstance();
            cb.RegisterType<TestCa3>().As<ITestCa3>().SingleInstance();
            cb.RegisterType<TestCa4>().As<ITestCa4>().SingleInstance();
            cb.RegisterType<TestCa5>().As<ITestCa5>().SingleInstance();
            cb.RegisterType<TestCa6>().As<ITestCa6>().SingleInstance();
            cb.RegisterType<TestCa7>().As<ITestCa7>().SingleInstance();
            cb.RegisterType<TestCa8>().As<ITestCa8>().SingleInstance();
            cb.RegisterType<TestCa9>().As<ITestCa9>().SingleInstance();
            cb.RegisterType<TestCa10>().As<ITestCa10>().SingleInstance();

            cb.RegisterType<TestCb0>().As<ITestCb0>().SingleInstance();
            cb.RegisterType<TestCb1>().As<ITestCb1>().SingleInstance();
            cb.RegisterType<TestCb2>().As<ITestCb2>().SingleInstance();
            cb.RegisterType<TestCb3>().As<ITestCb3>().SingleInstance();
            cb.RegisterType<TestCb4>().As<ITestCb4>().SingleInstance();
            cb.RegisterType<TestCb5>().As<ITestCb5>().SingleInstance();
            cb.RegisterType<TestCb6>().As<ITestCb6>().SingleInstance();
            cb.RegisterType<TestCb7>().As<ITestCb7>().SingleInstance();
            cb.RegisterType<TestCb8>().As<ITestCb8>().SingleInstance();
            cb.RegisterType<TestCb9>().As<ITestCb9>().SingleInstance();
            cb.RegisterType<TestCb10>().As<ITestCb10>().SingleInstance();

            cb.RegisterType<TestCc0>().As<ITestCc0>().SingleInstance();
            cb.RegisterType<TestCc1>().As<ITestCc1>().SingleInstance();
            cb.RegisterType<TestCc2>().As<ITestCc2>().SingleInstance();
            cb.RegisterType<TestCc3>().As<ITestCc3>().SingleInstance();
            cb.RegisterType<TestCc4>().As<ITestCc4>().SingleInstance();
            cb.RegisterType<TestCc5>().As<ITestCc5>().SingleInstance();
            cb.RegisterType<TestCc6>().As<ITestCc6>().SingleInstance();
            cb.RegisterType<TestCc7>().As<ITestCc7>().SingleInstance();
            cb.RegisterType<TestCc8>().As<ITestCc8>().SingleInstance();
            cb.RegisterType<TestCc9>().As<ITestCc9>().SingleInstance();
            cb.RegisterType<TestCc10>().As<ITestCc10>().SingleInstance();

            cb.RegisterType<TestC>().As<ITestC>().SingleInstance();
            var c = cb.Build();

            return c;
        }
    }
}