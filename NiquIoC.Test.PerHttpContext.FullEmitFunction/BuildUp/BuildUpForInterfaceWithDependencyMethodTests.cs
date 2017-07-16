using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.BuildUp
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyMethodTests
    {
        [TestMethod]
        public void InterfaceWithoutBuildUpWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithoutInterfaceDependencyMethod();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(BuildUpNotSupportedException))]
        public void BuildUpInterfaceWithDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerHttpContext();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithInterfaceDependencyMethod();


            sampleClass = HttpContextTestsHelper.Initialize()
                .BuildUpObject(c, sampleClass, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
        }
    }
}