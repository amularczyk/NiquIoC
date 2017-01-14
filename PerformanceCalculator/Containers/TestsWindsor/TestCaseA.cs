using Castle.MicroKernel.Registration;
using Castle.Windsor;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsWindsor
{
    public class TestCaseA : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (WindsorContainer)container;

            c.Register(Component.For<ITestA0>().ImplementedBy<TestA0>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA1>().ImplementedBy<TestA1>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA2>().ImplementedBy<TestA2>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA3>().ImplementedBy<TestA3>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA4>().ImplementedBy<TestA4>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA5>().ImplementedBy<TestA5>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA6>().ImplementedBy<TestA6>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA7>().ImplementedBy<TestA7>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA8>().ImplementedBy<TestA8>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA9>().ImplementedBy<TestA9>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA>().ImplementedBy<TestA>().LifeStyle.Singleton);

            return c;
        }

        public object TransientRegister(object container)
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

        public object PerThreadRegister(object container)
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

        public object PerHttpContextRegister(object container)
        {
            var c = (WindsorContainer)container;

            c.Register(Component.For<ITestA0>().ImplementedBy<TestA0>().LifestylePerWebRequest());
            c.Register(Component.For<ITestA1>().ImplementedBy<TestA1>().LifestylePerWebRequest());
            c.Register(Component.For<ITestA2>().ImplementedBy<TestA2>().LifestylePerWebRequest());
            c.Register(Component.For<ITestA3>().ImplementedBy<TestA3>().LifestylePerWebRequest());
            c.Register(Component.For<ITestA4>().ImplementedBy<TestA4>().LifestylePerWebRequest());
            c.Register(Component.For<ITestA5>().ImplementedBy<TestA5>().LifestylePerWebRequest());
            c.Register(Component.For<ITestA6>().ImplementedBy<TestA6>().LifestylePerWebRequest());
            c.Register(Component.For<ITestA7>().ImplementedBy<TestA7>().LifestylePerWebRequest());
            c.Register(Component.For<ITestA8>().ImplementedBy<TestA8>().LifestylePerWebRequest());
            c.Register(Component.For<ITestA9>().ImplementedBy<TestA9>().LifestylePerWebRequest());
            c.Register(Component.For<ITestA>().ImplementedBy<TestA>().LifestylePerWebRequest());
            //c.Register(Component.For<ITestA0>().ImplementedBy<TestA0>().LifeStyle.PerWebRequest);
            //c.Register(Component.For<ITestA1>().ImplementedBy<TestA1>().LifeStyle.PerWebRequest);
            //c.Register(Component.For<ITestA2>().ImplementedBy<TestA2>().LifeStyle.PerWebRequest);
            //c.Register(Component.For<ITestA3>().ImplementedBy<TestA3>().LifeStyle.PerWebRequest);
            //c.Register(Component.For<ITestA4>().ImplementedBy<TestA4>().LifeStyle.PerWebRequest);
            //c.Register(Component.For<ITestA5>().ImplementedBy<TestA5>().LifeStyle.PerWebRequest);
            //c.Register(Component.For<ITestA6>().ImplementedBy<TestA6>().LifeStyle.PerWebRequest);
            //c.Register(Component.For<ITestA7>().ImplementedBy<TestA7>().LifeStyle.PerWebRequest);
            //c.Register(Component.For<ITestA8>().ImplementedBy<TestA8>().LifeStyle.PerWebRequest);
            //c.Register(Component.For<ITestA9>().ImplementedBy<TestA9>().LifeStyle.PerWebRequest);
            //c.Register(Component.For<ITestA>().ImplementedBy<TestA>().LifeStyle.PerWebRequest);

            return c;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (WindsorContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestA>();
            }
        }
    }
}