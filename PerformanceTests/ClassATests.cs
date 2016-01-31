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
    public class ClassATests
    {
        private void Check(ITest_A10 test_a10)
        {
            Assert.IsNotNull(test_a10);

            Assert.IsNotNull(test_a10.Test_a9);
            Assert.IsNotNull(test_a10.Test_a8);
            Assert.IsNotNull(test_a10.Test_a7);
            Assert.IsNotNull(test_a10.Test_a6);
            Assert.IsNotNull(test_a10.Test_a5);
            Assert.IsNotNull(test_a10.Test_a4);
            Assert.IsNotNull(test_a10.Test_a3);
            Assert.IsNotNull(test_a10.Test_a2);
            Assert.IsNotNull(test_a10.Test_a1);
            Assert.IsNotNull(test_a10.Test_a0);

            Assert.IsNotNull(test_a10.Test_a9.Test_a8);
            Assert.IsNotNull(test_a10.Test_a9.Test_a7);
            Assert.IsNotNull(test_a10.Test_a9.Test_a6);
            Assert.IsNotNull(test_a10.Test_a9.Test_a5);
            Assert.IsNotNull(test_a10.Test_a9.Test_a4);
            Assert.IsNotNull(test_a10.Test_a9.Test_a3);
            Assert.IsNotNull(test_a10.Test_a9.Test_a2);
            Assert.IsNotNull(test_a10.Test_a9.Test_a1);
            Assert.IsNotNull(test_a10.Test_a9.Test_a0);

            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a6);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a5);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a4);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a3);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a2);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a1);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a0);

            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a5);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a4);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a3);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a2);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a1);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a0);

            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a5);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a4);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a3);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a2);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a1);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a0);

            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a4.Test_a3);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a4.Test_a2);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a4.Test_a1);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a4.Test_a0);

            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a4.Test_a3.Test_a2);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a4.Test_a3.Test_a1);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a4.Test_a3.Test_a0);

            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a4.Test_a3.Test_a2.Test_a1);
            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a4.Test_a3.Test_a2.Test_a0);

            Assert.IsNotNull(test_a10.Test_a9.Test_a8.Test_a7.Test_a6.Test_a4.Test_a3.Test_a2.Test_a1.Test_a0);
        }

        [TestMethod]
        public void UpperIntermediateContainerTest()
        {
            SampleContainer.IContainer c = new SampleContainer.UpperIntermediateContainer();

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            c.RegisterType<ITest_A0, Test_A0>(false);
            c.RegisterType<ITest_A1, Test_A1>(false);
            c.RegisterType<ITest_A2, Test_A2>(false);
            c.RegisterType<ITest_A3, Test_A3>(false);
            c.RegisterType<ITest_A4, Test_A4>(false);
            c.RegisterType<ITest_A5, Test_A5>(false);
            c.RegisterType<ITest_A6, Test_A6>(false);
            c.RegisterType<ITest_A7, Test_A7>(false);
            c.RegisterType<ITest_A8, Test_A8>(false);
            c.RegisterType<ITest_A9, Test_A9>(false);
            c.RegisterType<ITest_A10, Test_A10>(false);
            sw.Stop();

            Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
            sw.Reset();

            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                var test = c.Resolve<ITest_A10>();
                sw.Stop();

                sw2.Start();
                Check(test);
                sw2.Stop();
            }

            Debug.WriteLine(string.Format("Resolve: {0} Ticks.", sw.ElapsedTicks));
            Debug.WriteLine(string.Format("Resolve: {0} Milliseconds.", sw.ElapsedMilliseconds));

            Debug.WriteLine(string.Format("Checking: {0} Ticks.", sw2.ElapsedTicks));
            Debug.WriteLine(string.Format("Checking: {0} Milliseconds.", sw2.ElapsedMilliseconds));
        }

        [TestMethod]
        public void ContainerWithFasterflectTest()
        {
            NiquIoCWithFasterflect.ContainerWithFasterflect c = new NiquIoCWithFasterflect.ContainerWithFasterflect();

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            c.RegisterType<ITest_A0, Test_A0>(false);
            c.RegisterType<ITest_A1, Test_A1>(false);
            c.RegisterType<ITest_A2, Test_A2>(false);
            c.RegisterType<ITest_A3, Test_A3>(false);
            c.RegisterType<ITest_A4, Test_A4>(false);
            c.RegisterType<ITest_A5, Test_A5>(false);
            c.RegisterType<ITest_A6, Test_A6>(false);
            c.RegisterType<ITest_A7, Test_A7>(false);
            c.RegisterType<ITest_A8, Test_A8>(false);
            c.RegisterType<ITest_A9, Test_A9>(false);
            c.RegisterType<ITest_A10, Test_A10>(false);
            sw.Stop();

            Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
            sw.Reset();

            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                var test = c.Resolve<ITest_A10>();
                sw.Stop();

                sw2.Start();
                Check(test);
                sw2.Stop();
            }

            Debug.WriteLine(string.Format("Resolve: {0} Ticks.", sw.ElapsedTicks));
            Debug.WriteLine(string.Format("Resolve: {0} Milliseconds.", sw.ElapsedMilliseconds));

            Debug.WriteLine(string.Format("Checking: {0} Ticks.", sw2.ElapsedTicks));
            Debug.WriteLine(string.Format("Checking: {0} Milliseconds.", sw2.ElapsedMilliseconds));
        }

        [TestMethod]
        public void IntermediateContainerTest()
        {
            SampleContainer.IContainer c = new SampleContainer.IntermediateContainer();

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            c.RegisterType<ITest_A0, Test_A0>(false);
            c.RegisterType<ITest_A1, Test_A1>(false);
            c.RegisterType<ITest_A2, Test_A2>(false);
            c.RegisterType<ITest_A3, Test_A3>(false);
            c.RegisterType<ITest_A4, Test_A4>(false);
            c.RegisterType<ITest_A5, Test_A5>(false);
            c.RegisterType<ITest_A6, Test_A6>(false);
            c.RegisterType<ITest_A7, Test_A7>(false);
            c.RegisterType<ITest_A8, Test_A8>(false);
            c.RegisterType<ITest_A9, Test_A9>(false);
            c.RegisterType<ITest_A10, Test_A10>(false);
            sw.Stop();

            Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
            sw.Reset();

            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                var test = c.Resolve<ITest_A10>();
                sw.Stop();

                sw2.Start();
                Check(test);
                sw2.Stop();
            }

            Debug.WriteLine(string.Format("Resolve: {0} Ticks.", sw.ElapsedTicks));
            Debug.WriteLine(string.Format("Resolve: {0} Milliseconds.", sw.ElapsedMilliseconds));

            Debug.WriteLine(string.Format("Checking: {0} Ticks.", sw2.ElapsedTicks));
            Debug.WriteLine(string.Format("Checking: {0} Milliseconds.", sw2.ElapsedMilliseconds));
        }

        //[TestMethod]
        //public void HiroTest()
        //{
        //    var dependencyMap = new DependencyMap();

        //    Stopwatch sw = new Stopwatch();
        //    Stopwatch sw2 = new Stopwatch();

        //    sw.Start();
        //    dependencyMap.AddService<ITest_A0, Test_A0>();
        //    dependencyMap.AddService<ITest_A1, Test_A1>();
        //    dependencyMap.AddService<ITest_A2, Test_A2>();
        //    dependencyMap.AddService<ITest_A3, Test_A3>();
        //    dependencyMap.AddService<ITest_A4, Test_A4>();
        //    dependencyMap.AddService<ITest_A5, Test_A5>();
        //    dependencyMap.AddService<ITest_A6, Test_A6>();
        //    dependencyMap.AddService<ITest_A7, Test_A7>();
        //    dependencyMap.AddService<ITest_A8, Test_A8>();
        //    dependencyMap.AddService<ITest_A9, Test_A9>();
        //    dependencyMap.AddService<ITest_A10, Test_A10>();
        //    sw.Stop();

        //    Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
        //    sw.Reset();

        //    for (int i = 0; i < 100; i++)
        //    {
        //        sw.Start();
        //        var dependency = new Dependency(typeof(ITest_A10));
        //        var test = dependencyMap.CreateContainer().GetInstance<ITest_A10>();
        //        sw.Stop();

        //        sw2.Start();
        //        Check(test);
        //        sw2.Stop();
        //    }

        //    Debug.WriteLine(string.Format("Resolve: {0} Ticks.", sw.ElapsedTicks));
        //    Debug.WriteLine(string.Format("Resolve: {0} Milliseconds.", sw.ElapsedMilliseconds));

        //    Debug.WriteLine(string.Format("Checking: {0} Ticks.", sw2.ElapsedTicks));
        //    Debug.WriteLine(string.Format("Checking: {0} Milliseconds.", sw2.ElapsedMilliseconds));
        //}
    }
}
