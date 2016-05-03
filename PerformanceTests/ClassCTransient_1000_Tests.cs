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
using Container = SimpleInjector.Container;
using IContainer = Autofac.IContainer;

namespace PerformanceTests
{
    [TestClass]
    public class ClassCTransient_1000_Tests
    {
        private static readonly int _testCasesNumber = 1000;
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "PerforamceTests_C_1000_Transient_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

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

            Assert.AreNotEqual(test.TestCa10.TestCa8, test.TestCa10.TestCa9.TestCa8);
            Assert.AreNotEqual(test.TestCa10.TestCa7, test.TestCa10.TestCa9.TestCa7);
            Assert.AreNotEqual(test.TestCa10.TestCa6, test.TestCa10.TestCa9.TestCa6);
            Assert.AreNotEqual(test.TestCa10.TestCa5, test.TestCa10.TestCa9.TestCa5);
            Assert.AreNotEqual(test.TestCa10.TestCa4, test.TestCa10.TestCa9.TestCa4);
            Assert.AreNotEqual(test.TestCa10.TestCa3, test.TestCa10.TestCa9.TestCa3);
            Assert.AreNotEqual(test.TestCa10.TestCa2, test.TestCa10.TestCa9.TestCa2);
            Assert.AreNotEqual(test.TestCa10.TestCa1, test.TestCa10.TestCa9.TestCa1);
            Assert.AreNotEqual(test.TestCa10.TestCa0, test.TestCa10.TestCa9.TestCa0);

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
            c.Register<ITestCa0, TestCa0>();
            c.Register<ITestCa1, TestCa1>();
            c.Register<ITestCa2, TestCa2>();
            c.Register<ITestCa3, TestCa3>();
            c.Register<ITestCa4, TestCa4>();
            c.Register<ITestCa5, TestCa5>();
            c.Register<ITestCa6, TestCa6>();
            c.Register<ITestCa7, TestCa7>();
            c.Register<ITestCa8, TestCa8>();
            c.Register<ITestCa9, TestCa9>();
            c.Register<ITestCa10, TestCa10>();

            c.Register<ITestCb0, TestCb0>();
            c.Register<ITestCb1, TestCb1>();
            c.Register<ITestCb2, TestCb2>();
            c.Register<ITestCb3, TestCb3>();
            c.Register<ITestCb4, TestCb4>();
            c.Register<ITestCb5, TestCb5>();
            c.Register<ITestCb6, TestCb6>();
            c.Register<ITestCb7, TestCb7>();
            c.Register<ITestCb8, TestCb8>();
            c.Register<ITestCb9, TestCb9>();
            c.Register<ITestCb10, TestCb10>();

            c.Register<ITestCc0, TestCc0>();
            c.Register<ITestCc1, TestCc1>();
            c.Register<ITestCc2, TestCc2>();
            c.Register<ITestCc3, TestCc3>();
            c.Register<ITestCc4, TestCc4>();
            c.Register<ITestCc5, TestCc5>();
            c.Register<ITestCc6, TestCc6>();
            c.Register<ITestCc7, TestCc7>();
            c.Register<ITestCc8, TestCc8>();
            c.Register<ITestCc9, TestCc9>();
            c.Register<ITestCc10, TestCc10>();

            c.Register<ITestC, TestC>();
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

                Assert.AreNotEqual(test, lastValue);
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
            c.Register<ITestCa0, TestCa0>();
            c.Register<ITestCa1, TestCa1>();
            c.Register<ITestCa2, TestCa2>();
            c.Register<ITestCa3, TestCa3>();
            c.Register<ITestCa4, TestCa4>();
            c.Register<ITestCa5, TestCa5>();
            c.Register<ITestCa6, TestCa6>();
            c.Register<ITestCa7, TestCa7>();
            c.Register<ITestCa8, TestCa8>();
            c.Register<ITestCa9, TestCa9>();
            c.Register<ITestCa10, TestCa10>();

            c.Register<ITestCb0, TestCb0>();
            c.Register<ITestCb1, TestCb1>();
            c.Register<ITestCb2, TestCb2>();
            c.Register<ITestCb3, TestCb3>();
            c.Register<ITestCb4, TestCb4>();
            c.Register<ITestCb5, TestCb5>();
            c.Register<ITestCb6, TestCb6>();
            c.Register<ITestCb7, TestCb7>();
            c.Register<ITestCb8, TestCb8>();
            c.Register<ITestCb9, TestCb9>();
            c.Register<ITestCb10, TestCb10>();

            c.Register<ITestCc0, TestCc0>();
            c.Register<ITestCc1, TestCc1>();
            c.Register<ITestCc2, TestCc2>();
            c.Register<ITestCc3, TestCc3>();
            c.Register<ITestCc4, TestCc4>();
            c.Register<ITestCc5, TestCc5>();
            c.Register<ITestCc6, TestCc6>();
            c.Register<ITestCc7, TestCc7>();
            c.Register<ITestCc8, TestCc8>();
            c.Register<ITestCc9, TestCc9>();
            c.Register<ITestCc10, TestCc10>();

            c.Register<ITestC, TestC>();
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
            c.Register<ITestCa0, TestCa0>();
            c.Register<ITestCa1, TestCa1>();
            c.Register<ITestCa2, TestCa2>();
            c.Register<ITestCa3, TestCa3>();
            c.Register<ITestCa4, TestCa4>();
            c.Register<ITestCa5, TestCa5>();
            c.Register<ITestCa6, TestCa6>();
            c.Register<ITestCa7, TestCa7>();
            c.Register<ITestCa8, TestCa8>();
            c.Register<ITestCa9, TestCa9>();
            c.Register<ITestCa10, TestCa10>();

            c.Register<ITestCb0, TestCb0>();
            c.Register<ITestCb1, TestCb1>();
            c.Register<ITestCb2, TestCb2>();
            c.Register<ITestCb3, TestCb3>();
            c.Register<ITestCb4, TestCb4>();
            c.Register<ITestCb5, TestCb5>();
            c.Register<ITestCb6, TestCb6>();
            c.Register<ITestCb7, TestCb7>();
            c.Register<ITestCb8, TestCb8>();
            c.Register<ITestCb9, TestCb9>();
            c.Register<ITestCb10, TestCb10>();

            c.Register<ITestCc0, TestCc0>();
            c.Register<ITestCc1, TestCc1>();
            c.Register<ITestCc2, TestCc2>();
            c.Register<ITestCc3, TestCc3>();
            c.Register<ITestCc4, TestCc4>();
            c.Register<ITestCc5, TestCc5>();
            c.Register<ITestCc6, TestCc6>();
            c.Register<ITestCc7, TestCc7>();
            c.Register<ITestCc8, TestCc8>();
            c.Register<ITestCc9, TestCc9>();
            c.Register<ITestCc10, TestCc10>();

            c.Register<ITestC, TestC>();
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
            c.Register(Component.For<ITestCa0>().ImplementedBy<TestCa0>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa1>().ImplementedBy<TestCa1>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa2>().ImplementedBy<TestCa2>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa3>().ImplementedBy<TestCa3>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa4>().ImplementedBy<TestCa4>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa5>().ImplementedBy<TestCa5>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa6>().ImplementedBy<TestCa6>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa7>().ImplementedBy<TestCa7>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa8>().ImplementedBy<TestCa8>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa9>().ImplementedBy<TestCa9>().LifeStyle.Transient);
            c.Register(Component.For<ITestCa10>().ImplementedBy<TestCa10>().LifeStyle.Transient);

            c.Register(Component.For<ITestCb0>().ImplementedBy<TestCb0>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb1>().ImplementedBy<TestCb1>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb2>().ImplementedBy<TestCb2>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb3>().ImplementedBy<TestCb3>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb4>().ImplementedBy<TestCb4>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb5>().ImplementedBy<TestCb5>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb6>().ImplementedBy<TestCb6>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb7>().ImplementedBy<TestCb7>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb8>().ImplementedBy<TestCb8>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb9>().ImplementedBy<TestCb9>().LifeStyle.Transient);
            c.Register(Component.For<ITestCb10>().ImplementedBy<TestCb10>().LifeStyle.Transient);

            c.Register(Component.For<ITestCc0>().ImplementedBy<TestCc0>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc1>().ImplementedBy<TestCc1>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc2>().ImplementedBy<TestCc2>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc3>().ImplementedBy<TestCc3>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc4>().ImplementedBy<TestCc4>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc5>().ImplementedBy<TestCc5>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc6>().ImplementedBy<TestCc6>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc7>().ImplementedBy<TestCc7>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc8>().ImplementedBy<TestCc8>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc9>().ImplementedBy<TestCc9>().LifeStyle.Transient);
            c.Register(Component.For<ITestCc10>().ImplementedBy<TestCc10>().LifeStyle.Transient);

            c.Register(Component.For<ITestC>().ImplementedBy<TestC>().LifeStyle.Transient);
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
                x.For<ITestCa0>().Use<TestCa0>().AlwaysUnique();
                x.For<ITestCa0>().Use<TestCa0>().AlwaysUnique();
                x.For<ITestCa1>().Use<TestCa1>().AlwaysUnique();
                x.For<ITestCa2>().Use<TestCa2>().AlwaysUnique();
                x.For<ITestCa3>().Use<TestCa3>().AlwaysUnique();
                x.For<ITestCa4>().Use<TestCa4>().AlwaysUnique();
                x.For<ITestCa5>().Use<TestCa5>().AlwaysUnique();
                x.For<ITestCa6>().Use<TestCa6>().AlwaysUnique();
                x.For<ITestCa7>().Use<TestCa7>().AlwaysUnique();
                x.For<ITestCa8>().Use<TestCa8>().AlwaysUnique();
                x.For<ITestCa9>().Use<TestCa9>().AlwaysUnique();
                x.For<ITestCa10>().Use<TestCa10>().AlwaysUnique();

                x.For<ITestCb0>().Use<TestCb0>().AlwaysUnique();
                x.For<ITestCb0>().Use<TestCb0>().AlwaysUnique();
                x.For<ITestCb1>().Use<TestCb1>().AlwaysUnique();
                x.For<ITestCb2>().Use<TestCb2>().AlwaysUnique();
                x.For<ITestCb3>().Use<TestCb3>().AlwaysUnique();
                x.For<ITestCb4>().Use<TestCb4>().AlwaysUnique();
                x.For<ITestCb5>().Use<TestCb5>().AlwaysUnique();
                x.For<ITestCb6>().Use<TestCb6>().AlwaysUnique();
                x.For<ITestCb7>().Use<TestCb7>().AlwaysUnique();
                x.For<ITestCb8>().Use<TestCb8>().AlwaysUnique();
                x.For<ITestCb9>().Use<TestCb9>().AlwaysUnique();
                x.For<ITestCb10>().Use<TestCb10>().AlwaysUnique();

                x.For<ITestCc0>().Use<TestCc0>().AlwaysUnique();
                x.For<ITestCc0>().Use<TestCc0>().AlwaysUnique();
                x.For<ITestCc1>().Use<TestCc1>().AlwaysUnique();
                x.For<ITestCc2>().Use<TestCc2>().AlwaysUnique();
                x.For<ITestCc3>().Use<TestCc3>().AlwaysUnique();
                x.For<ITestCc4>().Use<TestCc4>().AlwaysUnique();
                x.For<ITestCc5>().Use<TestCc5>().AlwaysUnique();
                x.For<ITestCc6>().Use<TestCc6>().AlwaysUnique();
                x.For<ITestCc7>().Use<TestCc7>().AlwaysUnique();
                x.For<ITestCc8>().Use<TestCc8>().AlwaysUnique();
                x.For<ITestCc9>().Use<TestCc9>().AlwaysUnique();
                x.For<ITestCc10>().Use<TestCc10>().AlwaysUnique();

                x.For<ITestC>().Use<TestC>().AlwaysUnique();
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
            var c = AutofacRegister(cb);
            AutofacResolve(c, _testCasesNumber);
            c.Dispose();
        }

        private IContainer AutofacRegister(ContainerBuilder cb)
        {
            var sw = new Stopwatch();

            sw.Start();
            cb.RegisterType<TestCa0>().As<ITestCa0>();
            cb.RegisterType<TestCa1>().As<ITestCa1>();
            cb.RegisterType<TestCa2>().As<ITestCa2>();
            cb.RegisterType<TestCa3>().As<ITestCa3>();
            cb.RegisterType<TestCa4>().As<ITestCa4>();
            cb.RegisterType<TestCa5>().As<ITestCa5>();
            cb.RegisterType<TestCa6>().As<ITestCa6>();
            cb.RegisterType<TestCa7>().As<ITestCa7>();
            cb.RegisterType<TestCa8>().As<ITestCa8>();
            cb.RegisterType<TestCa9>().As<ITestCa9>();
            cb.RegisterType<TestCa10>().As<ITestCa10>();

            cb.RegisterType<TestCb0>().As<ITestCb0>();
            cb.RegisterType<TestCb1>().As<ITestCb1>();
            cb.RegisterType<TestCb2>().As<ITestCb2>();
            cb.RegisterType<TestCb3>().As<ITestCb3>();
            cb.RegisterType<TestCb4>().As<ITestCb4>();
            cb.RegisterType<TestCb5>().As<ITestCb5>();
            cb.RegisterType<TestCb6>().As<ITestCb6>();
            cb.RegisterType<TestCb7>().As<ITestCb7>();
            cb.RegisterType<TestCb8>().As<ITestCb8>();
            cb.RegisterType<TestCb9>().As<ITestCb9>();
            cb.RegisterType<TestCb10>().As<ITestCb10>();

            cb.RegisterType<TestCc0>().As<ITestCc0>();
            cb.RegisterType<TestCc1>().As<ITestCc1>();
            cb.RegisterType<TestCc2>().As<ITestCc2>();
            cb.RegisterType<TestCc3>().As<ITestCc3>();
            cb.RegisterType<TestCc4>().As<ITestCc4>();
            cb.RegisterType<TestCc5>().As<ITestCc5>();
            cb.RegisterType<TestCc6>().As<ITestCc6>();
            cb.RegisterType<TestCc7>().As<ITestCc7>();
            cb.RegisterType<TestCc8>().As<ITestCc8>();
            cb.RegisterType<TestCc9>().As<ITestCc9>();
            cb.RegisterType<TestCc10>().As<ITestCc10>();

            cb.RegisterType<TestC>().As<ITestC>();

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
            c.RegisterType<ITestCa0, TestCa0>();
            c.RegisterType<ITestCa1, TestCa1>();
            c.RegisterType<ITestCa2, TestCa2>();
            c.RegisterType<ITestCa3, TestCa3>();
            c.RegisterType<ITestCa4, TestCa4>();
            c.RegisterType<ITestCa5, TestCa5>();
            c.RegisterType<ITestCa6, TestCa6>();
            c.RegisterType<ITestCa7, TestCa7>();
            c.RegisterType<ITestCa8, TestCa8>();
            c.RegisterType<ITestCa9, TestCa9>();
            c.RegisterType<ITestCa10, TestCa10>();

            c.RegisterType<ITestCb0, TestCb0>();
            c.RegisterType<ITestCb1, TestCb1>();
            c.RegisterType<ITestCb2, TestCb2>();
            c.RegisterType<ITestCb3, TestCb3>();
            c.RegisterType<ITestCb4, TestCb4>();
            c.RegisterType<ITestCb5, TestCb5>();
            c.RegisterType<ITestCb6, TestCb6>();
            c.RegisterType<ITestCb7, TestCb7>();
            c.RegisterType<ITestCb8, TestCb8>();
            c.RegisterType<ITestCb9, TestCb9>();
            c.RegisterType<ITestCb10, TestCb10>();

            c.RegisterType<ITestCc0, TestCc0>();
            c.RegisterType<ITestCc1, TestCc1>();
            c.RegisterType<ITestCc2, TestCc2>();
            c.RegisterType<ITestCc3, TestCc3>();
            c.RegisterType<ITestCc4, TestCc4>();
            c.RegisterType<ITestCc5, TestCc5>();
            c.RegisterType<ITestCc6, TestCc6>();
            c.RegisterType<ITestCc7, TestCc7>();
            c.RegisterType<ITestCc8, TestCc8>();
            c.RegisterType<ITestCc9, TestCc9>();
            c.RegisterType<ITestCc10, TestCc10>();

            c.RegisterType<ITestC, TestC>();
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
            c.RegisterType<ITestCa0, TestCa0>();
            c.RegisterType<ITestCa1, TestCa1>();
            c.RegisterType<ITestCa2, TestCa2>();
            c.RegisterType<ITestCa3, TestCa3>();
            c.RegisterType<ITestCa4, TestCa4>();
            c.RegisterType<ITestCa5, TestCa5>();
            c.RegisterType<ITestCa6, TestCa6>();
            c.RegisterType<ITestCa7, TestCa7>();
            c.RegisterType<ITestCa8, TestCa8>();
            c.RegisterType<ITestCa9, TestCa9>();
            c.RegisterType<ITestCa10, TestCa10>();

            c.RegisterType<ITestCb0, TestCb0>();
            c.RegisterType<ITestCb1, TestCb1>();
            c.RegisterType<ITestCb2, TestCb2>();
            c.RegisterType<ITestCb3, TestCb3>();
            c.RegisterType<ITestCb4, TestCb4>();
            c.RegisterType<ITestCb5, TestCb5>();
            c.RegisterType<ITestCb6, TestCb6>();
            c.RegisterType<ITestCb7, TestCb7>();
            c.RegisterType<ITestCb8, TestCb8>();
            c.RegisterType<ITestCb9, TestCb9>();
            c.RegisterType<ITestCb10, TestCb10>();

            c.RegisterType<ITestCc0, TestCc0>();
            c.RegisterType<ITestCc1, TestCc1>();
            c.RegisterType<ITestCc2, TestCc2>();
            c.RegisterType<ITestCc3, TestCc3>();
            c.RegisterType<ITestCc4, TestCc4>();
            c.RegisterType<ITestCc5, TestCc5>();
            c.RegisterType<ITestCc6, TestCc6>();
            c.RegisterType<ITestCc7, TestCc7>();
            c.RegisterType<ITestCc8, TestCc8>();
            c.RegisterType<ITestCc9, TestCc9>();
            c.RegisterType<ITestCc10, TestCc10>();

            c.RegisterType<ITestC, TestC>();
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

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }
    }
}