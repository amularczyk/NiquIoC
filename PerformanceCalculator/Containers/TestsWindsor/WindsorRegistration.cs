using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsWindsor
{
    public abstract class WindsorRegistration : IRegistration
    {
        public abstract void Register<TFrom, TTo>(object container)
            where TFrom : class
            where TTo : class, TFrom;

        public object RegisterCallback(object container)
        {
            return container;
        }
    }
}