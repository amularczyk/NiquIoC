using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyPropertyTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithClassDependencyProperty>().AsPerHttpContext();


            var sampleClass = HttpContextTestsHelper.Initialize().ResolveObject<SampleClassWithClassDependencyProperty>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithoutDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            c.RegisterType<SampleClassWithoutClassDependencyProperty>().AsPerHttpContext();


            var sampleClass = HttpContextTestsHelper.Initialize().ResolveObject<SampleClassWithoutClassDependencyProperty>(c, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}