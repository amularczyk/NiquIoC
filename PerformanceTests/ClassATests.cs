using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleContainer;
using PerformanceTests.Classes;
using System.Diagnostics;
using Hiro;
using Hiro.Containers;

namespace PerformanceTests
{
    [TestClass]
    public class ClassATests
    {
        [TestMethod]
        public void UpperIntermediateContainerTest()
        {
            IContainer c = new UpperIntermediateContainer();

            Stopwatch sw = new Stopwatch();

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

            sw.Start();
            for (int i = 0; i < 100; i++)
            {
                c.Resolve<ITest_A10>();
            }
            sw.Stop();

            Debug.WriteLine(string.Format("Resolve: {0} Ticks.", sw.ElapsedTicks));
            Debug.WriteLine(string.Format("Resolve: {0} Milliseconds.", sw.ElapsedMilliseconds));
        }

        [TestMethod]
        public void HiroTest()
        {
            var dependencyMap = new DependencyMap();

            Stopwatch sw = new Stopwatch();

            sw.Start();
            dependencyMap.AddService<ITest_A0, Test_A0>();
            dependencyMap.AddService<ITest_A1, Test_A1>();
            dependencyMap.AddService<ITest_A2, Test_A2>();
            dependencyMap.AddService<ITest_A3, Test_A3>();
            dependencyMap.AddService<ITest_A4, Test_A4>();
            dependencyMap.AddService<ITest_A5, Test_A5>();
            dependencyMap.AddService<ITest_A6, Test_A6>();
            dependencyMap.AddService<ITest_A7, Test_A7>();
            dependencyMap.AddService<ITest_A8, Test_A8>();
            dependencyMap.AddService<ITest_A9, Test_A9>();
            dependencyMap.AddService<ITest_A10, Test_A10>();
            sw.Stop();

            Debug.WriteLine(string.Format("Register: {0} Ticks.", sw.ElapsedTicks));
            sw.Reset();

            sw.Start();
            for (int i = 0; i < 100; i++)
            {
                var dependency = new Dependency(typeof(ITest_A10), string.Empty);
                dependencyMap.GetImplementations(dependency, false);
            }
            sw.Stop();

            Debug.WriteLine(string.Format("Resolve: {0} Ticks.", sw.ElapsedTicks));
            Debug.WriteLine(string.Format("Resolve: {0} Milliseconds.", sw.ElapsedMilliseconds));
        }
    }
}
