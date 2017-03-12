using Ninject;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class SingletonNinjectRegistration : Registration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<TFrom>().To<TTo>().InSingletonScope();
        }
    }
}