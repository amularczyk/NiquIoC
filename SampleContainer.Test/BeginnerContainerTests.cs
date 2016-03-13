using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleContainer;

namespace SampleContainer.Test
{
    [TestClass]
    public class BeginnerContainerTests
    {
        private IContainer GetContainer()
        {
            return new BeginnerContainer();
        }

        [TestMethod]
        public void ClassNotSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooBC>(false);

            var foo1 = c.Resolve<FooBC>();
            Assert.IsNotNull(foo1);
            var foo2 = c.Resolve<FooBC>();
            Assert.IsNotNull(foo2);

            Assert.AreNotEqual(foo1, foo2);
        }

        [TestMethod]
        public void ClassSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<FooBC>(true);

            var foo1 = c.Resolve<FooBC>();
            Assert.IsNotNull(foo1);
            var foo2 = c.Resolve<FooBC>();
            Assert.IsNotNull(foo2);

            Assert.AreEqual(foo1, foo2);
        }

        [TestMethod]
        public void ClassDoubleRegisterTest()
        {
            IContainer c = GetContainer();

            c.RegisterType<FooBC>(true);
            var foo1 = c.Resolve<FooBC>();
            Assert.IsNotNull(foo1);

            c.RegisterType<FooBC>(true);
            var foo2 = c.Resolve<FooBC>();
            Assert.IsNotNull(foo2);

            Assert.AreNotEqual(foo1, foo2);
        }

        [TestMethod]
        public void InterfaceNotSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<IFooBC, FooBC>(false);

            var foo1 = c.Resolve<IFooBC>();
            Assert.IsNotNull(foo1);
            var foo2 = c.Resolve<IFooBC>();
            Assert.IsNotNull(foo2);

            Assert.AreNotEqual(foo1, foo2);
        }

        [TestMethod]
        public void InterfaceSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<IFooBC, FooBC>(true);

            var foo1 = c.Resolve<IFooBC>();
            Assert.IsNotNull(foo1);
            var foo2 = c.Resolve<IFooBC>();
            Assert.IsNotNull(foo2);

            Assert.AreEqual(foo1, foo2);
        }

        [TestMethod]
        public void InterfaceDoubleRegisterTest()
        {
            IContainer c = GetContainer();

            c.RegisterType<IFooBC, FooBC>(true);
            var foo1 = c.Resolve<IFooBC>();
            Assert.IsNotNull(foo1);

            c.RegisterType<IFooBC, FooBC>(true);
            var foo2 = c.Resolve<IFooBC>();
            Assert.IsNotNull(foo2);

            Assert.AreNotEqual(foo1, foo2);
        }

        [TestMethod]
        public void InstanceTest()
        {
            IContainer c = GetContainer();

            IFooBC foo1 = new FooBC();

            c.RegisterInstance<IFooBC>(foo1);
            IFooBC foo2 = c.Resolve<IFooBC>();

            Assert.AreEqual(foo1, foo2);
        }
    }
}
