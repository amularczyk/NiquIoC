using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction
{
    [TestClass]
    public class RegisterClassWithDependencyPropertyTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type NiquIoC.Test.ClassDefinitions.EmptyClass has not been registered.")]
        public void RegisteredClassWithDependencyPropertyWithoutRegisteredNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyProperty>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyProperty>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithoutDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithoutClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithoutClassDependencyProperty>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisteredClassWithManyClassDependencyProperties_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();
            c.RegisterType<SampleClassWithManyClassDependencyProperties>();

            var sampleClass = c.Resolve<SampleClassWithManyClassDependencyProperties>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClass);
        }

        [TestMethod]
        public void RegisteredClassWithNestedClassDependencyProperty_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyProperty>();
            c.RegisterType<SampleClassWithNestedClassDependencyProperty>();

            var sampleClass = c.Resolve<SampleClassWithNestedClassDependencyProperty>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty);
            Assert.IsNotNull(sampleClass.SampleClassWithClassDependencyProperty.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithDependencyPropertyWithoutSetMethod_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClassWithClassDependencyPropertyWithoutSetMethod>();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyPropertyWithoutSetMethod>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}