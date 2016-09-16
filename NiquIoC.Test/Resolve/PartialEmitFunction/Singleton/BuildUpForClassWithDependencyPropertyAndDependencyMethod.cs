using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.Singleton
{
    [TestClass]
    public class BuildUpForClassWithDependencyPropertyAndDependencyMethod
    {
        [TestMethod]
        public void RegisteredClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var sampleClass = new SampleClassWithClassDependencyPropertyAndDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void DifferentObjects_RegisteredClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var sampleClass1 = new SampleClassWithClassDependencyPropertyAndDependencyMethod();
            var sampleClass2 = new SampleClassWithClassDependencyPropertyAndDependencyMethod();

            c.BuildUp(sampleClass1);
            c.BuildUp(sampleClass2);

            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyMethod);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyProperty);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyMethod, sampleClass2.EmptyClassFromDependencyMethod);
        }
    }
}