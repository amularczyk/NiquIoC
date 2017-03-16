using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyMethodTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyMethod>().AsPerHttpContext();


            var sampleClass = TestsHelper.ResolveObject<SampleClassWithClassDependencyMethod>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithoutDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithoutClassDependencyMethod>().AsPerHttpContext();


            var sampleClass = TestsHelper.ResolveObject<SampleClassWithoutClassDependencyMethod>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}