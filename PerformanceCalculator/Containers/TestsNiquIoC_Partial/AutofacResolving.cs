using NiquIoC;
using NiquIoC.Enums;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Partial
{
    public class AutofacResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<T>(ResolveKind.PartialEmitFunction);
            }
        }
    }
}