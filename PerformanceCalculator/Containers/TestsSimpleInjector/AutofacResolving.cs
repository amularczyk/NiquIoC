using PerformanceCalculator.Interfaces;
using SimpleInjector;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class AutofacResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<T>();
            }
        }
    }
}