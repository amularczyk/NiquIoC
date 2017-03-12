using Grace.DependencyInjection;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public class TransientGraceRegistration : Registration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (DependencyInjectionContainer)container;

            c.Configure(x => { x.Export<TTo>().As<TFrom>(); });
        }
    }
}