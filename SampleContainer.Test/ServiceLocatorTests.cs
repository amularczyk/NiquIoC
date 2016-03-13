using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleContainer;

namespace SampleContainer.Test
{
    [TestClass]
    public class ServiceLocatorTests
    {
        private IContainer GetContainer()
        {
            return new UpperIntermediateContainer();
        }

        [TestMethod]
        public void ServiceLocatorSingletonTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<BarUIC>(false);
            c.RegisterType<IFooUIC, FooUIC>(false);

            ContainerProviderDelegate containerProvider = () => c;
            ServiceLocator.SetContainerProvider(containerProvider);

            IFooUIC foo = ServiceLocator.Current.GetInstance<IFooUIC>();

            Assert.IsNotNull(foo);
            Assert.IsNotNull(foo.Bar);
        }

        [TestMethod]
        public void ServiceLocatorNewTest()
        {

            ContainerProviderDelegate containerProvider = () => GetContainer();
            ServiceLocator.SetContainerProvider(containerProvider);

            IContainer c = ServiceLocator.Current.GetInstance<IContainer>();

            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void ServiceLocatorSingletonBuildUpTest()
        {
            IContainer c = GetContainer();
            c.RegisterType<BarUIC>(false);

            ContainerProviderDelegate containerProvider = () => c;
            ServiceLocator.SetContainerProvider(containerProvider);

            IContainer newC = ServiceLocator.Current.GetInstance<IContainer>();

            FooPropUIC foo = new FooPropUIC();

            Assert.IsNotNull(foo);
            Assert.IsNull(foo.Bar);

            newC.BuildUp<FooPropUIC>(foo);

            Assert.IsNotNull(foo.Bar);
        }
    }
}
