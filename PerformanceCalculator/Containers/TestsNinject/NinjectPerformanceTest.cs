using System;
using System.Diagnostics;
using Ninject;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class NinjectPerformanceTest : PerformanceTest
    {
        protected override ITestCase GetTestCase(string testCase, RegistrationKind registrationKind)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    return new TestCaseA(GetRegistration(registrationKind), new NinjectResolving());

                case TestCaseName.B:
                    return new TestCaseB(GetRegistration(registrationKind), new NinjectResolving());

                case TestCaseName.C:
                    return new TestCaseC(GetRegistration(registrationKind), new NinjectResolving());

                case TestCaseName.D:
                    return new TestCaseD(GetRegistration(registrationKind), new NinjectResolving());

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected IRegistration GetRegistration(RegistrationKind registrationKind)
        {
            switch (registrationKind)
            {
                case RegistrationKind.Singleton:
                    return new SingletonNinjectRegistration();

                case RegistrationKind.Transient:
                    return new TransientNinjectRegistration();

                case RegistrationKind.PerThread:
                    return new PerThreadNinjectRegistration();

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected override object GetContainer(RegistrationKind registrationKind)
        {
            return new StandardKernel();
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
            ((StandardKernel)container).Dispose();
        }
    }
}