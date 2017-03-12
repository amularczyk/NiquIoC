using SimpleInjector;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class TransientSimpleInjectorRegistration : Registration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.Register<TFrom, TTo>();
        }
    }
}