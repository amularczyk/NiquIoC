using Autofac;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class TestCaseB : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TestB00>().As<ITestB00>().SingleInstance();
            cb.RegisterType<TestB01>().As<ITestB01>().SingleInstance();
            cb.RegisterType<TestB02>().As<ITestB02>().SingleInstance();
            cb.RegisterType<TestB03>().As<ITestB03>().SingleInstance();
            cb.RegisterType<TestB04>().As<ITestB04>().SingleInstance();
            cb.RegisterType<TestB05>().As<ITestB05>().SingleInstance();
            cb.RegisterType<TestB06>().As<ITestB06>().SingleInstance();
            cb.RegisterType<TestB07>().As<ITestB07>().SingleInstance();
            cb.RegisterType<TestB08>().As<ITestB08>().SingleInstance();
            cb.RegisterType<TestB09>().As<ITestB09>().SingleInstance();

            cb.RegisterType<TestB10>().As<ITestB10>().SingleInstance();
            cb.RegisterType<TestB11>().As<ITestB11>().SingleInstance();
            cb.RegisterType<TestB12>().As<ITestB12>().SingleInstance();
            cb.RegisterType<TestB13>().As<ITestB13>().SingleInstance();
            cb.RegisterType<TestB14>().As<ITestB14>().SingleInstance();
            cb.RegisterType<TestB15>().As<ITestB15>().SingleInstance();
            cb.RegisterType<TestB16>().As<ITestB16>().SingleInstance();
            cb.RegisterType<TestB17>().As<ITestB17>().SingleInstance();
            cb.RegisterType<TestB18>().As<ITestB18>().SingleInstance();
            cb.RegisterType<TestB19>().As<ITestB19>().SingleInstance();

            cb.RegisterType<TestB20>().As<ITestB20>().SingleInstance();
            cb.RegisterType<TestB21>().As<ITestB21>().SingleInstance();
            cb.RegisterType<TestB22>().As<ITestB22>().SingleInstance();
            cb.RegisterType<TestB23>().As<ITestB23>().SingleInstance();
            cb.RegisterType<TestB24>().As<ITestB24>().SingleInstance();
            cb.RegisterType<TestB25>().As<ITestB25>().SingleInstance();
            cb.RegisterType<TestB26>().As<ITestB26>().SingleInstance();
            cb.RegisterType<TestB27>().As<ITestB27>().SingleInstance();
            cb.RegisterType<TestB28>().As<ITestB28>().SingleInstance();
            cb.RegisterType<TestB29>().As<ITestB29>().SingleInstance();

            cb.RegisterType<TestB30>().As<ITestB30>().SingleInstance();
            cb.RegisterType<TestB31>().As<ITestB31>().SingleInstance();
            cb.RegisterType<TestB32>().As<ITestB32>().SingleInstance();
            cb.RegisterType<TestB33>().As<ITestB33>().SingleInstance();
            cb.RegisterType<TestB34>().As<ITestB34>().SingleInstance();
            cb.RegisterType<TestB35>().As<ITestB35>().SingleInstance();
            cb.RegisterType<TestB36>().As<ITestB36>().SingleInstance();
            cb.RegisterType<TestB37>().As<ITestB37>().SingleInstance();
            cb.RegisterType<TestB38>().As<ITestB38>().SingleInstance();
            cb.RegisterType<TestB39>().As<ITestB39>().SingleInstance();

            cb.RegisterType<TestB40>().As<ITestB40>().SingleInstance();
            cb.RegisterType<TestB41>().As<ITestB41>().SingleInstance();
            cb.RegisterType<TestB42>().As<ITestB42>().SingleInstance();
            cb.RegisterType<TestB43>().As<ITestB43>().SingleInstance();
            cb.RegisterType<TestB44>().As<ITestB44>().SingleInstance();
            cb.RegisterType<TestB45>().As<ITestB45>().SingleInstance();
            cb.RegisterType<TestB46>().As<ITestB46>().SingleInstance();
            cb.RegisterType<TestB47>().As<ITestB47>().SingleInstance();
            cb.RegisterType<TestB48>().As<ITestB48>().SingleInstance();
            cb.RegisterType<TestB49>().As<ITestB49>().SingleInstance();

            cb.RegisterType<TestB>().As<ITestB>().SingleInstance();
            var c = cb.Build();

            return c;
        }

        public object TransientRegister(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TestB00>().As<ITestB00>();
            cb.RegisterType<TestB01>().As<ITestB01>();
            cb.RegisterType<TestB02>().As<ITestB02>();
            cb.RegisterType<TestB03>().As<ITestB03>();
            cb.RegisterType<TestB04>().As<ITestB04>();
            cb.RegisterType<TestB05>().As<ITestB05>();
            cb.RegisterType<TestB06>().As<ITestB06>();
            cb.RegisterType<TestB07>().As<ITestB07>();
            cb.RegisterType<TestB08>().As<ITestB08>();
            cb.RegisterType<TestB09>().As<ITestB09>();

            cb.RegisterType<TestB10>().As<ITestB10>();
            cb.RegisterType<TestB11>().As<ITestB11>();
            cb.RegisterType<TestB12>().As<ITestB12>();
            cb.RegisterType<TestB13>().As<ITestB13>();
            cb.RegisterType<TestB14>().As<ITestB14>();
            cb.RegisterType<TestB15>().As<ITestB15>();
            cb.RegisterType<TestB16>().As<ITestB16>();
            cb.RegisterType<TestB17>().As<ITestB17>();
            cb.RegisterType<TestB18>().As<ITestB18>();
            cb.RegisterType<TestB19>().As<ITestB19>();

            cb.RegisterType<TestB20>().As<ITestB20>();
            cb.RegisterType<TestB21>().As<ITestB21>();
            cb.RegisterType<TestB22>().As<ITestB22>();
            cb.RegisterType<TestB23>().As<ITestB23>();
            cb.RegisterType<TestB24>().As<ITestB24>();
            cb.RegisterType<TestB25>().As<ITestB25>();
            cb.RegisterType<TestB26>().As<ITestB26>();
            cb.RegisterType<TestB27>().As<ITestB27>();
            cb.RegisterType<TestB28>().As<ITestB28>();
            cb.RegisterType<TestB29>().As<ITestB29>();

            cb.RegisterType<TestB30>().As<ITestB30>();
            cb.RegisterType<TestB31>().As<ITestB31>();
            cb.RegisterType<TestB32>().As<ITestB32>();
            cb.RegisterType<TestB33>().As<ITestB33>();
            cb.RegisterType<TestB34>().As<ITestB34>();
            cb.RegisterType<TestB35>().As<ITestB35>();
            cb.RegisterType<TestB36>().As<ITestB36>();
            cb.RegisterType<TestB37>().As<ITestB37>();
            cb.RegisterType<TestB38>().As<ITestB38>();
            cb.RegisterType<TestB39>().As<ITestB39>();

            cb.RegisterType<TestB40>().As<ITestB40>();
            cb.RegisterType<TestB41>().As<ITestB41>();
            cb.RegisterType<TestB42>().As<ITestB42>();
            cb.RegisterType<TestB43>().As<ITestB43>();
            cb.RegisterType<TestB44>().As<ITestB44>();
            cb.RegisterType<TestB45>().As<ITestB45>();
            cb.RegisterType<TestB46>().As<ITestB46>();
            cb.RegisterType<TestB47>().As<ITestB47>();
            cb.RegisterType<TestB48>().As<ITestB48>();
            cb.RegisterType<TestB49>().As<ITestB49>();

            cb.RegisterType<TestB>().As<ITestB>();
            var c = cb.Build();

            return c;
        }

        public object PerThreadRegister(object container)
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

        public object PerHttpContextRegister(object container)
        {
            throw new System.NotImplementedException();
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (IContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestB>();
            }
        }
    }
}