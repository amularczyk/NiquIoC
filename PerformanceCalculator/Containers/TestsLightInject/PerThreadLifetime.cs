using System;
using System.Threading;
using LightInject;

namespace PerformanceCalculator.Containers.TestsLightInject
{
    public class PerThreadLifetime : ILifetime
    {
        ThreadLocal<object> instances = new ThreadLocal<object>();

        public object GetInstance(Func<object> instanceFactory, Scope currentScope)
        {
            if (instances.Value == null)
            {
                instances.Value = instanceFactory();
            }
            return instances.Value;
        }
    }
}