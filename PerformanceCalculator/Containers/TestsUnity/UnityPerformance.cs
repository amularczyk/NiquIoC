using System.Diagnostics;
using Microsoft.Practices.Unity;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class UnityPerformance : IPerformance
    {
        public TestResult DoTest(ITestCase testCase, int testCasesNumber, bool singleton)
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
            sw.Start();
            testCase.Resolve(c, testCasesNumber, singleton);
            sw.Stop();
            result.ResolveTime = sw.ElapsedMilliseconds;

            c.Dispose();

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