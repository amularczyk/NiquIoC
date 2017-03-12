using Microsoft.Practices.Unity;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class AutofacResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
        {
            var c = (UnityContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<T>();
            }
        }
    }
}