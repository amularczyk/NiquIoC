using Autofac;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class AutofacResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
            where T : class
        {
            if (container is ILifetimeScope)
            {
                var c = (ILifetimeScope)container;

                for (var i = 0; i < testCasesNumber; i++)
                {
                    c.Resolve<T>();
                }
            }
            else
            {
                // ReSharper disable once PossibleInvalidCastException
                var c = (IContainer)container;

                for (var i = 0; i < testCasesNumber; i++)
                {
                    c.Resolve<T>();
                }
            }
        }
    }
}