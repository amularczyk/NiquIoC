using System;
using System.Diagnostics;
using System.IO;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;

namespace PerformanceTests.TestsWindsor
{
    [TestClass]
    public class ClassC
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsWindsor" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

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

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void TransientRegister(WindsorContainer c)
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

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void Resolve(WindsorContainer c, int testCasesNumber, bool singleton)
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