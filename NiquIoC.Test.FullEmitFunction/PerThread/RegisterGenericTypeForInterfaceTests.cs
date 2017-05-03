using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.PerThread
{
    [TestClass]
    public class RegisterGenericTypeForInterfaceTests
    {
        [TestMethod]
        public void RegisterSimpleGenericClass_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<IGenericClass<IEmptyClass>, GenericClass<IEmptyClass>>().AsPerThread();
            IGenericClass<IEmptyClass> genericClass = null;

            var thread = new Thread(() => { genericClass = c.Resolve<IGenericClass<IEmptyClass>>(ResolveKind.FullEmitFunction); });
            thread.Start();
            thread.Join();

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithClassWithNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerThread();
            c.RegisterType<IGenericClass<ISampleClassWithInterfaceAsParameter>, GenericClass<ISampleClassWithInterfaceAsParameter>>().AsPerThread();
            IGenericClass<ISampleClassWithInterfaceAsParameter> genericClass = null;

            var thread = new Thread(() => { genericClass = c.Resolve<IGenericClass<ISampleClassWithInterfaceAsParameter>>(ResolveKind.FullEmitFunction); });
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
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerThread();
            c.RegisterType<IGenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>,
                GenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>>().AsPerThread();
            IGenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter> genericClass = null;

            var thread = new Thread(() => { genericClass = c.Resolve<IGenericClassWithManyParameters<IEmptyClass, ISampleClassWithInterfaceAsParameter>>(ResolveKind.FullEmitFunction); });
            thread.Start();
            thread.Join();

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass1);
            Assert.IsNotNull(genericClass.NestedClass2);
            Assert.IsNotNull(genericClass.NestedClass2.EmptyClass);
            Assert.AreEqual(genericClass.NestedClass1, genericClass.NestedClass2.EmptyClass);
        }

        [TestMethod]
        public void SameThread_RegisterManyGenericClasses_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerThread();
            c.RegisterType<IGenericClass<IEmptyClass>, GenericClass<IEmptyClass>>().AsPerThread();
            c.RegisterType<IGenericClass<ISampleClassWithInterfaceAsParameter>, GenericClass<ISampleClassWithInterfaceAsParameter>>().AsPerThread();
            IGenericClass<IEmptyClass> genericClass1 = null;
            IGenericClass<ISampleClassWithInterfaceAsParameter> genericClass2 = null;
            
            var thread = new Thread(() =>
            {
                genericClass1 = c.Resolve<IGenericClass<IEmptyClass>>(ResolveKind.FullEmitFunction);
                genericClass2 = c.Resolve<IGenericClass<ISampleClassWithInterfaceAsParameter>>(ResolveKind.FullEmitFunction);
            });
            thread.Start();
            thread.Join();

            Assert.AreNotEqual(genericClass1, genericClass2);
            Assert.AreNotEqual(genericClass1.GetType(), genericClass2.GetType());
            Assert.AreEqual(genericClass1.NestedClass, genericClass2.NestedClass.EmptyClass);
            Assert.AreEqual(genericClass1.NestedClass.GetType(), genericClass2.NestedClass.EmptyClass.GetType());
        }

        [TestMethod]
        public void DifferentThreads_RegisterManyGenericClasses_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>().AsPerThread();
            c.RegisterType<IGenericClass<IEmptyClass>, GenericClass<IEmptyClass>>().AsPerThread();
            c.RegisterType<IGenericClass<ISampleClassWithInterfaceAsParameter>, GenericClass<ISampleClassWithInterfaceAsParameter>>().AsPerThread();
            IGenericClass<IEmptyClass> genericClass1 = null;
            IGenericClass<ISampleClassWithInterfaceAsParameter> genericClass2 = null;

            var thread1 = new Thread(() => { genericClass1 = c.Resolve<IGenericClass<IEmptyClass>>(ResolveKind.FullEmitFunction); });
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => { genericClass2 = c.Resolve<IGenericClass<ISampleClassWithInterfaceAsParameter>>(ResolveKind.FullEmitFunction); });
            thread2.Start();
            thread2.Join();

            Assert.AreNotEqual(genericClass1, genericClass2);
            Assert.AreNotEqual(genericClass1.GetType(), genericClass2.GetType());
            Assert.AreNotEqual(genericClass1.NestedClass, genericClass2.NestedClass.EmptyClass);
            Assert.AreEqual(genericClass1.NestedClass.GetType(), genericClass2.NestedClass.EmptyClass.GetType());
        }
    }
}