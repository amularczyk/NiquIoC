using System.Diagnostics;
using Autofac;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator
{
    internal abstract class Performance : IPerformance
    {
        public TestResult DoTest(ITestCase testCase, int testCasesNumber, bool singleton)
        {
            var result = new TestResult { Singleton = singleton, TestCasesNumber = testCasesNumber };
            var sw = new Stopwatch();

            var cb = new ContainerBuilder();
            IContainer c;
            if (singleton)
            {
                sw.Start();
                c = (IContainer)testCase.SingletonRegister(cb);
                sw.Stop();
            }
            else
            {
                sw.Start();
                c = (IContainer)testCase.TransientRegister(cb);
                sw.Stop();
            }
            result.RegisterTime = sw.ElapsedMilliseconds;

            sw.Reset();
            sw.Start();
            testCase.Resolve(c, testCasesNumber, singleton);
            sw.Stop();
            result.ResolveTime = sw.ElapsedMilliseconds;

            c.Dispose();

            return result;
        }

        public abstract TestResult DoTestA(int testCasesNumber, bool singleton);

        public abstract TestResult DoTestB(int testCasesNumber, bool singleton);

        public abstract TestResult DoTestC(int testCasesNumber, bool singleton);
    }
}