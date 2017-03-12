using Autofac;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class SingletonAutofacRegistration : AutofacRegistration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TTo>().As<TFrom>().SingleInstance();
        }
    }
}