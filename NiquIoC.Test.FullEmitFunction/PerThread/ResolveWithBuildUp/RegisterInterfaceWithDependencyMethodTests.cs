using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.PerThread.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterInterfaceWithDependencyMethodTests
    {
        [TestMethod]
        public void RegisterInterfaceAsClassWithDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>().AsPerThread();

            var sampleClass = c.Resolve<ISampleClassWithInterfaceMethod>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterInterfaceAsClassWithoutDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>().AsPerThread();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithoutInterfaceDependencyMethod>()
                .AsPerThread();
            ISampleClassWithInterfaceMethod sampleClass = null;
            Exception exception = null;


            var thread = new Thread(() =>
            {
                try
                {
                    sampleClass = c.Resolve<ISampleClassWithInterfaceMethod>(ResolveKind.FullEmitFunction);
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


            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }
    }
}