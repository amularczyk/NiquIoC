using Autofac;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class TransientAutofacRegistration : AutofacRegistration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TTo>().As<TFrom>();
        }
    }
}