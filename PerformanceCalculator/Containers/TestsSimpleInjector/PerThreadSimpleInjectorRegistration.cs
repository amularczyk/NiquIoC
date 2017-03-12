using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class PerThreadSimpleInjectorRegistration : Registration
    {
        public override object BeforeRegisterCallback(object container)
        {
            var c = (Container)container;

            c.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();

            return c;
        }

        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.Register<TFrom, TTo>(Lifestyle.Scoped);
        }
    }
}