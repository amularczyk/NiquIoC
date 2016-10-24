﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction.MixObjectsLifeTime.BuildUp
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyPropertyAndDependencyMethodTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_SampleClassAsSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass = new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes();


            c.BuildUp(sampleClass, Enums.ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass, sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_SampleClassAsSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsSingleton();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass1 = new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass2 = new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes();
            

            c.BuildUp(sampleClass1, Enums.ResolveKind.FullEmitFunction);
            c.BuildUp(sampleClass2, Enums.ResolveKind.FullEmitFunction);


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
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass = new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes();


            c.BuildUp(sampleClass, Enums.ResolveKind.FullEmitFunction);


            Assert.IsNotNull(sampleClass.SampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.AreNotEqual(sampleClass.SampleClass, sampleClass.EmptyClass);
            Assert.AreEqual(sampleClass.SampleClass.EmptyClass, sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_RegisterClassWithDependencyPropertyAndDependencyMethodWithDifferentTypes_SEmptyClassAsSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass1 = new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes();
            ISampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes sampleClass2 = new SampleClassWithInterfaceDependencyPropertyAndDependencyMethodWithDifferentTypes();


            c.BuildUp(sampleClass1, Enums.ResolveKind.FullEmitFunction);
            c.BuildUp(sampleClass2, Enums.ResolveKind.FullEmitFunction);


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