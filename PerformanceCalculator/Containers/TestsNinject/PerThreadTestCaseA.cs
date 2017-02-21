using Ninject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class PerThreadTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<ITestA0>().To<TestA0>().InThreadScope();
            c.Bind<ITestA1>().To<TestA1>().InThreadScope();
            c.Bind<ITestA2>().To<TestA2>().InThreadScope();
            c.Bind<ITestA3>().To<TestA3>().InThreadScope();
            c.Bind<ITestA4>().To<TestA4>().InThreadScope();
            c.Bind<ITestA5>().To<TestA5>().InThreadScope();
            c.Bind<ITestA6>().To<TestA6>().InThreadScope();
            c.Bind<ITestA7>().To<TestA7>().InThreadScope();
            c.Bind<ITestA8>().To<TestA8>().InThreadScope();
            c.Bind<ITestA9>().To<TestA9>().InThreadScope();
            c.Bind<ITestA>().To<TestA>().InThreadScope();

            return c;
        }
    }
}