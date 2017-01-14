using StructureMap;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class SingletonTestCaseC : TestCaseC
    {
        public override object Register(object container)
        {
            var c = (Container)container;

            c.Configure(x =>
            {
                x.For<ITestCa0>().Use<TestCa0>().Singleton();
                x.For<ITestCa0>().Use<TestCa0>().Singleton();
                x.For<ITestCa1>().Use<TestCa1>().Singleton();
                x.For<ITestCa2>().Use<TestCa2>().Singleton();
                x.For<ITestCa3>().Use<TestCa3>().Singleton();
                x.For<ITestCa4>().Use<TestCa4>().Singleton();
                x.For<ITestCa5>().Use<TestCa5>().Singleton();
                x.For<ITestCa6>().Use<TestCa6>().Singleton();
                x.For<ITestCa7>().Use<TestCa7>().Singleton();
                x.For<ITestCa8>().Use<TestCa8>().Singleton();
                x.For<ITestCa9>().Use<TestCa9>().Singleton();
                x.For<ITestCa10>().Use<TestCa10>().Singleton();

                x.For<ITestCb0>().Use<TestCb0>().Singleton();
                x.For<ITestCb0>().Use<TestCb0>().Singleton();
                x.For<ITestCb1>().Use<TestCb1>().Singleton();
                x.For<ITestCb2>().Use<TestCb2>().Singleton();
                x.For<ITestCb3>().Use<TestCb3>().Singleton();
                x.For<ITestCb4>().Use<TestCb4>().Singleton();
                x.For<ITestCb5>().Use<TestCb5>().Singleton();
                x.For<ITestCb6>().Use<TestCb6>().Singleton();
                x.For<ITestCb7>().Use<TestCb7>().Singleton();
                x.For<ITestCb8>().Use<TestCb8>().Singleton();
                x.For<ITestCb9>().Use<TestCb9>().Singleton();
                x.For<ITestCb10>().Use<TestCb10>().Singleton();

                x.For<ITestCc0>().Use<TestCc0>().Singleton();
                x.For<ITestCc0>().Use<TestCc0>().Singleton();
                x.For<ITestCc1>().Use<TestCc1>().Singleton();
                x.For<ITestCc2>().Use<TestCc2>().Singleton();
                x.For<ITestCc3>().Use<TestCc3>().Singleton();
                x.For<ITestCc4>().Use<TestCc4>().Singleton();
                x.For<ITestCc5>().Use<TestCc5>().Singleton();
                x.For<ITestCc6>().Use<TestCc6>().Singleton();
                x.For<ITestCc7>().Use<TestCc7>().Singleton();
                x.For<ITestCc8>().Use<TestCc8>().Singleton();
                x.For<ITestCc9>().Use<TestCc9>().Singleton();
                x.For<ITestCc10>().Use<TestCc10>().Singleton();

                x.For<ITestC>().Use<TestC>().Singleton();
            });

            return c;
        }
    }
}