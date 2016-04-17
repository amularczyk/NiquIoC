using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Helpers;

namespace NiquIoC.Test
{
    [TestClass]
    public class EmitTmpTest
    {
        [TestMethod]
        public void FooA_test()
        {
            var a = EmitTmp.FooA();
        }

        [TestMethod]
        public void FooB_test()
        {
            var b = EmitTmp.FooB();
        }

        [TestMethod]
        public void FooC_test()
        {
            var c = EmitTmp.FooC();
        }
    }
}
