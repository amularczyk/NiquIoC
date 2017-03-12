using LightInject;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class PerThreadLightInjectRegistration : Registration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (ServiceContainer)container;

            c.Register<TFrom, TTo>(new PerScopeLifetime());
        }
    }
}