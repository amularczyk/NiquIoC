using System;
using System.Diagnostics;
using System.IO;
using Autofac;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DryIoc;
using LightInject;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;

namespace PerformanceTests
{
    [TestClass]
    public class ClassBTransientTests
    {
        private static readonly int _testCasesNumber = 1;
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "PerforamceTests_B_Transient_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        private static void Check(ITestB50 testB50)
        {
            Assert.IsNotNull(testB50);

            Assert.IsNotNull(testB50.TestB49);
            Assert.IsNotNull(testB50.TestB48);
            Assert.IsNotNull(testB50.TestB47);
            Assert.IsNotNull(testB50.TestB46);
            Assert.IsNotNull(testB50.TestB45);
            Assert.IsNotNull(testB50.TestB44);
            Assert.IsNotNull(testB50.TestB43);
            Assert.IsNotNull(testB50.TestB42);
            Assert.IsNotNull(testB50.TestB41);
            Assert.IsNotNull(testB50.TestB40);

            Assert.IsNotNull(testB50.TestB49.TestB39);
            Assert.IsNotNull(testB50.TestB49.TestB38);
            Assert.IsNotNull(testB50.TestB49.TestB37);
            Assert.IsNotNull(testB50.TestB49.TestB36);
            Assert.IsNotNull(testB50.TestB49.TestB35);
            Assert.IsNotNull(testB50.TestB49.TestB34);
            Assert.IsNotNull(testB50.TestB49.TestB33);
            Assert.IsNotNull(testB50.TestB49.TestB32);
            Assert.IsNotNull(testB50.TestB49.TestB31);
            Assert.IsNotNull(testB50.TestB49.TestB30);

            Assert.AreNotEqual(testB50.TestB49.TestB39, testB50.TestB48.TestB39);
            Assert.AreNotEqual(testB50.TestB49.TestB38, testB50.TestB48.TestB38);
            Assert.AreNotEqual(testB50.TestB49.TestB37, testB50.TestB48.TestB37);
            Assert.AreNotEqual(testB50.TestB49.TestB36, testB50.TestB48.TestB36);
            Assert.AreNotEqual(testB50.TestB49.TestB35, testB50.TestB48.TestB35);
            Assert.AreNotEqual(testB50.TestB49.TestB34, testB50.TestB48.TestB34);
            Assert.AreNotEqual(testB50.TestB49.TestB33, testB50.TestB48.TestB33);
            Assert.AreNotEqual(testB50.TestB49.TestB32, testB50.TestB48.TestB32);
            Assert.AreNotEqual(testB50.TestB49.TestB31, testB50.TestB48.TestB31);
            Assert.AreNotEqual(testB50.TestB49.TestB30, testB50.TestB48.TestB30);

            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB28);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB27);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB26);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB25);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB24);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB23);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB22);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB21);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB20);

            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB19);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB18);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB17);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB16);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB15);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB14);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB13);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB12);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB11);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB10);

            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB19.TestB09);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB19.TestB08);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB19.TestB07);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB19.TestB06);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB19.TestB05);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB19.TestB04);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB19.TestB03);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB19.TestB02);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB19.TestB01);
            Assert.IsNotNull(testB50.TestB49.TestB39.TestB29.TestB19.TestB00);
        }

        private static void WriteLine(string text, params object[] args)
        {
            using (var file = new StreamWriter(_fileName, true))
            {
                file.WriteLine(text, args);
            }
        }


        [TestMethod]
        public void DryIocTest()
        {
            WriteLine("\nDryIoc");

            try
            {
                var c = new DryIoc.Container();
                DryIocRegister(c);
                DryIocResolve(c, _testCasesNumber);
                c.Dispose();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        private void DryIocRegister(DryIoc.Container c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register<ITestB00, TestB00>();
            c.Register<ITestB01, TestB01>();
            c.Register<ITestB02, TestB02>();
            c.Register<ITestB03, TestB03>();
            c.Register<ITestB04, TestB04>();
            c.Register<ITestB05, TestB05>();
            c.Register<ITestB06, TestB06>();
            c.Register<ITestB07, TestB07>();
            c.Register<ITestB08, TestB08>();
            c.Register<ITestB09, TestB09>();

            c.Register<ITestB10, TestB10>();
            c.Register<ITestB11, TestB11>();
            c.Register<ITestB12, TestB12>();
            c.Register<ITestB13, TestB13>();
            c.Register<ITestB14, TestB14>();
            c.Register<ITestB15, TestB15>();
            c.Register<ITestB16, TestB16>();
            c.Register<ITestB17, TestB17>();
            c.Register<ITestB18, TestB18>();
            c.Register<ITestB19, TestB19>();

            c.Register<ITestB20, TestB20>();
            c.Register<ITestB21, TestB21>();
            c.Register<ITestB22, TestB22>();
            c.Register<ITestB23, TestB23>();
            c.Register<ITestB24, TestB24>();
            c.Register<ITestB25, TestB25>();
            c.Register<ITestB26, TestB26>();
            c.Register<ITestB27, TestB27>();
            c.Register<ITestB28, TestB28>();
            c.Register<ITestB29, TestB29>();

            c.Register<ITestB30, TestB30>();
            c.Register<ITestB31, TestB31>();
            c.Register<ITestB32, TestB32>();
            c.Register<ITestB33, TestB33>();
            c.Register<ITestB34, TestB34>();
            c.Register<ITestB35, TestB35>();
            c.Register<ITestB36, TestB36>();
            c.Register<ITestB37, TestB37>();
            c.Register<ITestB38, TestB38>();
            c.Register<ITestB39, TestB39>();

            c.Register<ITestB40, TestB40>();
            c.Register<ITestB41, TestB41>();
            c.Register<ITestB42, TestB42>();
            c.Register<ITestB43, TestB43>();
            c.Register<ITestB44, TestB44>();
            c.Register<ITestB45, TestB45>();
            c.Register<ITestB46, TestB46>();
            c.Register<ITestB47, TestB47>();
            c.Register<ITestB48, TestB48>();
            c.Register<ITestB49, TestB49>();

            c.Register<ITestB50, TestB50>();
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void DryIocResolve(DryIoc.Container c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestB50>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestB50>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }


        [TestMethod]
        public void LightInjectTest()
        {
            WriteLine("\nLightInject");

            var c = new ServiceContainer();
            LightInjectRegister(c);
            LightInjectResolve(c, _testCasesNumber);
            c.Dispose();
        }

        private void LightInjectRegister(ServiceContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register<ITestB00, TestB00>();
            c.Register<ITestB01, TestB01>();
            c.Register<ITestB02, TestB02>();
            c.Register<ITestB03, TestB03>();
            c.Register<ITestB04, TestB04>();
            c.Register<ITestB05, TestB05>();
            c.Register<ITestB06, TestB06>();
            c.Register<ITestB07, TestB07>();
            c.Register<ITestB08, TestB08>();
            c.Register<ITestB09, TestB09>();

            c.Register<ITestB10, TestB10>();
            c.Register<ITestB11, TestB11>();
            c.Register<ITestB12, TestB12>();
            c.Register<ITestB13, TestB13>();
            c.Register<ITestB14, TestB14>();
            c.Register<ITestB15, TestB15>();
            c.Register<ITestB16, TestB16>();
            c.Register<ITestB17, TestB17>();
            c.Register<ITestB18, TestB18>();
            c.Register<ITestB19, TestB19>();

            c.Register<ITestB20, TestB20>();
            c.Register<ITestB21, TestB21>();
            c.Register<ITestB22, TestB22>();
            c.Register<ITestB23, TestB23>();
            c.Register<ITestB24, TestB24>();
            c.Register<ITestB25, TestB25>();
            c.Register<ITestB26, TestB26>();
            c.Register<ITestB27, TestB27>();
            c.Register<ITestB28, TestB28>();
            c.Register<ITestB29, TestB29>();

            c.Register<ITestB30, TestB30>();
            c.Register<ITestB31, TestB31>();
            c.Register<ITestB32, TestB32>();
            c.Register<ITestB33, TestB33>();
            c.Register<ITestB34, TestB34>();
            c.Register<ITestB35, TestB35>();
            c.Register<ITestB36, TestB36>();
            c.Register<ITestB37, TestB37>();
            c.Register<ITestB38, TestB38>();
            c.Register<ITestB39, TestB39>();

            c.Register<ITestB40, TestB40>();
            c.Register<ITestB41, TestB41>();
            c.Register<ITestB42, TestB42>();
            c.Register<ITestB43, TestB43>();
            c.Register<ITestB44, TestB44>();
            c.Register<ITestB45, TestB45>();
            c.Register<ITestB46, TestB46>();
            c.Register<ITestB47, TestB47>();
            c.Register<ITestB48, TestB48>();
            c.Register<ITestB49, TestB49>();

            c.Register<ITestB50, TestB50>();
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void LightInjectResolve(ServiceContainer c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestB50>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestB50>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }


        [TestMethod]
        public void WindsorTest()
        {
            WriteLine("\nWindsor");

            var c = new WindsorContainer();
            WindsorRegister(c);
            WindsorResolve(c, _testCasesNumber);
            c.Dispose();
        }

        private void WindsorRegister(WindsorContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register(Component.For<ITestB00>().ImplementedBy<TestB00>().LifeStyle.Transient);
            c.Register(Component.For<ITestB01>().ImplementedBy<TestB01>().LifeStyle.Transient);
            c.Register(Component.For<ITestB02>().ImplementedBy<TestB02>().LifeStyle.Transient);
            c.Register(Component.For<ITestB03>().ImplementedBy<TestB03>().LifeStyle.Transient);
            c.Register(Component.For<ITestB04>().ImplementedBy<TestB04>().LifeStyle.Transient);
            c.Register(Component.For<ITestB05>().ImplementedBy<TestB05>().LifeStyle.Transient);
            c.Register(Component.For<ITestB06>().ImplementedBy<TestB06>().LifeStyle.Transient);
            c.Register(Component.For<ITestB07>().ImplementedBy<TestB07>().LifeStyle.Transient);
            c.Register(Component.For<ITestB08>().ImplementedBy<TestB08>().LifeStyle.Transient);
            c.Register(Component.For<ITestB09>().ImplementedBy<TestB09>().LifeStyle.Transient);

            c.Register(Component.For<ITestB10>().ImplementedBy<TestB10>().LifeStyle.Transient);
            c.Register(Component.For<ITestB11>().ImplementedBy<TestB11>().LifeStyle.Transient);
            c.Register(Component.For<ITestB12>().ImplementedBy<TestB12>().LifeStyle.Transient);
            c.Register(Component.For<ITestB13>().ImplementedBy<TestB13>().LifeStyle.Transient);
            c.Register(Component.For<ITestB14>().ImplementedBy<TestB14>().LifeStyle.Transient);
            c.Register(Component.For<ITestB15>().ImplementedBy<TestB15>().LifeStyle.Transient);
            c.Register(Component.For<ITestB16>().ImplementedBy<TestB16>().LifeStyle.Transient);
            c.Register(Component.For<ITestB17>().ImplementedBy<TestB17>().LifeStyle.Transient);
            c.Register(Component.For<ITestB18>().ImplementedBy<TestB18>().LifeStyle.Transient);
            c.Register(Component.For<ITestB19>().ImplementedBy<TestB19>().LifeStyle.Transient);

            c.Register(Component.For<ITestB20>().ImplementedBy<TestB20>().LifeStyle.Transient);
            c.Register(Component.For<ITestB21>().ImplementedBy<TestB21>().LifeStyle.Transient);
            c.Register(Component.For<ITestB22>().ImplementedBy<TestB22>().LifeStyle.Transient);
            c.Register(Component.For<ITestB23>().ImplementedBy<TestB23>().LifeStyle.Transient);
            c.Register(Component.For<ITestB24>().ImplementedBy<TestB24>().LifeStyle.Transient);
            c.Register(Component.For<ITestB25>().ImplementedBy<TestB25>().LifeStyle.Transient);
            c.Register(Component.For<ITestB26>().ImplementedBy<TestB26>().LifeStyle.Transient);
            c.Register(Component.For<ITestB27>().ImplementedBy<TestB27>().LifeStyle.Transient);
            c.Register(Component.For<ITestB28>().ImplementedBy<TestB28>().LifeStyle.Transient);
            c.Register(Component.For<ITestB29>().ImplementedBy<TestB29>().LifeStyle.Transient);

            c.Register(Component.For<ITestB30>().ImplementedBy<TestB30>().LifeStyle.Transient);
            c.Register(Component.For<ITestB31>().ImplementedBy<TestB31>().LifeStyle.Transient);
            c.Register(Component.For<ITestB32>().ImplementedBy<TestB32>().LifeStyle.Transient);
            c.Register(Component.For<ITestB33>().ImplementedBy<TestB33>().LifeStyle.Transient);
            c.Register(Component.For<ITestB34>().ImplementedBy<TestB34>().LifeStyle.Transient);
            c.Register(Component.For<ITestB35>().ImplementedBy<TestB35>().LifeStyle.Transient);
            c.Register(Component.For<ITestB36>().ImplementedBy<TestB36>().LifeStyle.Transient);
            c.Register(Component.For<ITestB37>().ImplementedBy<TestB37>().LifeStyle.Transient);
            c.Register(Component.For<ITestB38>().ImplementedBy<TestB38>().LifeStyle.Transient);
            c.Register(Component.For<ITestB39>().ImplementedBy<TestB39>().LifeStyle.Transient);

            c.Register(Component.For<ITestB40>().ImplementedBy<TestB40>().LifeStyle.Transient);
            c.Register(Component.For<ITestB41>().ImplementedBy<TestB41>().LifeStyle.Transient);
            c.Register(Component.For<ITestB42>().ImplementedBy<TestB42>().LifeStyle.Transient);
            c.Register(Component.For<ITestB43>().ImplementedBy<TestB43>().LifeStyle.Transient);
            c.Register(Component.For<ITestB44>().ImplementedBy<TestB44>().LifeStyle.Transient);
            c.Register(Component.For<ITestB45>().ImplementedBy<TestB45>().LifeStyle.Transient);
            c.Register(Component.For<ITestB46>().ImplementedBy<TestB46>().LifeStyle.Transient);
            c.Register(Component.For<ITestB47>().ImplementedBy<TestB47>().LifeStyle.Transient);
            c.Register(Component.For<ITestB48>().ImplementedBy<TestB48>().LifeStyle.Transient);
            c.Register(Component.For<ITestB49>().ImplementedBy<TestB49>().LifeStyle.Transient);

            c.Register(Component.For<ITestB50>().ImplementedBy<TestB50>().LifeStyle.Transient);
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void WindsorResolve(WindsorContainer c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestB50>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestB50>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }


        [TestMethod]
        public void StructureMapTest()
        {
            WriteLine("\nStructureMap");

            var c = new StructureMap.Container();
            StructureMapRegister(c);
            StructureMapResolve(c, _testCasesNumber);
            c.Dispose();
        }

        private void StructureMapRegister(StructureMap.Container c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Configure(x =>
            {
                x.For<ITestB00>().Use<TestB00>().AlwaysUnique();
                x.For<ITestB01>().Use<TestB01>().AlwaysUnique();
                x.For<ITestB02>().Use<TestB02>().AlwaysUnique();
                x.For<ITestB03>().Use<TestB03>().AlwaysUnique();
                x.For<ITestB04>().Use<TestB04>().AlwaysUnique();
                x.For<ITestB05>().Use<TestB05>().AlwaysUnique();
                x.For<ITestB06>().Use<TestB06>().AlwaysUnique();
                x.For<ITestB07>().Use<TestB07>().AlwaysUnique();
                x.For<ITestB08>().Use<TestB08>().AlwaysUnique();
                x.For<ITestB09>().Use<TestB09>().AlwaysUnique();

                x.For<ITestB10>().Use<TestB10>().AlwaysUnique();
                x.For<ITestB11>().Use<TestB11>().AlwaysUnique();
                x.For<ITestB12>().Use<TestB12>().AlwaysUnique();
                x.For<ITestB13>().Use<TestB13>().AlwaysUnique();
                x.For<ITestB14>().Use<TestB14>().AlwaysUnique();
                x.For<ITestB15>().Use<TestB15>().AlwaysUnique();
                x.For<ITestB16>().Use<TestB16>().AlwaysUnique();
                x.For<ITestB17>().Use<TestB17>().AlwaysUnique();
                x.For<ITestB18>().Use<TestB18>().AlwaysUnique();
                x.For<ITestB19>().Use<TestB19>().AlwaysUnique();

                x.For<ITestB20>().Use<TestB20>().AlwaysUnique();
                x.For<ITestB21>().Use<TestB21>().AlwaysUnique();
                x.For<ITestB22>().Use<TestB22>().AlwaysUnique();
                x.For<ITestB23>().Use<TestB23>().AlwaysUnique();
                x.For<ITestB24>().Use<TestB24>().AlwaysUnique();
                x.For<ITestB25>().Use<TestB25>().AlwaysUnique();
                x.For<ITestB26>().Use<TestB26>().AlwaysUnique();
                x.For<ITestB27>().Use<TestB27>().AlwaysUnique();
                x.For<ITestB28>().Use<TestB28>().AlwaysUnique();
                x.For<ITestB29>().Use<TestB29>().AlwaysUnique();

                x.For<ITestB30>().Use<TestB30>().AlwaysUnique();
                x.For<ITestB31>().Use<TestB31>().AlwaysUnique();
                x.For<ITestB32>().Use<TestB32>().AlwaysUnique();
                x.For<ITestB33>().Use<TestB33>().AlwaysUnique();
                x.For<ITestB34>().Use<TestB34>().AlwaysUnique();
                x.For<ITestB35>().Use<TestB35>().AlwaysUnique();
                x.For<ITestB36>().Use<TestB36>().AlwaysUnique();
                x.For<ITestB37>().Use<TestB37>().AlwaysUnique();
                x.For<ITestB38>().Use<TestB38>().AlwaysUnique();
                x.For<ITestB39>().Use<TestB39>().AlwaysUnique();

                x.For<ITestB40>().Use<TestB40>().AlwaysUnique();
                x.For<ITestB41>().Use<TestB41>().AlwaysUnique();
                x.For<ITestB42>().Use<TestB42>().AlwaysUnique();
                x.For<ITestB43>().Use<TestB43>().AlwaysUnique();
                x.For<ITestB44>().Use<TestB44>().AlwaysUnique();
                x.For<ITestB45>().Use<TestB45>().AlwaysUnique();
                x.For<ITestB46>().Use<TestB46>().AlwaysUnique();
                x.For<ITestB47>().Use<TestB47>().AlwaysUnique();
                x.For<ITestB48>().Use<TestB48>().AlwaysUnique();
                x.For<ITestB49>().Use<TestB49>().AlwaysUnique();

                x.For<ITestB50>().Use<TestB50>().AlwaysUnique();
            });
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void StructureMapResolve(StructureMap.Container c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestB50>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestB50>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }


        [TestMethod]
        public void AutofacTest()
        {
            WriteLine("\nAutofac");

            var cb = new ContainerBuilder();
            Autofac.IContainer c = AutofacRegister(cb);
            AutofacResolve(c, _testCasesNumber);
            c.Dispose();
        }

        private Autofac.IContainer AutofacRegister(ContainerBuilder cb)
        {
            var sw = new Stopwatch();

            sw.Start();
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

            cb.RegisterType<TestB50>().As<ITestB50>();

            Autofac.IContainer c = cb.Build();
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            return c;
        }

        private void AutofacResolve(Autofac.IContainer c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestB50>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestB50>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }

        [TestMethod]
        public void UnityTest()
        {
            WriteLine("\nUnity");

            var c = new UnityContainer();
            UnityRegister(c);
            UnityResolve(c, _testCasesNumber);
            c.Dispose();
        }

        private void UnityRegister(UnityContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.RegisterType<ITestB00, TestB00>();
            c.RegisterType<ITestB01, TestB01>();
            c.RegisterType<ITestB02, TestB02>();
            c.RegisterType<ITestB03, TestB03>();
            c.RegisterType<ITestB04, TestB04>();
            c.RegisterType<ITestB05, TestB05>();
            c.RegisterType<ITestB06, TestB06>();
            c.RegisterType<ITestB07, TestB07>();
            c.RegisterType<ITestB08, TestB08>();
            c.RegisterType<ITestB09, TestB09>();

            c.RegisterType<ITestB10, TestB10>();
            c.RegisterType<ITestB11, TestB11>();
            c.RegisterType<ITestB12, TestB12>();
            c.RegisterType<ITestB13, TestB13>();
            c.RegisterType<ITestB14, TestB14>();
            c.RegisterType<ITestB15, TestB15>();
            c.RegisterType<ITestB16, TestB16>();
            c.RegisterType<ITestB17, TestB17>();
            c.RegisterType<ITestB18, TestB18>();
            c.RegisterType<ITestB19, TestB19>();

            c.RegisterType<ITestB20, TestB20>();
            c.RegisterType<ITestB21, TestB21>();
            c.RegisterType<ITestB22, TestB22>();
            c.RegisterType<ITestB23, TestB23>();
            c.RegisterType<ITestB24, TestB24>();
            c.RegisterType<ITestB25, TestB25>();
            c.RegisterType<ITestB26, TestB26>();
            c.RegisterType<ITestB27, TestB27>();
            c.RegisterType<ITestB28, TestB28>();
            c.RegisterType<ITestB29, TestB29>();

            c.RegisterType<ITestB30, TestB30>();
            c.RegisterType<ITestB31, TestB31>();
            c.RegisterType<ITestB32, TestB32>();
            c.RegisterType<ITestB33, TestB33>();
            c.RegisterType<ITestB34, TestB34>();
            c.RegisterType<ITestB35, TestB35>();
            c.RegisterType<ITestB36, TestB36>();
            c.RegisterType<ITestB37, TestB37>();
            c.RegisterType<ITestB38, TestB38>();
            c.RegisterType<ITestB39, TestB39>();

            c.RegisterType<ITestB40, TestB40>();
            c.RegisterType<ITestB41, TestB41>();
            c.RegisterType<ITestB42, TestB42>();
            c.RegisterType<ITestB43, TestB43>();
            c.RegisterType<ITestB44, TestB44>();
            c.RegisterType<ITestB45, TestB45>();
            c.RegisterType<ITestB46, TestB46>();
            c.RegisterType<ITestB47, TestB47>();
            c.RegisterType<ITestB48, TestB48>();
            c.RegisterType<ITestB49, TestB49>();

            c.RegisterType<ITestB50, TestB50>();
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void UnityResolve(UnityContainer c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestB50>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestB50>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }


        [TestMethod]
        public void NiquIoCTest()
        {
            WriteLine("\nNiquIoC");

            var c = new NiquIoC.Container();
            NiquIoCRegister(c);
            NiquIoCResolve(c, _testCasesNumber);
        }

        private void NiquIoCRegister(NiquIoC.Container c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.RegisterType<ITestB00, TestB00>();
            c.RegisterType<ITestB01, TestB01>();
            c.RegisterType<ITestB02, TestB02>();
            c.RegisterType<ITestB03, TestB03>();
            c.RegisterType<ITestB04, TestB04>();
            c.RegisterType<ITestB05, TestB05>();
            c.RegisterType<ITestB06, TestB06>();
            c.RegisterType<ITestB07, TestB07>();
            c.RegisterType<ITestB08, TestB08>();
            c.RegisterType<ITestB09, TestB09>();

            c.RegisterType<ITestB10, TestB10>();
            c.RegisterType<ITestB11, TestB11>();
            c.RegisterType<ITestB12, TestB12>();
            c.RegisterType<ITestB13, TestB13>();
            c.RegisterType<ITestB14, TestB14>();
            c.RegisterType<ITestB15, TestB15>();
            c.RegisterType<ITestB16, TestB16>();
            c.RegisterType<ITestB17, TestB17>();
            c.RegisterType<ITestB18, TestB18>();
            c.RegisterType<ITestB19, TestB19>();

            c.RegisterType<ITestB20, TestB20>();
            c.RegisterType<ITestB21, TestB21>();
            c.RegisterType<ITestB22, TestB22>();
            c.RegisterType<ITestB23, TestB23>();
            c.RegisterType<ITestB24, TestB24>();
            c.RegisterType<ITestB25, TestB25>();
            c.RegisterType<ITestB26, TestB26>();
            c.RegisterType<ITestB27, TestB27>();
            c.RegisterType<ITestB28, TestB28>();
            c.RegisterType<ITestB29, TestB29>();

            c.RegisterType<ITestB30, TestB30>();
            c.RegisterType<ITestB31, TestB31>();
            c.RegisterType<ITestB32, TestB32>();
            c.RegisterType<ITestB33, TestB33>();
            c.RegisterType<ITestB34, TestB34>();
            c.RegisterType<ITestB35, TestB35>();
            c.RegisterType<ITestB36, TestB36>();
            c.RegisterType<ITestB37, TestB37>();
            c.RegisterType<ITestB38, TestB38>();
            c.RegisterType<ITestB39, TestB39>();

            c.RegisterType<ITestB40, TestB40>();
            c.RegisterType<ITestB41, TestB41>();
            c.RegisterType<ITestB42, TestB42>();
            c.RegisterType<ITestB43, TestB43>();
            c.RegisterType<ITestB44, TestB44>();
            c.RegisterType<ITestB45, TestB45>();
            c.RegisterType<ITestB46, TestB46>();
            c.RegisterType<ITestB47, TestB47>();
            c.RegisterType<ITestB48, TestB48>();
            c.RegisterType<ITestB49, TestB49>();

            c.RegisterType<ITestB50, TestB50>();
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void NiquIoCResolve(NiquIoC.Container c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestB50>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestB50>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }
    }
}