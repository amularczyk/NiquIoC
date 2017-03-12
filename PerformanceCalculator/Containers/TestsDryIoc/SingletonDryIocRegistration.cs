using DryIoc;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class SingletonDryIocRegistration : DryIocRegistration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.Register<TFrom, TTo>(Reuse.Singleton);
        }
    }
}