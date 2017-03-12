using NiquIoC;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Partial
{
    public class PerThreadNiquIoCPartialRegistration : Registration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.RegisterType<TFrom, TTo>().AsPerThread();
        }
    }
}