using Ninject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class TransientTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<ITestCa0>().To<TestCa0>().InTransientScope();
            c.Bind<ITestCa1>().To<TestCa1>().InTransientScope();
            c.Bind<ITestCa2>().To<TestCa2>().InTransientScope();
            c.Bind<ITestCa3>().To<TestCa3>().InTransientScope();
            c.Bind<ITestCa4>().To<TestCa4>().InTransientScope();
            c.Bind<ITestCa5>().To<TestCa5>().InTransientScope();
            c.Bind<ITestCa6>().To<TestCa6>().InTransientScope();
            c.Bind<ITestCa7>().To<TestCa7>().InTransientScope();
            c.Bind<ITestCa8>().To<TestCa8>().InTransientScope();
            c.Bind<ITestCa9>().To<TestCa9>().InTransientScope();
            c.Bind<ITestCa10>().To<TestCa10>().InTransientScope();

            c.Bind<ITestCb0>().To<TestCb0>().InTransientScope();
            c.Bind<ITestCb1>().To<TestCb1>().InTransientScope();
            c.Bind<ITestCb2>().To<TestCb2>().InTransientScope();
            c.Bind<ITestCb3>().To<TestCb3>().InTransientScope();
            c.Bind<ITestCb4>().To<TestCb4>().InTransientScope();
            c.Bind<ITestCb5>().To<TestCb5>().InTransientScope();
            c.Bind<ITestCb6>().To<TestCb6>().InTransientScope();
            c.Bind<ITestCb7>().To<TestCb7>().InTransientScope();
            c.Bind<ITestCb8>().To<TestCb8>().InTransientScope();
            c.Bind<ITestCb9>().To<TestCb9>().InTransientScope();
            c.Bind<ITestCb10>().To<TestCb10>().InTransientScope();

            c.Bind<ITestCc0>().To<TestCc0>().InTransientScope();
            c.Bind<ITestCc1>().To<TestCc1>().InTransientScope();
            c.Bind<ITestCc2>().To<TestCc2>().InTransientScope();
            c.Bind<ITestCc3>().To<TestCc3>().InTransientScope();
            c.Bind<ITestCc4>().To<TestCc4>().InTransientScope();
            c.Bind<ITestCc5>().To<TestCc5>().InTransientScope();
            c.Bind<ITestCc6>().To<TestCc6>().InTransientScope();
            c.Bind<ITestCc7>().To<TestCc7>().InTransientScope();
            c.Bind<ITestCc8>().To<TestCc8>().InTransientScope();
            c.Bind<ITestCc9>().To<TestCc9>().InTransientScope();
            c.Bind<ITestCc10>().To<TestCc10>().InTransientScope();

            c.Bind<ITestC>().To<TestC>().InTransientScope();

            return c;
        }
    }
}