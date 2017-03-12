using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers
{
    public abstract class TestCase : ITestCase
    {
        protected readonly IRegistration _registration;
        protected readonly IResolving _resolving;

        protected TestCase(IRegistration registration, IResolving resolving)
        {
            _registration = registration;
            _resolving = resolving;
        }

        public object Register(object container)
        {
            container = _registration.BeforeRegisterCallback(container);

            RegisterClasses(container);

            return _registration.AfterRegisterCallback(container);
        }

        public abstract void Resolve(object container, int testCasesNumber);

        public abstract void RegisterClasses(object container);
    }
}