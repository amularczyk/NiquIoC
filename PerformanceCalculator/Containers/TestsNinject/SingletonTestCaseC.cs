using Ninject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class SingletonTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<ITestCa0>().To<TestCa0>().InSingletonScope();
            c.Bind<ITestCa1>().To<TestCa1>().InSingletonScope();
            c.Bind<ITestCa2>().To<TestCa2>().InSingletonScope();
            c.Bind<ITestCa3>().To<TestCa3>().InSingletonScope();
            c.Bind<ITestCa4>().To<TestCa4>().InSingletonScope();
            c.Bind<ITestCa5>().To<TestCa5>().InSingletonScope();
            c.Bind<ITestCa6>().To<TestCa6>().InSingletonScope();
            c.Bind<ITestCa7>().To<TestCa7>().InSingletonScope();
            c.Bind<ITestCa8>().To<TestCa8>().InSingletonScope();
            c.Bind<ITestCa9>().To<TestCa9>().InSingletonScope();
            c.Bind<ITestCa10>().To<TestCa10>().InSingletonScope();

            c.Bind<ITestCb0>().To<TestCb0>().InSingletonScope();
            c.Bind<ITestCb1>().To<TestCb1>().InSingletonScope();
            c.Bind<ITestCb2>().To<TestCb2>().InSingletonScope();
            c.Bind<ITestCb3>().To<TestCb3>().InSingletonScope();
            c.Bind<ITestCb4>().To<TestCb4>().InSingletonScope();
            c.Bind<ITestCb5>().To<TestCb5>().InSingletonScope();
            c.Bind<ITestCb6>().To<TestCb6>().InSingletonScope();
            c.Bind<ITestCb7>().To<TestCb7>().InSingletonScope();
            c.Bind<ITestCb8>().To<TestCb8>().InSingletonScope();
            c.Bind<ITestCb9>().To<TestCb9>().InSingletonScope();
            c.Bind<ITestCb10>().To<TestCb10>().InSingletonScope();

            c.Bind<ITestCc0>().To<TestCc0>().InSingletonScope();
            c.Bind<ITestCc1>().To<TestCc1>().InSingletonScope();
            c.Bind<ITestCc2>().To<TestCc2>().InSingletonScope();
            c.Bind<ITestCc3>().To<TestCc3>().InSingletonScope();
            c.Bind<ITestCc4>().To<TestCc4>().InSingletonScope();
            c.Bind<ITestCc5>().To<TestCc5>().InSingletonScope();
            c.Bind<ITestCc6>().To<TestCc6>().InSingletonScope();
            c.Bind<ITestCc7>().To<TestCc7>().InSingletonScope();
            c.Bind<ITestCc8>().To<TestCc8>().InSingletonScope();
            c.Bind<ITestCc9>().To<TestCc9>().InSingletonScope();
            c.Bind<ITestCc10>().To<TestCc10>().InSingletonScope();

            c.Bind<ITestC>().To<TestC>().InSingletonScope();

            return c;
        }
    }
}