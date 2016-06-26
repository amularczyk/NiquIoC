using System.Diagnostics;
using Microsoft.Practices.Unity;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class UnityPerformance : Performance
    {
        public override TestResult DoTest(ITestCase testCase, int testCasesNumber, bool singleton)
        {
            var result = new TestResult { Singleton = singleton, TestCasesNumber = testCasesNumber };
            var sw = new Stopwatch();

            var c = new UnityContainer();
            if (singleton)
            {
                sw.Start();
                c = (UnityContainer)testCase.SingletonRegister(c);
                sw.Stop();
            }
            else
            {
                sw.Start();
                c = (UnityContainer)testCase.TransientRegister(c);
                sw.Stop();
            }
            result.RegisterTime = sw.ElapsedMilliseconds;

            sw.Reset();
            result.ResolveTime = DoResolve(sw, testCase, c, testCasesNumber, singleton);

            c.Dispose();

            return result;
        }

        public override TestResult DoTestA(int testCasesNumber, bool singleton)
        {
            return DoTest(new TestCaseA(), testCasesNumber, singleton);
        }

        public override TestResult DoTestB(int testCasesNumber, bool singleton)
        {
            return DoTest(new TestCaseB(), testCasesNumber, singleton);
        }

        public override TestResult DoTestC(int testCasesNumber, bool singleton)
        {
            return DoTest(new TestCaseC(), testCasesNumber, singleton);
        }
    }
}