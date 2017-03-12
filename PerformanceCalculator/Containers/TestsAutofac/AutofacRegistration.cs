using Autofac;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public abstract class AutofacRegistration : IRegistration
    {
        public abstract void Register<TFrom, TTo>(object container)
            where TFrom : class
            where TTo : class, TFrom;

        public object RegisterCallback(object container)
        {
            return ((ContainerBuilder)container).Build();
        }
    }
}