using Ninject;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public abstract class TestCaseA : ITestCaseA
    {
        public abstract object Register(object container);

        public void Resolve(object container, int testCasesNumber)
        {
            var c = (StandardKernel)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Get<ITestA>();
            }
        }
    }
}