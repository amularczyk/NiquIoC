using System;
using System.Reflection.Emit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Helpers;

namespace NiquIoC.Test
{
    [TestClass]
    public class EmitIntOntoStackTests
    {
        [TestMethod]
        public void Emit_0_OntoStack_Success()
        {
            var value = 0;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }

        [TestMethod]
        public void Emit_1_OntoStack_Success()
        {
            var value = 1;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }

        [TestMethod]
        public void Emit_2_OntoStack_Success()
        {
            var value = 2;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }

        [TestMethod]
        public void Emit_3_OntoStack_Success()
        {
            var value = 3;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }

        [TestMethod]
        public void Emit_4_OntoStack_Success()
        {
            var value = 4;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }

        [TestMethod]
        public void Emit_5_OntoStack_Success()
        {
            var value = 5;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }

        [TestMethod]
        public void Emit_6_OntoStack_Success()
        {
            var value = 6;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }

        [TestMethod]
        public void Emit_7_OntoStack_Success()
        {
            var value = 7;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }

        [TestMethod]
        public void Emit_8_OntoStack_Success()
        {
            var value = 8;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }

        [TestMethod]
        public void Emit_9_OntoStack_Success()
        {
            var value = 9;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }

        [TestMethod]
        public void Emit_127_OntoStack_Success()
        {
            var value = 127;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }

        [TestMethod]
        public void Emit_128_OntoStack_Success()
        {
            var value = 128;
            var dm = new DynamicMethod("Create", typeof(int), Type.EmptyTypes, true);
            var ilgen = dm.GetILGenerator();

            EmitHelper.EmitIntOntoStack(ilgen, value);
            ilgen.Emit(OpCodes.Ret);
            var result = dm.Invoke(null, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, value);
        }
    }
}