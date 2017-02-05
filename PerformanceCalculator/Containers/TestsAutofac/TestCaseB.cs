using Autofac;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public abstract class TestCaseB : ITestCaseB
    {
        public abstract object Register(object container);

        public void Resolve(object container, int testCasesNumber)
        {
            if (container is ILifetimeScope)
            {
                var c = (ILifetimeScope)container;

                for (var i = 0; i < testCasesNumber; i++)
                {
                    c.Resolve<ITestB>();
                }
            }
            else
            {
                // ReSharper disable once PossibleInvalidCastException
                var c = (IContainer)container;

                for (var i = 0; i < testCasesNumber; i++)
                {
                    c.Resolve<ITestB>();
                }
            }
        }
    }
}