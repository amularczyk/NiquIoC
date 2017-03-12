using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace PerformanceCalculator.Containers.TestsWindsor
{
    public class PerThreadWindsorRegistration : Registration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (WindsorContainer)container;

            c.Register(Component.For<TFrom>().ImplementedBy<TTo>().LifeStyle.PerThread);
        }
    }
}