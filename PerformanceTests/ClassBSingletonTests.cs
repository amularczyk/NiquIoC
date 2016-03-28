using System;
using System.Diagnostics;
using System.IO;
using Autofac;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;
using StructureMap;
using IContainer = Autofac.IContainer;

namespace PerformanceTests
{
    [TestClass]
    public class ClassBSingletonTests
    {
        private static readonly int _testCasesNumber = 1;
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "PerforamceTests_B_Singleton_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

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

            Assert.AreEqual(testB50.TestB49.TestB39, testB50.TestB48.TestB39);
            Assert.AreEqual(testB50.TestB49.TestB38, testB50.TestB48.TestB38);
            Assert.AreEqual(testB50.TestB49.TestB37, testB50.TestB48.TestB37);
            Assert.AreEqual(testB50.TestB49.TestB36, testB50.TestB48.TestB36);
            Assert.AreEqual(testB50.TestB49.TestB35, testB50.TestB48.TestB35);
            Assert.AreEqual(testB50.TestB49.TestB34, testB50.TestB48.TestB34);
            Assert.AreEqual(testB50.TestB49.TestB33, testB50.TestB48.TestB33);
            Assert.AreEqual(testB50.TestB49.TestB32, testB50.TestB48.TestB32);
            Assert.AreEqual(testB50.TestB49.TestB31, testB50.TestB48.TestB31);
            Assert.AreEqual(testB50.TestB49.TestB30, testB50.TestB48.TestB30);

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
        public void WindsorTest()
        {
            WriteLine("\nWindsor");

            var c = new WindsorContainer();
            WindsorRegister(c);
            WindsorResolve(c, _testCasesNumber);
        }

        private void WindsorRegister(WindsorContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register(Component.For<ITestB00>().ImplementedBy<TestB00>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB01>().ImplementedBy<TestB01>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB02>().ImplementedBy<TestB02>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB03>().ImplementedBy<TestB03>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB04>().ImplementedBy<TestB04>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB05>().ImplementedBy<TestB05>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB06>().ImplementedBy<TestB06>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB07>().ImplementedBy<TestB07>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB08>().ImplementedBy<TestB08>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB09>().ImplementedBy<TestB09>().LifeStyle.Singleton);

            c.Register(Component.For<ITestB10>().ImplementedBy<TestB10>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB11>().ImplementedBy<TestB11>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB12>().ImplementedBy<TestB12>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB13>().ImplementedBy<TestB13>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB14>().ImplementedBy<TestB14>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB15>().ImplementedBy<TestB15>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB16>().ImplementedBy<TestB16>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB17>().ImplementedBy<TestB17>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB18>().ImplementedBy<TestB18>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB19>().ImplementedBy<TestB19>().LifeStyle.Singleton);

            c.Register(Component.For<ITestB20>().ImplementedBy<TestB20>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB21>().ImplementedBy<TestB21>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB22>().ImplementedBy<TestB22>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB23>().ImplementedBy<TestB23>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB24>().ImplementedBy<TestB24>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB25>().ImplementedBy<TestB25>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB26>().ImplementedBy<TestB26>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB27>().ImplementedBy<TestB27>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB28>().ImplementedBy<TestB28>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB29>().ImplementedBy<TestB29>().LifeStyle.Singleton);

            c.Register(Component.For<ITestB30>().ImplementedBy<TestB30>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB31>().ImplementedBy<TestB31>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB32>().ImplementedBy<TestB32>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB33>().ImplementedBy<TestB33>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB34>().ImplementedBy<TestB34>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB35>().ImplementedBy<TestB35>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB36>().ImplementedBy<TestB36>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB37>().ImplementedBy<TestB37>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB38>().ImplementedBy<TestB38>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB39>().ImplementedBy<TestB39>().LifeStyle.Singleton);

            c.Register(Component.For<ITestB40>().ImplementedBy<TestB40>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB41>().ImplementedBy<TestB41>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB42>().ImplementedBy<TestB42>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB43>().ImplementedBy<TestB43>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB44>().ImplementedBy<TestB44>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB45>().ImplementedBy<TestB45>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB46>().ImplementedBy<TestB46>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB47>().ImplementedBy<TestB47>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB48>().ImplementedBy<TestB48>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB49>().ImplementedBy<TestB49>().LifeStyle.Singleton);

            c.Register(Component.For<ITestB50>().ImplementedBy<TestB50>().LifeStyle.Singleton);
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

                Assert.AreEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }

        [TestMethod]
        public void StructureMapTest()
        {
            WriteLine("\nStructureMap");

            var c = new Container();
            StructureMapRegister(c);
            StructureMapResolve(c, _testCasesNumber);
        }

        private void StructureMapRegister(Container c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Configure(x =>
            {
                x.For<ITestB00>().Use<TestB00>().Singleton();
                x.For<ITestB01>().Use<TestB01>().Singleton();
                x.For<ITestB02>().Use<TestB02>().Singleton();
                x.For<ITestB03>().Use<TestB03>().Singleton();
                x.For<ITestB04>().Use<TestB04>().Singleton();
                x.For<ITestB05>().Use<TestB05>().Singleton();
                x.For<ITestB06>().Use<TestB06>().Singleton();
                x.For<ITestB07>().Use<TestB07>().Singleton();
                x.For<ITestB08>().Use<TestB08>().Singleton();
                x.For<ITestB09>().Use<TestB09>().Singleton();

                x.For<ITestB10>().Use<TestB10>().Singleton();
                x.For<ITestB11>().Use<TestB11>().Singleton();
                x.For<ITestB12>().Use<TestB12>().Singleton();
                x.For<ITestB13>().Use<TestB13>().Singleton();
                x.For<ITestB14>().Use<TestB14>().Singleton();
                x.For<ITestB15>().Use<TestB15>().Singleton();
                x.For<ITestB16>().Use<TestB16>().Singleton();
                x.For<ITestB17>().Use<TestB17>().Singleton();
                x.For<ITestB18>().Use<TestB18>().Singleton();
                x.For<ITestB19>().Use<TestB19>().Singleton();

                x.For<ITestB20>().Use<TestB20>().Singleton();
                x.For<ITestB21>().Use<TestB21>().Singleton();
                x.For<ITestB22>().Use<TestB22>().Singleton();
                x.For<ITestB23>().Use<TestB23>().Singleton();
                x.For<ITestB24>().Use<TestB24>().Singleton();
                x.For<ITestB25>().Use<TestB25>().Singleton();
                x.For<ITestB26>().Use<TestB26>().Singleton();
                x.For<ITestB27>().Use<TestB27>().Singleton();
                x.For<ITestB28>().Use<TestB28>().Singleton();
                x.For<ITestB29>().Use<TestB29>().Singleton();

                x.For<ITestB30>().Use<TestB30>().Singleton();
                x.For<ITestB31>().Use<TestB31>().Singleton();
                x.For<ITestB32>().Use<TestB32>().Singleton();
                x.For<ITestB33>().Use<TestB33>().Singleton();
                x.For<ITestB34>().Use<TestB34>().Singleton();
                x.For<ITestB35>().Use<TestB35>().Singleton();
                x.For<ITestB36>().Use<TestB36>().Singleton();
                x.For<ITestB37>().Use<TestB37>().Singleton();
                x.For<ITestB38>().Use<TestB38>().Singleton();
                x.For<ITestB39>().Use<TestB39>().Singleton();

                x.For<ITestB40>().Use<TestB40>().Singleton();
                x.For<ITestB41>().Use<TestB41>().Singleton();
                x.For<ITestB42>().Use<TestB42>().Singleton();
                x.For<ITestB43>().Use<TestB43>().Singleton();
                x.For<ITestB44>().Use<TestB44>().Singleton();
                x.For<ITestB45>().Use<TestB45>().Singleton();
                x.For<ITestB46>().Use<TestB46>().Singleton();
                x.For<ITestB47>().Use<TestB47>().Singleton();
                x.For<ITestB48>().Use<TestB48>().Singleton();
                x.For<ITestB49>().Use<TestB49>().Singleton();

                x.For<ITestB50>().Use<TestB50>().Singleton();
            });
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void StructureMapResolve(Container c, int testCasesNumber)
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

                Assert.AreEqual(test, lastValue);
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
            IContainer c = AutofacRegister(cb);
            AutofacResolve(c, _testCasesNumber);
        }

        private IContainer AutofacRegister(ContainerBuilder cb)
        {
            var sw = new Stopwatch();

            sw.Start();
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

            cb.RegisterType<TestB50>().As<ITestB50>().SingleInstance();

            IContainer c = cb.Build();
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            return c;
        }

        private void AutofacResolve(IContainer c, int testCasesNumber)
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

                Assert.AreEqual(test, lastValue);
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
        }

        private void UnityRegister(UnityContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.RegisterType<ITestB00, TestB00>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB01, TestB01>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB02, TestB02>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB03, TestB03>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB04, TestB04>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB05, TestB05>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB06, TestB06>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB07, TestB07>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB08, TestB08>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB09, TestB09>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB10, TestB10>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB11, TestB11>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB12, TestB12>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB13, TestB13>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB14, TestB14>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB15, TestB15>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB16, TestB16>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB17, TestB17>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB18, TestB18>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB19, TestB19>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB20, TestB20>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB21, TestB21>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB22, TestB22>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB23, TestB23>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB24, TestB24>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB25, TestB25>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB26, TestB26>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB27, TestB27>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB28, TestB28>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB29, TestB29>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB30, TestB30>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB31, TestB31>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB32, TestB32>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB33, TestB33>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB34, TestB34>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB35, TestB35>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB36, TestB36>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB37, TestB37>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB38, TestB38>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB39, TestB39>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB40, TestB40>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB41, TestB41>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB42, TestB42>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB43, TestB43>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB44, TestB44>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB45, TestB45>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB46, TestB46>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB47, TestB47>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB48, TestB48>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB49, TestB49>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB50, TestB50>(new ContainerControlledLifetimeManager());
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

                Assert.AreEqual(test, lastValue);
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
            c.RegisterType<ITestB00, TestB00>().AsSingleton();
            c.RegisterType<ITestB01, TestB01>().AsSingleton();
            c.RegisterType<ITestB02, TestB02>().AsSingleton();
            c.RegisterType<ITestB03, TestB03>().AsSingleton();
            c.RegisterType<ITestB04, TestB04>().AsSingleton();
            c.RegisterType<ITestB05, TestB05>().AsSingleton();
            c.RegisterType<ITestB06, TestB06>().AsSingleton();
            c.RegisterType<ITestB07, TestB07>().AsSingleton();
            c.RegisterType<ITestB08, TestB08>().AsSingleton();
            c.RegisterType<ITestB09, TestB09>().AsSingleton();

            c.RegisterType<ITestB10, TestB10>().AsSingleton();
            c.RegisterType<ITestB11, TestB11>().AsSingleton();
            c.RegisterType<ITestB12, TestB12>().AsSingleton();
            c.RegisterType<ITestB13, TestB13>().AsSingleton();
            c.RegisterType<ITestB14, TestB14>().AsSingleton();
            c.RegisterType<ITestB15, TestB15>().AsSingleton();
            c.RegisterType<ITestB16, TestB16>().AsSingleton();
            c.RegisterType<ITestB17, TestB17>().AsSingleton();
            c.RegisterType<ITestB18, TestB18>().AsSingleton();
            c.RegisterType<ITestB19, TestB19>().AsSingleton();

            c.RegisterType<ITestB20, TestB20>().AsSingleton();
            c.RegisterType<ITestB21, TestB21>().AsSingleton();
            c.RegisterType<ITestB22, TestB22>().AsSingleton();
            c.RegisterType<ITestB23, TestB23>().AsSingleton();
            c.RegisterType<ITestB24, TestB24>().AsSingleton();
            c.RegisterType<ITestB25, TestB25>().AsSingleton();
            c.RegisterType<ITestB26, TestB26>().AsSingleton();
            c.RegisterType<ITestB27, TestB27>().AsSingleton();
            c.RegisterType<ITestB28, TestB28>().AsSingleton();
            c.RegisterType<ITestB29, TestB29>().AsSingleton();

            c.RegisterType<ITestB30, TestB30>().AsSingleton();
            c.RegisterType<ITestB31, TestB31>().AsSingleton();
            c.RegisterType<ITestB32, TestB32>().AsSingleton();
            c.RegisterType<ITestB33, TestB33>().AsSingleton();
            c.RegisterType<ITestB34, TestB34>().AsSingleton();
            c.RegisterType<ITestB35, TestB35>().AsSingleton();
            c.RegisterType<ITestB36, TestB36>().AsSingleton();
            c.RegisterType<ITestB37, TestB37>().AsSingleton();
            c.RegisterType<ITestB38, TestB38>().AsSingleton();
            c.RegisterType<ITestB39, TestB39>().AsSingleton();

            c.RegisterType<ITestB40, TestB40>().AsSingleton();
            c.RegisterType<ITestB41, TestB41>().AsSingleton();
            c.RegisterType<ITestB42, TestB42>().AsSingleton();
            c.RegisterType<ITestB43, TestB43>().AsSingleton();
            c.RegisterType<ITestB44, TestB44>().AsSingleton();
            c.RegisterType<ITestB45, TestB45>().AsSingleton();
            c.RegisterType<ITestB46, TestB46>().AsSingleton();
            c.RegisterType<ITestB47, TestB47>().AsSingleton();
            c.RegisterType<ITestB48, TestB48>().AsSingleton();
            c.RegisterType<ITestB49, TestB49>().AsSingleton();

            c.RegisterType<ITestB50, TestB50>().AsSingleton();
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

                Assert.AreEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }
    }
}