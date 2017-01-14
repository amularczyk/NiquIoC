using DryIoc;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class SingletonTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Register<ITestA0, TestA0>(Reuse.Singleton);
            c.Register<ITestA1, TestA1>(Reuse.Singleton);
            c.Register<ITestA2, TestA2>(Reuse.Singleton);
            c.Register<ITestA3, TestA3>(Reuse.Singleton);
            c.Register<ITestA4, TestA4>(Reuse.Singleton);
            c.Register<ITestA5, TestA5>(Reuse.Singleton);
            c.Register<ITestA6, TestA6>(Reuse.Singleton);
            c.Register<ITestA7, TestA7>(Reuse.Singleton);
            c.Register<ITestA8, TestA8>(Reuse.Singleton);
            c.Register<ITestA9, TestA9>(Reuse.Singleton);
            c.Register<ITestA, TestA>(Reuse.Singleton);

            return c;
        }
    }
}