using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.PerThread
{
    [TestClass]
    public class RegisterTypeForClassTests
    {
        [TestMethod]
        public void RegisterClassWithConstructorWithoutParameters_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            EmptyClass emptyClass = null;


            var thread = new Thread(container => { emptyClass = c.Resolve<EmptyClass>(ResolveKind.FullEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(emptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException),
            "Type NiquIoC.Test.Model.EmptyClass has not been registered.")]
        public void InternalClassNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClass>().AsPerThread();
            SampleClass sampleClass = null;
            Exception exception = null;


            var thread = new Thread(() =>
            {
                try
                {
                    sampleClass = c.Resolve<SampleClass>(ResolveKind.FullEmitFunction);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });
            thread.Start();
            thread.Join();

            if (exception != null)
            {
                throw exception;
            }


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type System.String has not been registered.")]
        public void InternalStringTypeNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithStringType>().AsPerThread();
            SampleClassWithStringType sampleClassWithSimpleType = null;
            Exception exception = null;


            var thread = new Thread(() =>
            {
                try
                {
                    sampleClassWithSimpleType = c.Resolve<SampleClassWithStringType>(ResolveKind.FullEmitFunction);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });
            thread.Start();
            thread.Join();

            if (exception != null)
            {
                throw exception;
            }


            Assert.IsNull(sampleClassWithSimpleType);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException), "Type System.Int32 has not been registered.")]
        public void InternalIntTypeNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClassWithIntType>().AsPerThread();
            SampleClassWithIntType sampleClassWithSimpleType = null;
            Exception exception = null;


            var thread = new Thread(() =>
            {
                try
                {
                    sampleClassWithSimpleType = c.Resolve<SampleClassWithIntType>(ResolveKind.FullEmitFunction);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });
            thread.Start();
            thread.Join();

            if (exception != null)
            {
                throw exception;
            }


            Assert.IsNull(sampleClassWithSimpleType);
        }

        [TestMethod]
        public void RegisterClassWithConstructorWithParameter_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            SampleClass sampleClass = null;


            var thread =
                new Thread(container => { sampleClass = c.Resolve<SampleClass>(ResolveKind.FullEmitFunction); });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException),
            "Appeared cycle when resolving constructor for object of type NiquIoC.Test.Model.FirstClassWithCycleInConstructor")]
        public void RegisterClassWithCycleInConstructor_Fail()
        {
            var c = new Container();
            c.RegisterType<SecondClassWithCycleInConstructor>().AsPerThread();
            c.RegisterType<FirstClassWithCycleInConstructor>().AsPerThread();
            FirstClassWithCycleInConstructor sampleClass = null;
            Exception exception = null;


            var thread = new Thread(() =>
            {
                try
                {
                    sampleClass = c.Resolve<FirstClassWithCycleInConstructor>(ResolveKind.FullEmitFunction);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });
            thread.Start();
            thread.Join();

            if (exception != null)
            {
                throw exception;
            }


            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void SameThread_RegisterClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            SampleClass sampleClass1 = null;
            SampleClass sampleClass2 = null;


            var thread = new Thread(() =>
            {
                sampleClass1 = c.Resolve<SampleClass>(ResolveKind.FullEmitFunction);
                sampleClass2 = c.Resolve<SampleClass>(ResolveKind.FullEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreads_RegisterClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            SampleClass sampleClass1 = null;
            SampleClass sampleClass2 = null;


            var thread1 = new Thread(container =>
            {
                sampleClass1 = c.Resolve<SampleClass>(ResolveKind.FullEmitFunction);
            });
            var thread2 = new Thread(container =>
            {
                sampleClass2 = c.Resolve<SampleClass>(ResolveKind.FullEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void DifferentThreadsAndSameThread_RegisterClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClass>().AsPerThread();
            SampleClass sampleClass11 = null;
            SampleClass sampleClass12 = null;
            SampleClass sampleClass21 = null;
            SampleClass sampleClass22 = null;


            var thread1 = new Thread(() =>
            {
                sampleClass11 = c.Resolve<SampleClass>(ResolveKind.FullEmitFunction);
                sampleClass12 = c.Resolve<SampleClass>(ResolveKind.FullEmitFunction);
            });
            var thread2 = new Thread(() =>
            {
                sampleClass21 = c.Resolve<SampleClass>(ResolveKind.FullEmitFunction);
                sampleClass22 = c.Resolve<SampleClass>(ResolveKind.FullEmitFunction);
            });
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();


            Assert.IsNotNull(sampleClass11);
            Assert.IsNotNull(sampleClass11.EmptyClass);
            Assert.IsNotNull(sampleClass12);
            Assert.IsNotNull(sampleClass12.EmptyClass);
            Assert.IsNotNull(sampleClass21);
            Assert.IsNotNull(sampleClass21.EmptyClass);
            Assert.IsNotNull(sampleClass22);
            Assert.IsNotNull(sampleClass22.EmptyClass);

            Assert.AreEqual(sampleClass11, sampleClass12);
            Assert.AreEqual(sampleClass11.EmptyClass, sampleClass12.EmptyClass);

            Assert.AreNotEqual(sampleClass11, sampleClass21);
            Assert.AreNotEqual(sampleClass11.EmptyClass, sampleClass21.EmptyClass);

            Assert.AreEqual(sampleClass21, sampleClass22);
            Assert.AreEqual(sampleClass21.EmptyClass, sampleClass22.EmptyClass);
        }
    }
}