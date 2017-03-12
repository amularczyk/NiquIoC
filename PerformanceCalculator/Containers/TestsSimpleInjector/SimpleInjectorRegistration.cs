using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public abstract class SimpleInjectorRegistration : IRegistration
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