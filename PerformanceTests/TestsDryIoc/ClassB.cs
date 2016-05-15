using System;
using System.Diagnostics;
using System.IO;
using DryIoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;

namespace PerformanceTests.TestsDryIoc
{
    [TestClass]
    public class ClassB
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsDryIoc" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve1_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "DryIoc");

            var c = new Container();
            SingletonRegister(c);
            Resolve(c, 1, true);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1_TransientRegister()
        {
            try
            {
                Helper.WriteLine(_fileName, "DryIoc");

                var c = new Container();
                TransientRegister(c);
                Resolve(c, 1, false);
                c.Dispose();
            }
            catch (Exception ex)
            {
                Helper.WriteLine(_fileName, ex.Message);
            }
        }

        [TestMethod]
        public void Resolve10_TransientRegister()
        {
            try
            {
                Helper.WriteLine(_fileName, "DryIoc");

                var c = new Container();
                TransientRegister(c);
                Resolve(c, 10, false);
                c.Dispose();
            }
            catch (Exception ex)
            {
                Helper.WriteLine(_fileName, ex.Message);
            }
        }

        private void SingletonRegister(Container c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register<ITestB00, TestB00>(Reuse.Singleton);
            c.Register<ITestB01, TestB01>(Reuse.Singleton);
            c.Register<ITestB02, TestB02>(Reuse.Singleton);
            c.Register<ITestB03, TestB03>(Reuse.Singleton);
            c.Register<ITestB04, TestB04>(Reuse.Singleton);
            c.Register<ITestB05, TestB05>(Reuse.Singleton);
            c.Register<ITestB06, TestB06>(Reuse.Singleton);
            c.Register<ITestB07, TestB07>(Reuse.Singleton);
            c.Register<ITestB08, TestB08>(Reuse.Singleton);
            c.Register<ITestB09, TestB09>(Reuse.Singleton);

            c.Register<ITestB10, TestB10>(Reuse.Singleton);
            c.Register<ITestB11, TestB11>(Reuse.Singleton);
            c.Register<ITestB12, TestB12>(Reuse.Singleton);
            c.Register<ITestB13, TestB13>(Reuse.Singleton);
            c.Register<ITestB14, TestB14>(Reuse.Singleton);
            c.Register<ITestB15, TestB15>(Reuse.Singleton);
            c.Register<ITestB16, TestB16>(Reuse.Singleton);
            c.Register<ITestB17, TestB17>(Reuse.Singleton);
            c.Register<ITestB18, TestB18>(Reuse.Singleton);
            c.Register<ITestB19, TestB19>(Reuse.Singleton);

            c.Register<ITestB20, TestB20>(Reuse.Singleton);
            c.Register<ITestB21, TestB21>(Reuse.Singleton);
            c.Register<ITestB22, TestB22>(Reuse.Singleton);
            c.Register<ITestB23, TestB23>(Reuse.Singleton);
            c.Register<ITestB24, TestB24>(Reuse.Singleton);
            c.Register<ITestB25, TestB25>(Reuse.Singleton);
            c.Register<ITestB26, TestB26>(Reuse.Singleton);
            c.Register<ITestB27, TestB27>(Reuse.Singleton);
            c.Register<ITestB28, TestB28>(Reuse.Singleton);
            c.Register<ITestB29, TestB29>(Reuse.Singleton);

            c.Register<ITestB30, TestB30>(Reuse.Singleton);
            c.Register<ITestB31, TestB31>(Reuse.Singleton);
            c.Register<ITestB32, TestB32>(Reuse.Singleton);
            c.Register<ITestB33, TestB33>(Reuse.Singleton);
            c.Register<ITestB34, TestB34>(Reuse.Singleton);
            c.Register<ITestB35, TestB35>(Reuse.Singleton);
            c.Register<ITestB36, TestB36>(Reuse.Singleton);
            c.Register<ITestB37, TestB37>(Reuse.Singleton);
            c.Register<ITestB38, TestB38>(Reuse.Singleton);
            c.Register<ITestB39, TestB39>(Reuse.Singleton);

            c.Register<ITestB40, TestB40>(Reuse.Singleton);
            c.Register<ITestB41, TestB41>(Reuse.Singleton);
            c.Register<ITestB42, TestB42>(Reuse.Singleton);
            c.Register<ITestB43, TestB43>(Reuse.Singleton);
            c.Register<ITestB44, TestB44>(Reuse.Singleton);
            c.Register<ITestB45, TestB45>(Reuse.Singleton);
            c.Register<ITestB46, TestB46>(Reuse.Singleton);
            c.Register<ITestB47, TestB47>(Reuse.Singleton);
            c.Register<ITestB48, TestB48>(Reuse.Singleton);
            c.Register<ITestB49, TestB49>(Reuse.Singleton);

            c.Register<ITestB, TestB>(Reuse.Singleton);
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void TransientRegister(Container c)
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

        private void Resolve(Container c, int testCasesNumber, bool singleton)
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