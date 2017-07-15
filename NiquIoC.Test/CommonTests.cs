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
        public void Calling_Resolve_Without_Parameter_When_Container_Without_ResolveKind_Fail()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();

            var emptyClass = c.Resolve<EmptyClass>();

            Assert.IsNull(emptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingResolveKindException))]
        public void Calling_BuildUp_Without_Parameter_When_Container_Without_ResolveKind_Fail()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();

            c.BuildUp(emptyClass);
        }

        [TestMethod]
        public void Calling_Resolve_Without_Parameter_When_Container_With_ResolveKind_Success()
        {
            var c = new Container(ResolveKind.PartialEmitFunction);
            c.RegisterType<EmptyClass>();

            var emptyClass = c.Resolve<EmptyClass>();

            Assert.IsNotNull(emptyClass);
        }

        [TestMethod]
        public void Calling_BuildUp_Without_Parameter_When_Container_With_ResolveKind_Success()
        {
            var c = new Container(ResolveKind.PartialEmitFunction);
            var emptyClass = new EmptyClass();

            c.BuildUp(emptyClass);

            Assert.IsNotNull(emptyClass);
        }
    }
}