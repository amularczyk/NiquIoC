using System;
using System.Diagnostics;
using System.IO;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;

namespace PerformanceTests.TestsWindsor
{
    public class ClassA
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve100_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "Windsor");

            var c = new WindsorContainer();
            SingletonRegister(c);
            Resolve(c, 100, true);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Windsor");

            var c = new WindsorContainer();
            TransientRegister(c);
            Resolve(c, 1, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Windsor");

            var c = new WindsorContainer();
            TransientRegister(c);
            Resolve(c, 10, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve100_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Windsor");

            var c = new WindsorContainer();
            TransientRegister(c);
            Resolve(c, 100, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1000_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Windsor");

            var c = new WindsorContainer();
            TransientRegister(c);
            Resolve(c, 1000, false);
            c.Dispose();
        }

        private void SingletonRegister(WindsorContainer c)
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

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void TransientRegister(WindsorContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register(Component.For<ITestA0>().ImplementedBy<TestA0>().LifeStyle.Transient);
            c.Register(Component.For<ITestA1>().ImplementedBy<TestA1>().LifeStyle.Transient);
            c.Register(Component.For<ITestA2>().ImplementedBy<TestA2>().LifeStyle.Transient);
            c.Register(Component.For<ITestA3>().ImplementedBy<TestA3>().LifeStyle.Transient);
            c.Register(Component.For<ITestA4>().ImplementedBy<TestA4>().LifeStyle.Transient);
            c.Register(Component.For<ITestA5>().ImplementedBy<TestA5>().LifeStyle.Transient);
            c.Register(Component.For<ITestA6>().ImplementedBy<TestA6>().LifeStyle.Transient);
            c.Register(Component.For<ITestA7>().ImplementedBy<TestA7>().LifeStyle.Transient);
            c.Register(Component.For<ITestA8>().ImplementedBy<TestA8>().LifeStyle.Transient);
            c.Register(Component.For<ITestA9>().ImplementedBy<TestA9>().LifeStyle.Transient);
            c.Register(Component.For<ITestA10>().ImplementedBy<TestA10>().LifeStyle.Transient);
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void Resolve(WindsorContainer c, int testCasesNumber, bool singleton)
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