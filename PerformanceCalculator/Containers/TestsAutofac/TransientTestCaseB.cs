using Autofac;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class TransientTestCaseB : TestCaseB
    {
        public override object Register(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TestB00>().As<ITestB00>().InstancePerLifetimeScope();
            cb.RegisterType<TestB01>().As<ITestB01>().InstancePerLifetimeScope();
            cb.RegisterType<TestB02>().As<ITestB02>().InstancePerLifetimeScope();
            cb.RegisterType<TestB03>().As<ITestB03>().InstancePerLifetimeScope();
            cb.RegisterType<TestB04>().As<ITestB04>().InstancePerLifetimeScope();
            cb.RegisterType<TestB05>().As<ITestB05>().InstancePerLifetimeScope();
            cb.RegisterType<TestB06>().As<ITestB06>().InstancePerLifetimeScope();
            cb.RegisterType<TestB07>().As<ITestB07>().InstancePerLifetimeScope();
            cb.RegisterType<TestB08>().As<ITestB08>().InstancePerLifetimeScope();
            cb.RegisterType<TestB09>().As<ITestB09>().InstancePerLifetimeScope();

            cb.RegisterType<TestB10>().As<ITestB10>().InstancePerLifetimeScope();
            cb.RegisterType<TestB11>().As<ITestB11>().InstancePerLifetimeScope();
            cb.RegisterType<TestB12>().As<ITestB12>().InstancePerLifetimeScope();
            cb.RegisterType<TestB13>().As<ITestB13>().InstancePerLifetimeScope();
            cb.RegisterType<TestB14>().As<ITestB14>().InstancePerLifetimeScope();
            cb.RegisterType<TestB15>().As<ITestB15>().InstancePerLifetimeScope();
            cb.RegisterType<TestB16>().As<ITestB16>().InstancePerLifetimeScope();
            cb.RegisterType<TestB17>().As<ITestB17>().InstancePerLifetimeScope();
            cb.RegisterType<TestB18>().As<ITestB18>().InstancePerLifetimeScope();
            cb.RegisterType<TestB19>().As<ITestB19>().InstancePerLifetimeScope();

            cb.RegisterType<TestB20>().As<ITestB20>().InstancePerLifetimeScope();
            cb.RegisterType<TestB21>().As<ITestB21>().InstancePerLifetimeScope();
            cb.RegisterType<TestB22>().As<ITestB22>().InstancePerLifetimeScope();
            cb.RegisterType<TestB23>().As<ITestB23>().InstancePerLifetimeScope();
            cb.RegisterType<TestB24>().As<ITestB24>().InstancePerLifetimeScope();
            cb.RegisterType<TestB25>().As<ITestB25>().InstancePerLifetimeScope();
            cb.RegisterType<TestB26>().As<ITestB26>().InstancePerLifetimeScope();
            cb.RegisterType<TestB27>().As<ITestB27>().InstancePerLifetimeScope();
            cb.RegisterType<TestB28>().As<ITestB28>().InstancePerLifetimeScope();
            cb.RegisterType<TestB29>().As<ITestB29>().InstancePerLifetimeScope();

            cb.RegisterType<TestB30>().As<ITestB30>().InstancePerLifetimeScope();
            cb.RegisterType<TestB31>().As<ITestB31>().InstancePerLifetimeScope();
            cb.RegisterType<TestB32>().As<ITestB32>().InstancePerLifetimeScope();
            cb.RegisterType<TestB33>().As<ITestB33>().InstancePerLifetimeScope();
            cb.RegisterType<TestB34>().As<ITestB34>().InstancePerLifetimeScope();
            cb.RegisterType<TestB35>().As<ITestB35>().InstancePerLifetimeScope();
            cb.RegisterType<TestB36>().As<ITestB36>().InstancePerLifetimeScope();
            cb.RegisterType<TestB37>().As<ITestB37>().InstancePerLifetimeScope();
            cb.RegisterType<TestB38>().As<ITestB38>().InstancePerLifetimeScope();
            cb.RegisterType<TestB39>().As<ITestB39>().InstancePerLifetimeScope();

            cb.RegisterType<TestB40>().As<ITestB40>().InstancePerLifetimeScope();
            cb.RegisterType<TestB41>().As<ITestB41>().InstancePerLifetimeScope();
            cb.RegisterType<TestB42>().As<ITestB42>().InstancePerLifetimeScope();
            cb.RegisterType<TestB43>().As<ITestB43>().InstancePerLifetimeScope();
            cb.RegisterType<TestB44>().As<ITestB44>().InstancePerLifetimeScope();
            cb.RegisterType<TestB45>().As<ITestB45>().InstancePerLifetimeScope();
            cb.RegisterType<TestB46>().As<ITestB46>().InstancePerLifetimeScope();
            cb.RegisterType<TestB47>().As<ITestB47>().InstancePerLifetimeScope();
            cb.RegisterType<TestB48>().As<ITestB48>().InstancePerLifetimeScope();
            cb.RegisterType<TestB49>().As<ITestB49>().InstancePerLifetimeScope();

            cb.RegisterType<TestB>().As<ITestB>().InstancePerLifetimeScope();
            var c = cb.Build();

            return c;
        }
    }
}