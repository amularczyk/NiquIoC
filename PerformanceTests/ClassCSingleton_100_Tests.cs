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
using Container = SimpleInjector.Container;
using IContainer = Autofac.IContainer;

namespace PerformanceTests
{
    [TestClass]
    public class ClassCSingleton_100_Tests
    {
        private static readonly int _testCasesNumber = 100;
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "PerforamceTests_C_100_Singleton_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        private static void Check(ITestC test)
        {
            Assert.IsNotNull(test);

            Assert.IsNotNull(test.TestCa10);
            Assert.IsNotNull(test.TestCb10);
            Assert.IsNotNull(test.TestCc10);

            Assert.IsNotNull(test.TestCa10.TestCa9);
            Assert.IsNotNull(test.TestCa10.TestCa8);
            Assert.IsNotNull(test.TestCa10.TestCa7);
            Assert.IsNotNull(test.TestCa10.TestCa6);
            Assert.IsNotNull(test.TestCa10.TestCa5);
            Assert.IsNotNull(test.TestCa10.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa7);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa6);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa5);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa0);

            Assert.AreEqual(test.TestCa10.TestCa8, test.TestCa10.TestCa9.TestCa8);
            Assert.AreEqual(test.TestCa10.TestCa7, test.TestCa10.TestCa9.TestCa7);
            Assert.AreEqual(test.TestCa10.TestCa6, test.TestCa10.TestCa9.TestCa6);
            Assert.AreEqual(test.TestCa10.TestCa5, test.TestCa10.TestCa9.TestCa5);
            Assert.AreEqual(test.TestCa10.TestCa4, test.TestCa10.TestCa9.TestCa4);
            Assert.AreEqual(test.TestCa10.TestCa3, test.TestCa10.TestCa9.TestCa3);
            Assert.AreEqual(test.TestCa10.TestCa2, test.TestCa10.TestCa9.TestCa2);
            Assert.AreEqual(test.TestCa10.TestCa1, test.TestCa10.TestCa9.TestCa1);
            Assert.AreEqual(test.TestCa10.TestCa0, test.TestCa10.TestCa9.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa6);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa5);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa5);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa1.TestCa0);
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

            var c = new Container();
            SimpleInjectorRegister(c);
            SimpleInjectorResolve(c, _testCasesNumber);
            c.Dispose();
        }

        private void SimpleInjectorRegister(Container c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register<ITestCa0, TestCa0>(Lifestyle.Singleton);
            c.Register<ITestCa1, TestCa1>(Lifestyle.Singleton);
            c.Register<ITestCa2, TestCa2>(Lifestyle.Singleton);
            c.Register<ITestCa3, TestCa3>(Lifestyle.Singleton);
            c.Register<ITestCa4, TestCa4>(Lifestyle.Singleton);
            c.Register<ITestCa5, TestCa5>(Lifestyle.Singleton);
            c.Register<ITestCa6, TestCa6>(Lifestyle.Singleton);
            c.Register<ITestCa7, TestCa7>(Lifestyle.Singleton);
            c.Register<ITestCa8, TestCa8>(Lifestyle.Singleton);
            c.Register<ITestCa9, TestCa9>(Lifestyle.Singleton);
            c.Register<ITestCa10, TestCa10>(Lifestyle.Singleton);

            c.Register<ITestCb0, TestCb0>(Lifestyle.Singleton);
            c.Register<ITestCb1, TestCb1>(Lifestyle.Singleton);
            c.Register<ITestCb2, TestCb2>(Lifestyle.Singleton);
            c.Register<ITestCb3, TestCb3>(Lifestyle.Singleton);
            c.Register<ITestCb4, TestCb4>(Lifestyle.Singleton);
            c.Register<ITestCb5, TestCb5>(Lifestyle.Singleton);
            c.Register<ITestCb6, TestCb6>(Lifestyle.Singleton);
            c.Register<ITestCb7, TestCb7>(Lifestyle.Singleton);
            c.Register<ITestCb8, TestCb8>(Lifestyle.Singleton);
            c.Register<ITestCb9, TestCb9>(Lifestyle.Singleton);
            c.Register<ITestCb10, TestCb10>(Lifestyle.Singleton);

            c.Register<ITestCc0, TestCc0>(Lifestyle.Singleton);
            c.Register<ITestCc1, TestCc1>(Lifestyle.Singleton);
            c.Register<ITestCc2, TestCc2>(Lifestyle.Singleton);
            c.Register<ITestCc3, TestCc3>(Lifestyle.Singleton);
            c.Register<ITestCc4, TestCc4>(Lifestyle.Singleton);
            c.Register<ITestCc5, TestCc5>(Lifestyle.Singleton);
            c.Register<ITestCc6, TestCc6>(Lifestyle.Singleton);
            c.Register<ITestCc7, TestCc7>(Lifestyle.Singleton);
            c.Register<ITestCc8, TestCc8>(Lifestyle.Singleton);
            c.Register<ITestCc9, TestCc9>(Lifestyle.Singleton);
            c.Register<ITestCc10, TestCc10>(Lifestyle.Singleton);

            c.Register<ITestC, TestC>(Lifestyle.Singleton);
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void SimpleInjectorResolve(Container c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestC>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestC>();
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
            c.Register<ITestCa0, TestCa0>(Reuse.Singleton);
            c.Register<ITestCa1, TestCa1>(Reuse.Singleton);
            c.Register<ITestCa2, TestCa2>(Reuse.Singleton);
            c.Register<ITestCa3, TestCa3>(Reuse.Singleton);
            c.Register<ITestCa4, TestCa4>(Reuse.Singleton);
            c.Register<ITestCa5, TestCa5>(Reuse.Singleton);
            c.Register<ITestCa6, TestCa6>(Reuse.Singleton);
            c.Register<ITestCa7, TestCa7>(Reuse.Singleton);
            c.Register<ITestCa8, TestCa8>(Reuse.Singleton);
            c.Register<ITestCa9, TestCa9>(Reuse.Singleton);
            c.Register<ITestCa10, TestCa10>(Reuse.Singleton);

            c.Register<ITestCb0, TestCb0>(Reuse.Singleton);
            c.Register<ITestCb1, TestCb1>(Reuse.Singleton);
            c.Register<ITestCb2, TestCb2>(Reuse.Singleton);
            c.Register<ITestCb3, TestCb3>(Reuse.Singleton);
            c.Register<ITestCb4, TestCb4>(Reuse.Singleton);
            c.Register<ITestCb5, TestCb5>(Reuse.Singleton);
            c.Register<ITestCb6, TestCb6>(Reuse.Singleton);
            c.Register<ITestCb7, TestCb7>(Reuse.Singleton);
            c.Register<ITestCb8, TestCb8>(Reuse.Singleton);
            c.Register<ITestCb9, TestCb9>(Reuse.Singleton);
            c.Register<ITestCb10, TestCb10>(Reuse.Singleton);

            c.Register<ITestCc0, TestCc0>(Reuse.Singleton);
            c.Register<ITestCc1, TestCc1>(Reuse.Singleton);
            c.Register<ITestCc2, TestCc2>(Reuse.Singleton);
            c.Register<ITestCc3, TestCc3>(Reuse.Singleton);
            c.Register<ITestCc4, TestCc4>(Reuse.Singleton);
            c.Register<ITestCc5, TestCc5>(Reuse.Singleton);
            c.Register<ITestCc6, TestCc6>(Reuse.Singleton);
            c.Register<ITestCc7, TestCc7>(Reuse.Singleton);
            c.Register<ITestCc8, TestCc8>(Reuse.Singleton);
            c.Register<ITestCc9, TestCc9>(Reuse.Singleton);
            c.Register<ITestCc10, TestCc10>(Reuse.Singleton);

            c.Register<ITestC, TestC>(Reuse.Singleton);
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void DryIocResolve(DryIoc.Container c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestC>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestC>();
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
            c.Register<ITestCa0, TestCa0>(new PerContainerLifetime());
            c.Register<ITestCa1, TestCa1>(new PerContainerLifetime());
            c.Register<ITestCa2, TestCa2>(new PerContainerLifetime());
            c.Register<ITestCa3, TestCa3>(new PerContainerLifetime());
            c.Register<ITestCa4, TestCa4>(new PerContainerLifetime());
            c.Register<ITestCa5, TestCa5>(new PerContainerLifetime());
            c.Register<ITestCa6, TestCa6>(new PerContainerLifetime());
            c.Register<ITestCa7, TestCa7>(new PerContainerLifetime());
            c.Register<ITestCa8, TestCa8>(new PerContainerLifetime());
            c.Register<ITestCa9, TestCa9>(new PerContainerLifetime());
            c.Register<ITestCa10, TestCa10>(new PerContainerLifetime());

            c.Register<ITestCb0, TestCb0>(new PerContainerLifetime());
            c.Register<ITestCb1, TestCb1>(new PerContainerLifetime());
            c.Register<ITestCb2, TestCb2>(new PerContainerLifetime());
            c.Register<ITestCb3, TestCb3>(new PerContainerLifetime());
            c.Register<ITestCb4, TestCb4>(new PerContainerLifetime());
            c.Register<ITestCb5, TestCb5>(new PerContainerLifetime());
            c.Register<ITestCb6, TestCb6>(new PerContainerLifetime());
            c.Register<ITestCb7, TestCb7>(new PerContainerLifetime());
            c.Register<ITestCb8, TestCb8>(new PerContainerLifetime());
            c.Register<ITestCb9, TestCb9>(new PerContainerLifetime());
            c.Register<ITestCb10, TestCb10>(new PerContainerLifetime());

            c.Register<ITestCc0, TestCc0>(new PerContainerLifetime());
            c.Register<ITestCc1, TestCc1>(new PerContainerLifetime());
            c.Register<ITestCc2, TestCc2>(new PerContainerLifetime());
            c.Register<ITestCc3, TestCc3>(new PerContainerLifetime());
            c.Register<ITestCc4, TestCc4>(new PerContainerLifetime());
            c.Register<ITestCc5, TestCc5>(new PerContainerLifetime());
            c.Register<ITestCc6, TestCc6>(new PerContainerLifetime());
            c.Register<ITestCc7, TestCc7>(new PerContainerLifetime());
            c.Register<ITestCc8, TestCc8>(new PerContainerLifetime());
            c.Register<ITestCc9, TestCc9>(new PerContainerLifetime());
            c.Register<ITestCc10, TestCc10>(new PerContainerLifetime());

            c.Register<ITestC, TestC>(new PerContainerLifetime());
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void LightInjectResolve(ServiceContainer c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestC>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestC>();
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
            c.Register(Component.For<ITestCa0>().ImplementedBy<TestCa0>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa1>().ImplementedBy<TestCa1>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa2>().ImplementedBy<TestCa2>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa3>().ImplementedBy<TestCa3>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa4>().ImplementedBy<TestCa4>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa5>().ImplementedBy<TestCa5>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa6>().ImplementedBy<TestCa6>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa7>().ImplementedBy<TestCa7>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa8>().ImplementedBy<TestCa8>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa9>().ImplementedBy<TestCa9>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCa10>().ImplementedBy<TestCa10>().LifeStyle.Singleton);

            c.Register(Component.For<ITestCb0>().ImplementedBy<TestCb0>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb1>().ImplementedBy<TestCb1>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb2>().ImplementedBy<TestCb2>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb3>().ImplementedBy<TestCb3>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb4>().ImplementedBy<TestCb4>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb5>().ImplementedBy<TestCb5>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb6>().ImplementedBy<TestCb6>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb7>().ImplementedBy<TestCb7>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb8>().ImplementedBy<TestCb8>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb9>().ImplementedBy<TestCb9>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCb10>().ImplementedBy<TestCb10>().LifeStyle.Singleton);

            c.Register(Component.For<ITestCc0>().ImplementedBy<TestCc0>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc1>().ImplementedBy<TestCc1>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc2>().ImplementedBy<TestCc2>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc3>().ImplementedBy<TestCc3>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc4>().ImplementedBy<TestCc4>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc5>().ImplementedBy<TestCc5>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc6>().ImplementedBy<TestCc6>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc7>().ImplementedBy<TestCc7>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc8>().ImplementedBy<TestCc8>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc9>().ImplementedBy<TestCc9>().LifeStyle.Singleton);
            c.Register(Component.For<ITestCc10>().ImplementedBy<TestCc10>().LifeStyle.Singleton);

            c.Register(Component.For<ITestC>().ImplementedBy<TestC>().LifeStyle.Singleton);
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void WindsorResolve(WindsorContainer c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestC>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestC>();
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
                x.For<ITestCa0>().Use<TestCa0>().Singleton();
                x.For<ITestCa0>().Use<TestCa0>().Singleton();
                x.For<ITestCa1>().Use<TestCa1>().Singleton();
                x.For<ITestCa2>().Use<TestCa2>().Singleton();
                x.For<ITestCa3>().Use<TestCa3>().Singleton();
                x.For<ITestCa4>().Use<TestCa4>().Singleton();
                x.For<ITestCa5>().Use<TestCa5>().Singleton();
                x.For<ITestCa6>().Use<TestCa6>().Singleton();
                x.For<ITestCa7>().Use<TestCa7>().Singleton();
                x.For<ITestCa8>().Use<TestCa8>().Singleton();
                x.For<ITestCa9>().Use<TestCa9>().Singleton();
                x.For<ITestCa10>().Use<TestCa10>().Singleton();

                x.For<ITestCb0>().Use<TestCb0>().Singleton();
                x.For<ITestCb0>().Use<TestCb0>().Singleton();
                x.For<ITestCb1>().Use<TestCb1>().Singleton();
                x.For<ITestCb2>().Use<TestCb2>().Singleton();
                x.For<ITestCb3>().Use<TestCb3>().Singleton();
                x.For<ITestCb4>().Use<TestCb4>().Singleton();
                x.For<ITestCb5>().Use<TestCb5>().Singleton();
                x.For<ITestCb6>().Use<TestCb6>().Singleton();
                x.For<ITestCb7>().Use<TestCb7>().Singleton();
                x.For<ITestCb8>().Use<TestCb8>().Singleton();
                x.For<ITestCb9>().Use<TestCb9>().Singleton();
                x.For<ITestCb10>().Use<TestCb10>().Singleton();

                x.For<ITestCc0>().Use<TestCc0>().Singleton();
                x.For<ITestCc0>().Use<TestCc0>().Singleton();
                x.For<ITestCc1>().Use<TestCc1>().Singleton();
                x.For<ITestCc2>().Use<TestCc2>().Singleton();
                x.For<ITestCc3>().Use<TestCc3>().Singleton();
                x.For<ITestCc4>().Use<TestCc4>().Singleton();
                x.For<ITestCc5>().Use<TestCc5>().Singleton();
                x.For<ITestCc6>().Use<TestCc6>().Singleton();
                x.For<ITestCc7>().Use<TestCc7>().Singleton();
                x.For<ITestCc8>().Use<TestCc8>().Singleton();
                x.For<ITestCc9>().Use<TestCc9>().Singleton();
                x.For<ITestCc10>().Use<TestCc10>().Singleton();

                x.For<ITestC>().Use<TestC>().Singleton();
            });
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void StructureMapResolve(StructureMap.Container c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestC>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestC>();
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
            var c = AutofacRegister(cb);
            AutofacResolve(c, _testCasesNumber);
            c.Dispose();
        }

        private IContainer AutofacRegister(ContainerBuilder cb)
        {
            var sw = new Stopwatch();

            sw.Start();
            cb.RegisterType<TestCa0>().As<ITestCa0>().SingleInstance();
            cb.RegisterType<TestCa1>().As<ITestCa1>().SingleInstance();
            cb.RegisterType<TestCa2>().As<ITestCa2>().SingleInstance();
            cb.RegisterType<TestCa3>().As<ITestCa3>().SingleInstance();
            cb.RegisterType<TestCa4>().As<ITestCa4>().SingleInstance();
            cb.RegisterType<TestCa5>().As<ITestCa5>().SingleInstance();
            cb.RegisterType<TestCa6>().As<ITestCa6>().SingleInstance();
            cb.RegisterType<TestCa7>().As<ITestCa7>().SingleInstance();
            cb.RegisterType<TestCa8>().As<ITestCa8>().SingleInstance();
            cb.RegisterType<TestCa9>().As<ITestCa9>().SingleInstance();
            cb.RegisterType<TestCa10>().As<ITestCa10>().SingleInstance();

            cb.RegisterType<TestCb0>().As<ITestCb0>().SingleInstance();
            cb.RegisterType<TestCb1>().As<ITestCb1>().SingleInstance();
            cb.RegisterType<TestCb2>().As<ITestCb2>().SingleInstance();
            cb.RegisterType<TestCb3>().As<ITestCb3>().SingleInstance();
            cb.RegisterType<TestCb4>().As<ITestCb4>().SingleInstance();
            cb.RegisterType<TestCb5>().As<ITestCb5>().SingleInstance();
            cb.RegisterType<TestCb6>().As<ITestCb6>().SingleInstance();
            cb.RegisterType<TestCb7>().As<ITestCb7>().SingleInstance();
            cb.RegisterType<TestCb8>().As<ITestCb8>().SingleInstance();
            cb.RegisterType<TestCb9>().As<ITestCb9>().SingleInstance();
            cb.RegisterType<TestCb10>().As<ITestCb10>().SingleInstance();

            cb.RegisterType<TestCc0>().As<ITestCc0>().SingleInstance();
            cb.RegisterType<TestCc1>().As<ITestCc1>().SingleInstance();
            cb.RegisterType<TestCc2>().As<ITestCc2>().SingleInstance();
            cb.RegisterType<TestCc3>().As<ITestCc3>().SingleInstance();
            cb.RegisterType<TestCc4>().As<ITestCc4>().SingleInstance();
            cb.RegisterType<TestCc5>().As<ITestCc5>().SingleInstance();
            cb.RegisterType<TestCc6>().As<ITestCc6>().SingleInstance();
            cb.RegisterType<TestCc7>().As<ITestCc7>().SingleInstance();
            cb.RegisterType<TestCc8>().As<ITestCc8>().SingleInstance();
            cb.RegisterType<TestCc9>().As<ITestCc9>().SingleInstance();
            cb.RegisterType<TestCc10>().As<ITestCc10>().SingleInstance();

            cb.RegisterType<TestC>().As<ITestC>().SingleInstance();

            var c = cb.Build();
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            return c;
        }

        private void AutofacResolve(IContainer c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestC>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestC>();
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
            c.RegisterType<ITestCa0, TestCa0>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa1, TestCa1>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa2, TestCa2>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa3, TestCa3>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa4, TestCa4>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa5, TestCa5>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa6, TestCa6>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa7, TestCa7>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa8, TestCa8>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa9, TestCa9>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa10, TestCa10>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestCb0, TestCb0>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb1, TestCb1>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb2, TestCb2>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb3, TestCb3>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb4, TestCb4>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb5, TestCb5>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb6, TestCb6>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb7, TestCb7>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb8, TestCb8>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb9, TestCb9>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb10, TestCb10>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestCc0, TestCc0>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc1, TestCc1>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc2, TestCc2>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc3, TestCc3>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc4, TestCc4>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc5, TestCc5>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc6, TestCc6>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc7, TestCc7>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc8, TestCc8>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc9, TestCc9>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc10, TestCc10>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestC, TestC>(new ContainerControlledLifetimeManager());
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void UnityResolve(UnityContainer c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestC>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestC>();
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
            c.RegisterType<ITestCa0, TestCa0>().AsSingleton();
            c.RegisterType<ITestCa1, TestCa1>().AsSingleton();
            c.RegisterType<ITestCa2, TestCa2>().AsSingleton();
            c.RegisterType<ITestCa3, TestCa3>().AsSingleton();
            c.RegisterType<ITestCa4, TestCa4>().AsSingleton();
            c.RegisterType<ITestCa5, TestCa5>().AsSingleton();
            c.RegisterType<ITestCa6, TestCa6>().AsSingleton();
            c.RegisterType<ITestCa7, TestCa7>().AsSingleton();
            c.RegisterType<ITestCa8, TestCa8>().AsSingleton();
            c.RegisterType<ITestCa9, TestCa9>().AsSingleton();
            c.RegisterType<ITestCa10, TestCa10>().AsSingleton();

            c.RegisterType<ITestCb0, TestCb0>().AsSingleton();
            c.RegisterType<ITestCb1, TestCb1>().AsSingleton();
            c.RegisterType<ITestCb2, TestCb2>().AsSingleton();
            c.RegisterType<ITestCb3, TestCb3>().AsSingleton();
            c.RegisterType<ITestCb4, TestCb4>().AsSingleton();
            c.RegisterType<ITestCb5, TestCb5>().AsSingleton();
            c.RegisterType<ITestCb6, TestCb6>().AsSingleton();
            c.RegisterType<ITestCb7, TestCb7>().AsSingleton();
            c.RegisterType<ITestCb8, TestCb8>().AsSingleton();
            c.RegisterType<ITestCb9, TestCb9>().AsSingleton();
            c.RegisterType<ITestCb10, TestCb10>().AsSingleton();

            c.RegisterType<ITestCc0, TestCc0>().AsSingleton();
            c.RegisterType<ITestCc1, TestCc1>().AsSingleton();
            c.RegisterType<ITestCc2, TestCc2>().AsSingleton();
            c.RegisterType<ITestCc3, TestCc3>().AsSingleton();
            c.RegisterType<ITestCc4, TestCc4>().AsSingleton();
            c.RegisterType<ITestCc5, TestCc5>().AsSingleton();
            c.RegisterType<ITestCc6, TestCc6>().AsSingleton();
            c.RegisterType<ITestCc7, TestCc7>().AsSingleton();
            c.RegisterType<ITestCc8, TestCc8>().AsSingleton();
            c.RegisterType<ITestCc9, TestCc9>().AsSingleton();
            c.RegisterType<ITestCc10, TestCc10>().AsSingleton();

            c.RegisterType<ITestC, TestC>().AsSingleton();
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void NiquIoCResolve(NiquIoC.Container c, int testCasesNumber)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestC>();
            sw.Stop();

            Check(lastValue);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestC>();
                sw.Stop();

                Assert.AreEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }
    }
}