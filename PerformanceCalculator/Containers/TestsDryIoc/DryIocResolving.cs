using DryIoc;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class DryIocResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<T>();
            }
        }
    }
}