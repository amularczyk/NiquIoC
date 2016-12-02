using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.PartialEmitFunction.PerThread.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForInterfaceWithDependencyConstrutorTests
    {
        [TestMethod]
        public void RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameterWithDependencyConstrutor>().AsPerThread();
            ISampleClassWithInterfaceAsParameter sampleClass = null;


            var thread = new Thread(() => { sampleClass = c.Resolve<ISampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();
            

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>().AsPerThread();
            ISampleClassWithInterfaceAsParameter sampleClass = null;
            Exception exception = null;


            var thread = new Thread(() =>
            {
                try
                {
                    sampleClass = c.Resolve<ISampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction);
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
        public void RegisteredInterfaceAsClassWithNestedInterfaceAsParameterWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameterWithDependencyConstrutor>().AsPerThread();
            c.RegisterType<ISampleClassISampleClassWithInterfaceAsParameter, SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>().AsPerThread();
            ISampleClassISampleClassWithInterfaceAsParameter sampleClass = null;


            var thread = new Thread(() => { sampleClass = c.Resolve<ISampleClassISampleClassWithInterfaceAsParameter>(ResolveKind.PartialEmitFunction); });
            thread.Start();
            thread.Join();
            

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter.EmptyClass);
        }
    }
}