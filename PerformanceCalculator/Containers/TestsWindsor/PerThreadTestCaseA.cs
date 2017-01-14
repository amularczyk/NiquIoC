using Castle.MicroKernel.Registration;
using Castle.Windsor;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsWindsor
{
    public class PerThreadTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (WindsorContainer)container;

            c.Register(Component.For<ITestA0>().ImplementedBy<TestA0>().LifeStyle.PerThread);
            c.Register(Component.For<ITestA1>().ImplementedBy<TestA1>().LifeStyle.PerThread);
            c.Register(Component.For<ITestA2>().ImplementedBy<TestA2>().LifeStyle.PerThread);
            c.Register(Component.For<ITestA3>().ImplementedBy<TestA3>().LifeStyle.PerThread);
            c.Register(Component.For<ITestA4>().ImplementedBy<TestA4>().LifeStyle.PerThread);
            c.Register(Component.For<ITestA5>().ImplementedBy<TestA5>().LifeStyle.PerThread);
            c.Register(Component.For<ITestA6>().ImplementedBy<TestA6>().LifeStyle.PerThread);
            c.Register(Component.For<ITestA7>().ImplementedBy<TestA7>().LifeStyle.PerThread);
            c.Register(Component.For<ITestA8>().ImplementedBy<TestA8>().LifeStyle.PerThread);
            c.Register(Component.For<ITestA9>().ImplementedBy<TestA9>().LifeStyle.PerThread);
            c.Register(Component.For<ITestA>().ImplementedBy<TestA>().LifeStyle.PerThread);

            return c;
        }
    }
}