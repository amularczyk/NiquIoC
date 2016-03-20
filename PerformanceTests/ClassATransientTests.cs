using System;
using System.Diagnostics;
using System.IO;
using Autofac;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;
using SampleContainer;
using StructureMap;
using IContainer = Autofac.IContainer;

namespace PerformanceTests
{
    [TestClass]
    public class ClassATransientTests
    {
        private static readonly int _testCase = 100;
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "PerforamceTests_Transient_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        private static void Check(ITestA10 testA10)
        {
            Assert.IsNotNull(testA10);

            Assert.IsNotNull(testA10.TestA9);
            Assert.IsNotNull(testA10.TestA8);
            Assert.IsNotNull(testA10.TestA7);
            Assert.IsNotNull(testA10.TestA6);
            Assert.IsNotNull(testA10.TestA5);
            Assert.IsNotNull(testA10.TestA4);
            Assert.IsNotNull(testA10.TestA3);
            Assert.IsNotNull(testA10.TestA2);
            Assert.IsNotNull(testA10.TestA1);
            Assert.IsNotNull(testA10.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8);
            Assert.IsNotNull(testA10.TestA9.TestA7);
            Assert.IsNotNull(testA10.TestA9.TestA6);
            Assert.IsNotNull(testA10.TestA9.TestA5);
            Assert.IsNotNull(testA10.TestA9.TestA4);
            Assert.IsNotNull(testA10.TestA9.TestA3);
            Assert.IsNotNull(testA10.TestA9.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA0);

            Assert.AreNotEqual(testA10.TestA8, testA10.TestA9.TestA8);
            Assert.AreNotEqual(testA10.TestA7, testA10.TestA9.TestA7);
            Assert.AreNotEqual(testA10.TestA6, testA10.TestA9.TestA6);
            Assert.AreNotEqual(testA10.TestA5, testA10.TestA9.TestA5);
            Assert.AreNotEqual(testA10.TestA4, testA10.TestA9.TestA4);
            Assert.AreNotEqual(testA10.TestA3, testA10.TestA9.TestA3);
            Assert.AreNotEqual(testA10.TestA2, testA10.TestA9.TestA2);
            Assert.AreNotEqual(testA10.TestA1, testA10.TestA9.TestA1);
            Assert.AreNotEqual(testA10.TestA0, testA10.TestA9.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA6);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA5);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA4);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA3);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA5);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA4);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA3);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA5);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA3);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4.TestA3);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4.TestA3.TestA2);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4.TestA3.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4.TestA3.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4.TestA3.TestA2.TestA1);
            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4.TestA3.TestA2.TestA0);

            Assert.IsNotNull(testA10.TestA9.TestA8.TestA7.TestA6.TestA4.TestA3.TestA2.TestA1.TestA0);
        }

        private static void WriteLine(string text, params object[] args)
        {
            using (var file = new StreamWriter(_fileName, true))
            {
                file.WriteLine(text, args);
            }
        }

        [TestMethod]
        public void PoorContainerWithCacheTest()
        {
            WriteLine("\nPoorContainerWithCache");

            var c = new PoorContainerWithCache();
            var sw = new Stopwatch();

            sw.Start();
            c.RegisterType<ITestA0, TestA0>(false);
            c.RegisterType<ITestA1, TestA1>(false);
            c.RegisterType<ITestA2, TestA2>(false);
            c.RegisterType<ITestA3, TestA3>(false);
            c.RegisterType<ITestA4, TestA4>(false);
            c.RegisterType<ITestA5, TestA5>(false);
            c.RegisterType<ITestA6, TestA6>(false);
            c.RegisterType<ITestA7, TestA7>(false);
            c.RegisterType<ITestA8, TestA8>(false);
            c.RegisterType<ITestA9, TestA9>(false);
            c.RegisterType<ITestA10, TestA10>(false);
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            var lastValue = c.Resolve<ITestA10>();
            sw.Stop();
            
            Check(lastValue);
            
            WriteLine("First resolve: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            for (var i = 0; i < _testCase; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA10>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;
                
                Check(test);
            }
            
            WriteLine("Next {0} resolve: {1} Milliseconds.", _testCase, sw.ElapsedMilliseconds);
        }

        [TestMethod]
        public void WindsorContainerTest()
        {
            WriteLine("\nWindsorContainer");

            var c = new WindsorContainer();
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

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            var lastValue = c.Resolve<ITestA10>();
            sw.Stop();
            
            Check(lastValue);
            
            WriteLine("First resolve: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            for (var i = 0; i < _testCase; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA10>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;
                
                Check(test);
            }
            
            WriteLine("Next {0} resolve: {1} Milliseconds.", _testCase, sw.ElapsedMilliseconds);
        }

        [TestMethod]
        public void StructureMapTest()
        {
            WriteLine("\nStructureMap");

            var sw = new Stopwatch();

            sw.Start();
            var c = new Container(x =>
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

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            var lastValue = c.GetInstance<ITestA10>();
            sw.Stop();
            
            Check(lastValue);
            
            WriteLine("First resolve: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            for (var i = 0; i < _testCase; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestA10>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;
                
                Check(test);
            }

            WriteLine("Next {0} resolve: {1} Milliseconds.", _testCase, sw.ElapsedMilliseconds);
        }

        [TestMethod]
        public void AutofacTest()
        {
            WriteLine("\nAutofac");

            var cb = new ContainerBuilder();
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
            cb.RegisterType<TestA10>().As<ITestA10>();
            IContainer c = cb.Build();
            sw.Stop();

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            var lastValue = c.Resolve<ITestA10>();
            sw.Stop();
            
            Check(lastValue);
            
            WriteLine("First resolve: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            for (var i = 0; i < _testCase; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA10>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;
                
                Check(test);
            }
            
            WriteLine("Next {0} resolve: {1} Milliseconds.", _testCase, sw.ElapsedMilliseconds);
        }

        [TestMethod]
        public void UnityTest()
        {
            WriteLine("\nUnity");

            var c = new UnityContainer();
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

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            var lastValue = c.Resolve<ITestA10>();
            sw.Stop();
            
            Check(lastValue);
            
            WriteLine("First resolve: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            for (var i = 0; i < _testCase; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA10>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;
                
                Check(test);
            }
            
            WriteLine("Next {0} resolve: {1} Milliseconds.", _testCase, sw.ElapsedMilliseconds);
        }

        [TestMethod]
        public void NiquIoCTest()
        {
            WriteLine("\nNiquIoC");

            var c = new NiquIoC.Container();
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

            WriteLine("Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            var lastValue = c.Resolve<ITestA10>();
            sw.Stop();

            Check(lastValue);

            WriteLine("First resolve: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();

            for (var i = 0; i < _testCase; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestA10>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

                Check(test);
            }

            WriteLine("Next {0} resolve: {1} Milliseconds.", _testCase, sw.ElapsedMilliseconds);
        }
    }
}