using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleContainer;
using PerformanceTests.Classes;
using System.Diagnostics;
using System.Linq;
using NiquIoC;

namespace PerformanceTests
{
    [TestClass]
    public class BasicPerformanceTests
    {
        [TestMethod]
        public void NiquIoCBasicTest()
        {
            NiquIoC.IContainer c = new NiquIoC.Container();

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            c.RegisterType<ITest_A0, Test_A0>(false);
            sw.Stop();

            Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
            sw.Reset();

            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                //var test = c.Resolve<ITest_A10>();
                var test = c.Resolve<ITest_A0>();
                sw.Stop();

                sw2.Start();
                Assert.IsNotNull(test);
                sw2.Stop();
            }

            Debug.WriteLine(string.Format("Resolve: {0} Ticks.", sw.ElapsedTicks));
            Debug.WriteLine(string.Format("Resolve: {0} Milliseconds.", sw.ElapsedMilliseconds));

            Debug.WriteLine(string.Format("Checking: {0} Ticks.", sw2.ElapsedTicks));
            Debug.WriteLine(string.Format("Checking: {0} Milliseconds.", sw2.ElapsedMilliseconds));
        }

        [TestMethod]
        public void UpperIntermediateContainerBasicTest()
        {
            SampleContainer.UpperIntermediateContainer c = new SampleContainer.UpperIntermediateContainer();

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            c.RegisterType<ITest_A0, Test_A0>(false);
            sw.Stop();

            Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
            sw.Reset();

            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                //var test = c.Resolve<ITest_A10>();
                var test = c.Resolve<ITest_A0>();
                sw.Stop();

                sw2.Start();
                Assert.IsNotNull(test);
                sw2.Stop();
            }

            Debug.WriteLine(string.Format("Resolve: {0} Ticks.", sw.ElapsedTicks));
            Debug.WriteLine(string.Format("Resolve: {0} Milliseconds.", sw.ElapsedMilliseconds));

            Debug.WriteLine(string.Format("Checking: {0} Ticks.", sw2.ElapsedTicks));
            Debug.WriteLine(string.Format("Checking: {0} Milliseconds.", sw2.ElapsedMilliseconds));
        }

        [TestMethod]
        public void NiquIoWithFasterflectCBasicTest()
        {
            NiquIoCWithFasterflect.ContainerWithFasterflect c = new NiquIoCWithFasterflect.ContainerWithFasterflect();

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            c.RegisterType<ITest_A0, Test_A0>(false);
            sw.Stop();

            Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
            sw.Reset();

            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                //var test = c.Resolve<ITest_A10>();
                var test = c.Resolve<ITest_A0>();
                sw.Stop();

                sw2.Start();
                Assert.IsNotNull(test);
                sw2.Stop();
            }

            Debug.WriteLine(string.Format("Resolve: {0} Ticks.", sw.ElapsedTicks));
            Debug.WriteLine(string.Format("Resolve: {0} Milliseconds.", sw.ElapsedMilliseconds));

            Debug.WriteLine(string.Format("Checking: {0} Ticks.", sw2.ElapsedTicks));
            Debug.WriteLine(string.Format("Checking: {0} Milliseconds.", sw2.ElapsedMilliseconds));
        }
    }
}
