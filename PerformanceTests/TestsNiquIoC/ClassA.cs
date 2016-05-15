using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;
using NiquIoC;

namespace PerformanceTests.TestsNiquIoC
{
    public class ClassA
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve100_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "NiquIoC");

            var c = new Container();
            SingletonRegister(c);
            Resolve(c, 100, true);
        }

        [TestMethod]
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "NiquIoC");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 1, false);
        }

        [TestMethod]
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "NiquIoC");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 10, false);
        }

        [TestMethod]
        public void Resolve100_TransientRegister()
        {
            Helper.WriteLine(_fileName, "NiquIoC");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 100, false);
        }

        [TestMethod]
        public void Resolve1000_TransientRegister()
        {
            Helper.WriteLine(_fileName, "NiquIoC");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 1000, false);
        }

        private void SingletonRegister(Container c)
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

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void TransientRegister(Container c)
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

        private void Resolve(Container c, int testCasesNumber, bool singleton)
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