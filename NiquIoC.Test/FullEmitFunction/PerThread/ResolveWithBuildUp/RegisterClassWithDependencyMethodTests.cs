using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Test.Model;

namespace NiquIoC.Test.FullEmitFunction.PerThread.ResolveWithBuildUp
{
    [TestClass]
    public class RegisterClassWithDependencyMethodTests
    {
        [TestMethod]
        public void RegisterClassWithDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithClassDependencyMethod>().AsPerThread();

            var sampleClass = c.Resolve<SampleClassWithClassDependencyMethod>(ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterClassWithoutDependencyMethod_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsPerThread();
            c.RegisterType<SampleClassWithoutClassDependencyMethod>().AsPerThread();
            SampleClassWithoutClassDependencyMethod sampleClass = null;
            Exception exception = null;

            var thread = new Thread(() =>
            {
                try
                {
                    sampleClass = c.Resolve<SampleClassWithoutClassDependencyMethod>(ResolveKind.FullEmitFunction);
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