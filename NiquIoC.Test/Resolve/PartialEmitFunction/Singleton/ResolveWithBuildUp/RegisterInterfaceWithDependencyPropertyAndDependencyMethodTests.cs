﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.Singleton.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterInterfaceWithDependencyPropertyAndDependencyMethodTests
    {
        [TestMethod]
        public void RegisterInterfaceWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType, SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>();

            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyProperty);
            Assert.IsNotNull(sampleClass.EmptyClassFromDependencyMethod);
            Assert.AreEqual(sampleClass.EmptyClassFromDependencyProperty, sampleClass.EmptyClassFromDependencyMethod);
        }

        [TestMethod]
        public void DifferentObjects_RegisterInterfaceWithDependencyPropertyAndDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType, SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>();

            var sampleClass1 = c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>();
            var sampleClass2 = c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithSameType>();

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
        public void RegisterInterfaceWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes, SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>();

            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass, sampleClass.EmptyClass);
            Assert.AreEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterInterfaceWithDependencyPropertyAndDependencyMethodWithDifferentTypes_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes, SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>();

            var sampleClass1 = c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>();
            var sampleClass2 = c.Resolve<ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes>();

            Assert.IsNotNull(sampleClass1.SampleClass);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClass, sampleClass1.EmptyClass);
            Assert.AreEqual(sampleClass1.SampleClass.EmptyClass, sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass2.SampleClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass2.SampleClass.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.SampleClass, sampleClass2.SampleClass);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}