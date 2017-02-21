using Ninject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class TransientTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<ITestB00>().To<TestB00>().InTransientScope();
            c.Bind<ITestB01>().To<TestB01>().InTransientScope();
            c.Bind<ITestB02>().To<TestB02>().InTransientScope();
            c.Bind<ITestB03>().To<TestB03>().InTransientScope();
            c.Bind<ITestB04>().To<TestB04>().InTransientScope();
            c.Bind<ITestB05>().To<TestB05>().InTransientScope();
            c.Bind<ITestB06>().To<TestB06>().InTransientScope();
            c.Bind<ITestB07>().To<TestB07>().InTransientScope();
            c.Bind<ITestB08>().To<TestB08>().InTransientScope();
            c.Bind<ITestB09>().To<TestB09>().InTransientScope();

            c.Bind<ITestB10>().To<TestB10>().InTransientScope();
            c.Bind<ITestB11>().To<TestB11>().InTransientScope();
            c.Bind<ITestB12>().To<TestB12>().InTransientScope();
            c.Bind<ITestB13>().To<TestB13>().InTransientScope();
            c.Bind<ITestB14>().To<TestB14>().InTransientScope();
            c.Bind<ITestB15>().To<TestB15>().InTransientScope();
            c.Bind<ITestB16>().To<TestB16>().InTransientScope();
            c.Bind<ITestB17>().To<TestB17>().InTransientScope();
            c.Bind<ITestB18>().To<TestB18>().InTransientScope();
            c.Bind<ITestB19>().To<TestB19>().InTransientScope();

            c.Bind<ITestB20>().To<TestB20>().InTransientScope();
            c.Bind<ITestB21>().To<TestB21>().InTransientScope();
            c.Bind<ITestB22>().To<TestB22>().InTransientScope();
            c.Bind<ITestB23>().To<TestB23>().InTransientScope();
            c.Bind<ITestB24>().To<TestB24>().InTransientScope();
            c.Bind<ITestB25>().To<TestB25>().InTransientScope();
            c.Bind<ITestB26>().To<TestB26>().InTransientScope();
            c.Bind<ITestB27>().To<TestB27>().InTransientScope();
            c.Bind<ITestB28>().To<TestB28>().InTransientScope();
            c.Bind<ITestB29>().To<TestB29>().InTransientScope();

            c.Bind<ITestB30>().To<TestB30>().InTransientScope();
            c.Bind<ITestB31>().To<TestB31>().InTransientScope();
            c.Bind<ITestB32>().To<TestB32>().InTransientScope();
            c.Bind<ITestB33>().To<TestB33>().InTransientScope();
            c.Bind<ITestB34>().To<TestB34>().InTransientScope();
            c.Bind<ITestB35>().To<TestB35>().InTransientScope();
            c.Bind<ITestB36>().To<TestB36>().InTransientScope();
            c.Bind<ITestB37>().To<TestB37>().InTransientScope();
            c.Bind<ITestB38>().To<TestB38>().InTransientScope();
            c.Bind<ITestB39>().To<TestB39>().InTransientScope();

            c.Bind<ITestB40>().To<TestB40>().InTransientScope();
            c.Bind<ITestB41>().To<TestB41>().InTransientScope();
            c.Bind<ITestB42>().To<TestB42>().InTransientScope();
            c.Bind<ITestB43>().To<TestB43>().InTransientScope();
            c.Bind<ITestB44>().To<TestB44>().InTransientScope();
            c.Bind<ITestB45>().To<TestB45>().InTransientScope();
            c.Bind<ITestB46>().To<TestB46>().InTransientScope();
            c.Bind<ITestB47>().To<TestB47>().InTransientScope();
            c.Bind<ITestB48>().To<TestB48>().InTransientScope();
            c.Bind<ITestB49>().To<TestB49>().InTransientScope();

            c.Bind<ITestB>().To<TestB>().InTransientScope();

            return c;
        }
    }
}