using DryIoc;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class PerThreadDryIocRegistration : Registration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.Register<TFrom, TTo>(Reuse.InThread);
        }
    }
}