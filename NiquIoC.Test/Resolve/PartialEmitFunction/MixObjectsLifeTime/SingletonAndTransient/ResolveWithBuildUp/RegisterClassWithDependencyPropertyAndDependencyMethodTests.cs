using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.MixObjectsLifeTime.SingletonAndTransient.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyPropertyAndDependencyMethodTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_SampleClassAsSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();


            var sampleClass = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();


            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass, sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_SampleClassAsSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();


            var sampleClass1 = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();
            var sampleClass2 = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();


            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass1.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass.EmptyClass, sampleClass1.EmptyClass);

            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass2.SampleClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass2.SampleClass.EmptyClass, sampleClass2.EmptyClass);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
            Assert.AreEqual(sampleClass1.SampleClass.EmptyClass, sampleClass2.SampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_EmptyClassAsSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();


            var sampleClass = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();


            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass, sampleClass.EmptyClass);
            Assert.AreEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_EmptyClassAsSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();


            var sampleClass1 = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();
            var sampleClass2 = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();


            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass1.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass.EmptyClass, sampleClass1.EmptyClass);

            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass2.SampleClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass2.SampleClass.EmptyClass, sampleClass2.EmptyClass);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
            Assert.AreEqual(sampleClass1.SampleClass.EmptyClass, sampleClass2.SampleClass.EmptyClass);
        }
    }
}