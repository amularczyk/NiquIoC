using NiquIoC;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class PerThreadTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestCa0, TestCa0>().AsPerThread();
            c.RegisterType<ITestCa1, TestCa1>().AsPerThread();
            c.RegisterType<ITestCa2, TestCa2>().AsPerThread();
            c.RegisterType<ITestCa3, TestCa3>().AsPerThread();
            c.RegisterType<ITestCa4, TestCa4>().AsPerThread();
            c.RegisterType<ITestCa5, TestCa5>().AsPerThread();
            c.RegisterType<ITestCa6, TestCa6>().AsPerThread();
            c.RegisterType<ITestCa7, TestCa7>().AsPerThread();
            c.RegisterType<ITestCa8, TestCa8>().AsPerThread();
            c.RegisterType<ITestCa9, TestCa9>().AsPerThread();
            c.RegisterType<ITestCa10, TestCa10>().AsPerThread();

            c.RegisterType<ITestCb0, TestCb0>().AsPerThread();
            c.RegisterType<ITestCb1, TestCb1>().AsPerThread();
            c.RegisterType<ITestCb2, TestCb2>().AsPerThread();
            c.RegisterType<ITestCb3, TestCb3>().AsPerThread();
            c.RegisterType<ITestCb4, TestCb4>().AsPerThread();
            c.RegisterType<ITestCb5, TestCb5>().AsPerThread();
            c.RegisterType<ITestCb6, TestCb6>().AsPerThread();
            c.RegisterType<ITestCb7, TestCb7>().AsPerThread();
            c.RegisterType<ITestCb8, TestCb8>().AsPerThread();
            c.RegisterType<ITestCb9, TestCb9>().AsPerThread();
            c.RegisterType<ITestCb10, TestCb10>().AsPerThread();

            c.RegisterType<ITestCc0, TestCc0>().AsPerThread();
            c.RegisterType<ITestCc1, TestCc1>().AsPerThread();
            c.RegisterType<ITestCc2, TestCc2>().AsPerThread();
            c.RegisterType<ITestCc3, TestCc3>().AsPerThread();
            c.RegisterType<ITestCc4, TestCc4>().AsPerThread();
            c.RegisterType<ITestCc5, TestCc5>().AsPerThread();
            c.RegisterType<ITestCc6, TestCc6>().AsPerThread();
            c.RegisterType<ITestCc7, TestCc7>().AsPerThread();
            c.RegisterType<ITestCc8, TestCc8>().AsPerThread();
            c.RegisterType<ITestCc9, TestCc9>().AsPerThread();
            c.RegisterType<ITestCc10, TestCc10>().AsPerThread();

            c.RegisterType<ITestC, TestC>().AsPerThread();

            return c;
        }
    }
}