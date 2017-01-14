using Microsoft.Practices.Unity;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class PerThreadTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (UnityContainer)container;

            c.RegisterType<ITestCa0, TestCa0>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCa1, TestCa1>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCa2, TestCa2>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCa3, TestCa3>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCa4, TestCa4>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCa5, TestCa5>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCa6, TestCa6>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCa7, TestCa7>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCa8, TestCa8>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCa9, TestCa9>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCa10, TestCa10>(new PerThreadLifetimeManager());

            c.RegisterType<ITestCb0, TestCb0>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCb1, TestCb1>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCb2, TestCb2>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCb3, TestCb3>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCb4, TestCb4>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCb5, TestCb5>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCb6, TestCb6>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCb7, TestCb7>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCb8, TestCb8>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCb9, TestCb9>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCb10, TestCb10>(new PerThreadLifetimeManager());

            c.RegisterType<ITestCc0, TestCc0>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCc1, TestCc1>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCc2, TestCc2>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCc3, TestCc3>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCc4, TestCc4>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCc5, TestCc5>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCc6, TestCc6>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCc7, TestCc7>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCc8, TestCc8>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCc9, TestCc9>(new PerThreadLifetimeManager());
            c.RegisterType<ITestCc10, TestCc10>(new PerThreadLifetimeManager());

            c.RegisterType<ITestC, TestC>(new PerThreadLifetimeManager());

            return c;
        }
    }
}