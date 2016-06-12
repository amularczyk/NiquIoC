using System;
using System.Diagnostics;
using System.IO;
using LightInject;
using PerformanceCalculator.Classes;

namespace PerformanceCalculator.TestsLightInject
{
    public class TestCaseA : ITestCase
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsLightInject" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        
        public void Resolve100_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            SingletonRegister(c);
            Resolve(c, 100, true);
            c.Dispose();
        }

        
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            TransientRegister(c);
            Resolve(c, 1, false);
            c.Dispose();
        }

        
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            TransientRegister(c);
            Resolve(c, 10, false);
            c.Dispose();
        }

        
        public void Resolve100_TransientRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            TransientRegister(c);
            Resolve(c, 100, false);
            c.Dispose();
        }

        
        public void Resolve1000_TransientRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            TransientRegister(c);
            Resolve(c, 1000, false);
            c.Dispose();
        }

        public object SingletonRegister(object container)
        {
            var sw = new Stopwatch();

            var c = (ServiceContainer)container;
            sw.Start();
            c.Register<ITestA0, TestA0>(new PerContainerLifetime());
            c.Register<ITestA1, TestA1>(new PerContainerLifetime());
            c.Register<ITestA2, TestA2>(new PerContainerLifetime());
            c.Register<ITestA3, TestA3>(new PerContainerLifetime());
            c.Register<ITestA4, TestA4>(new PerContainerLifetime());
            c.Register<ITestA5, TestA5>(new PerContainerLifetime());
            c.Register<ITestA6, TestA6>(new PerContainerLifetime());
            c.Register<ITestA7, TestA7>(new PerContainerLifetime());
            c.Register<ITestA8, TestA8>(new PerContainerLifetime());
            c.Register<ITestA9, TestA9>(new PerContainerLifetime());
            c.Register<ITestA, TestA>(new PerContainerLifetime());
            sw.Stop();

            Helper.WriteLine(_fileName, $"Register: {sw.ElapsedMilliseconds} Milliseconds.");
            sw.Reset();

            return container;
        }

        public object TransientRegister(object container)
        {
            var sw = new Stopwatch();

            var c = (ServiceContainer)container;
            sw.Start();
            c.Register<ITestA0, TestA0>();
            c.Register<ITestA1, TestA1>();
            c.Register<ITestA2, TestA2>();
            c.Register<ITestA3, TestA3>();
            c.Register<ITestA4, TestA4>();
            c.Register<ITestA5, TestA5>();
            c.Register<ITestA6, TestA6>();
            c.Register<ITestA7, TestA7>();
            c.Register<ITestA8, TestA8>();
            c.Register<ITestA9, TestA9>();
            c.Register<ITestA, TestA>();
            sw.Stop();

            Helper.WriteLine(_fileName, $"Register: {sw.ElapsedMilliseconds} Milliseconds.");
            sw.Reset();

            return container;
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var sw = new Stopwatch();

            var c = (ServiceContainer)container;
            sw.Start();
            var lastValue = c.GetInstance<ITestA>();
            sw.Stop();

            Helper.Check(lastValue, singleton);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestA>();
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