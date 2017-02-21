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
                x.Export<ITestA0>().As<TestA0>();
                x.Export<ITestA0>().As<TestA0>();
                x.Export<ITestA1>().As<TestA1>();
                x.Export<ITestA2>().As<TestA2>();
                x.Export<ITestA3>().As<TestA3>();
                x.Export<ITestA4>().As<TestA4>();
                x.Export<ITestA5>().As<TestA5>();
                x.Export<ITestA6>().As<TestA6>();
                x.Export<ITestA7>().As<TestA7>();
                x.Export<ITestA8>().As<TestA8>();
                x.Export<ITestA9>().As<TestA9>();
                x.Export<ITestA>().As<TestA>();
            });

            return c;
        }
    }
}