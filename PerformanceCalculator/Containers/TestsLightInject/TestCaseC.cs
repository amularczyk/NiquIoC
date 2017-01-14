using LightInject;
using PerformanceCalculator.Common;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public abstract class TestCaseC : ITestCaseC
    {
        public abstract object Register(object container);

        public void Resolve(object container, int testCasesNumber)
        {
            var c = (ServiceContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<ITestC>();
            }
        }
    }
}