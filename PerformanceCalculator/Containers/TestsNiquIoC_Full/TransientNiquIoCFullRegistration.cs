using NiquIoC;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class TransientNiquIoCFullRegistration : Registration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.RegisterType<TFrom, TTo>();
        }
    }
}