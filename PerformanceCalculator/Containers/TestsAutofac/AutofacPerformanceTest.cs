using System;
using System.Diagnostics;
using Autofac;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class AutofacPerformanceTest : PerformanceTest
    {
        protected override ITestCase GetTestCase(string testCase, RegistrationKind registrationKind)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    return new TestCaseA(GetRegistration(registrationKind), new AutofacResolving());

                case TestCaseName.B:
                    return new TestCaseB(GetRegistration(registrationKind), new AutofacResolving());

                case TestCaseName.C:
                    return new TestCaseC(GetRegistration(registrationKind), new AutofacResolving());

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected IRegistration GetRegistration(RegistrationKind registrationKind)
        {
            switch (registrationKind)
            {
                case RegistrationKind.Singleton:
                    return new SingletonAutofacRegistration();

                case RegistrationKind.Transient:
                    return new TransientAutofacRegistration();

                case RegistrationKind.PerThread:
                    return new PerThreadAutofacRegistration();

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected override object GetContainer(RegistrationKind registrationKind)
        {
            return new ContainerBuilder();
        }

        protected override long RunResolve(Stopwatch sw, ITestCase testCase, object container, int testCasesCount, RegistrationKind registrationKind)
        {
            try
            {
                if (registrationKind == RegistrationKind.PerThread)
                {
                    sw.Start();
                    using (var threadLifetime = ((IContainer)container).BeginLifetimeScope())
                    {
                        testCase.Resolve(threadLifetime, testCasesCount);
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
            ((IContainer)container).Dispose();
        }
    }
}