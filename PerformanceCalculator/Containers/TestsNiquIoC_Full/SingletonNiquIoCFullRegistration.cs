using NiquIoC;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class SingletonNiquIoCFullRegistration : NiquIoCFullRegistration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.RegisterType<TFrom, TTo>().AsSingleton();
        }
    }
}