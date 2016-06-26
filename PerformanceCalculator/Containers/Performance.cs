using System;
using System.Diagnostics;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers
{
    public abstract class Performance : IPerformance
    {
        public abstract TestResult DoTest(ITestCase testCase, int testCasesNumber, bool singleton);
        public abstract TestResult DoTestA(int testCasesNumber, bool singleton);
        public abstract TestResult DoTestB(int testCasesNumber, bool singleton);
        public abstract TestResult DoTestC(int testCasesNumber, bool singleton);
        
        protected long DoResolve(Stopwatch sw, ITestCase testCase, object c, int testCasesNumber, bool singleton)
        {
            try
            {
                sw.Start();
                testCase.Resolve(c, testCasesNumber, singleton);
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }
            catch (OutOfMemoryException)
            {
                return -1;
            }
        }
    }
}