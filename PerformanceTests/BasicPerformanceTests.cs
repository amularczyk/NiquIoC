using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;
using System.Diagnostics;

namespace PerformanceTests
{
    [TestClass]
    public class BasicPerformanceTests
    {
        [TestMethod]
        public void UpperIntermediateContainerBasicTest()
        {
            SampleContainer.UpperIntermediateContainer c = new SampleContainer.UpperIntermediateContainer();

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw.Start();
            c.RegisterType<ITestA0, TestA0>(false);
            sw.Stop();

            Debug.WriteLine("Register: {0} Ticks.", sw.ElapsedTicks);
            sw.Reset();

            for (int i = 0; i < 100; i++)
            {
                sw.Start();
                //var test = c.Resolve<ITest_A10>();
                var test = c.Resolve<ITestA0>();
                sw.Stop();

                sw2.Start();
                Assert.IsNotNull(test);
                sw2.Stop();
            }

            Debug.WriteLine("Resolve: {0} Ticks.", sw.ElapsedTicks);
            Debug.WriteLine("Resolve: {0} Milliseconds.", sw.ElapsedMilliseconds);

            Debug.WriteLine("Checking: {0} Ticks.", sw2.ElapsedTicks);
            Debug.WriteLine("Checking: {0} Milliseconds.", sw2.ElapsedMilliseconds);
        }
    }
}
