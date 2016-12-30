﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Tests.PerHttpContext.Containers.TestsAutofac
{
    [TestClass]
    public class AutofacPerformanceTests
    {
        private IPerformance GetPerformance()
        {
            return new AutofacPerformance();
        }

        [TestMethod]
        public void DoTestA_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.DoTestA(1, true);
        }

        [TestMethod]
        public void DoTestA_Transient_Success()
        {
            var performance = GetPerformance();
            performance.DoTestA(1, false);
        }

        [TestMethod]
        public void DoTestB_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.DoTestB(1, true);
        }

        [TestMethod]
        public void DoTestB_Transient_Success()
        {
            var performance = GetPerformance();
            performance.DoTestB(1, false);
        }

        [TestMethod]
        public void DoTestC_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.DoTestC(1, true);
        }

        [TestMethod]
        public void DoTestC_Transient_Success()
        {
            var performance = GetPerformance();
            performance.DoTestC(1, false);
        }
    }
}