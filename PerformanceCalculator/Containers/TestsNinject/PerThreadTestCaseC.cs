using Ninject;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class PerThreadTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<ITestCa0>().To<TestCa0>().InThreadScope();
            c.Bind<ITestCa1>().To<TestCa1>().InThreadScope();
            c.Bind<ITestCa2>().To<TestCa2>().InThreadScope();
            c.Bind<ITestCa3>().To<TestCa3>().InThreadScope();
            c.Bind<ITestCa4>().To<TestCa4>().InThreadScope();
            c.Bind<ITestCa5>().To<TestCa5>().InThreadScope();
            c.Bind<ITestCa6>().To<TestCa6>().InThreadScope();
            c.Bind<ITestCa7>().To<TestCa7>().InThreadScope();
            c.Bind<ITestCa8>().To<TestCa8>().InThreadScope();
            c.Bind<ITestCa9>().To<TestCa9>().InThreadScope();
            c.Bind<ITestCa10>().To<TestCa10>().InThreadScope();

            c.Bind<ITestCb0>().To<TestCb0>().InThreadScope();
            c.Bind<ITestCb1>().To<TestCb1>().InThreadScope();
            c.Bind<ITestCb2>().To<TestCb2>().InThreadScope();
            c.Bind<ITestCb3>().To<TestCb3>().InThreadScope();
            c.Bind<ITestCb4>().To<TestCb4>().InThreadScope();
            c.Bind<ITestCb5>().To<TestCb5>().InThreadScope();
            c.Bind<ITestCb6>().To<TestCb6>().InThreadScope();
            c.Bind<ITestCb7>().To<TestCb7>().InThreadScope();
            c.Bind<ITestCb8>().To<TestCb8>().InThreadScope();
            c.Bind<ITestCb9>().To<TestCb9>().InThreadScope();
            c.Bind<ITestCb10>().To<TestCb10>().InThreadScope();

            c.Bind<ITestCc0>().To<TestCc0>().InThreadScope();
            c.Bind<ITestCc1>().To<TestCc1>().InThreadScope();
            c.Bind<ITestCc2>().To<TestCc2>().InThreadScope();
            c.Bind<ITestCc3>().To<TestCc3>().InThreadScope();
            c.Bind<ITestCc4>().To<TestCc4>().InThreadScope();
            c.Bind<ITestCc5>().To<TestCc5>().InThreadScope();
            c.Bind<ITestCc6>().To<TestCc6>().InThreadScope();
            c.Bind<ITestCc7>().To<TestCc7>().InThreadScope();
            c.Bind<ITestCc8>().To<TestCc8>().InThreadScope();
            c.Bind<ITestCc9>().To<TestCc9>().InThreadScope();
            c.Bind<ITestCc10>().To<TestCc10>().InThreadScope();

            c.Bind<ITestC>().To<TestC>().InThreadScope();

            return c;
        }
    }
}