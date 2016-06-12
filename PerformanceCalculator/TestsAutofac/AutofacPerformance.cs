using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Autofac;

namespace PerformanceCalculator.TestsAutofac
{
    public class AutofacPerformance : IPerformance
    {
        public IEnumerable<TestResult> DoTests()
        {
            var results = new List<TestResult>
            {
                DoTest(new TestCaseA(), 100, true),
                DoTest(new TestCaseA(), 1, false),
                DoTest(new TestCaseA(), 10, false),
                DoTest(new TestCaseA(), 100, false),
                DoTest(new TestCaseA(), 1000, false)
            };


            return results;
        }

        public TestResult DoTest(ITestCase testCase, int testCasesNumber, bool singleton)
        {
            var result = new TestResult() { Singleton = singleton, TestCasesNumber = testCasesNumber };
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
                c = (IContainer)testCase.TransientRegister(cb); ;
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
    }
}