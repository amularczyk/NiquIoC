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
    public class ClassB
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "TestsWindsor" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve1_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "Windsor");

            var c = new WindsorContainer();
            SingletonRegister(c);
            Resolve(c, 1, true);
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

        private void SingletonRegister(WindsorContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register(Component.For<ITestB00>().ImplementedBy<TestB00>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB01>().ImplementedBy<TestB01>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB02>().ImplementedBy<TestB02>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB03>().ImplementedBy<TestB03>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB04>().ImplementedBy<TestB04>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB05>().ImplementedBy<TestB05>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB06>().ImplementedBy<TestB06>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB07>().ImplementedBy<TestB07>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB08>().ImplementedBy<TestB08>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB09>().ImplementedBy<TestB09>().LifeStyle.Singleton);

            c.Register(Component.For<ITestB10>().ImplementedBy<TestB10>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB11>().ImplementedBy<TestB11>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB12>().ImplementedBy<TestB12>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB13>().ImplementedBy<TestB13>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB14>().ImplementedBy<TestB14>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB15>().ImplementedBy<TestB15>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB16>().ImplementedBy<TestB16>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB17>().ImplementedBy<TestB17>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB18>().ImplementedBy<TestB18>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB19>().ImplementedBy<TestB19>().LifeStyle.Singleton);

            c.Register(Component.For<ITestB20>().ImplementedBy<TestB20>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB21>().ImplementedBy<TestB21>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB22>().ImplementedBy<TestB22>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB23>().ImplementedBy<TestB23>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB24>().ImplementedBy<TestB24>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB25>().ImplementedBy<TestB25>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB26>().ImplementedBy<TestB26>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB27>().ImplementedBy<TestB27>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB28>().ImplementedBy<TestB28>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB29>().ImplementedBy<TestB29>().LifeStyle.Singleton);

            c.Register(Component.For<ITestB30>().ImplementedBy<TestB30>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB31>().ImplementedBy<TestB31>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB32>().ImplementedBy<TestB32>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB33>().ImplementedBy<TestB33>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB34>().ImplementedBy<TestB34>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB35>().ImplementedBy<TestB35>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB36>().ImplementedBy<TestB36>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB37>().ImplementedBy<TestB37>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB38>().ImplementedBy<TestB38>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB39>().ImplementedBy<TestB39>().LifeStyle.Singleton);

            c.Register(Component.For<ITestB40>().ImplementedBy<TestB40>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB41>().ImplementedBy<TestB41>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB42>().ImplementedBy<TestB42>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB43>().ImplementedBy<TestB43>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB44>().ImplementedBy<TestB44>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB45>().ImplementedBy<TestB45>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB46>().ImplementedBy<TestB46>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB47>().ImplementedBy<TestB47>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB48>().ImplementedBy<TestB48>().LifeStyle.Singleton);
            c.Register(Component.For<ITestB49>().ImplementedBy<TestB49>().LifeStyle.Singleton);

            c.Register(Component.For<ITestB>().ImplementedBy<TestB>().LifeStyle.Singleton);
            sw.Stop();

            Helper.WriteLine(_fileName, $"Register: {sw.ElapsedMilliseconds} Milliseconds.");
            sw.Reset();
        }

        private void TransientRegister(WindsorContainer c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register(Component.For<ITestB00>().ImplementedBy<TestB00>().LifeStyle.Transient);
            c.Register(Component.For<ITestB01>().ImplementedBy<TestB01>().LifeStyle.Transient);
            c.Register(Component.For<ITestB02>().ImplementedBy<TestB02>().LifeStyle.Transient);
            c.Register(Component.For<ITestB03>().ImplementedBy<TestB03>().LifeStyle.Transient);
            c.Register(Component.For<ITestB04>().ImplementedBy<TestB04>().LifeStyle.Transient);
            c.Register(Component.For<ITestB05>().ImplementedBy<TestB05>().LifeStyle.Transient);
            c.Register(Component.For<ITestB06>().ImplementedBy<TestB06>().LifeStyle.Transient);
            c.Register(Component.For<ITestB07>().ImplementedBy<TestB07>().LifeStyle.Transient);
            c.Register(Component.For<ITestB08>().ImplementedBy<TestB08>().LifeStyle.Transient);
            c.Register(Component.For<ITestB09>().ImplementedBy<TestB09>().LifeStyle.Transient);

            c.Register(Component.For<ITestB10>().ImplementedBy<TestB10>().LifeStyle.Transient);
            c.Register(Component.For<ITestB11>().ImplementedBy<TestB11>().LifeStyle.Transient);
            c.Register(Component.For<ITestB12>().ImplementedBy<TestB12>().LifeStyle.Transient);
            c.Register(Component.For<ITestB13>().ImplementedBy<TestB13>().LifeStyle.Transient);
            c.Register(Component.For<ITestB14>().ImplementedBy<TestB14>().LifeStyle.Transient);
            c.Register(Component.For<ITestB15>().ImplementedBy<TestB15>().LifeStyle.Transient);
            c.Register(Component.For<ITestB16>().ImplementedBy<TestB16>().LifeStyle.Transient);
            c.Register(Component.For<ITestB17>().ImplementedBy<TestB17>().LifeStyle.Transient);
            c.Register(Component.For<ITestB18>().ImplementedBy<TestB18>().LifeStyle.Transient);
            c.Register(Component.For<ITestB19>().ImplementedBy<TestB19>().LifeStyle.Transient);

            c.Register(Component.For<ITestB20>().ImplementedBy<TestB20>().LifeStyle.Transient);
            c.Register(Component.For<ITestB21>().ImplementedBy<TestB21>().LifeStyle.Transient);
            c.Register(Component.For<ITestB22>().ImplementedBy<TestB22>().LifeStyle.Transient);
            c.Register(Component.For<ITestB23>().ImplementedBy<TestB23>().LifeStyle.Transient);
            c.Register(Component.For<ITestB24>().ImplementedBy<TestB24>().LifeStyle.Transient);
            c.Register(Component.For<ITestB25>().ImplementedBy<TestB25>().LifeStyle.Transient);
            c.Register(Component.For<ITestB26>().ImplementedBy<TestB26>().LifeStyle.Transient);
            c.Register(Component.For<ITestB27>().ImplementedBy<TestB27>().LifeStyle.Transient);
            c.Register(Component.For<ITestB28>().ImplementedBy<TestB28>().LifeStyle.Transient);
            c.Register(Component.For<ITestB29>().ImplementedBy<TestB29>().LifeStyle.Transient);

            c.Register(Component.For<ITestB30>().ImplementedBy<TestB30>().LifeStyle.Transient);
            c.Register(Component.For<ITestB31>().ImplementedBy<TestB31>().LifeStyle.Transient);
            c.Register(Component.For<ITestB32>().ImplementedBy<TestB32>().LifeStyle.Transient);
            c.Register(Component.For<ITestB33>().ImplementedBy<TestB33>().LifeStyle.Transient);
            c.Register(Component.For<ITestB34>().ImplementedBy<TestB34>().LifeStyle.Transient);
            c.Register(Component.For<ITestB35>().ImplementedBy<TestB35>().LifeStyle.Transient);
            c.Register(Component.For<ITestB36>().ImplementedBy<TestB36>().LifeStyle.Transient);
            c.Register(Component.For<ITestB37>().ImplementedBy<TestB37>().LifeStyle.Transient);
            c.Register(Component.For<ITestB38>().ImplementedBy<TestB38>().LifeStyle.Transient);
            c.Register(Component.For<ITestB39>().ImplementedBy<TestB39>().LifeStyle.Transient);

            c.Register(Component.For<ITestB40>().ImplementedBy<TestB40>().LifeStyle.Transient);
            c.Register(Component.For<ITestB41>().ImplementedBy<TestB41>().LifeStyle.Transient);
            c.Register(Component.For<ITestB42>().ImplementedBy<TestB42>().LifeStyle.Transient);
            c.Register(Component.For<ITestB43>().ImplementedBy<TestB43>().LifeStyle.Transient);
            c.Register(Component.For<ITestB44>().ImplementedBy<TestB44>().LifeStyle.Transient);
            c.Register(Component.For<ITestB45>().ImplementedBy<TestB45>().LifeStyle.Transient);
            c.Register(Component.For<ITestB46>().ImplementedBy<TestB46>().LifeStyle.Transient);
            c.Register(Component.For<ITestB47>().ImplementedBy<TestB47>().LifeStyle.Transient);
            c.Register(Component.For<ITestB48>().ImplementedBy<TestB48>().LifeStyle.Transient);
            c.Register(Component.For<ITestB49>().ImplementedBy<TestB49>().LifeStyle.Transient);

            c.Register(Component.For<ITestB>().ImplementedBy<TestB>().LifeStyle.Transient);
            sw.Stop();

            Helper.WriteLine(_fileName, $"Register: {sw.ElapsedMilliseconds} Milliseconds.");
            sw.Reset();
        }

        private void Resolve(WindsorContainer c, int testCasesNumber, bool singleton)
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

            Helper.WriteLine(_fileName, $"{testCasesNumber} resolve: {sw.ElapsedMilliseconds} Milliseconds." );
        }
    }
}