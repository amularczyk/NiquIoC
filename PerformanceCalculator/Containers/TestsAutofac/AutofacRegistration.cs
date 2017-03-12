using Autofac;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public abstract class AutofacRegistration : Registration
    {
        public override object AfterRegisterCallback(object container)
        {
            return ((ContainerBuilder)container).Build();
        }
    }
}