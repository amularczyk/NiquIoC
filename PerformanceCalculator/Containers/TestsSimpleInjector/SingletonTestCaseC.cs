using SimpleInjector;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class SingletonTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Register<ITestCa0, TestCa0>(Lifestyle.Singleton);
            c.Register<ITestCa1, TestCa1>(Lifestyle.Singleton);
            c.Register<ITestCa2, TestCa2>(Lifestyle.Singleton);
            c.Register<ITestCa3, TestCa3>(Lifestyle.Singleton);
            c.Register<ITestCa4, TestCa4>(Lifestyle.Singleton);
            c.Register<ITestCa5, TestCa5>(Lifestyle.Singleton);
            c.Register<ITestCa6, TestCa6>(Lifestyle.Singleton);
            c.Register<ITestCa7, TestCa7>(Lifestyle.Singleton);
            c.Register<ITestCa8, TestCa8>(Lifestyle.Singleton);
            c.Register<ITestCa9, TestCa9>(Lifestyle.Singleton);
            c.Register<ITestCa10, TestCa10>(Lifestyle.Singleton);

            c.Register<ITestCb0, TestCb0>(Lifestyle.Singleton);
            c.Register<ITestCb1, TestCb1>(Lifestyle.Singleton);
            c.Register<ITestCb2, TestCb2>(Lifestyle.Singleton);
            c.Register<ITestCb3, TestCb3>(Lifestyle.Singleton);
            c.Register<ITestCb4, TestCb4>(Lifestyle.Singleton);
            c.Register<ITestCb5, TestCb5>(Lifestyle.Singleton);
            c.Register<ITestCb6, TestCb6>(Lifestyle.Singleton);
            c.Register<ITestCb7, TestCb7>(Lifestyle.Singleton);
            c.Register<ITestCb8, TestCb8>(Lifestyle.Singleton);
            c.Register<ITestCb9, TestCb9>(Lifestyle.Singleton);
            c.Register<ITestCb10, TestCb10>(Lifestyle.Singleton);

            c.Register<ITestCc0, TestCc0>(Lifestyle.Singleton);
            c.Register<ITestCc1, TestCc1>(Lifestyle.Singleton);
            c.Register<ITestCc2, TestCc2>(Lifestyle.Singleton);
            c.Register<ITestCc3, TestCc3>(Lifestyle.Singleton);
            c.Register<ITestCc4, TestCc4>(Lifestyle.Singleton);
            c.Register<ITestCc5, TestCc5>(Lifestyle.Singleton);
            c.Register<ITestCc6, TestCc6>(Lifestyle.Singleton);
            c.Register<ITestCc7, TestCc7>(Lifestyle.Singleton);
            c.Register<ITestCc8, TestCc8>(Lifestyle.Singleton);
            c.Register<ITestCc9, TestCc9>(Lifestyle.Singleton);
            c.Register<ITestCc10, TestCc10>(Lifestyle.Singleton);

            c.Register<ITestC, TestC>(Lifestyle.Singleton);

            return c;
        }
    }
}