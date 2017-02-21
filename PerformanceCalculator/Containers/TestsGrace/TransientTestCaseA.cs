using Grace.DependencyInjection;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class TransientTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (DependencyInjectionContainer)container;

            c.Configure(x =>
            {
                x.Export<TestA0>().As<ITestA0>();
                x.Export<TestA0>().As<ITestA0>();
                x.Export<TestA1>().As<ITestA1>();
                x.Export<TestA2>().As<ITestA2>();
                x.Export<TestA3>().As<ITestA3>();
                x.Export<TestA4>().As<ITestA4>();
                x.Export<TestA5>().As<ITestA5>();
                x.Export<TestA6>().As<ITestA6>();
                x.Export<TestA7>().As<ITestA7>();
                x.Export<TestA8>().As<ITestA8>();
                x.Export<TestA9>().As<ITestA9>();
                x.Export<TestA>().As<ITestA>();
            });

            return c;
        }
    }
}