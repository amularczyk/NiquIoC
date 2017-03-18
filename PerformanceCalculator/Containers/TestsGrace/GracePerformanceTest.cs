using System;
using System.Diagnostics;
using Grace.DependencyInjection;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class GracePerformanceTest : PerformanceTest
    {
        protected override ITestCase GetTestCase(string testCase, RegistrationKind registrationKind)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    return new TestCaseA(GetRegistration(registrationKind), new GraceResolving());

                case TestCaseName.D:
                    return new TestCaseD(GetRegistration(registrationKind), new GraceResolving());

                case TestCaseName.B:
                    return new TestCaseC(GetRegistration(registrationKind), new GraceResolving());

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected IRegistration GetRegistration(RegistrationKind registrationKind)
        {
            switch (registrationKind)
            {
                case RegistrationKind.Singleton:
                    return new SingletonGraceRegistration();

                case RegistrationKind.Transient:
                    return new TransientGraceRegistration();

                case RegistrationKind.PerThread:
                    return new PerThreadGraceRegistration();

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected override object GetContainer(RegistrationKind registrationKind)
        {
            return new DependencyInjectionContainer();
        }

        protected override long RunResolve(Stopwatch sw, ITestCase testCase, object container, int testCasesCount, RegistrationKind registrationKind)
        {
            try
            {
                if (registrationKind == RegistrationKind.PerThread)
                {
                    sw.Start();
                    using (var scope = ((DependencyInjectionContainer)container).BeginLifetimeScope())
                    {
                        testCase.Resolve(scope, testCasesCount);
                    }
                    sw.Stop();
                    return sw.ElapsedMilliseconds;
                }

                return base.RunResolve(sw, testCase, container, testCasesCount, registrationKind);
            }
            catch (OutOfMemoryException)
            {
                return -1;
            }
        }

        protected override void RunDispose(object container)
        {
            ((DependencyInjectionContainer)container).Dispose();
        }
    }
}