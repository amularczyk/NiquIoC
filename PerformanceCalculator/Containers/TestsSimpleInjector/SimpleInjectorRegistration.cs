using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class SimpleInjectorRegistration : Registration
    {
        public override object BeforeRegisterCallback(object container)
        {
            var c = (Container)container;

            c.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle(); //ToDo - only for PerThread

            return c;
        }

        public override void RegisterSingleton<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.Register<TFrom, TTo>(Lifestyle.Singleton);
        }

        public override void RegisterTransient<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.Register<TFrom, TTo>();
        }

        public override void RegisterPerThread<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.Register<TFrom, TTo>(Lifestyle.Scoped);
        }
    }
}