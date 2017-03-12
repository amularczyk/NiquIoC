using Autofac;

namespace PerformanceCalculator.Containers.TestsAutofac
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