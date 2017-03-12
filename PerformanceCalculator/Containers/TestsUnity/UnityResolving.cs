using Microsoft.Practices.Unity;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsUnity
{
    public class UnityResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
            where T : class
        {
            var c = (UnityContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<T>();
            }
        }
    }
}