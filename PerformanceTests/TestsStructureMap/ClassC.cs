using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;
using StructureMap;

namespace PerformanceTests.TestsStructureMap
{
    [TestClass]
    public class ClassC
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsStructureMap" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve100_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "StructureMap");

            var c = new Container();
            SingletonRegister(c);
            Resolve(c, 100, true);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "StructureMap");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 1, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "StructureMap");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 10, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve100_TransientRegister()
        {
            Helper.WriteLine(_fileName, "StructureMap");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 100, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1000_TransientRegister()
        {
            Helper.WriteLine(_fileName, "StructureMap");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 1000, false);
            c.Dispose();
        }

        private void SingletonRegister(Container c)
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

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void TransientRegister(Container c)
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