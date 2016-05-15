using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;

namespace PerformanceTests.TestsUnity
{
    [TestClass]
    public class ClassB
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsUnity" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve1_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            SingletonRegister(c);
            Resolve(c, 1, true);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            TransientRegister(c);
            Resolve(c, 1, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "Unity");

            var c = new UnityContainer();
            TransientRegister(c);
            Resolve(c, 10, false);
            c.Dispose();
        }

        private void SingletonRegister(UnityContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.RegisterType<ITestB00, TestB00>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB01, TestB01>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB02, TestB02>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB03, TestB03>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB04, TestB04>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB05, TestB05>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB06, TestB06>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB07, TestB07>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB08, TestB08>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB09, TestB09>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB10, TestB10>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB11, TestB11>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB12, TestB12>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB13, TestB13>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB14, TestB14>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB15, TestB15>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB16, TestB16>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB17, TestB17>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB18, TestB18>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB19, TestB19>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB20, TestB20>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB21, TestB21>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB22, TestB22>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB23, TestB23>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB24, TestB24>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB25, TestB25>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB26, TestB26>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB27, TestB27>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB28, TestB28>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB29, TestB29>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB30, TestB30>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB31, TestB31>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB32, TestB32>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB33, TestB33>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB34, TestB34>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB35, TestB35>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB36, TestB36>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB37, TestB37>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB38, TestB38>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB39, TestB39>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB40, TestB40>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB41, TestB41>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB42, TestB42>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB43, TestB43>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB44, TestB44>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB45, TestB45>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB46, TestB46>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB47, TestB47>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB48, TestB48>(new ContainerControlledLifetimeManager());
            c.RegisterType<ITestB49, TestB49>(new ContainerControlledLifetimeManager());

            c.RegisterType<ITestB, TestB>(new ContainerControlledLifetimeManager());
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void TransientRegister(UnityContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.RegisterType<ITestB00, TestB00>();
            c.RegisterType<ITestB01, TestB01>();
            c.RegisterType<ITestB02, TestB02>();
            c.RegisterType<ITestB03, TestB03>();
            c.RegisterType<ITestB04, TestB04>();
            c.RegisterType<ITestB05, TestB05>();
            c.RegisterType<ITestB06, TestB06>();
            c.RegisterType<ITestB07, TestB07>();
            c.RegisterType<ITestB08, TestB08>();
            c.RegisterType<ITestB09, TestB09>();

            c.RegisterType<ITestB10, TestB10>();
            c.RegisterType<ITestB11, TestB11>();
            c.RegisterType<ITestB12, TestB12>();
            c.RegisterType<ITestB13, TestB13>();
            c.RegisterType<ITestB14, TestB14>();
            c.RegisterType<ITestB15, TestB15>();
            c.RegisterType<ITestB16, TestB16>();
            c.RegisterType<ITestB17, TestB17>();
            c.RegisterType<ITestB18, TestB18>();
            c.RegisterType<ITestB19, TestB19>();

            c.RegisterType<ITestB20, TestB20>();
            c.RegisterType<ITestB21, TestB21>();
            c.RegisterType<ITestB22, TestB22>();
            c.RegisterType<ITestB23, TestB23>();
            c.RegisterType<ITestB24, TestB24>();
            c.RegisterType<ITestB25, TestB25>();
            c.RegisterType<ITestB26, TestB26>();
            c.RegisterType<ITestB27, TestB27>();
            c.RegisterType<ITestB28, TestB28>();
            c.RegisterType<ITestB29, TestB29>();

            c.RegisterType<ITestB30, TestB30>();
            c.RegisterType<ITestB31, TestB31>();
            c.RegisterType<ITestB32, TestB32>();
            c.RegisterType<ITestB33, TestB33>();
            c.RegisterType<ITestB34, TestB34>();
            c.RegisterType<ITestB35, TestB35>();
            c.RegisterType<ITestB36, TestB36>();
            c.RegisterType<ITestB37, TestB37>();
            c.RegisterType<ITestB38, TestB38>();
            c.RegisterType<ITestB39, TestB39>();

            c.RegisterType<ITestB40, TestB40>();
            c.RegisterType<ITestB41, TestB41>();
            c.RegisterType<ITestB42, TestB42>();
            c.RegisterType<ITestB43, TestB43>();
            c.RegisterType<ITestB44, TestB44>();
            c.RegisterType<ITestB45, TestB45>();
            c.RegisterType<ITestB46, TestB46>();
            c.RegisterType<ITestB47, TestB47>();
            c.RegisterType<ITestB48, TestB48>();
            c.RegisterType<ITestB49, TestB49>();

            c.RegisterType<ITestB, TestB>();
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void Resolve(UnityContainer c, int testCasesNumber, bool singleton)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.Resolve<ITestB>();
            sw.Stop();

            Helper.Check(lastValue, singleton);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.Resolve<ITestB>();
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