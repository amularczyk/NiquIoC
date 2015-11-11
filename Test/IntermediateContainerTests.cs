using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleContainer;

namespace SampleContainer.Test
{
    [TestClass]
    public class IntermediateContainerTests
    {
        private IContainer GetContainer()
        {
            return new IntermediateContainer();
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Brak odpowiedniego konstruktora")]
        public void ConstructorWithAttributeExceptionTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooAttrIC>(false);
            c.RegisterType<BarIC>(false);

            var foo = c.Resolve<FooAttrIC>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Brak odpowiedniego konstruktora")]
        public void TwoConstructorWithAttributeExceptionTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooTwoAttrIC>(false);
            c.RegisterType<BarIC>(false);

            var foo = c.Resolve<FooAttrIC>();
        }

        [TestMethod]
        public void ConstructorWithAttributeTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooAttrIC>(false);
            c.RegisterType<BarIC>(false);
            string text = "Text";
            c.RegisterInstance(text);

            var foo2 = c.Resolve<FooAttrIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);
            Assert.AreEqual(foo2.Text, text);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Cycle in class FooAttrIC")]
        public void CycleInConstructorTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooCycleIC>(false);
            c.RegisterType<BarCycleIC>(false);

            var foo = c.Resolve<FooCycleIC>();
        }

        [TestMethod]
        public void ClassNotSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooIC>(false);
            c.RegisterType<BarIC>(false);

            var foo1 = c.Resolve<FooIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            var foo2 = c.Resolve<FooIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreNotEqual(foo1, foo2);
            Assert.AreNotEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void ClassSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooIC>(true);
            c.RegisterType<BarIC>(true);

            var foo1 = c.Resolve<FooIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            var foo2 = c.Resolve<FooIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreEqual(foo1, foo2);
            Assert.AreEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void ClassDoubleRegisterTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<BarIC>(true);

            c.RegisterType<FooIC>(true);
            var foo1 = c.Resolve<FooIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            c.RegisterType<FooIC>(true);
            var foo2 = c.Resolve<FooIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreNotEqual(foo1, foo2);
            Assert.AreEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void InterfaceNotSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<IFooIC, FooIC>(false);
            c.RegisterType<BarIC>(false);

            var foo1 = c.Resolve<IFooIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            var foo2 = c.Resolve<IFooIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreNotEqual(foo1, foo2);
            Assert.AreNotEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void InterfaceSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<IFooIC, FooIC>(true);
            c.RegisterType<BarIC>(true);

            var foo1 = c.Resolve<IFooIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            var foo2 = c.Resolve<IFooIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreEqual(foo1, foo2);
            Assert.AreEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void InterfaceDoubleRegisterTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<BarIC>(true);

            c.RegisterType<IFooIC, FooIC>(true);
            var foo1 = c.Resolve<IFooIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            c.RegisterType<IFooIC, FooIC>(true);
            var foo2 = c.Resolve<IFooIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreNotEqual(foo1, foo2);
            Assert.AreEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void InstanceTest()
        {
            IContainer c = GetContainer();

            BarIC bar = new BarIC();
            IFooIC foo1 = new FooIC(bar);

            c.RegisterInstance<IFooIC>(foo1);
            IFooIC foo2 = c.Resolve<IFooIC>();

            Assert.AreEqual(foo1, foo2);
            Assert.AreEqual(bar, foo2.Bar);
        }
    }
}
