using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.PartialEmitFunction.PerThread
{
    [TestClass]
    public class RegisterGenericTypeForClassTests
    {
        [TestMethod]
        public void RegisterSimpleGenericClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<GenericClass<EmptyClass>>().AsSingleton();
            GenericClass<EmptyClass> genericClass = null;

            var thread = new Thread(() => { genericClass = c.Resolve<GenericClass<EmptyClass>>(); });
            thread.Start();
            thread.Join();

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithClassWithNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<GenericClass<SampleClass>>().AsSingleton();
            GenericClass<SampleClass> genericClass = null;

            var thread = new Thread(() => { genericClass = c.Resolve<GenericClass<SampleClass>>(); });
            thread.Start();
            thread.Join();

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
            Assert.IsNotNull(genericClass.NestedClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithManyParameters_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<GenericClassWithManyParameters<EmptyClass, SampleClass>>().AsSingleton();
            GenericClassWithManyParameters<EmptyClass, SampleClass> genericClass = null;

            var thread = new Thread(() => { genericClass = c.Resolve<GenericClassWithManyParameters<EmptyClass, SampleClass>>(); });
            thread.Start();
            thread.Join();

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass1);
            Assert.IsNotNull(genericClass.NestedClass2);
            Assert.IsNotNull(genericClass.NestedClass2.EmptyClass);
            Assert.AreEqual(genericClass.NestedClass1, genericClass.NestedClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterManyGenericClasses_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<GenericClass<EmptyClass>>().AsSingleton();
            c.RegisterType<GenericClass<SampleClass>>().AsSingleton();
            GenericClass<EmptyClass> genericClass1 = null;
            GenericClass<SampleClass> genericClass2 = null;

            var thread1 = new Thread(() => { genericClass1 = c.Resolve<GenericClass<EmptyClass>>(); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { genericClass2 = c.Resolve<GenericClass<SampleClass>>(); });
            thread2.Start();
            thread2.Join();

            Assert.AreNotEqual(genericClass1, genericClass2);
            Assert.AreNotEqual(genericClass1.GetType(), genericClass2.GetType());
            Assert.AreEqual(genericClass1.NestedClass, genericClass2.NestedClass.EmptyClass);
            Assert.AreEqual(genericClass1.NestedClass.GetType(), genericClass2.NestedClass.EmptyClass.GetType());
        }
    }
}