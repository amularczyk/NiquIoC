using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;
using SimpleInjector;

namespace PerformanceTests.TestsSimpleInjector
{
    [TestClass]
    public class ClassC
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsSimpleInjector" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve100_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "SimpleInjector");

            var c = new Container();
            SingletonRegister(c);
            Resolve(c, 100, true);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "SimpleInjector");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 1, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "SimpleInjector");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 10, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve100_TransientRegister()
        {
            Helper.WriteLine(_fileName, "SimpleInjector");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 100, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1000_TransientRegister()
        {
            Helper.WriteLine(_fileName, "SimpleInjector");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 1000, false);
            c.Dispose();
        }

        private void SingletonRegister(Container c)
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

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void TransientRegister(Container c)
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

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void Resolve(Container c, int testCasesNumber, bool singleton)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestC>();
            sw.Stop();

            Helper.Check(lastValue, singleton);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestC>();
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