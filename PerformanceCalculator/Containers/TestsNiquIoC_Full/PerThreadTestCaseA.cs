using NiquIoC;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class PerThreadTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestA0, TestA0>().AsPerThread();
            c.RegisterType<ITestA1, TestA1>().AsPerThread();
            c.RegisterType<ITestA2, TestA2>().AsPerThread();
            c.RegisterType<ITestA3, TestA3>().AsPerThread();
            c.RegisterType<ITestA4, TestA4>().AsPerThread();
            c.RegisterType<ITestA5, TestA5>().AsPerThread();
            c.RegisterType<ITestA6, TestA6>().AsPerThread();
            c.RegisterType<ITestA7, TestA7>().AsPerThread();
            c.RegisterType<ITestA8, TestA8>().AsPerThread();
            c.RegisterType<ITestA9, TestA9>().AsPerThread();
            c.RegisterType<ITestA, TestA>().AsPerThread();

            return c;
        }
    }
}