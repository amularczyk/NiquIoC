using NiquIoC;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class PerThreadTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestB00, TestB00>().AsPerThread();
            c.RegisterType<ITestB01, TestB01>().AsPerThread();
            c.RegisterType<ITestB02, TestB02>().AsPerThread();
            c.RegisterType<ITestB03, TestB03>().AsPerThread();
            c.RegisterType<ITestB04, TestB04>().AsPerThread();
            c.RegisterType<ITestB05, TestB05>().AsPerThread();
            c.RegisterType<ITestB06, TestB06>().AsPerThread();
            c.RegisterType<ITestB07, TestB07>().AsPerThread();
            c.RegisterType<ITestB08, TestB08>().AsPerThread();
            c.RegisterType<ITestB09, TestB09>().AsPerThread();

            c.RegisterType<ITestB10, TestB10>().AsPerThread();
            c.RegisterType<ITestB11, TestB11>().AsPerThread();
            c.RegisterType<ITestB12, TestB12>().AsPerThread();
            c.RegisterType<ITestB13, TestB13>().AsPerThread();
            c.RegisterType<ITestB14, TestB14>().AsPerThread();
            c.RegisterType<ITestB15, TestB15>().AsPerThread();
            c.RegisterType<ITestB16, TestB16>().AsPerThread();
            c.RegisterType<ITestB17, TestB17>().AsPerThread();
            c.RegisterType<ITestB18, TestB18>().AsPerThread();
            c.RegisterType<ITestB19, TestB19>().AsPerThread();

            c.RegisterType<ITestB20, TestB20>().AsPerThread();
            c.RegisterType<ITestB21, TestB21>().AsPerThread();
            c.RegisterType<ITestB22, TestB22>().AsPerThread();
            c.RegisterType<ITestB23, TestB23>().AsPerThread();
            c.RegisterType<ITestB24, TestB24>().AsPerThread();
            c.RegisterType<ITestB25, TestB25>().AsPerThread();
            c.RegisterType<ITestB26, TestB26>().AsPerThread();
            c.RegisterType<ITestB27, TestB27>().AsPerThread();
            c.RegisterType<ITestB28, TestB28>().AsPerThread();
            c.RegisterType<ITestB29, TestB29>().AsPerThread();

            c.RegisterType<ITestB30, TestB30>().AsPerThread();
            c.RegisterType<ITestB31, TestB31>().AsPerThread();
            c.RegisterType<ITestB32, TestB32>().AsPerThread();
            c.RegisterType<ITestB33, TestB33>().AsPerThread();
            c.RegisterType<ITestB34, TestB34>().AsPerThread();
            c.RegisterType<ITestB35, TestB35>().AsPerThread();
            c.RegisterType<ITestB36, TestB36>().AsPerThread();
            c.RegisterType<ITestB37, TestB37>().AsPerThread();
            c.RegisterType<ITestB38, TestB38>().AsPerThread();
            c.RegisterType<ITestB39, TestB39>().AsPerThread();

            c.RegisterType<ITestB40, TestB40>().AsPerThread();
            c.RegisterType<ITestB41, TestB41>().AsPerThread();
            c.RegisterType<ITestB42, TestB42>().AsPerThread();
            c.RegisterType<ITestB43, TestB43>().AsPerThread();
            c.RegisterType<ITestB44, TestB44>().AsPerThread();
            c.RegisterType<ITestB45, TestB45>().AsPerThread();
            c.RegisterType<ITestB46, TestB46>().AsPerThread();
            c.RegisterType<ITestB47, TestB47>().AsPerThread();
            c.RegisterType<ITestB48, TestB48>().AsPerThread();
            c.RegisterType<ITestB49, TestB49>().AsPerThread();

            c.RegisterType<ITestB, TestB>().AsPerThread();

            return c;
        }
    }
}