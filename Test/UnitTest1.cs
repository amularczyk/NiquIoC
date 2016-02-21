using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleContainer;

namespace Test
{
    [TestClass]
    public class EmitTmpTests
    {
        [TestMethod]
        public void Test1()
        {
            EmitTmp tmp = new EmitTmp();

            var t = tmp.Foo();
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void Test2()
        {
            EmitTmp tmp = new EmitTmp();

            var t = tmp.Foo2();
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void Test3()
        {
            EmitTmp tmp = new EmitTmp();

            var t = tmp.Foo3();
            Assert.IsNotNull(t);
            Assert.IsNotNull(t.Bar);
        }
    }
}
