using System;
using System.Diagnostics;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;
using SimpleInjector;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class SimpleInjectorPerformanceTest : PerformanceTest
    {
        protected override ITestCase TestCaseFactory(string testCase, RegistrationKind registrationKind)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    switch (registrationKind)
                    {
                        case RegistrationKind.Singleton:
                            return new SingletonTestCaseA();

                        case RegistrationKind.Transient:
                            return new TransientTestCaseA();

                        case RegistrationKind.PerThread:
                            return new PerThreadTestCaseA();

                        default:
                            throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
                    }

                case TestCaseName.B:
                    switch (registrationKind)
                    {
                        case RegistrationKind.Singleton:
                            return new SingletonTestCaseB();

                        case RegistrationKind.Transient:
                            return new TransientTestCaseB();

                        case RegistrationKind.PerThread:
                            return new PerThreadTestCaseB();

                        default:
                            throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
                    }

                case TestCaseName.C:
                    switch (registrationKind)
                    {
                        case RegistrationKind.Singleton:
                            return new SingletonTestCaseC();

                        case RegistrationKind.Transient:
                            return new TransientTestCaseC();

                        case RegistrationKind.PerThread:
                            return new PerThreadTestCaseC();

                        default:
                            throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
                    }

                default:
                    throw new ArgumentOutOfRangeException(nameof(testCase), testCase, null);
            }
        }

        protected override TestResult RunTest(ITestCase testCase, int testCasesCount, RegistrationKind registrationKind)
        {
            var result = new TestResult { RegistrationKind = registrationKind, TestCasesCount = testCasesCount };
            var sw = new Stopwatch();

            var c = new Container();
            sw.Start();
            c = (Container)testCase.Register(c);
            sw.Stop();
            result.RegisterTime = sw.ElapsedMilliseconds;

            sw.Reset();
            result.ResolveTime = DoResolve(sw, testCase, c, testCasesCount, registrationKind);

            c.Dispose();

            return result;
        }

        protected override long DoResolve(Stopwatch sw, ITestCase testCase, object c, int testCasesNumber, RegistrationKind registrationKind)
        {
            try
            {
                if (registrationKind == RegistrationKind.PerThread)
                {
                    sw.Start();
                    using (((Container)c).BeginLifetimeScope())
                    {
                        testCase.Resolve(c, testCasesNumber);
                    }
                    sw.Stop();
                    return sw.ElapsedMilliseconds;
                }

                return base.DoResolve(sw, testCase, c, testCasesNumber, registrationKind);
            }
            catch (OutOfMemoryException)
            {
                return -1;
            }
        }
    }
}