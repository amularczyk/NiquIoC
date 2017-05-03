using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.BuildUp
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyPropertyTests
    {
        [TestMethod]
        public void InterfaceWithoutBuildUpWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(BuildUpNotSupportedException))]
        public void BuildUpInterfaceWithDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceProperty sampleClass = new SampleClassWithInterfaceDependencyProperty();


            sampleClass = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
        }
    }
}