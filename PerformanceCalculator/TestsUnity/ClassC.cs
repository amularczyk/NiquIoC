using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Practices.Unity;
using PerformanceCalculator.Classes;

namespace PerformanceCalculator.TestsUnity
{
    
    public class ClassC
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsUnity" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        
        public void Resolve100_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            SingletonRegister(c);
            Resolve(c, 100, true);
            c.Dispose();
        }

        
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            TransientRegister(c);
            Resolve(c, 1, false);
            c.Dispose();
        }

        
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            TransientRegister(c);
            Resolve(c, 10, false);
            c.Dispose();
        }

        
        public void Resolve100_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            TransientRegister(c);
            Resolve(c, 100, false);
            c.Dispose();
        }

        
        public void Resolve1000_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            TransientRegister(c);
            Resolve(c, 1000, false);
            c.Dispose();
        }

        private void SingletonRegister(UnityContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.RegisterType<ITestCa0, TestCa0>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa1, TestCa1>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa2, TestCa2>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa3, TestCa3>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa4, TestCa4>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa5, TestCa5>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa6, TestCa6>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa7, TestCa7>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa8, TestCa8>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa9, TestCa9>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCa10, TestCa10>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestCb0, TestCb0>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb1, TestCb1>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb2, TestCb2>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb3, TestCb3>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb4, TestCb4>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb5, TestCb5>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb6, TestCb6>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb7, TestCb7>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb8, TestCb8>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb9, TestCb9>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCb10, TestCb10>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestCc0, TestCc0>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc1, TestCc1>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc2, TestCc2>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc3, TestCc3>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc4, TestCc4>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc5, TestCc5>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc6, TestCc6>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc7, TestCc7>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc8, TestCc8>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc9, TestCc9>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestCc10, TestCc10>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestC, TestC>(new ContainerControlledLifetimeManager());
            sw.Stop();

            Helper.WriteLine(_fileName, $"Register: {sw.ElapsedMilliseconds} Milliseconds.");
            sw.Reset();
        }

        private void TransientRegister(UnityContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.RegisterType<ITestCa0, TestCa0>();
            c.RegisterType<ITestCa1, TestCa1>();
            c.RegisterType<ITestCa2, TestCa2>();
            c.RegisterType<ITestCa3, TestCa3>();
            c.RegisterType<ITestCa4, TestCa4>();
            c.RegisterType<ITestCa5, TestCa5>();
            c.RegisterType<ITestCa6, TestCa6>();
            c.RegisterType<ITestCa7, TestCa7>();
            c.RegisterType<ITestCa8, TestCa8>();
            c.RegisterType<ITestCa9, TestCa9>();
            c.RegisterType<ITestCa10, TestCa10>();

            c.RegisterType<ITestCb0, TestCb0>();
            c.RegisterType<ITestCb1, TestCb1>();
            c.RegisterType<ITestCb2, TestCb2>();
            c.RegisterType<ITestCb3, TestCb3>();
            c.RegisterType<ITestCb4, TestCb4>();
            c.RegisterType<ITestCb5, TestCb5>();
            c.RegisterType<ITestCb6, TestCb6>();
            c.RegisterType<ITestCb7, TestCb7>();
            c.RegisterType<ITestCb8, TestCb8>();
            c.RegisterType<ITestCb9, TestCb9>();
            c.RegisterType<ITestCb10, TestCb10>();

            c.RegisterType<ITestCc0, TestCc0>();
            c.RegisterType<ITestCc1, TestCc1>();
            c.RegisterType<ITestCc2, TestCc2>();
            c.RegisterType<ITestCc3, TestCc3>();
            c.RegisterType<ITestCc4, TestCc4>();
            c.RegisterType<ITestCc5, TestCc5>();
            c.RegisterType<ITestCc6, TestCc6>();
            c.RegisterType<ITestCc7, TestCc7>();
            c.RegisterType<ITestCc8, TestCc8>();
            c.RegisterType<ITestCc9, TestCc9>();
            c.RegisterType<ITestCc10, TestCc10>();

            c.RegisterType<ITestC, TestC>();
            sw.Stop();

            Helper.WriteLine(_fileName, $"Register: {sw.ElapsedMilliseconds} Milliseconds.");
            sw.Reset();
        }

        private void Resolve(UnityContainer c, int testCasesNumber, bool singleton)
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

            Helper.WriteLine(_fileName, $"{testCasesNumber} resolve: {sw.ElapsedMilliseconds} Milliseconds." );
        }
    }
}