using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction.MixObjectsLifeTime
{
    [TestClass]
    public class ReRegistereInterfaceTests
    {
        [TestMethod]
        public void InterfaceReRegisteredFromSingletonToTransient_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve<IEmptyClass>(Enums.ResolveKind.FullEmitFunction);
            var emptyClass2 = c.Resolve<IEmptyClass>(Enums.ResolveKind.FullEmitFunction);

            c.RegisterType<IEmptyClass, EmptyClass>().AsTransient();
            var emptyClass3 = c.Resolve<IEmptyClass>(Enums.ResolveKind.FullEmitFunction);
            var emptyClass4 = c.Resolve<IEmptyClass>(Enums.ResolveKind.FullEmitFunction);

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromTransientToSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsTransient();
            var emptyClass1 = c.Resolve<IEmptyClass>(Enums.ResolveKind.FullEmitFunction);
            var emptyClass2 = c.Resolve<IEmptyClass>(Enums.ResolveKind.FullEmitFunction);

            c.RegisterType<IEmptyClass, EmptyClass>().AsSingleton();
            var emptyClass3 = c.Resolve<IEmptyClass>(Enums.ResolveKind.FullEmitFunction);
            var emptyClass4 = c.Resolve<IEmptyClass>(Enums.ResolveKind.FullEmitFunction);

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheOtherSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsTransient();

            c.RegisterType<ISampleClass, SampleClass>().AsSingleton();
            var sampleClass1 = c.Resolve<ISampleClass>(Enums.ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<ISampleClass>(Enums.ResolveKind.FullEmitFunction);

            c.RegisterType<ISampleClass, SampleClassOther>().AsSingleton();
            var sampleClass3 = c.Resolve<ISampleClass>(Enums.ResolveKind.FullEmitFunction);
            var sampleClass4 = c.Resolve<ISampleClass>(Enums.ResolveKind.FullEmitFunction);

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.GetType(), sampleClass2.GetType());
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass3, sampleClass4);
            Assert.AreEqual(sampleClass3.GetType(), sampleClass4.GetType());
            Assert.AreEqual(sampleClass3.EmptyClass, sampleClass4.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass3);
            Assert.AreNotEqual(sampleClass1.GetType(), sampleClass3.GetType());
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass3.EmptyClass);
        }

        [TestMethod]
        public void InterfaceReRegisteredFromOneClassToTheOtherTransient_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();

            c.RegisterType<ISampleClass, SampleClass>().AsTransient();
            var sampleClass1 = c.Resolve<ISampleClass>(Enums.ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<ISampleClass>(Enums.ResolveKind.FullEmitFunction);

            c.RegisterType<ISampleClass, SampleClassOther>().AsTransient();
            var sampleClass3 = c.Resolve<ISampleClass>(Enums.ResolveKind.FullEmitFunction);
            var sampleClass4 = c.Resolve<ISampleClass>(Enums.ResolveKind.FullEmitFunction);

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.GetType(), sampleClass2.GetType());
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass3, sampleClass4);
            Assert.AreEqual(sampleClass3.GetType(), sampleClass4.GetType());
            Assert.AreEqual(sampleClass3.EmptyClass, sampleClass4.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass3);
            Assert.AreNotEqual(sampleClass1.GetType(), sampleClass3.GetType());
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass3.EmptyClass);
        }
    }
}