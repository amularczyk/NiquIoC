using System;
using NiquIoC;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Partial
{
    public class NiquIoCPartialPerformanceTest : PerformanceTest
    {
        protected override ITestCase GetTestCase(string testCase, RegistrationKind registrationKind)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    return new TestCaseA(GetRegistration(registrationKind), new NiquIoCPartialResolving());

                case TestCaseName.D:
                    return new TestCaseD(GetRegistration(registrationKind), new NiquIoCPartialResolving());

                case TestCaseName.B:
                    return new TestCaseC(GetRegistration(registrationKind), new NiquIoCPartialResolving());

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected IRegistration GetRegistration(RegistrationKind registrationKind)
        {
            switch (registrationKind)
            {
                case RegistrationKind.Singleton:
                    return new SingletonNiquIoCPartialRegistration();

                case RegistrationKind.Transient:
                    return new TransientNiquIoCPartialRegistration();

                case RegistrationKind.PerThread:
                    return new PerThreadNiquIoCPartialRegistration();

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected override object GetContainer(RegistrationKind registrationKind)
        {
            return new Container();
        }
    }
}