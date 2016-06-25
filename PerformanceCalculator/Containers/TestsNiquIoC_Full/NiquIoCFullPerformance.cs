using System.Diagnostics;
using NiquIoC;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class NiquIoCFullPerformance : IPerformance
    {
        public TestResult DoTest(ITestCase testCase, int testCasesNumber, bool singleton)
        {
            var result = new TestResult { Singleton = singleton, TestCasesNumber = testCasesNumber };
            var sw = new Stopwatch();

            var c = new Container();
            if (singleton)
            {
                sw.Start();
                c = (Container)testCase.SingletonRegister(c);
                sw.Stop();
            }
            else
            {
                sw.Start();
                c = (Container)testCase.TransientRegister(c);
                sw.Stop();
            }
            result.RegisterTime = sw.ElapsedMilliseconds;

            sw.Reset();
            sw.Start();
            testCase.Resolve(c, testCasesNumber, singleton);
            sw.Stop();
            result.ResolveTime = sw.ElapsedMilliseconds;

            //c.Dispose();

            return result;
        }

        public TestResult DoTestA(int testCasesNumber, bool singleton)
        {
            return DoTest(new TestsAutofac.TestCaseA(), testCasesNumber, singleton);
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