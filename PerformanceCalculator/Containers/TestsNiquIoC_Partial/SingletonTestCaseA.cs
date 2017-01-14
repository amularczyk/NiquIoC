using NiquIoC;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Partial
{
    public class SingletonTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.RegisterType<ITestA0, TestA0>().AsSingleton();
            c.RegisterType<ITestA1, TestA1>().AsSingleton();
            c.RegisterType<ITestA2, TestA2>().AsSingleton();
            c.RegisterType<ITestA3, TestA3>().AsSingleton();
            c.RegisterType<ITestA4, TestA4>().AsSingleton();
            c.RegisterType<ITestA5, TestA5>().AsSingleton();
            c.RegisterType<ITestA6, TestA6>().AsSingleton();
            c.RegisterType<ITestA7, TestA7>().AsSingleton();
            c.RegisterType<ITestA8, TestA8>().AsSingleton();
            c.RegisterType<ITestA9, TestA9>().AsSingleton();
            c.RegisterType<ITestA, TestA>().AsSingleton();

            return c;
        }
    }
}