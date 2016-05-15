using System;
using System.Diagnostics;
using System.IO;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;

namespace PerformanceTests.TestsAutofac
{
    [TestClass]
    public class ClassA
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
            cb.RegisterType<TestA>().As<ITestA>().SingleInstance();
            var c = cb.Build();
            sw.Stop();

            Helper.WriteLine(_fileName, $"Register: {sw.ElapsedMilliseconds} Milliseconds.");
            sw.Reset();

            return c;
        }

        private IContainer TransientRegister(ContainerBuilder cb)
        {
            var sw = new Stopwatch();

            sw.Start();
            cb.RegisterType<TestA0>().As<ITestA0>();
            cb.RegisterType<TestA1>().As<ITestA1>();
            cb.RegisterType<TestA2>().As<ITestA2>();
            cb.RegisterType<TestA3>().As<ITestA3>();
            cb.RegisterType<TestA4>().As<ITestA4>();
            cb.RegisterType<TestA5>().As<ITestA5>();
            cb.RegisterType<TestA6>().As<ITestA6>();
            cb.RegisterType<TestA7>().As<ITestA7>();
            cb.RegisterType<TestA8>().As<ITestA8>();
            cb.RegisterType<TestA9>().As<ITestA9>();
            cb.RegisterType<TestA>().As<ITestA>();
            var c = cb.Build();
            sw.Stop();

            Helper.WriteLine(_fileName, $"Register: {sw.ElapsedMilliseconds} Milliseconds.");
            sw.Reset();

            return c;
        }

        private void Resolve(IContainer c, int testCasesNumber, bool singleton)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestA>();
            sw.Stop();

            Helper.Check(lastValue, singleton);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA>();
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

            Helper.WriteLine(_fileName, $"{testCasesNumber} resolve: {sw.ElapsedMilliseconds} Milliseconds." );
        }
    }
}