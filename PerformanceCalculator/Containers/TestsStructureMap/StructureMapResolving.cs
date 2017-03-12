using PerformanceCalculator.Interfaces;
using StructureMap;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class StructureMapResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
            where T : class
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<T>();
            }
        }
    }
}