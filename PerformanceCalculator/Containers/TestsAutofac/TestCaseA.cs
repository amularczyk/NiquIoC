using Autofac;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsAutofac
{
    public class TestCaseA : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TestA0>().As<ITestA0>().SingleInstance();
            cb.RegisterType<TestA1>().As<ITestA1>().SingleInstance();
            cb.RegisterType<TestA2>().As<ITestA2>().SingleInstance();
            cb.RegisterType<TestA3>().As<ITestA3>().SingleInstance();
            cb.RegisterType<TestA4>().As<ITestA4>().SingleInstance();
            cb.RegisterType<TestA5>().As<ITestA5>().SingleInstance();
            cb.RegisterType<TestA6>().As<ITestA6>().SingleInstance();
            cb.RegisterType<TestA7>().As<ITestA7>().SingleInstance();
            cb.RegisterType<TestA8>().As<ITestA8>().SingleInstance();
            cb.RegisterType<TestA9>().As<ITestA9>().SingleInstance();
            cb.RegisterType<TestA>().As<ITestA>().SingleInstance();
            var c = cb.Build();

            return c;
        }

        public object TransientRegister(object container)
        {
            var cb = (ContainerBuilder)container;

            cb.RegisterType<TestA0>().As<ITestA0>();
            cb.RegisterType<TestA1>().As<ITestA1>();
            cb.RegisterType<TestA2>().As<ITestA2>();
            cb.RegisterType<TestA3>().As<ITestA3>();
            cb.RegisterType<TestA4>().As<ITestA4>();
            cb.RegisterType<TestA5>().As<ITestA5>();
            cb.RegisterType<TestA6>().As<ITestA6>();
            cb.RegisterType<TestA7>().As<ITestA7>();
            cb.RegisterType<TestA8>().As<ITestA8>();
            cb.RegisterType<TestA9>().As<ITestA9>();
            cb.RegisterType<TestA>().As<ITestA>();
            var c = cb.Build();

            return c;
        }

        //public object PerThreadRegister(object container)
        //{
        //    var cb = (ContainerBuilder)container;

        //    cb.RegisterType<TestA0>().As<ITestA0>().;
        //    cb.RegisterType<TestA1>().As<ITestA1>().SingleInstance();
        //    cb.RegisterType<TestA2>().As<ITestA2>().SingleInstance();
        //    cb.RegisterType<TestA3>().As<ITestA3>().SingleInstance();
        //    cb.RegisterType<TestA4>().As<ITestA4>().SingleInstance();
        //    cb.RegisterType<TestA5>().As<ITestA5>().SingleInstance();
        //    cb.RegisterType<TestA6>().As<ITestA6>().SingleInstance();
        //    cb.RegisterType<TestA7>().As<ITestA7>().SingleInstance();
        //    cb.RegisterType<TestA8>().As<ITestA8>().SingleInstance();
        //    cb.RegisterType<TestA9>().As<ITestA9>().SingleInstance();
        //    cb.RegisterType<TestA>().As<ITestA>().SingleInstance();
        //    var c = cb.Build();

        //    return c;
        //}

        //public object PerHttpContextRegister(object container)
        //{
        //    var cb = (ContainerBuilder)container;

        //    cb.RegisterType<TestA0>().As<ITestA0>().;
        //    cb.RegisterType<TestA1>().As<ITestA1>().SingleInstance();
        //    cb.RegisterType<TestA2>().As<ITestA2>().SingleInstance();
        //    cb.RegisterType<TestA3>().As<ITestA3>().SingleInstance();
        //    cb.RegisterType<TestA4>().As<ITestA4>().SingleInstance();
        //    cb.RegisterType<TestA5>().As<ITestA5>().SingleInstance();
        //    cb.RegisterType<TestA6>().As<ITestA6>().SingleInstance();
        //    cb.RegisterType<TestA7>().As<ITestA7>().SingleInstance();
        //    cb.RegisterType<TestA8>().As<ITestA8>().SingleInstance();
        //    cb.RegisterType<TestA9>().As<ITestA9>().SingleInstance();
        //    cb.RegisterType<TestA>().As<ITestA>().SingleInstance();
        //    var c = cb.Build();

        //    return c;
        //}

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (IContainer)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestA>();
            }
        }
    }
}