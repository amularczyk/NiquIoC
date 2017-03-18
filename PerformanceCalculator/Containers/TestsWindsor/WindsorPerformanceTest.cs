using System;
using System.Diagnostics;
using Castle.Windsor;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsWindsor
{
    public class WindsorPerformanceTest : PerformanceTest
    {
        protected override ITestCase GetTestCase(string testCase, RegistrationKind registrationKind)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    return new TestCaseA(GetRegistration(registrationKind), new WindsorResolving());

                case TestCaseName.D:
                    return new TestCaseD(GetRegistration(registrationKind), new WindsorResolving());

                case TestCaseName.B:
                    return new TestCaseC(GetRegistration(registrationKind), new WindsorResolving());

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected IRegistration GetRegistration(RegistrationKind registrationKind)
        {
            switch (registrationKind)
            {
                case RegistrationKind.Singleton:
                    return new SingletonWindsorRegistration();

                case RegistrationKind.Transient:
                    return new TransientWindsorRegistration();

                case RegistrationKind.PerThread:
                    return new PerThreadWindsorRegistration();

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected override object GetContainer(RegistrationKind registrationKind)
        {
            return new WindsorContainer();
        }

        protected override long RunResolve(Stopwatch sw, ITestCase testCase, object container, int testCasesCount, RegistrationKind registrationKind)
        {
            try
            {
                return base.RunResolve(sw, testCase, container, testCasesCount, registrationKind);
            }
            catch (OutOfMemoryException)
            {
                return -1;
            }
        }

        protected override void RunDispose(object container)
        {
            ((WindsorContainer)container).Dispose();
        }
    }
}