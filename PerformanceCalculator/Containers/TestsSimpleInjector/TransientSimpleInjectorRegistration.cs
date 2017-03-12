using SimpleInjector;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class TransientSimpleInjectorRegistration : SimpleInjectorRegistration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.Register<TFrom, TTo>();
        }
    }
}