using Castle.MicroKernel.Registration;
using Castle.Windsor;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsWindsor
{
    public class TestCaseC : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (WindsorContainer)container;

            c.Register(Component.For<ITestCa0>().ImplementedBy<TestCa0>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa1>().ImplementedBy<TestCa1>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa2>().ImplementedBy<TestCa2>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa3>().ImplementedBy<TestCa3>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa4>().ImplementedBy<TestCa4>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa5>().ImplementedBy<TestCa5>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa6>().ImplementedBy<TestCa6>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa7>().ImplementedBy<TestCa7>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa8>().ImplementedBy<TestCa8>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa9>().ImplementedBy<TestCa9>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa10>().ImplementedBy<TestCa10>().LifeStyle.Singleton);

            c.Register(Component.For<ITestCb0>().ImplementedBy<TestCb0>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb1>().ImplementedBy<TestCb1>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb2>().ImplementedBy<TestCb2>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb3>().ImplementedBy<TestCb3>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb4>().ImplementedBy<TestCb4>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb5>().ImplementedBy<TestCb5>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb6>().ImplementedBy<TestCb6>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb7>().ImplementedBy<TestCb7>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb8>().ImplementedBy<TestCb8>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb9>().ImplementedBy<TestCb9>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb10>().ImplementedBy<TestCb10>().LifeStyle.Singleton);

            c.Register(Component.For<ITestCc0>().ImplementedBy<TestCc0>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc1>().ImplementedBy<TestCc1>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc2>().ImplementedBy<TestCc2>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc3>().ImplementedBy<TestCc3>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc4>().ImplementedBy<TestCc4>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc5>().ImplementedBy<TestCc5>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc6>().ImplementedBy<TestCc6>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc7>().ImplementedBy<TestCc7>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc8>().ImplementedBy<TestCc8>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc9>().ImplementedBy<TestCc9>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc10>().ImplementedBy<TestCc10>().LifeStyle.Singleton);

            c.Register(Component.For<ITestC>().ImplementedBy<TestC>().LifeStyle.Singleton);

            return c;
        }

        public object TransientRegister(object container)
        {
            var c = (WindsorContainer)container;

            c.Register(Component.For<ITestCa0>().ImplementedBy<TestCa0>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa1>().ImplementedBy<TestCa1>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa2>().ImplementedBy<TestCa2>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa3>().ImplementedBy<TestCa3>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa4>().ImplementedBy<TestCa4>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa5>().ImplementedBy<TestCa5>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa6>().ImplementedBy<TestCa6>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa7>().ImplementedBy<TestCa7>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa8>().ImplementedBy<TestCa8>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa9>().ImplementedBy<TestCa9>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa10>().ImplementedBy<TestCa10>().LifeStyle.Transient);

            c.Register(Component.For<ITestCb0>().ImplementedBy<TestCb0>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb1>().ImplementedBy<TestCb1>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb2>().ImplementedBy<TestCb2>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb3>().ImplementedBy<TestCb3>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb4>().ImplementedBy<TestCb4>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb5>().ImplementedBy<TestCb5>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb6>().ImplementedBy<TestCb6>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb7>().ImplementedBy<TestCb7>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb8>().ImplementedBy<TestCb8>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb9>().ImplementedBy<TestCb9>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb10>().ImplementedBy<TestCb10>().LifeStyle.Transient);

            c.Register(Component.For<ITestCc0>().ImplementedBy<TestCc0>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc1>().ImplementedBy<TestCc1>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc2>().ImplementedBy<TestCc2>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc3>().ImplementedBy<TestCc3>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc4>().ImplementedBy<TestCc4>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc5>().ImplementedBy<TestCc5>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc6>().ImplementedBy<TestCc6>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc7>().ImplementedBy<TestCc7>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc8>().ImplementedBy<TestCc8>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc9>().ImplementedBy<TestCc9>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc10>().ImplementedBy<TestCc10>().LifeStyle.Transient);

            c.Register(Component.For<ITestC>().ImplementedBy<TestC>().LifeStyle.Transient);

            return c;
        }

        public object PerThreadRegister(object container)
        {
            var c = (WindsorContainer)container;

            c.Register(Component.For<ITestCa0>().ImplementedBy<TestCa0>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCa1>().ImplementedBy<TestCa1>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCa2>().ImplementedBy<TestCa2>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCa3>().ImplementedBy<TestCa3>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCa4>().ImplementedBy<TestCa4>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCa5>().ImplementedBy<TestCa5>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCa6>().ImplementedBy<TestCa6>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCa7>().ImplementedBy<TestCa7>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCa8>().ImplementedBy<TestCa8>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCa9>().ImplementedBy<TestCa9>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCa10>().ImplementedBy<TestCa10>().LifeStyle.PerThread);

            c.Register(Component.For<ITestCb0>().ImplementedBy<TestCb0>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCb1>().ImplementedBy<TestCb1>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCb2>().ImplementedBy<TestCb2>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCb3>().ImplementedBy<TestCb3>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCb4>().ImplementedBy<TestCb4>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCb5>().ImplementedBy<TestCb5>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCb6>().ImplementedBy<TestCb6>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCb7>().ImplementedBy<TestCb7>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCb8>().ImplementedBy<TestCb8>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCb9>().ImplementedBy<TestCb9>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCb10>().ImplementedBy<TestCb10>().LifeStyle.PerThread);

            c.Register(Component.For<ITestCc0>().ImplementedBy<TestCc0>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCc1>().ImplementedBy<TestCc1>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCc2>().ImplementedBy<TestCc2>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCc3>().ImplementedBy<TestCc3>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCc4>().ImplementedBy<TestCc4>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCc5>().ImplementedBy<TestCc5>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCc6>().ImplementedBy<TestCc6>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCc7>().ImplementedBy<TestCc7>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCc8>().ImplementedBy<TestCc8>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCc9>().ImplementedBy<TestCc9>().LifeStyle.PerThread);
            c.Register(Component.For<ITestCc10>().ImplementedBy<TestCc10>().LifeStyle.PerThread);

            c.Register(Component.For<ITestC>().ImplementedBy<TestC>().LifeStyle.PerThread);

            return c;
        }

        public object PerHttpContextRegister(object container)
        {
            var c = (WindsorContainer)container;

            c.Register(Component.For<ITestCa0>().ImplementedBy<TestCa0>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCa1>().ImplementedBy<TestCa1>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCa2>().ImplementedBy<TestCa2>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCa3>().ImplementedBy<TestCa3>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCa4>().ImplementedBy<TestCa4>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCa5>().ImplementedBy<TestCa5>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCa6>().ImplementedBy<TestCa6>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCa7>().ImplementedBy<TestCa7>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCa8>().ImplementedBy<TestCa8>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCa9>().ImplementedBy<TestCa9>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCa10>().ImplementedBy<TestCa10>().LifeStyle.PerWebRequest);

            c.Register(Component.For<ITestCb0>().ImplementedBy<TestCb0>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCb1>().ImplementedBy<TestCb1>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCb2>().ImplementedBy<TestCb2>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCb3>().ImplementedBy<TestCb3>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCb4>().ImplementedBy<TestCb4>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCb5>().ImplementedBy<TestCb5>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCb6>().ImplementedBy<TestCb6>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCb7>().ImplementedBy<TestCb7>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCb8>().ImplementedBy<TestCb8>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCb9>().ImplementedBy<TestCb9>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCb10>().ImplementedBy<TestCb10>().LifeStyle.PerWebRequest);

            c.Register(Component.For<ITestCc0>().ImplementedBy<TestCc0>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCc1>().ImplementedBy<TestCc1>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCc2>().ImplementedBy<TestCc2>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCc3>().ImplementedBy<TestCc3>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCc4>().ImplementedBy<TestCc4>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCc5>().ImplementedBy<TestCc5>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCc6>().ImplementedBy<TestCc6>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCc7>().ImplementedBy<TestCc7>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCc8>().ImplementedBy<TestCc8>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCc9>().ImplementedBy<TestCc9>().LifeStyle.PerWebRequest);
            c.Register(Component.For<ITestCc10>().ImplementedBy<TestCc10>().LifeStyle.PerWebRequest);

            c.Register(Component.For<ITestC>().ImplementedBy<TestC>().LifeStyle.PerWebRequest);

            return c;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (WindsorContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestC>();
            }
        }
    }
}