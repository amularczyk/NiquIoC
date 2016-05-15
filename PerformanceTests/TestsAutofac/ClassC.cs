using System;
using System.Diagnostics;
using System.IO;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;

namespace PerformanceTests.TestsAutofac
{
    [TestClass]
    public class ClassC
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsAutofac" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve100_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "Autofac");

            var cb = new ContainerBuilder();
            var c = SingletonRegister(cb);
            Resolve(c, 100, true);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Autofac");

            var cb = new ContainerBuilder();
            var c = TransientRegister(cb);
            Resolve(c, 1, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Autofac");

            var cb = new ContainerBuilder();
            var c = TransientRegister(cb);
            Resolve(c, 10, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve100_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Autofac");
            
            var cb = new ContainerBuilder();
            var c = TransientRegister(cb);
            Resolve(c, 100, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1000_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Autofac");

            var cb = new ContainerBuilder();
            var c = TransientRegister(cb);
            Resolve(c, 1000, false);
            c.Dispose();
        }

        private IContainer SingletonRegister(ContainerBuilder cb)
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

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            return c;
        }

        private IContainer TransientRegister(ContainerBuilder cb)
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

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            return c;
        }

        private void Resolve(IContainer c, int testCasesNumber, bool singleton)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestC>();
            sw.Stop();

            Helper.Check(lastValue, singleton);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestC>();
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