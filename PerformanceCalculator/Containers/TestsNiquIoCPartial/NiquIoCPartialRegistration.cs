using NiquIoC;

namespace PerformanceCalculator.Containers.TestsNiquIoCPartial
{
    public class NiquIoCPartialRegistration : Registration
    {
        public override void RegisterSingleton<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.RegisterType<TFrom, TTo>().AsSingleton();
        }

        public override void RegisterTransient<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.RegisterType<TFrom, TTo>();
        }

        public override void RegisterPerThread<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.RegisterType<TFrom, TTo>().AsPerThread();
        }
    }
}