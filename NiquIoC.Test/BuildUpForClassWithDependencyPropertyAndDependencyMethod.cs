using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test
{
    [TestClass]
    public class BuildUpForClassWithDependencyPropertyAndDependencyMethod
    {
        [TestMethod]
        public void RegisteredClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            var sampleClass = new SampleClassWithClassDependencyPropertyAndDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
        }
    }
}