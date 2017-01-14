using DryIoc;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class PerThreadTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Register<ITestCa0, TestCa0>(Reuse.InThread);
            c.Register<ITestCa1, TestCa1>(Reuse.InThread);
            c.Register<ITestCa2, TestCa2>(Reuse.InThread);
            c.Register<ITestCa3, TestCa3>(Reuse.InThread);
            c.Register<ITestCa4, TestCa4>(Reuse.InThread);
            c.Register<ITestCa5, TestCa5>(Reuse.InThread);
            c.Register<ITestCa6, TestCa6>(Reuse.InThread);
            c.Register<ITestCa7, TestCa7>(Reuse.InThread);
            c.Register<ITestCa8, TestCa8>(Reuse.InThread);
            c.Register<ITestCa9, TestCa9>(Reuse.InThread);
            c.Register<ITestCa10, TestCa10>(Reuse.InThread);

            c.Register<ITestCb0, TestCb0>(Reuse.InThread);
            c.Register<ITestCb1, TestCb1>(Reuse.InThread);
            c.Register<ITestCb2, TestCb2>(Reuse.InThread);
            c.Register<ITestCb3, TestCb3>(Reuse.InThread);
            c.Register<ITestCb4, TestCb4>(Reuse.InThread);
            c.Register<ITestCb5, TestCb5>(Reuse.InThread);
            c.Register<ITestCb6, TestCb6>(Reuse.InThread);
            c.Register<ITestCb7, TestCb7>(Reuse.InThread);
            c.Register<ITestCb8, TestCb8>(Reuse.InThread);
            c.Register<ITestCb9, TestCb9>(Reuse.InThread);
            c.Register<ITestCb10, TestCb10>(Reuse.InThread);

            c.Register<ITestCc0, TestCc0>(Reuse.InThread);
            c.Register<ITestCc1, TestCc1>(Reuse.InThread);
            c.Register<ITestCc2, TestCc2>(Reuse.InThread);
            c.Register<ITestCc3, TestCc3>(Reuse.InThread);
            c.Register<ITestCc4, TestCc4>(Reuse.InThread);
            c.Register<ITestCc5, TestCc5>(Reuse.InThread);
            c.Register<ITestCc6, TestCc6>(Reuse.InThread);
            c.Register<ITestCc7, TestCc7>(Reuse.InThread);
            c.Register<ITestCc8, TestCc8>(Reuse.InThread);
            c.Register<ITestCc9, TestCc9>(Reuse.InThread);
            c.Register<ITestCc10, TestCc10>(Reuse.InThread);

            c.Register<ITestC, TestC>(Reuse.InThread);

            return c;
        }
    }
}