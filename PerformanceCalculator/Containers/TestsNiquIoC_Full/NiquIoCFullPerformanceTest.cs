using System;
using NiquIoC;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class NiquIoCFullPerformanceTest : PerformanceTest
    {
        protected override ITestCase GetTestCase(string testCase, RegistrationKind registrationKind)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    return new TestCaseA(GetRegistration(registrationKind), new NiquIoCFullResolving());

                case TestCaseName.B:
                    return new TestCaseB(GetRegistration(registrationKind), new NiquIoCFullResolving());

                case TestCaseName.C:
                    return new TestCaseC(GetRegistration(registrationKind), new NiquIoCFullResolving());

                case TestCaseName.D:
                    return new TestCaseD(GetRegistration(registrationKind), new NiquIoCFullResolving());

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected IRegistration GetRegistration(RegistrationKind registrationKind)
        {
            switch (registrationKind)
            {
                case RegistrationKind.Singleton:
                    return new SingletonNiquIoCFullRegistration();

                case RegistrationKind.Transient:
                    return new TransientNiquIoCFullRegistration();

                case RegistrationKind.PerThread:
                    return new PerThreadNiquIoCFullRegistration();

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