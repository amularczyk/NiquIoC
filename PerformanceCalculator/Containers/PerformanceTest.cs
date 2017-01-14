﻿using System;
using System.Diagnostics;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers
{
    public abstract class PerformanceTest : IPerformanceTest
    {
        public TestResult DoTest(int count, string testCase, RegistrationKind registrationKind)
        {
            return DoTest(TestCaseFactory(testCase, registrationKind), count, registrationKind);
        }

        protected abstract ITestCase TestCaseFactory(string testCase, RegistrationKind registrationKind);

        protected abstract TestResult DoTest(ITestCase testCase, int testCasesNumber, RegistrationKind registrationKind);

        protected long DoResolve(Stopwatch sw, ITestCase testCase, object c, int testCasesNumber)
        {
            try
            {
                sw.Start();
                testCase.Resolve(c, testCasesNumber);
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