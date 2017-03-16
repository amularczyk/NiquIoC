using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.Singleton.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterInterfaceWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithInterfaceDependencyProperty>().AsSingleton();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithoutDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceProperty, SampleClassWithoutInterfaceDependencyProperty>().AsSingleton();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceProperty>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}