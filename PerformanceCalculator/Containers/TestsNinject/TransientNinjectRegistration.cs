using Ninject;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class TransientNinjectRegistration : Registration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<TFrom>().To<TTo>().InTransientScope();
        }
    }
}