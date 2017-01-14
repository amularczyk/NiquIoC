using NiquIoC;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class TransientTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestCa0, TestCa0>();
            c.RegisterType<ITestCa1, TestCa1>();
            c.RegisterType<ITestCa2, TestCa2>();
            c.RegisterType<ITestCa3, TestCa3>();
            c.RegisterType<ITestCa4, TestCa4>();
            c.RegisterType<ITestCa5, TestCa5>();
            c.RegisterType<ITestCa6, TestCa6>();
            c.RegisterType<ITestCa7, TestCa7>();
            c.RegisterType<ITestCa8, TestCa8>();
            c.RegisterType<ITestCa9, TestCa9>();
            c.RegisterType<ITestCa10, TestCa10>();

            c.RegisterType<ITestCb0, TestCb0>();
            c.RegisterType<ITestCb1, TestCb1>();
            c.RegisterType<ITestCb2, TestCb2>();
            c.RegisterType<ITestCb3, TestCb3>();
            c.RegisterType<ITestCb4, TestCb4>();
            c.RegisterType<ITestCb5, TestCb5>();
            c.RegisterType<ITestCb6, TestCb6>();
            c.RegisterType<ITestCb7, TestCb7>();
            c.RegisterType<ITestCb8, TestCb8>();
            c.RegisterType<ITestCb9, TestCb9>();
            c.RegisterType<ITestCb10, TestCb10>();

            c.RegisterType<ITestCc0, TestCc0>();
            c.RegisterType<ITestCc1, TestCc1>();
            c.RegisterType<ITestCc2, TestCc2>();
            c.RegisterType<ITestCc3, TestCc3>();
            c.RegisterType<ITestCc4, TestCc4>();
            c.RegisterType<ITestCc5, TestCc5>();
            c.RegisterType<ITestCc6, TestCc6>();
            c.RegisterType<ITestCc7, TestCc7>();
            c.RegisterType<ITestCc8, TestCc8>();
            c.RegisterType<ITestCc9, TestCc9>();
            c.RegisterType<ITestCc10, TestCc10>();

            c.RegisterType<ITestC, TestC>();

            return c;
        }
    }
}