using System;
using System.Diagnostics;
using LightInject;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class LightInjectPerformanceTest : PerformanceTest
    {
        protected override ITestCase GetTestCase(string testCase, RegistrationKind registrationKind)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    return new TestCaseA(GetRegistration(registrationKind), new LightInjectResolving());

                case TestCaseName.D:
                    return new TestCaseD(GetRegistration(registrationKind), new LightInjectResolving());

                case TestCaseName.C:
                    return new TestCaseC(GetRegistration(registrationKind), new LightInjectResolving());

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected IRegistration GetRegistration(RegistrationKind registrationKind)
        {
            switch (registrationKind)
            {
                case RegistrationKind.Singleton:
                    return new SingletonLightInjectRegistration();

                case RegistrationKind.Transient:
                    return new TransientLightInjectRegistration();

                case RegistrationKind.PerThread:
                    return new PerThreadLightInjectRegistration();

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected override object GetContainer(RegistrationKind registrationKind)
        {
            return new ServiceContainer();
        }

        protected override long RunResolve(Stopwatch sw, ITestCase testCase, object container, int testCasesCount, RegistrationKind registrationKind)
        {
            try
            {
                if (registrationKind == RegistrationKind.PerThread)
                {
                    if (testCase is TestCaseD || testCase is TestCaseC)
                    {
                        throw new OutOfMemoryException("Process takes more than 20 minutes!");
                    }

                    sw.Start();
                    using (((ServiceContainer)container).BeginScope())
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
            ((ServiceContainer)container).Dispose();
        }
    }
}