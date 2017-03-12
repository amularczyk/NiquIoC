using System;
using System.Diagnostics;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers
{
    public abstract class PerformanceTest : IPerformanceTest
    {
        public TestResult RunTest(int count, string testCaseName, RegistrationKind registrationKind)
        {
            var testResult = new TestResult { TestCaseName = testCaseName, RegistrationKind = registrationKind, TestCasesCount = count };
            var sw = new Stopwatch();

            var testCase = GetTestCase(testCaseName, registrationKind);
            var container = RunRegister(sw, testCase, GetContainer(registrationKind), registrationKind);
            testResult.RegisterTime = sw.ElapsedMilliseconds;

            sw.Reset();
            testResult.ResolveTime = RunResolve(sw, testCase, container, count, registrationKind);

            RunDispose(container);

            return testResult;
        }

        protected abstract ITestCase GetTestCase(string testCase, RegistrationKind registrationKind);

        protected abstract object GetContainer(RegistrationKind registrationKind);

        protected virtual object RunRegister(Stopwatch sw, ITestCase testCase, object container, RegistrationKind registrationKind)
        {
            sw.Start();
            var newContainer = testCase.Register(container);
            sw.Stop();

            return newContainer;
        }

        protected virtual long RunResolve(Stopwatch sw, ITestCase testCase, object container, int testCasesCount, RegistrationKind registrationKind)
        {
            try
            {
                sw.Start();
                testCase.Resolve(container, testCasesCount);
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }
            catch (OutOfMemoryException)
            {
                return -1;
            }
        }

        protected virtual void RunDispose(object container)
        {
        }
    }
}