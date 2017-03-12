using System;
using Microsoft.Practices.Unity;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class UnityPerformanceTest : PerformanceTest
    {
        protected override ITestCase GetTestCase(string testCase, RegistrationKind registrationKind)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    return new TestCaseA(GetRegistration(registrationKind), new UnityResolving());

                case TestCaseName.B:
                    return new TestCaseB(GetRegistration(registrationKind), new UnityResolving());

                case TestCaseName.C:
                    return new TestCaseC(GetRegistration(registrationKind), new UnityResolving());

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected IRegistration GetRegistration(RegistrationKind registrationKind)
        {
            switch (registrationKind)
            {
                case RegistrationKind.Singleton:
                    return new SingletonUnityRegistration();

                case RegistrationKind.Transient:
                    return new TransientUnityRegistration();

                case RegistrationKind.PerThread:
                    return new PerThreadUnityRegistration();

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected override object GetContainer(RegistrationKind registrationKind)
        {
            return new UnityContainer();
        }

        protected override void RunDispose(object container)
        {
            ((UnityContainer)container).Dispose();
        }
    }
}