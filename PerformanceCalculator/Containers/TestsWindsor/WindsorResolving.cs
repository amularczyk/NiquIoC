using Castle.Windsor;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsWindsor
{
    public class WindsorResolving : IResolving
    {
        public void Resolve<T>(object container, int testCasesNumber)
            where T : class
        {
            var c = (WindsorContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<T>();
            }
        }
    }
}