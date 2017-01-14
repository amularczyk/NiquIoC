using Microsoft.Practices.Unity;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class PerThreadTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (UnityContainer)container;

            c.RegisterType<ITestA0, TestA0>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA1, TestA1>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA2, TestA2>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA3, TestA3>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA4, TestA4>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA5, TestA5>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA6, TestA6>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA7, TestA7>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA8, TestA8>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA9, TestA9>(new PerThreadLifetimeManager());
            c.RegisterType<ITestA, TestA>(new PerThreadLifetimeManager());

            return c;
        }
    }
}