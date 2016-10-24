using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.MixObjectsLifeTime.SingletonAndTransient.ReRegister
{
    [TestClass]
    public class ReRegistereClassTests
    {
        [TestMethod]
        public void ClassReRegisteredFromSingletonToTransient_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve<EmptyClass>();
            var emptyClass2 = c.Resolve<EmptyClass>();

            c.RegisterType<EmptyClass>().AsTransient();
            var emptyClass3 = c.Resolve<EmptyClass>();
            var emptyClass4 = c.Resolve<EmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void ClassReRegisteredFromTransientToSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsTransient();
            var emptyClass1 = c.Resolve<EmptyClass>();
            var emptyClass2 = c.Resolve<EmptyClass>();

            c.RegisterType<EmptyClass>().AsSingleton();
            var emptyClass3 = c.Resolve<EmptyClass>();
            var emptyClass4 = c.Resolve<EmptyClass>();

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }
    }
}