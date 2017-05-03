using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.PerThread.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForClassWithDependencyConstrutorTests
    {
        [TestMethod]
        public void RegisterClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithDependencyConstrutor>().AsPerThread();
            SampleClassWithDependencyConstrutor sampleClass = null;


            var thread = new Thread(() => { sampleClass = c.Resolve<SampleClassWithDependencyConstrutor>(ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();
            

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void RegisterClassWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithTwoDependencyConstrutor>().AsPerThread();
            SampleClassWithTwoDependencyConstrutor sampleClass = null;
            Exception exception = null;


            var thread = new Thread(() =>
            {
                try
                {
                    sampleClass = c.Resolve<SampleClassWithTwoDependencyConstrutor>(ResolveKind.PartialEmitFunction);
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
        public void RegisterClassWithNestedClassWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithDependencyConstrutor>().AsPerThread();
            c.RegisterType<SampleClassWithNestedClassWithDependencyConstrutor>().AsPerThread();
            SampleClassWithNestedClassWithDependencyConstrutor sampleClass = null;


            var thread = new Thread(() => { sampleClass = c.Resolve<SampleClassWithNestedClassWithDependencyConstrutor>(ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();
            

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor);
            Assert.IsNotNull(sampleClass.SampleClassWithDependencyConstrutor.EmptyClass);
        }
    }
}