using Microsoft.Practices.Unity;
using Ninject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class SingletonTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<ITestA0>().To<TestA0>().InSingletonScope();
            c.Bind<ITestA1>().To<TestA1>().InSingletonScope();
            c.Bind<ITestA2>().To<TestA2>().InSingletonScope();
            c.Bind<ITestA3>().To<TestA3>().InSingletonScope();
            c.Bind<ITestA4>().To<TestA4>().InSingletonScope();
            c.Bind<ITestA5>().To<TestA5>().InSingletonScope();
            c.Bind<ITestA6>().To<TestA6>().InSingletonScope();
            c.Bind<ITestA7>().To<TestA7>().InSingletonScope();
            c.Bind<ITestA8>().To<TestA8>().InSingletonScope();
            c.Bind<ITestA9>().To<TestA9>().InSingletonScope();
            c.Bind<ITestA>().To<TestA>().InSingletonScope();

            return c;
        }
    }
}