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
        [ExpectedException(typeof(ResolveKindNotImplementedException))]
        public void ClassNotRegistered_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();

            var emptyClass = c.Resolve<EmptyClass>((ResolveKind)3);

            Assert.IsNull(emptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingResolveKindException))]
        public void Resolve_Without_Parameter_When_Container_Without_ResolveKind_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();

            var emptyClass = c.Resolve<EmptyClass>();

            Assert.IsNull(emptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingResolveKindException))]
        public void BuildUp_Without_Parameter_When_Container_Without_ResolveKind_Fail()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();

            c.BuildUp(emptyClass);
        }
    }
}