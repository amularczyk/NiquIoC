using StructureMap;
using StructureMap.Pipeline;

namespace PerformanceCalculator.Containers.TestsStructureMap
{
    public class PerThreadStructureMapRegistration : StructureMapRegistration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.Configure(x => { x.For<TFrom>(Lifecycles.ThreadLocal).Use<TTo>(); });
        }
    }
}