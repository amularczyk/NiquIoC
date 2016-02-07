using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleContainer;
using PerformanceTests.Classes;
using System.Diagnostics;
using System.Linq;
using Autofac;
using Microsoft.Practices.Unity;

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
            //Register: 5953 Ticks.
            //Resolve: 3699186 Ticks.
            //Resolve: 1460 Milliseconds.
            //Checking: 25294 Ticks.
            //Checking: 9 Milliseconds.

            var c = new SampleContainer.UpperIntermediateContainer();

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

            ITest_A10 lastValue = null;
            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                var test = c.Resolve<ITest_A10>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

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
        
        [TestMethod]
        public void WindsorContainerTest()
        {
            //Register: 623646 Ticks.
            //Resolve: 1939082 Ticks.
            //Resolve: 765 Milliseconds.
            //Checking: 29581 Ticks.
            //Checking: 11 Milliseconds.

            var c = new Castle.Windsor.WindsorContainer();

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            c.Register(Castle.MicroKernel.Registration.Component.For<ITest_A0>().ImplementedBy<Test_A0>().LifeStyle.Transient);
            c.Register(Castle.MicroKernel.Registration.Component.For<ITest_A1>().ImplementedBy<Test_A1>().LifeStyle.Transient);
            c.Register(Castle.MicroKernel.Registration.Component.For<ITest_A2>().ImplementedBy<Test_A2>().LifeStyle.Transient);
            c.Register(Castle.MicroKernel.Registration.Component.For<ITest_A3>().ImplementedBy<Test_A3>().LifeStyle.Transient);
            c.Register(Castle.MicroKernel.Registration.Component.For<ITest_A4>().ImplementedBy<Test_A4>().LifeStyle.Transient);
            c.Register(Castle.MicroKernel.Registration.Component.For<ITest_A5>().ImplementedBy<Test_A5>().LifeStyle.Transient);
            c.Register(Castle.MicroKernel.Registration.Component.For<ITest_A6>().ImplementedBy<Test_A6>().LifeStyle.Transient);
            c.Register(Castle.MicroKernel.Registration.Component.For<ITest_A7>().ImplementedBy<Test_A7>().LifeStyle.Transient);
            c.Register(Castle.MicroKernel.Registration.Component.For<ITest_A8>().ImplementedBy<Test_A8>().LifeStyle.Transient);
            c.Register(Castle.MicroKernel.Registration.Component.For<ITest_A9>().ImplementedBy<Test_A9>().LifeStyle.Transient);
            c.Register(Castle.MicroKernel.Registration.Component.For<ITest_A10>().ImplementedBy<Test_A10>().LifeStyle.Transient);
            sw.Stop();

            Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
            sw.Reset();

            ITest_A10 lastValue = null;
            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                var test = c.Resolve<ITest_A10>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

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
        public void StructureMapTest()
        {
            //Register: 397482 Ticks.
            //Resolve: 1279467 Ticks.
            //Resolve: 505 Milliseconds.
            //Checking: 29972 Ticks.
            //Checking: 11 Milliseconds.

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            var c = new StructureMap.Container(x =>
            {
                x.For<ITest_A0>().Use<Test_A0>();
                x.For<ITest_A0>().Use<Test_A0>();
                x.For<ITest_A1>().Use<Test_A1>();
                x.For<ITest_A2>().Use<Test_A2>();
                x.For<ITest_A3>().Use<Test_A3>();
                x.For<ITest_A4>().Use<Test_A4>();
                x.For<ITest_A5>().Use<Test_A5>();
                x.For<ITest_A6>().Use<Test_A6>();
                x.For<ITest_A7>().Use<Test_A7>();
                x.For<ITest_A8>().Use<Test_A8>();
                x.For<ITest_A9>().Use<Test_A9>();
                x.For<ITest_A10>().Use<Test_A10>();
            });
            sw.Stop();

            Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
            sw.Reset();

            ITest_A10 lastValue = null;
            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITest_A10>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

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
        public void AutofacTest()
        {
            //Register: 503279 Ticks.
            //Resolve: 2135576 Ticks.
            //Resolve: 843 Milliseconds.
            //Checking: 45452 Ticks.
            //Checking: 17 Milliseconds.

            var cb = new Autofac.ContainerBuilder();

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            cb.RegisterType<Test_A0>().As<ITest_A0>();
            cb.RegisterType<Test_A1>().As<ITest_A1>();
            cb.RegisterType<Test_A2>().As<ITest_A2>();
            cb.RegisterType<Test_A3>().As<ITest_A3>();
            cb.RegisterType<Test_A4>().As<ITest_A4>();
            cb.RegisterType<Test_A5>().As<ITest_A5>();
            cb.RegisterType<Test_A6>().As<ITest_A6>();
            cb.RegisterType<Test_A7>().As<ITest_A7>();
            cb.RegisterType<Test_A8>().As<ITest_A8>();
            cb.RegisterType<Test_A9>().As<ITest_A9>();
            cb.RegisterType<Test_A10>().As<ITest_A10>();
            var c = cb.Build();
            sw.Stop();

            Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
            sw.Reset();

            ITest_A10 lastValue = null;
            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                var test = c.Resolve<ITest_A10>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

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
        public void UnityTest()
        {
            //Register: 13795 Ticks.
            //Resolve: 1752101 Ticks.
            //Resolve: 691 Milliseconds.
            //Checking: 22515 Ticks.
            //Checking: 8 Milliseconds.

            var c = new Microsoft.Practices.Unity.UnityContainer();

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            c.RegisterType<ITest_A0, Test_A0>();
            c.RegisterType<ITest_A1, Test_A1>();
            c.RegisterType<ITest_A2, Test_A2>();
            c.RegisterType<ITest_A3, Test_A3>();
            c.RegisterType<ITest_A4, Test_A4>();
            c.RegisterType<ITest_A5, Test_A5>();
            c.RegisterType<ITest_A6, Test_A6>();
            c.RegisterType<ITest_A7, Test_A7>();
            c.RegisterType<ITest_A8, Test_A8>();
            c.RegisterType<ITest_A9, Test_A9>();
            c.RegisterType<ITest_A10, Test_A10>();
            sw.Stop();

            Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
            sw.Reset();

            ITest_A10 lastValue = null;
            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                var test = c.Resolve<ITest_A10>();
                sw.Stop();

                Assert.AreNotEqual(test, lastValue);
                lastValue = test;

                sw2.Start();
                Check(test);
                sw2.Stop();
            }

            Debug.WriteLine(string.Format("Resolve: {0} Ticks.", sw.ElapsedTicks));
            Debug.WriteLine(string.Format("Resolve: {0} Milliseconds.", sw.ElapsedMilliseconds));

            Debug.WriteLine(string.Format("Checking: {0} Ticks.", sw2.ElapsedTicks));
            Debug.WriteLine(string.Format("Checking: {0} Milliseconds.", sw2.ElapsedMilliseconds));
        }
    }
}
