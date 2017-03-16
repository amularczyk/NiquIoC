using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterInterfaceWithDependencyMethodTests
    {
        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>().AsPerHttpContext();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithInterfaceMethod>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithoutDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithoutInterfaceDependencyMethod>().AsPerHttpContext();


            var sampleClass = TestsHelper.ResolveObject<ISampleClassWithInterfaceMethod>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}