using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyPropertyAndDependencyMethod
    {
        [TestMethod]
        public void RegisteredClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            var sampleClass = new SampleClassWithInterfaceDependencyPropertyAndDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
        }
    }
}