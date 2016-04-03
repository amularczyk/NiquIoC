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
using SimpleInjector;

namespace PerformanceTests
{
    [TestClass]
    public class ClassASingletonTests
    {
        private static readonly int _testCasesNumber = 100;
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "PerforamceTests_A_Singleton_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        private static void Check(ITestA10 testA10)
        {
            Assert.IsNotNull(testA10);

            Assert.IsNotNull(testA10.TestA9);
            Assert.IsNotNull(testA10.TestA8);
            Assert.IsNotNull(testA10.TestA7);
            Assert.IsNotNull(testA10.TestA6);
            Assert.IsNotNull(testA10.TestA5);
            Assert.IsNotNull(testA10.TestA4);
            Assert.IsNotNull(testA10.TestA3);
            Assert.IsNotNull(testA10.TestA2);
            Assert.IsNotNull(testA10.TestA1);
            Assert.IsNotNull(testA10.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8);
            Assert.IsNotNull(testA10.TestA9.TestA7);
            Assert.IsNotNull(testA10.TestA9.TestA6);
            Assert.IsNotNull(testA10.TestA9.TestA5);
            Assert.IsNotNull(testA10.TestA9.TestA4);
            Assert.IsNotNull(testA10.TestA9.TestA3);
            Assert.IsNotNull(testA10.TestA9.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA0);

            Assert.AreEqual(testA10.TestA8, testA10.TestA9.TestA8);
            Assert.AreEqual(testA10.TestA7, testA10.TestA9.TestA7);
            Assert.AreEqual(testA10.TestA6, testA10.TestA9.TestA6);
            Assert.AreEqual(testA10.TestA5, testA10.TestA9.TestA5);
            Assert.AreEqual(testA10.TestA4, testA10.TestA9.TestA4);
            Assert.AreEqual(testA10.TestA3, testA10.TestA9.TestA3);
            Assert.AreEqual(testA10.TestA2, testA10.TestA9.TestA2);
            Assert.AreEqual(testA10.TestA1, testA10.TestA9.TestA1);
            Assert.AreEqual(testA10.TestA0, testA10.TestA9.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA6);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA5);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA4);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA3);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA5);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA4);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA3);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA3);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA3);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA1.TestA0);
        }

        private static void WriteLine(string text, params object[] args)
        {
            using (var file = new StreamWriter(_fileName, true))
            {
                file.WriteLine(text, args);
            }
        }


        [TestMethod]
        public void SimpleInjectorTest()
        {
            WriteLine("\nSimpleInjector");

            var c = new SimpleInjector.Container();
            SimpleInjectorRegister(c);
            SimpleInjectorResolve(c, _testCasesNumber);
            c.Dispose();
        }

        private void SimpleInjectorRegister(SimpleInjector.Container c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register<ITestA0, TestA0>(Lifestyle.Singleton);
            c.Register<ITestA1, TestA1>(Lifestyle.Singleton);
            c.Register<ITestA2, TestA2>(Lifestyle.Singleton);
            c.Register<ITestA3, TestA3>(Lifestyle.Singleton);
            c.Register<ITestA4, TestA4>(Lifestyle.Singleton);
            c.Register<ITestA5, TestA5>(Lifestyle.Singleton);
            c.Register<ITestA6, TestA6>(Lifestyle.Singleton);
            c.Register<ITestA7, TestA7>(Lifestyle.Singleton);
            c.Register<ITestA8, TestA8>(Lifestyle.Singleton);
            c.Register<ITestA9, TestA9>(Lifestyle.Singleton);
            c.Register<ITestA10, TestA10>(Lifestyle.Singleton);
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void SimpleInjectorResolve(SimpleInjector.Container c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestA10>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestA10>();
                sw.Stop();

                Assert.AreEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }


        [TestMethod]
        public void DryIocTest()
        {
            WriteLine("\nDryIoc");

            var c = new DryIoc.Container();
            DryIocRegister(c);
            DryIocResolve(c, _testCasesNumber);
            c.Dispose();
        }

        private void DryIocRegister(DryIoc.Container c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register<ITestA0, TestA0>(Reuse.Singleton);
            c.Register<ITestA1, TestA1>(Reuse.Singleton);
            c.Register<ITestA2, TestA2>(Reuse.Singleton);
            c.Register<ITestA3, TestA3>(Reuse.Singleton);
            c.Register<ITestA4, TestA4>(Reuse.Singleton);
            c.Register<ITestA5, TestA5>(Reuse.Singleton);
            c.Register<ITestA6, TestA6>(Reuse.Singleton);
            c.Register<ITestA7, TestA7>(Reuse.Singleton);
            c.Register<ITestA8, TestA8>(Reuse.Singleton);
            c.Register<ITestA9, TestA9>(Reuse.Singleton);
            c.Register<ITestA10, TestA10>(Reuse.Singleton);
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void DryIocResolve(DryIoc.Container c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestA10>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA10>();
                sw.Stop();

                Assert.AreEqual(test, lastValue);
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
            c.Register<ITestA0, TestA0>(new PerContainerLifetime());
            c.Register<ITestA1, TestA1>(new PerContainerLifetime());
            c.Register<ITestA2, TestA2>(new PerContainerLifetime());
            c.Register<ITestA3, TestA3>(new PerContainerLifetime());
            c.Register<ITestA4, TestA4>(new PerContainerLifetime());
            c.Register<ITestA5, TestA5>(new PerContainerLifetime());
            c.Register<ITestA6, TestA6>(new PerContainerLifetime());
            c.Register<ITestA7, TestA7>(new PerContainerLifetime());
            c.Register<ITestA8, TestA8>(new PerContainerLifetime());
            c.Register<ITestA9, TestA9>(new PerContainerLifetime());
            c.Register<ITestA10, TestA10>(new PerContainerLifetime());
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void LightInjectResolve(ServiceContainer c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestA10>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestA10>();
                sw.Stop();

                Assert.AreEqual(test, lastValue);
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
            c.Register(Component.For<ITestA0>().ImplementedBy<TestA0>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA1>().ImplementedBy<TestA1>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA2>().ImplementedBy<TestA2>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA3>().ImplementedBy<TestA3>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA4>().ImplementedBy<TestA4>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA5>().ImplementedBy<TestA5>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA6>().ImplementedBy<TestA6>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA7>().ImplementedBy<TestA7>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA8>().ImplementedBy<TestA8>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA9>().ImplementedBy<TestA9>().LifeStyle.Singleton);
            c.Register(Component.For<ITestA10>().ImplementedBy<TestA10>().LifeStyle.Singleton);
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void WindsorResolve(WindsorContainer c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestA10>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA10>();
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
                x.For<ITestA0>().Use<TestA0>().Singleton();
                x.For<ITestA0>().Use<TestA0>().Singleton();
                x.For<ITestA1>().Use<TestA1>().Singleton();
                x.For<ITestA2>().Use<TestA2>().Singleton();
                x.For<ITestA3>().Use<TestA3>().Singleton();
                x.For<ITestA4>().Use<TestA4>().Singleton();
                x.For<ITestA5>().Use<TestA5>().Singleton();
                x.For<ITestA6>().Use<TestA6>().Singleton();
                x.For<ITestA7>().Use<TestA7>().Singleton();
                x.For<ITestA8>().Use<TestA8>().Singleton();
                x.For<ITestA9>().Use<TestA9>().Singleton();
                x.For<ITestA10>().Use<TestA10>().Singleton();
            });
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void StructureMapResolve(StructureMap.Container c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestA10>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestA10>();
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
            Autofac.IContainer c = AutofacRegister(cb);
            AutofacResolve(c, _testCasesNumber);
            c.Dispose();
        }

        private Autofac.IContainer AutofacRegister(ContainerBuilder cb)
        {
            var sw = new Stopwatch();

            sw.Start();
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
            cb.RegisterType<TestA10>().As<ITestA10>().SingleInstance();
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
            var lastValue = c.Resolve<ITestA10>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA10>();
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
            c.Dispose();
        }

        private void UnityRegister(UnityContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.RegisterType<ITestA0, TestA0>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA1, TestA1>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA2, TestA2>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA3, TestA3>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA4, TestA4>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA5, TestA5>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA6, TestA6>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA7, TestA7>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA8, TestA8>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA9, TestA9>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestA10, TestA10>(new ContainerControlledLifetimeManager());
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void UnityResolve(UnityContainer c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestA10>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA10>();
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
            c.RegisterType<ITestA0, TestA0>().AsSingleton();
            c.RegisterType<ITestA1, TestA1>().AsSingleton();
            c.RegisterType<ITestA2, TestA2>().AsSingleton();
            c.RegisterType<ITestA3, TestA3>().AsSingleton();
            c.RegisterType<ITestA4, TestA4>().AsSingleton();
            c.RegisterType<ITestA5, TestA5>().AsSingleton();
            c.RegisterType<ITestA6, TestA6>().AsSingleton();
            c.RegisterType<ITestA7, TestA7>().AsSingleton();
            c.RegisterType<ITestA8, TestA8>().AsSingleton();
            c.RegisterType<ITestA9, TestA9>().AsSingleton();
            c.RegisterType<ITestA10, TestA10>().AsSingleton();
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void NiquIoCResolve(NiquIoC.Container c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestA10>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA10>();
                sw.Stop();

                Assert.AreEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }
    }
}