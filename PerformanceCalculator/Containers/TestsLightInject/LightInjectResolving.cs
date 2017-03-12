using LightInject;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class LightInjectResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
            where T : class
        {
            var c = (ServiceContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<T>();
            }
        }
    }
}