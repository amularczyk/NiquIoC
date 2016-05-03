using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Helpers;

namespace NiquIoC.Test
{
    [TestClass]
    public class EmitNewIdeaTests
    {
        [TestMethod]
        public void A_Success()
        {
            var ctorDictionary = new Dictionary<Type, ConstructorInfo>();
            ctorDictionary.Add(typeof(A), typeof(A).GetConstructors()[0]);
            var func = EmitTmp.CreateFullObjectFunction(ctorDictionary[typeof(A)], ctorDictionary);
            var result = func.Invoke();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void B_Success()
        {
            var ctorDictionary = new Dictionary<Type, ConstructorInfo>();
            ctorDictionary.Add(typeof(A), typeof(A).GetConstructors()[0]);
            ctorDictionary.Add(typeof(B), typeof(B).GetConstructors()[0]);
            var func = EmitTmp.CreateFullObjectFunction(ctorDictionary[typeof(B)], ctorDictionary);
            var result = func.Invoke();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void C_Success()
        {
            var ctorDictionary = new Dictionary<Type, ConstructorInfo>();
            ctorDictionary.Add(typeof(A), typeof(A).GetConstructors()[0]);
            ctorDictionary.Add(typeof(B), typeof(B).GetConstructors()[0]);
            ctorDictionary.Add(typeof(C), typeof(C).GetConstructors()[0]);
            var func = EmitTmp.CreateFullObjectFunction(ctorDictionary[typeof(C)], ctorDictionary);
            var result = func.Invoke();

            Assert.IsNotNull(result);
        }
    }

    public class A
    {
        public A()
        {
        }
    }

    public class B
    {
        public A A;

        public B(A a)
        {
            A = a;
        }
    }
    public class C
    {
        public A A;
        public B B;
        public C(B b, A a)
        {
            A = a;
            B = b;
        }
    }
}
