using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleContainer;

namespace SampleContainer.Test
{
    [TestClass]
    public class UpperIntermediateContainerTests
    {
        private IContainer GetContainer()
        {
            return new UpperIntermediateContainer();
        }

        [TestMethod]
        public void PropertyTest()
        {
            IContainer c = GetContainer();

            c.RegisterType<BarUIC>(false);
            c.RegisterType<IFooPropUIC, FooPropUIC>(false);
            IFooPropUIC foo = c.Resolve<IFooPropUIC>();

            Assert.IsNotNull(foo);
            Assert.IsNotNull(foo.Bar);
        }

        [TestMethod]
        public void ManyPropertyTest()
        {
            IContainer c = GetContainer();

            c.RegisterType<BarUIC>(false);
            c.RegisterType<IFooPropUIC, FooPropUIC>(false);
            c.RegisterType<IFooManyPropUIC, FooManyPropUIC>(false);
            IFooManyPropUIC foo = c.Resolve<IFooManyPropUIC>();

            Assert.IsNotNull(foo);
            Assert.IsNotNull(foo.Bar);
            Assert.IsNotNull(foo.FooPropUIC);
            Assert.IsNotNull(foo.FooPropUIC.Bar);
        }

        [TestMethod]
        public void PropertyWithoutSetTest()
        {
            IContainer c = GetContainer();

            c.RegisterType<BarUIC>(false);
            c.RegisterType<IFooPropNoSetUIC, FooPropNoSetUIC>(false);
            IFooPropNoSetUIC foo = c.Resolve<IFooPropNoSetUIC>();

            Assert.IsNotNull(foo);
            Assert.IsNull(foo.Bar);
        }

        [TestMethod]
        public void BuildUpTest()
        {
            IContainer c = GetContainer();

            c.RegisterType<BarUIC>(false);
            FooPropUIC foo = new FooPropUIC();

            Assert.IsNotNull(foo);
            Assert.IsNull(foo.Bar);

            c.BuildUp<FooPropUIC>(foo);

            Assert.IsNotNull(foo.Bar);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Brak odpowiedniego konstruktora")]
        public void ConstructorWithAttributeExceptionTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooAttrUIC>(false);
            c.RegisterType<BarUIC>(false);

            var foo = c.Resolve<FooAttrUIC>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Brak odpowiedniego konstruktora")]
        public void TwoConstructorWithAttributeExceptionTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooTwoAttrUIC>(false);
            c.RegisterType<BarUIC>(false);

            var foo = c.Resolve<FooAttrUIC>();
        }

        [TestMethod]
        public void ConstructorWithAttributeTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooAttrUIC>(false);
            c.RegisterType<BarUIC>(false);
            string text = "Text";
            c.RegisterInstance(text);

            var foo2 = c.Resolve<FooAttrUIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);
            Assert.AreEqual(foo2.Text, text);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Cycle in class FooAttrUIC")]
        public void CycleInConstructorTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooCycleUIC>(false);
            c.RegisterType<BarCycleUIC>(false);

            var foo = c.Resolve<FooCycleUIC>();
        }

        [TestMethod]
        public void ClassNotSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooUIC>(false);
            c.RegisterType<BarUIC>(false);

            var foo1 = c.Resolve<FooUIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            var foo2 = c.Resolve<FooUIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreNotEqual(foo1, foo2);
            Assert.AreNotEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void ClassSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooUIC>(true);
            c.RegisterType<BarUIC>(true);

            var foo1 = c.Resolve<FooUIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            var foo2 = c.Resolve<FooUIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreEqual(foo1, foo2);
            Assert.AreEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void ClassDoubleRegisterTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<BarUIC>(true);

            c.RegisterType<FooUIC>(true);
            var foo1 = c.Resolve<FooUIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            c.RegisterType<FooUIC>(true);
            var foo2 = c.Resolve<FooUIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreNotEqual(foo1, foo2);
            Assert.AreEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void InterfaceNotSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<IFooUIC, FooUIC>(false);
            c.RegisterType<BarUIC>(false);

            var foo1 = c.Resolve<IFooUIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            var foo2 = c.Resolve<IFooUIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreNotEqual(foo1, foo2);
            Assert.AreNotEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void InterfaceSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<IFooUIC, FooUIC>(true);
            c.RegisterType<BarUIC>(true);

            var foo1 = c.Resolve<IFooUIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            var foo2 = c.Resolve<IFooUIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreEqual(foo1, foo2);
            Assert.AreEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void InterfaceDoubleRegisterTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<BarUIC>(true);

            c.RegisterType<IFooUIC, FooUIC>(true);
            var foo1 = c.Resolve<IFooUIC>();
            Assert.IsNotNull(foo1);
            Assert.IsNotNull(foo1.Bar);

            c.RegisterType<IFooUIC, FooUIC>(true);
            var foo2 = c.Resolve<IFooUIC>();
            Assert.IsNotNull(foo2);
            Assert.IsNotNull(foo2.Bar);

            Assert.AreNotEqual(foo1, foo2);
            Assert.AreEqual(foo1.Bar, foo2.Bar);
        }

        [TestMethod]
        public void InstanceTest()
        {
            IContainer c = GetContainer();

            BarUIC bar = new BarUIC();
            IFooUIC foo1 = new FooUIC(bar);

            c.RegisterInstance<IFooUIC>(foo1);
            IFooUIC foo2 = c.Resolve<IFooUIC>();

            Assert.AreEqual(foo1, foo2);
            Assert.AreEqual(bar, foo2.Bar);
        }
    }
}
