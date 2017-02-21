using Ninject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class TransientTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<ITestA0>().To<TestA0>().InTransientScope();
            c.Bind<ITestA1>().To<TestA1>().InTransientScope();
            c.Bind<ITestA2>().To<TestA2>().InTransientScope();
            c.Bind<ITestA3>().To<TestA3>().InTransientScope();
            c.Bind<ITestA4>().To<TestA4>().InTransientScope();
            c.Bind<ITestA5>().To<TestA5>().InTransientScope();
            c.Bind<ITestA6>().To<TestA6>().InTransientScope();
            c.Bind<ITestA7>().To<TestA7>().InTransientScope();
            c.Bind<ITestA8>().To<TestA8>().InTransientScope();
            c.Bind<ITestA9>().To<TestA9>().InTransientScope();
            c.Bind<ITestA>().To<TestA>().InTransientScope();

            return c;
        }
    }
}