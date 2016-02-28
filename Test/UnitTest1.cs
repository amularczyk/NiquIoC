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
        public void TestT()
        {
            EmitTmp tmp = new EmitTmp();

            var t = tmp.FooT();
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

        [TestMethod]
        public void Test4()
        {
            EmitTmp tmp = new EmitTmp();

            var t = tmp.Foo4();
            Assert.IsNotNull(t);
            Assert.IsNotNull(t.Bar);
            Assert.IsNotNull(t.Bar2);
            Assert.IsNotNull(t.Bar2.Bar);
        }

        [TestMethod]
        public void Test5()
        {
            EmitTmp tmp = new EmitTmp();

            var t = tmp.Foo5();
            Assert.IsNotNull(t);
            Assert.IsNotNull(t.Bar);
            Assert.IsNotNull(t.Bar4);
        }

        [TestMethod]
        public void Test6()
        {
            EmitTmp tmp = new EmitTmp();

            var t = tmp.Foo6();
            Assert.IsNotNull(t);
            Assert.IsNotNull(t.Bar);
            Assert.IsNotNull(t.Bar4);
        }

        [TestMethod]
        public void Test7()
        {
            EmitTmp tmp = new EmitTmp();

            var t = tmp.Foo7();
            Assert.IsNotNull(t);
            Assert.IsNotNull(t.Bar);
            Assert.IsNotNull(t.Bar4);
        }

        [TestMethod]
        public void Test11()
        {
            var someCtor = typeof(SomeClass).GetConstructors()[0];
            var factoryFunction = EmitTmp3.CreateObjectFactoryMethodWithCtorParams(someCtor);
            var obj = (SomeClass)factoryFunction(new object[] { "A String", 123 }); //input ctor args

            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.S);
            Assert.IsNotNull(obj.T);
        }

        [TestMethod]
        public void Test12()
        {
            var someCtor = typeof(Bar5).GetConstructors()[0];
            var factoryFunction = EmitTmp3.CreateObjectFactoryMethodWithCtorParams(someCtor);
            var obj = (Bar5)factoryFunction(new object[] { new Bar(), new Bar4() }); //input ctor args

            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Bar);
            Assert.IsNotNull(obj.Bar4);
        }
        
        [TestMethod]
        public void Test21()
        {
            EmitTmp2 tmp = new EmitTmp2();
            var obj = (Bar5)tmp.Create<Bar5>();

            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Bar);
            Assert.IsNotNull(obj.Bar4);
        }
    }
    class SomeClass
    {
        public string S { get; private set; }
        public int T { get; private set; }

        public SomeClass(string s, int t)
        {
            S = s;
            T = t;
        }
    }
}
