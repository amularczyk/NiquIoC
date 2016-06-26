using System.Diagnostics;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;
using StructureMap;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class StructureMapPerformance : Performance
    {
        public override TestResult DoTest(ITestCase testCase, int testCasesNumber, bool singleton)
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