using SimpleInjector;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class SingletonTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Register<ITestA0, TestA0>(Lifestyle.Singleton);
            c.Register<ITestA1, TestA1>(Lifestyle.Singleton);
            c.Register<ITestA2, TestA2>(Lifestyle.Singleton);
            c.Register<ITestA3, TestA3>(Lifestyle.Singleton);
            c.Register<ITestA4, TestA4>(Lifestyle.Singleton);
            c.Register<ITestA5, TestA5>(Lifestyle.Singleton);
            c.Register<ITestA6, TestA6>(Lifestyle.Singleton);
            c.Register<ITestA7, TestA7>(Lifestyle.Singleton);
            c.Register<ITestA8, TestA8>(Lifestyle.Singleton);
            c.Register<ITestA9, TestA9>(Lifestyle.Singleton);
            c.Register<ITestA, TestA>(Lifestyle.Singleton);

            return c;
        }
    }
}