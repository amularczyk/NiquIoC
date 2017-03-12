using Autofac;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public abstract class AutofacRegistration : IRegistration
    {
        public abstract void Register<TFrom, TTo>(object container);

        public object RegisterCallback(object container)
        {
            return ((ContainerBuilder)container).Build();
        }
    }
}