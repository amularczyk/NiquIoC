using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;
using StructureMap;

namespace PerformanceTests.TestsStructureMap
{
    public class ClassA
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

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
                x.For<ITestA0>().Use<TestA0>().Singleton();
                x.For<ITestA0>().Use<TestA0>().Singleton();
                x.For<ITestA1>().Use<TestA1>().Singleton();
                x.For<ITestA2>().Use<TestA2>().Singleton();
                x.For<ITestA3>().Use<TestA3>().Singleton();
                x.For<ITestA4>().Use<TestA4>().Singleton();
                x.For<ITestA5>().Use<TestA5>().Singleton();
                x.For<ITestA6>().Use<TestA6>().Singleton();
                x.For<ITestA7>().Use<TestA7>().Singleton();
                x.For<ITestA8>().Use<TestA8>().Singleton();
                x.For<ITestA9>().Use<TestA9>().Singleton();
                x.For<ITestA10>().Use<TestA10>().Singleton();
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
                x.For<ITestA0>().Use<TestA0>().AlwaysUnique();
                x.For<ITestA0>().Use<TestA0>().AlwaysUnique();
                x.For<ITestA1>().Use<TestA1>().AlwaysUnique();
                x.For<ITestA2>().Use<TestA2>().AlwaysUnique();
                x.For<ITestA3>().Use<TestA3>().AlwaysUnique();
                x.For<ITestA4>().Use<TestA4>().AlwaysUnique();
                x.For<ITestA5>().Use<TestA5>().AlwaysUnique();
                x.For<ITestA6>().Use<TestA6>().AlwaysUnique();
                x.For<ITestA7>().Use<TestA7>().AlwaysUnique();
                x.For<ITestA8>().Use<TestA8>().AlwaysUnique();
                x.For<ITestA9>().Use<TestA9>().AlwaysUnique();
                x.For<ITestA10>().Use<TestA10>().AlwaysUnique();
            });
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void Resolve(Container c, int testCasesNumber, bool singleton)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestA10>();
            sw.Stop();

            Helper.Check(lastValue, true);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestA10>();
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