using Castle.MicroKernel.Registration;
using Castle.Windsor;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsWindsor
{
    public class TransientTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (WindsorContainer)container;

            c.Register(Component.For<ITestA0>().ImplementedBy<TestA0>().LifeStyle.Transient);
            c.Register(Component.For<ITestA1>().ImplementedBy<TestA1>().LifeStyle.Transient);
            c.Register(Component.For<ITestA2>().ImplementedBy<TestA2>().LifeStyle.Transient);
            c.Register(Component.For<ITestA3>().ImplementedBy<TestA3>().LifeStyle.Transient);
            c.Register(Component.For<ITestA4>().ImplementedBy<TestA4>().LifeStyle.Transient);
            c.Register(Component.For<ITestA5>().ImplementedBy<TestA5>().LifeStyle.Transient);
            c.Register(Component.For<ITestA6>().ImplementedBy<TestA6>().LifeStyle.Transient);
            c.Register(Component.For<ITestA7>().ImplementedBy<TestA7>().LifeStyle.Transient);
            c.Register(Component.For<ITestA8>().ImplementedBy<TestA8>().LifeStyle.Transient);
            c.Register(Component.For<ITestA9>().ImplementedBy<TestA9>().LifeStyle.Transient);
            c.Register(Component.For<ITestA>().ImplementedBy<TestA>().LifeStyle.Transient);

            return c;
        }
    }
}