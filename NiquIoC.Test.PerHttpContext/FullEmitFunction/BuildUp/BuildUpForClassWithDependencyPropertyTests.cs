using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PerHttpContext.FullEmitFunction.BuildUp
{
    [TestClass]
    public class BuildUpForClassWithDependencyPropertyTests
    {
        [TestMethod]
        public void ClassWithoutBuildUpWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithClassDependencyProperty();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(BuildUpNotSupportedException))]
        public void BuildUpClassWithDependencyProperty_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerHttpContext();
            var sampleClass = new SampleClassWithClassDependencyProperty();


            sampleClass = HttpContextTestsHelper.Initialize().BuildUpObject(c, sampleClass, ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
        }
    }
}