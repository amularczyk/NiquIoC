using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.Singleton
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyPropertyAndDependencyMethod
    {
        [TestMethod]
        public void RegisteredClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethod sampleClass = new SampleClassWithInterfaceDependencyPropertyAndDependencyMethod();

            c.BuildUp(sampleClass);

            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void DifferentObjects_RegisteredClassWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethod sampleClass1 = new SampleClassWithInterfaceDependencyPropertyAndDependencyMethod();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethod sampleClass2 = new SampleClassWithInterfaceDependencyPropertyAndDependencyMethod();

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