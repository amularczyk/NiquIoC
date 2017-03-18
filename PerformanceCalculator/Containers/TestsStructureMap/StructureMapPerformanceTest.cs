using System;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;
using StructureMap;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class StructureMapPerformanceTest : PerformanceTest
    {
        protected override ITestCase GetTestCase(string testCase, RegistrationKind registrationKind)
        {
            switch (testCase)
            {
                case TestCaseName.A:
                    return new TestCaseA(GetRegistration(registrationKind), new StructureMapResolving());

                case TestCaseName.B:
                    return new TestCaseB(GetRegistration(registrationKind), new StructureMapResolving());

                case TestCaseName.C:
                    return new TestCaseC(GetRegistration(registrationKind), new StructureMapResolving());

                case TestCaseName.D:
                    return new TestCaseD(GetRegistration(registrationKind), new StructureMapResolving());

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected IRegistration GetRegistration(RegistrationKind registrationKind)
        {
            switch (registrationKind)
            {
                case RegistrationKind.Singleton:
                    return new SingletonStructureMapRegistration();

                case RegistrationKind.Transient:
                    return new TransientStructureMapRegistration();

                case RegistrationKind.PerThread:
                    return new PerThreadStructureMapRegistration();

                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationKind), registrationKind, null);
            }
        }

        protected override object GetContainer(RegistrationKind registrationKind)
        {
            return new Container();
        }

        protected override void RunDispose(object container)
        {
            ((Container)container).Dispose();
        }
    }
}