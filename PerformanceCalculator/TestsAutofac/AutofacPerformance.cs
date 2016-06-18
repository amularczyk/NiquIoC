using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Autofac;

namespace PerformanceCalculator.TestsAutofac
{
    public class AutofacPerformance : Performance
    {
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