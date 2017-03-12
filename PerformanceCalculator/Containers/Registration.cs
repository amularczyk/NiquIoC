using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers
{
    public abstract class Registration : IRegistration
    {
        public virtual object BeforeRegisterCallback(object container)
        {
            return container;
        }

        public abstract void Register<TFrom, TTo>(object container)
            where TFrom : class
            where TTo : class, TFrom;

        public virtual object AfterRegisterCallback(object container)
        {
            return container;
        }
    }
}