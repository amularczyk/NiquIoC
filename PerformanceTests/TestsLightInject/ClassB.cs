using System;
using System.Diagnostics;
using System.IO;
using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;

namespace PerformanceTests.TestsLightInject
{
    [TestClass]
    public class ClassB
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsLightInject" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve1_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            SingletonRegister(c);
            Resolve(c, 1, true);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            TransientRegister(c);
            Resolve(c, 1, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "LightInject");

            var c = new ServiceContainer();
            TransientRegister(c);
            Resolve(c, 10, false);
            c.Dispose();
        }

        private void SingletonRegister(ServiceContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register<ITestB00, TestB00>(new PerContainerLifetime());
            c.Register<ITestB01, TestB01>(new PerContainerLifetime());
            c.Register<ITestB02, TestB02>(new PerContainerLifetime());
            c.Register<ITestB03, TestB03>(new PerContainerLifetime());
            c.Register<ITestB04, TestB04>(new PerContainerLifetime());
            c.Register<ITestB05, TestB05>(new PerContainerLifetime());
            c.Register<ITestB06, TestB06>(new PerContainerLifetime());
            c.Register<ITestB07, TestB07>(new PerContainerLifetime());
            c.Register<ITestB08, TestB08>(new PerContainerLifetime());
            c.Register<ITestB09, TestB09>(new PerContainerLifetime());

            c.Register<ITestB10, TestB10>(new PerContainerLifetime());
            c.Register<ITestB11, TestB11>(new PerContainerLifetime());
            c.Register<ITestB12, TestB12>(new PerContainerLifetime());
            c.Register<ITestB13, TestB13>(new PerContainerLifetime());
            c.Register<ITestB14, TestB14>(new PerContainerLifetime());
            c.Register<ITestB15, TestB15>(new PerContainerLifetime());
            c.Register<ITestB16, TestB16>(new PerContainerLifetime());
            c.Register<ITestB17, TestB17>(new PerContainerLifetime());
            c.Register<ITestB18, TestB18>(new PerContainerLifetime());
            c.Register<ITestB19, TestB19>(new PerContainerLifetime());

            c.Register<ITestB20, TestB20>(new PerContainerLifetime());
            c.Register<ITestB21, TestB21>(new PerContainerLifetime());
            c.Register<ITestB22, TestB22>(new PerContainerLifetime());
            c.Register<ITestB23, TestB23>(new PerContainerLifetime());
            c.Register<ITestB24, TestB24>(new PerContainerLifetime());
            c.Register<ITestB25, TestB25>(new PerContainerLifetime());
            c.Register<ITestB26, TestB26>(new PerContainerLifetime());
            c.Register<ITestB27, TestB27>(new PerContainerLifetime());
            c.Register<ITestB28, TestB28>(new PerContainerLifetime());
            c.Register<ITestB29, TestB29>(new PerContainerLifetime());

            c.Register<ITestB30, TestB30>(new PerContainerLifetime());
            c.Register<ITestB31, TestB31>(new PerContainerLifetime());
            c.Register<ITestB32, TestB32>(new PerContainerLifetime());
            c.Register<ITestB33, TestB33>(new PerContainerLifetime());
            c.Register<ITestB34, TestB34>(new PerContainerLifetime());
            c.Register<ITestB35, TestB35>(new PerContainerLifetime());
            c.Register<ITestB36, TestB36>(new PerContainerLifetime());
            c.Register<ITestB37, TestB37>(new PerContainerLifetime());
            c.Register<ITestB38, TestB38>(new PerContainerLifetime());
            c.Register<ITestB39, TestB39>(new PerContainerLifetime());

            c.Register<ITestB40, TestB40>(new PerContainerLifetime());
            c.Register<ITestB41, TestB41>(new PerContainerLifetime());
            c.Register<ITestB42, TestB42>(new PerContainerLifetime());
            c.Register<ITestB43, TestB43>(new PerContainerLifetime());
            c.Register<ITestB44, TestB44>(new PerContainerLifetime());
            c.Register<ITestB45, TestB45>(new PerContainerLifetime());
            c.Register<ITestB46, TestB46>(new PerContainerLifetime());
            c.Register<ITestB47, TestB47>(new PerContainerLifetime());
            c.Register<ITestB48, TestB48>(new PerContainerLifetime());
            c.Register<ITestB49, TestB49>(new PerContainerLifetime());

            c.Register<ITestB, TestB>(new PerContainerLifetime());
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void TransientRegister(ServiceContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register<ITestB00, TestB00>();
            c.Register<ITestB01, TestB01>();
            c.Register<ITestB02, TestB02>();
            c.Register<ITestB03, TestB03>();
            c.Register<ITestB04, TestB04>();
            c.Register<ITestB05, TestB05>();
            c.Register<ITestB06, TestB06>();
            c.Register<ITestB07, TestB07>();
            c.Register<ITestB08, TestB08>();
            c.Register<ITestB09, TestB09>();

            c.Register<ITestB10, TestB10>();
            c.Register<ITestB11, TestB11>();
            c.Register<ITestB12, TestB12>();
            c.Register<ITestB13, TestB13>();
            c.Register<ITestB14, TestB14>();
            c.Register<ITestB15, TestB15>();
            c.Register<ITestB16, TestB16>();
            c.Register<ITestB17, TestB17>();
            c.Register<ITestB18, TestB18>();
            c.Register<ITestB19, TestB19>();

            c.Register<ITestB20, TestB20>();
            c.Register<ITestB21, TestB21>();
            c.Register<ITestB22, TestB22>();
            c.Register<ITestB23, TestB23>();
            c.Register<ITestB24, TestB24>();
            c.Register<ITestB25, TestB25>();
            c.Register<ITestB26, TestB26>();
            c.Register<ITestB27, TestB27>();
            c.Register<ITestB28, TestB28>();
            c.Register<ITestB29, TestB29>();

            c.Register<ITestB30, TestB30>();
            c.Register<ITestB31, TestB31>();
            c.Register<ITestB32, TestB32>();
            c.Register<ITestB33, TestB33>();
            c.Register<ITestB34, TestB34>();
            c.Register<ITestB35, TestB35>();
            c.Register<ITestB36, TestB36>();
            c.Register<ITestB37, TestB37>();
            c.Register<ITestB38, TestB38>();
            c.Register<ITestB39, TestB39>();

            c.Register<ITestB40, TestB40>();
            c.Register<ITestB41, TestB41>();
            c.Register<ITestB42, TestB42>();
            c.Register<ITestB43, TestB43>();
            c.Register<ITestB44, TestB44>();
            c.Register<ITestB45, TestB45>();
            c.Register<ITestB46, TestB46>();
            c.Register<ITestB47, TestB47>();
            c.Register<ITestB48, TestB48>();
            c.Register<ITestB49, TestB49>();

            c.Register<ITestB, TestB>();
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void Resolve(ServiceContainer c, int testCasesNumber, bool singleton)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestB>();
            sw.Stop();

            Helper.Check(lastValue, singleton);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestB>();
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