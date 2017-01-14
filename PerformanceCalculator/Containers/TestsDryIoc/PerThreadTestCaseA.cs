using DryIoc;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class PerThreadTestCaseA : TestCaseA
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Register<ITestA0, TestA0>(Reuse.InThread);
            c.Register<ITestA1, TestA1>(Reuse.InThread);
            c.Register<ITestA2, TestA2>(Reuse.InThread);
            c.Register<ITestA3, TestA3>(Reuse.InThread);
            c.Register<ITestA4, TestA4>(Reuse.InThread);
            c.Register<ITestA5, TestA5>(Reuse.InThread);
            c.Register<ITestA6, TestA6>(Reuse.InThread);
            c.Register<ITestA7, TestA7>(Reuse.InThread);
            c.Register<ITestA8, TestA8>(Reuse.InThread);
            c.Register<ITestA9, TestA9>(Reuse.InThread);
            c.Register<ITestA, TestA>(Reuse.InThread);

            return c;
        }
    }
}