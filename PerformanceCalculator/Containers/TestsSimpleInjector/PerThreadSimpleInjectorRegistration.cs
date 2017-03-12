using SimpleInjector;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class PerThreadSimpleInjectorRegistration : SimpleInjectorRegistration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            //TODO: c.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();

            c.Register<TFrom, TTo>(Lifestyle.Scoped);
        }
    }
}