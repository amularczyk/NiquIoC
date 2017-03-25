using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Enums;
using NiquIoC.Exceptions;
using NiquIoC.Test.Model;

namespace NiquIoC.Test
{
    [TestClass]
    public class CommonTests
    {
        [TestMethod]
        [ExpectedException(typeof(ResolveKindMissingException))]
        public void ClassNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();

            var sampleClass = c.Resolve<EmptyClass>((ResolveKind)3);

            Assert.IsNull(sampleClass);
        }
    }
}