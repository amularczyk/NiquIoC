using Ninject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class SingletonTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<ITestB00>().To<TestB00>().InSingletonScope();
            c.Bind<ITestB01>().To<TestB01>().InSingletonScope();
            c.Bind<ITestB02>().To<TestB02>().InSingletonScope();
            c.Bind<ITestB03>().To<TestB03>().InSingletonScope();
            c.Bind<ITestB04>().To<TestB04>().InSingletonScope();
            c.Bind<ITestB05>().To<TestB05>().InSingletonScope();
            c.Bind<ITestB06>().To<TestB06>().InSingletonScope();
            c.Bind<ITestB07>().To<TestB07>().InSingletonScope();
            c.Bind<ITestB08>().To<TestB08>().InSingletonScope();
            c.Bind<ITestB09>().To<TestB09>().InSingletonScope();

            c.Bind<ITestB10>().To<TestB10>().InSingletonScope();
            c.Bind<ITestB11>().To<TestB11>().InSingletonScope();
            c.Bind<ITestB12>().To<TestB12>().InSingletonScope();
            c.Bind<ITestB13>().To<TestB13>().InSingletonScope();
            c.Bind<ITestB14>().To<TestB14>().InSingletonScope();
            c.Bind<ITestB15>().To<TestB15>().InSingletonScope();
            c.Bind<ITestB16>().To<TestB16>().InSingletonScope();
            c.Bind<ITestB17>().To<TestB17>().InSingletonScope();
            c.Bind<ITestB18>().To<TestB18>().InSingletonScope();
            c.Bind<ITestB19>().To<TestB19>().InSingletonScope();

            c.Bind<ITestB20>().To<TestB20>().InSingletonScope();
            c.Bind<ITestB21>().To<TestB21>().InSingletonScope();
            c.Bind<ITestB22>().To<TestB22>().InSingletonScope();
            c.Bind<ITestB23>().To<TestB23>().InSingletonScope();
            c.Bind<ITestB24>().To<TestB24>().InSingletonScope();
            c.Bind<ITestB25>().To<TestB25>().InSingletonScope();
            c.Bind<ITestB26>().To<TestB26>().InSingletonScope();
            c.Bind<ITestB27>().To<TestB27>().InSingletonScope();
            c.Bind<ITestB28>().To<TestB28>().InSingletonScope();
            c.Bind<ITestB29>().To<TestB29>().InSingletonScope();

            c.Bind<ITestB30>().To<TestB30>().InSingletonScope();
            c.Bind<ITestB31>().To<TestB31>().InSingletonScope();
            c.Bind<ITestB32>().To<TestB32>().InSingletonScope();
            c.Bind<ITestB33>().To<TestB33>().InSingletonScope();
            c.Bind<ITestB34>().To<TestB34>().InSingletonScope();
            c.Bind<ITestB35>().To<TestB35>().InSingletonScope();
            c.Bind<ITestB36>().To<TestB36>().InSingletonScope();
            c.Bind<ITestB37>().To<TestB37>().InSingletonScope();
            c.Bind<ITestB38>().To<TestB38>().InSingletonScope();
            c.Bind<ITestB39>().To<TestB39>().InSingletonScope();

            c.Bind<ITestB40>().To<TestB40>().InSingletonScope();
            c.Bind<ITestB41>().To<TestB41>().InSingletonScope();
            c.Bind<ITestB42>().To<TestB42>().InSingletonScope();
            c.Bind<ITestB43>().To<TestB43>().InSingletonScope();
            c.Bind<ITestB44>().To<TestB44>().InSingletonScope();
            c.Bind<ITestB45>().To<TestB45>().InSingletonScope();
            c.Bind<ITestB46>().To<TestB46>().InSingletonScope();
            c.Bind<ITestB47>().To<TestB47>().InSingletonScope();
            c.Bind<ITestB48>().To<TestB48>().InSingletonScope();
            c.Bind<ITestB49>().To<TestB49>().InSingletonScope();

            c.Bind<ITestB>().To<TestB>().InSingletonScope();

            return c;
        }
    }
}