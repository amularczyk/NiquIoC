using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.Transient.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterInterfaceWithDependencyPropertyAndDependencyMethodTests
    {
        [TestMethod]
        public void RegisterInterfaceWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c
                .RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType,
                    SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>();

            var sampleClass =
                c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>(ResolveKind
                    .PartialEmitFunction);

            c.BuildUp(sampleClass, ResolveKind.PartialEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass.EmptyClassFromDependencyProperty,
                sampleClass.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void DifferentObjects_RegisterInterfaceWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c
                .RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType,
                    SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>();

            var sampleClass1 =
                c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>(ResolveKind
                    .PartialEmitFunction);
            var sampleClass2 =
                c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>(ResolveKind
                    .PartialEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass1.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyProperty,
                sampleClass1.EmptyClassFromDependencyMethod);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass2.EmptyClassFromDependencyProperty,
                sampleClass2.EmptyClassFromDependencyMethod);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyProperty,
                sampleClass2.EmptyClassFromDependencyProperty);
            Assert.AreNotEqual(sampleClass1.EmptyClassFromDependencyMethod,
                sampleClass2.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void RegisterInterfaceWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c
                .RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes,
                    SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>();

            var sampleClass =
                c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>(ResolveKind
                    .PartialEmitFunction);

            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass, sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void
            DifferentObjects_RegisterInterfaceWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            c
                .RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes,
                    SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>();

            var sampleClass1 =
                c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>(ResolveKind
                    .PartialEmitFunction);
            var sampleClass2 =
                c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>(ResolveKind
                    .PartialEmitFunction);

            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass1.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass.EmptyClass, sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass2.SampleClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass2.SampleClass.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}