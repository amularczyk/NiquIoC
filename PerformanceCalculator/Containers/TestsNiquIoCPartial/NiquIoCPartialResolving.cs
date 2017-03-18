using NiquIoC;
using NiquIoC.Enums;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsNiquIoCPartial
{
    public class NiquIoCPartialResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
            where T : class
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<T>(ResolveKind.PartialEmitFunction);
            }
        }
    }
}