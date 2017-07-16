using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.PerThread.DependencyConstrutor
{
    [TestClass]
    public class RegisterTypeForClassWithDependencyConstrutorWithInterfaceTests
    {
        [TestMethod]
        public void
            RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>().AsPerThread();
            SampleClassWithInterfaceAsParameterWithDependencyConstrutor sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<SampleClassWithInterfaceAsParameterWithDependencyConstrutor>(ResolveKind
                        .FullEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(NoProperConstructorException))]
        public void
            RegisteredInterfaceAsClassWithInterfaceAsParameterAndWithTwoConstructorsWithAttributeDependencyConstrutor_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>().AsPerThread();
            SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor sampleClass = null;
            Exception exception = null;


            var thread = new Thread(() =>
            {
                try
                {
                    sampleClass =
                        c.Resolve<SampleClassWithInterfaceAsParameterWithTwoDependencyConstrutor>(ResolveKind
                            .FullEmitFunction);
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
        public void
            RegisterClassWithNestedInterfaceAsParameterWithInterfaceAsParameterAndWithConstructorWithAttributeDependencyConstrutor_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c
                .RegisterType<ISampleClassWithInterfaceAsParameter,
                    SampleClassWithInterfaceAsParameterWithDependencyConstrutor>()
                .AsPerThread();
            c.RegisterType<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>().AsPerThread();
            SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor sampleClass = null;


            var thread = new Thread(container =>
            {
                sampleClass =
                    c.Resolve<SampleClassWithNestedInterfaceAsParameterWithDependencyConstrutor>(ResolveKind
                        .FullEmitFunction);
            });
            thread.Start();
            thread.Join();


            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter.EmptyClass);
        }
    }
}