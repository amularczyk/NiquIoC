using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction.Singleton.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyPropertyAndDependencyMethodTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyPropertyAndDependencyMethodWithSameType_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass.EmptyClassFromDependencyProperty, sampleClass.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithSameType_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>();

            var sampleClass1 = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>(ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithSameType>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass1.EmptyClassFromDependencyMethod);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass2.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyProperty);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyMethod, sampleClass2.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass.EmptyClassFromDependencyProperty, sampleClass.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass.EmptyClassFromDependencyProperty.EmptyClass, sampleClass.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>();

            var sampleClass1 = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>(ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithClassDependencyPropertyAndDependencyMethodWithDifferentTypes>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass1.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty.EmptyClass, sampleClass1.EmptyClassFromDependencyMethod);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass2.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass2.EmptyClassFromDependencyProperty.EmptyClass, sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyProperty, sampleClass2.EmptyClassFromDependencyProperty);
            Assert.AreEqual(sampleClass1.EmptyClassFromDependencyMethod, sampleClass2.EmptyClassFromDependencyMethod);
        }
    }
}