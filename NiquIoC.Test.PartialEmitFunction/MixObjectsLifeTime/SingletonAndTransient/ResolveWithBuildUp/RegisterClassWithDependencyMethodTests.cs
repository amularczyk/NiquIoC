using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.MixObjectsLifeTime.SingletonAndTransient.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyMethodTests
    {
        [TestMethod]
        public void RegisterClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<SampleClassWithManyClassDependencyMethods>();


            var sampleClass = c.Resolve<SampleClassWithManyClassDependencyMethods>(ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithManyClassDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<SampleClassWithManyClassDependencyMethods>();


            var sampleClass1 = c.Resolve<SampleClassWithManyClassDependencyMethods>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithManyClassDependencyMethods>(ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass1.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass.EmptyClass, sampleClass1.EmptyClass);

            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.IsNotNull(sampleClass2.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass2.SampleClass.EmptyClass, sampleClass2.EmptyClass);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
            Assert.AreEqual(sampleClass1.SampleClass.EmptyClass, sampleClass2.SampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<SampleClassWithManyClassParametersInDependencyMethod>();


            var sampleClass =
                c.Resolve<SampleClassWithManyClassParametersInDependencyMethod>(ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithManyClassParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<SampleClassWithManyClassParametersInDependencyMethod>();


            var sampleClass1 =
                c.Resolve<SampleClassWithManyClassParametersInDependencyMethod>(ResolveKind.PartialEmitFunction);
            var sampleClass2 =
                c.Resolve<SampleClassWithManyClassParametersInDependencyMethod>(ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass1.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass.EmptyClass, sampleClass1.EmptyClass);

            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.IsNotNull(sampleClass2.SampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass2.SampleClass.EmptyClass, sampleClass2.EmptyClass);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
            Assert.AreEqual(sampleClass1.SampleClass.EmptyClass, sampleClass2.SampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyMethod>();
            c.RegisterType<SampleClassWithNestedClassDependencyMethod>();


            var sampleClass = c.Resolve<SampleClassWithNestedClassDependencyMethod>(ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyMethod.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithNestedClassDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClassWithClassDependencyMethod>();
            c.RegisterType<SampleClassWithNestedClassDependencyMethod>();


            var sampleClass1 = c.Resolve<SampleClassWithNestedClassDependencyMethod>(ResolveKind.PartialEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithNestedClassDependencyMethod>(ResolveKind.PartialEmitFunction);


            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass);

            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.IsNotNull(sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithClassDependencyMethod,
                sampleClass2.SampleClassWithClassDependencyMethod);
            Assert.AreEqual(sampleClass1.SampleClassWithClassDependencyMethod.EmptyClass,
                sampleClass2.SampleClassWithClassDependencyMethod.EmptyClass);
        }
    }
}