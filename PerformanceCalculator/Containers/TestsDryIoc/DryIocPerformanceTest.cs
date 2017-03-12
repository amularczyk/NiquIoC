using System;
using System.Diagnostics;
using DryIoc;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class DryIocPerformanceTest : PerformanceTest
    {
        protected override ITestCase GetTestCase(string testCase, RegistrationKind registrationKind)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    return new TestCaseA(GetRegistration(registrationKind), new DryIocResolving());

                case TestCaseName.B:
                    return new TestCaseB(GetRegistration(registrationKind), new DryIocResolving());

                case TestCaseName.C:
                    return new TestCaseC(GetRegistration(registrationKind), new DryIocResolving());

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected IRegistration GetRegistration(RegistrationKind registrationKind)
        {
            switch (registrationKind)
            {
                case RegistrationKind.Singleton:
                    return new SingletonDryIocRegistration();

                case RegistrationKind.Transient:
                    return new TransientDryIocRegistration();

                case RegistrationKind.PerThread:
                    return new PerThreadDryIocRegistration();

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected override object GetContainer(RegistrationKind registrationKind)
        {
            return registrationKind == RegistrationKind.PerThread ? new Container(scopeContext: new ThreadScopeContext()) : new Container();
        }

        protected override long RunResolve(Stopwatch sw, ITestCase testCase, object container, int testCasesCount, RegistrationKind registrationKind)
        {
            try
            {
                if (registrationKind == RegistrationKind.PerThread)
                {
                    sw.Start();
                    using (((Container)container).OpenScope())
                    {
                        testCase.Resolve(container, testCasesCount);
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
            ((Container)container).Dispose();
        }
    }
}