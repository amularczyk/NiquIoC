using Ninject;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class NinjectResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
            where T : class
        {
            var c = (StandardKernel)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Get<T>();
            }
        }
    }
}