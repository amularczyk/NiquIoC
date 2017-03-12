using PerformanceCalculator.Interfaces;
using StructureMap;

namespace PerformanceCalculator.Containers.TestsStructureMap
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