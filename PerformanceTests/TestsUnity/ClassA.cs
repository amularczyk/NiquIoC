using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;

namespace PerformanceTests.TestsUnity
{
    public class ClassA
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve100_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            SingletonRegister(c);
            Resolve(c, 100, true);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            TransientRegister(c);
            Resolve(c, 1, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            TransientRegister(c);
            Resolve(c, 10, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve100_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            TransientRegister(c);
            Resolve(c, 100, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1000_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            TransientRegister(c);
            Resolve(c, 1000, false);
            c.Dispose();
        }

        private void SingletonRegister(UnityContainer c)
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

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void TransientRegister(UnityContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.RegisterType<ITestA0, TestA0>();
            c.RegisterType<ITestA1, TestA1>();
            c.RegisterType<ITestA2, TestA2>();
            c.RegisterType<ITestA3, TestA3>();
            c.RegisterType<ITestA4, TestA4>();
            c.RegisterType<ITestA5, TestA5>();
            c.RegisterType<ITestA6, TestA6>();
            c.RegisterType<ITestA7, TestA7>();
            c.RegisterType<ITestA8, TestA8>();
            c.RegisterType<ITestA9, TestA9>();
            c.RegisterType<ITestA10, TestA10>();
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void Resolve(UnityContainer c, int testCasesNumber, bool singleton)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestA10>();
            sw.Stop();

            Helper.Check(lastValue, true);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA10>();
                sw.Stop();

                if (singleton)
                {
                    Assert.AreEqual(test, lastValue);
                }
                else
                {
                    Assert.AreNotEqual(test, lastValue);
                }

                Helper.Check(test, true);
                lastValue = test;
            }

            Helper.WriteLine(_fileName, "{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }
    }
}