using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public abstract class StructureMapRegistration : IRegistration
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