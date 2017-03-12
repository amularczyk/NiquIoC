using NiquIoC;
using NiquIoC.Enums;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class NiquIoCFullResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
            where T : class
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<T>(ResolveKind.FullEmitFunction);
            }
        }
    }
}