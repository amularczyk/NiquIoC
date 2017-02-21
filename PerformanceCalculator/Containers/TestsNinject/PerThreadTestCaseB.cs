using Ninject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class PerThreadTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<ITestB00>().To<TestB00>().InThreadScope();
            c.Bind<ITestB01>().To<TestB01>().InThreadScope();
            c.Bind<ITestB02>().To<TestB02>().InThreadScope();
            c.Bind<ITestB03>().To<TestB03>().InThreadScope();
            c.Bind<ITestB04>().To<TestB04>().InThreadScope();
            c.Bind<ITestB05>().To<TestB05>().InThreadScope();
            c.Bind<ITestB06>().To<TestB06>().InThreadScope();
            c.Bind<ITestB07>().To<TestB07>().InThreadScope();
            c.Bind<ITestB08>().To<TestB08>().InThreadScope();
            c.Bind<ITestB09>().To<TestB09>().InThreadScope();

            c.Bind<ITestB10>().To<TestB10>().InThreadScope();
            c.Bind<ITestB11>().To<TestB11>().InThreadScope();
            c.Bind<ITestB12>().To<TestB12>().InThreadScope();
            c.Bind<ITestB13>().To<TestB13>().InThreadScope();
            c.Bind<ITestB14>().To<TestB14>().InThreadScope();
            c.Bind<ITestB15>().To<TestB15>().InThreadScope();
            c.Bind<ITestB16>().To<TestB16>().InThreadScope();
            c.Bind<ITestB17>().To<TestB17>().InThreadScope();
            c.Bind<ITestB18>().To<TestB18>().InThreadScope();
            c.Bind<ITestB19>().To<TestB19>().InThreadScope();

            c.Bind<ITestB20>().To<TestB20>().InThreadScope();
            c.Bind<ITestB21>().To<TestB21>().InThreadScope();
            c.Bind<ITestB22>().To<TestB22>().InThreadScope();
            c.Bind<ITestB23>().To<TestB23>().InThreadScope();
            c.Bind<ITestB24>().To<TestB24>().InThreadScope();
            c.Bind<ITestB25>().To<TestB25>().InThreadScope();
            c.Bind<ITestB26>().To<TestB26>().InThreadScope();
            c.Bind<ITestB27>().To<TestB27>().InThreadScope();
            c.Bind<ITestB28>().To<TestB28>().InThreadScope();
            c.Bind<ITestB29>().To<TestB29>().InThreadScope();

            c.Bind<ITestB30>().To<TestB30>().InThreadScope();
            c.Bind<ITestB31>().To<TestB31>().InThreadScope();
            c.Bind<ITestB32>().To<TestB32>().InThreadScope();
            c.Bind<ITestB33>().To<TestB33>().InThreadScope();
            c.Bind<ITestB34>().To<TestB34>().InThreadScope();
            c.Bind<ITestB35>().To<TestB35>().InThreadScope();
            c.Bind<ITestB36>().To<TestB36>().InThreadScope();
            c.Bind<ITestB37>().To<TestB37>().InThreadScope();
            c.Bind<ITestB38>().To<TestB38>().InThreadScope();
            c.Bind<ITestB39>().To<TestB39>().InThreadScope();

            c.Bind<ITestB40>().To<TestB40>().InThreadScope();
            c.Bind<ITestB41>().To<TestB41>().InThreadScope();
            c.Bind<ITestB42>().To<TestB42>().InThreadScope();
            c.Bind<ITestB43>().To<TestB43>().InThreadScope();
            c.Bind<ITestB44>().To<TestB44>().InThreadScope();
            c.Bind<ITestB45>().To<TestB45>().InThreadScope();
            c.Bind<ITestB46>().To<TestB46>().InThreadScope();
            c.Bind<ITestB47>().To<TestB47>().InThreadScope();
            c.Bind<ITestB48>().To<TestB48>().InThreadScope();
            c.Bind<ITestB49>().To<TestB49>().InThreadScope();

            c.Bind<ITestB>().To<TestB>().InThreadScope();

            return c;
        }
    }
}