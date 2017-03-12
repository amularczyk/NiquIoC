using Castle.Windsor;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsWindsor
{
    public class AutofacResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
        {
            var c = (WindsorContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<T>();
            }
        }
    }
}