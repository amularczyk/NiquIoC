using System;
using System.Diagnostics;
using System.IO;
using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;

namespace PerformanceTests.TestsLightInject
{
    [TestClass]
    public class ClassA
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsLightInject" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve100_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            SingletonRegister(c);
            Resolve(c, 100, true);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            TransientRegister(c);
            Resolve(c, 1, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            TransientRegister(c);
            Resolve(c, 10, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve100_TransientRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            TransientRegister(c);
            Resolve(c, 100, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1000_TransientRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            TransientRegister(c);
            Resolve(c, 1000, false);
            c.Dispose();
        }

        private void SingletonRegister(ServiceContainer c)
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
            c.Register<ITestA, TestA>(new PerContainerLifetime());
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void TransientRegister(ServiceContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register<ITestA0, TestA0>();
            c.Register<ITestA1, TestA1>();
            c.Register<ITestA2, TestA2>();
            c.Register<ITestA3, TestA3>();
            c.Register<ITestA4, TestA4>();
            c.Register<ITestA5, TestA5>();
            c.Register<ITestA6, TestA6>();
            c.Register<ITestA7, TestA7>();
            c.Register<ITestA8, TestA8>();
            c.Register<ITestA9, TestA9>();
            c.Register<ITestA, TestA>();
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void Resolve(ServiceContainer c, int testCasesNumber, bool singleton)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestA>();
            sw.Stop();

            Helper.Check(lastValue, singleton);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestA>();
                sw.Stop();

                if (singleton)
                {
                    Assert.AreEqual(test, lastValue);
                }
                else
                {
                    Assert.AreNotEqual(test, lastValue);
                }

                Helper.Check(test, singleton);
                lastValue = test;
            }

            Helper.WriteLine(_fileName, "{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }
    }
}