using LightInject;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class AutofacResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
        {
            var c = (ServiceContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<T>();
            }
        }
    }
}