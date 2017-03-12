using Grace.DependencyInjection;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class GraceResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
            where T : class
        {
            if (container is IExportLocatorScope)
            {
                var c = (IExportLocatorScope)container;

                for (var i = 0; i < testCasesNumber; i++)
                {
                    c.Locate<T>();
                }
            }
            else
            {
                // ReSharper disable once PossibleInvalidCastException
                var c = (DependencyInjectionContainer)container;

                for (var i = 0; i < testCasesNumber; i++)
                {
                    c.Locate<T>();
                }
            }
        }
    }
}