using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public abstract class LightInjectRegistration : IRegistration
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