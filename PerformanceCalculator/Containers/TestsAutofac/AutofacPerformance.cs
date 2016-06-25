using System.Diagnostics;
using Autofac;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class AutofacPerformance : IPerformance
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

        public TestResult DoTestA(int testCasesNumber, bool singleton)
        {
            return DoTest(new TestCaseA(), testCasesNumber, singleton);
        }

        public TestResult DoTestB(int testCasesNumber, bool singleton)
        {
            return DoTest(new TestCaseB(), testCasesNumber, singleton);
        }

        public TestResult DoTestC(int testCasesNumber, bool singleton)
        {
            return DoTest(new TestCaseC(), testCasesNumber, singleton);
        }
    }
}