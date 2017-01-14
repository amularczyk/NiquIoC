using NiquIoC;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class SingletonTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestCa0, TestCa0>().AsSingleton();
            c.RegisterType<ITestCa1, TestCa1>().AsSingleton();
            c.RegisterType<ITestCa2, TestCa2>().AsSingleton();
            c.RegisterType<ITestCa3, TestCa3>().AsSingleton();
            c.RegisterType<ITestCa4, TestCa4>().AsSingleton();
            c.RegisterType<ITestCa5, TestCa5>().AsSingleton();
            c.RegisterType<ITestCa6, TestCa6>().AsSingleton();
            c.RegisterType<ITestCa7, TestCa7>().AsSingleton();
            c.RegisterType<ITestCa8, TestCa8>().AsSingleton();
            c.RegisterType<ITestCa9, TestCa9>().AsSingleton();
            c.RegisterType<ITestCa10, TestCa10>().AsSingleton();

            c.RegisterType<ITestCb0, TestCb0>().AsSingleton();
            c.RegisterType<ITestCb1, TestCb1>().AsSingleton();
            c.RegisterType<ITestCb2, TestCb2>().AsSingleton();
            c.RegisterType<ITestCb3, TestCb3>().AsSingleton();
            c.RegisterType<ITestCb4, TestCb4>().AsSingleton();
            c.RegisterType<ITestCb5, TestCb5>().AsSingleton();
            c.RegisterType<ITestCb6, TestCb6>().AsSingleton();
            c.RegisterType<ITestCb7, TestCb7>().AsSingleton();
            c.RegisterType<ITestCb8, TestCb8>().AsSingleton();
            c.RegisterType<ITestCb9, TestCb9>().AsSingleton();
            c.RegisterType<ITestCb10, TestCb10>().AsSingleton();

            c.RegisterType<ITestCc0, TestCc0>().AsSingleton();
            c.RegisterType<ITestCc1, TestCc1>().AsSingleton();
            c.RegisterType<ITestCc2, TestCc2>().AsSingleton();
            c.RegisterType<ITestCc3, TestCc3>().AsSingleton();
            c.RegisterType<ITestCc4, TestCc4>().AsSingleton();
            c.RegisterType<ITestCc5, TestCc5>().AsSingleton();
            c.RegisterType<ITestCc6, TestCc6>().AsSingleton();
            c.RegisterType<ITestCc7, TestCc7>().AsSingleton();
            c.RegisterType<ITestCc8, TestCc8>().AsSingleton();
            c.RegisterType<ITestCc9, TestCc9>().AsSingleton();
            c.RegisterType<ITestCc10, TestCc10>().AsSingleton();

            c.RegisterType<ITestC, TestC>().AsSingleton();

            return c;
        }
    }
}