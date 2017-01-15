using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests
{
    public static class CheckHelper
    {
        public static void Check(ITestA testA, bool singleton)
        {
            Assert.IsNotNull(testA);

            Assert.IsNotNull(testA.TestA9);
            Assert.IsNotNull(testA.TestA8);
            Assert.IsNotNull(testA.TestA7);
            Assert.IsNotNull(testA.TestA6);
            Assert.IsNotNull(testA.TestA5);
            Assert.IsNotNull(testA.TestA4);
            Assert.IsNotNull(testA.TestA3);
            Assert.IsNotNull(testA.TestA2);
            Assert.IsNotNull(testA.TestA1);
            Assert.IsNotNull(testA.TestA0);

            Assert.IsNotNull(testA.TestA9.TestA8);
            Assert.IsNotNull(testA.TestA9.TestA7);
            Assert.IsNotNull(testA.TestA9.TestA6);
            Assert.IsNotNull(testA.TestA9.TestA5);
            Assert.IsNotNull(testA.TestA9.TestA4);
            Assert.IsNotNull(testA.TestA9.TestA3);
            Assert.IsNotNull(testA.TestA9.TestA2);
            Assert.IsNotNull(testA.TestA9.TestA1);
            Assert.IsNotNull(testA.TestA9.TestA0);

            if (singleton)
            {
                Assert.AreEqual(testA.TestA8, testA.TestA9.TestA8);
                Assert.AreEqual(testA.TestA7, testA.TestA9.TestA7);
                Assert.AreEqual(testA.TestA6, testA.TestA9.TestA6);
                Assert.AreEqual(testA.TestA5, testA.TestA9.TestA5);
                Assert.AreEqual(testA.TestA4, testA.TestA9.TestA4);
                Assert.AreEqual(testA.TestA3, testA.TestA9.TestA3);
                Assert.AreEqual(testA.TestA2, testA.TestA9.TestA2);
                Assert.AreEqual(testA.TestA1, testA.TestA9.TestA1);
                Assert.AreEqual(testA.TestA0, testA.TestA9.TestA0);
            }
            else
            {
                Assert.AreNotEqual(testA.TestA8, testA.TestA9.TestA8);
                Assert.AreNotEqual(testA.TestA7, testA.TestA9.TestA7);
                Assert.AreNotEqual(testA.TestA6, testA.TestA9.TestA6);
                Assert.AreNotEqual(testA.TestA5, testA.TestA9.TestA5);
                Assert.AreNotEqual(testA.TestA4, testA.TestA9.TestA4);
                Assert.AreNotEqual(testA.TestA3, testA.TestA9.TestA3);
                Assert.AreNotEqual(testA.TestA2, testA.TestA9.TestA2);
                Assert.AreNotEqual(testA.TestA1, testA.TestA9.TestA1);
                Assert.AreNotEqual(testA.TestA0, testA.TestA9.TestA0);
            }

            Assert.IsNotNull(testA.TestA9.TestA8.TestA7);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA6);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA5);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA4);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA3);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA2);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA1);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA0);

            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA5);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA4);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA3);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA2);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA1);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA0);

            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA4);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA3);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA2);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA1);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA0);

            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA3);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA2);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA1);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA0);

            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA2);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA1);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA0);

            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA1);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA0);

            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA1);
            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA0);

            Assert.IsNotNull(testA.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA1.TestA0);
        }

        public static void Check(ITestA testA1, ITestA testA2, bool singleton)
        {
            Assert.AreEqual(testA1.Equals(testA2), singleton);

            Assert.AreEqual(testA1.TestA9.Equals(testA2.TestA9), singleton);
            Assert.AreEqual(testA1.TestA8.Equals(testA2.TestA8), singleton);
            Assert.AreEqual(testA1.TestA7.Equals(testA2.TestA7), singleton);
            Assert.AreEqual(testA1.TestA6.Equals(testA2.TestA6), singleton);
            Assert.AreEqual(testA1.TestA5.Equals(testA2.TestA5), singleton);
            Assert.AreEqual(testA1.TestA4.Equals(testA2.TestA4), singleton);
            Assert.AreEqual(testA1.TestA3.Equals(testA2.TestA3), singleton);
            Assert.AreEqual(testA1.TestA2.Equals(testA2.TestA2), singleton);
            Assert.AreEqual(testA1.TestA1.Equals(testA2.TestA1), singleton);
            Assert.AreEqual(testA1.TestA0.Equals(testA2.TestA0), singleton);

            Assert.AreEqual(testA1.TestA9.TestA8.Equals(testA2.TestA9.TestA8), singleton);
            Assert.AreEqual(testA1.TestA9.TestA7.Equals(testA2.TestA9.TestA7), singleton);
            Assert.AreEqual(testA1.TestA9.TestA6.Equals(testA2.TestA9.TestA6), singleton);
            Assert.AreEqual(testA1.TestA9.TestA5.Equals(testA2.TestA9.TestA5), singleton);
            Assert.AreEqual(testA1.TestA9.TestA4.Equals(testA2.TestA9.TestA4), singleton);
            Assert.AreEqual(testA1.TestA9.TestA3.Equals(testA2.TestA9.TestA3), singleton);
            Assert.AreEqual(testA1.TestA9.TestA2.Equals(testA2.TestA9.TestA2), singleton);
            Assert.AreEqual(testA1.TestA9.TestA1.Equals(testA2.TestA9.TestA1), singleton);
            Assert.AreEqual(testA1.TestA9.TestA0.Equals(testA2.TestA9.TestA0), singleton);
            
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.Equals(testA2.TestA9.TestA8.TestA7), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA6.Equals(testA2.TestA9.TestA8.TestA6), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA5.Equals(testA2.TestA9.TestA8.TestA5), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA4.Equals(testA2.TestA9.TestA8.TestA4), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA3.Equals(testA2.TestA9.TestA8.TestA3), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA2.Equals(testA2.TestA9.TestA8.TestA2), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA1.Equals(testA2.TestA9.TestA8.TestA1), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA0.Equals(testA2.TestA9.TestA8.TestA0), singleton);

            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.Equals(testA2.TestA9.TestA8.TestA7.TestA6), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA5.Equals(testA2.TestA9.TestA8.TestA7.TestA5), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA4.Equals(testA2.TestA9.TestA8.TestA7.TestA4), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA3.Equals(testA2.TestA9.TestA8.TestA7.TestA3), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA2.Equals(testA2.TestA9.TestA8.TestA7.TestA2), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA1.Equals(testA2.TestA9.TestA8.TestA7.TestA1), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA0.Equals(testA2.TestA9.TestA8.TestA7.TestA0), singleton);

            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA4.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA4), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA3.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA3), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA2.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA2), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA1.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA1), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA0.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA0), singleton);

            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA3.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA3), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA2.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA2), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA1.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA1), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA0.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA0), singleton);

            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA2.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA2), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA1.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA1), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA0.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA0), singleton);

            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA1.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA1), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA0.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA0), singleton);

            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA1.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA1), singleton);
            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA0.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA0), singleton);

            Assert.AreEqual(testA1.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA1.TestA0.Equals(testA2.TestA9.TestA8.TestA7.TestA6.TestA5.TestA4.TestA3.TestA2.TestA1.TestA0), singleton);
        }

        public static void Check(ITestB testB, bool singleton)
        {
            Assert.IsNotNull(testB);

            Assert.IsNotNull(testB.TestB49);
            Assert.IsNotNull(testB.TestB48);
            Assert.IsNotNull(testB.TestB47);
            Assert.IsNotNull(testB.TestB46);
            Assert.IsNotNull(testB.TestB45);
            Assert.IsNotNull(testB.TestB44);
            Assert.IsNotNull(testB.TestB43);
            Assert.IsNotNull(testB.TestB42);
            Assert.IsNotNull(testB.TestB41);
            Assert.IsNotNull(testB.TestB40);

            Assert.IsNotNull(testB.TestB49.TestB39);
            Assert.IsNotNull(testB.TestB49.TestB38);
            Assert.IsNotNull(testB.TestB49.TestB37);
            Assert.IsNotNull(testB.TestB49.TestB36);
            Assert.IsNotNull(testB.TestB49.TestB35);
            Assert.IsNotNull(testB.TestB49.TestB34);
            Assert.IsNotNull(testB.TestB49.TestB33);
            Assert.IsNotNull(testB.TestB49.TestB32);
            Assert.IsNotNull(testB.TestB49.TestB31);
            Assert.IsNotNull(testB.TestB49.TestB30);

            if (singleton)
            {
                Assert.AreEqual(testB.TestB49.TestB39, testB.TestB48.TestB39);
                Assert.AreEqual(testB.TestB49.TestB38, testB.TestB48.TestB38);
                Assert.AreEqual(testB.TestB49.TestB37, testB.TestB48.TestB37);
                Assert.AreEqual(testB.TestB49.TestB36, testB.TestB48.TestB36);
                Assert.AreEqual(testB.TestB49.TestB35, testB.TestB48.TestB35);
                Assert.AreEqual(testB.TestB49.TestB34, testB.TestB48.TestB34);
                Assert.AreEqual(testB.TestB49.TestB33, testB.TestB48.TestB33);
                Assert.AreEqual(testB.TestB49.TestB32, testB.TestB48.TestB32);
                Assert.AreEqual(testB.TestB49.TestB31, testB.TestB48.TestB31);
                Assert.AreEqual(testB.TestB49.TestB30, testB.TestB48.TestB30);
            }
            else
            {
                Assert.AreNotEqual(testB.TestB49.TestB39, testB.TestB48.TestB39);
                Assert.AreNotEqual(testB.TestB49.TestB38, testB.TestB48.TestB38);
                Assert.AreNotEqual(testB.TestB49.TestB37, testB.TestB48.TestB37);
                Assert.AreNotEqual(testB.TestB49.TestB36, testB.TestB48.TestB36);
                Assert.AreNotEqual(testB.TestB49.TestB35, testB.TestB48.TestB35);
                Assert.AreNotEqual(testB.TestB49.TestB34, testB.TestB48.TestB34);
                Assert.AreNotEqual(testB.TestB49.TestB33, testB.TestB48.TestB33);
                Assert.AreNotEqual(testB.TestB49.TestB32, testB.TestB48.TestB32);
                Assert.AreNotEqual(testB.TestB49.TestB31, testB.TestB48.TestB31);
                Assert.AreNotEqual(testB.TestB49.TestB30, testB.TestB48.TestB30);
            }

            Assert.IsNotNull(testB.TestB49.TestB39.TestB29);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB28);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB27);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB26);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB25);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB24);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB23);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB22);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB21);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB20);

            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB19);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB18);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB17);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB16);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB15);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB14);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB13);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB12);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB11);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB10);

            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB19.TestB09);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB19.TestB08);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB19.TestB07);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB19.TestB06);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB19.TestB05);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB19.TestB04);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB19.TestB03);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB19.TestB02);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB19.TestB01);
            Assert.IsNotNull(testB.TestB49.TestB39.TestB29.TestB19.TestB00);
        }

        public static void Check(ITestB testB1, ITestB testB2, bool singleton)
        {
            Assert.AreEqual(testB1.Equals(testB2), singleton);

            Assert.AreEqual(testB1.TestB49.Equals(testB2.TestB49), singleton);
            Assert.AreEqual(testB1.TestB48.Equals(testB2.TestB48), singleton);
            Assert.AreEqual(testB1.TestB47.Equals(testB2.TestB47), singleton);
            Assert.AreEqual(testB1.TestB46.Equals(testB2.TestB46), singleton);
            Assert.AreEqual(testB1.TestB45.Equals(testB2.TestB45), singleton);
            Assert.AreEqual(testB1.TestB44.Equals(testB2.TestB44), singleton);
            Assert.AreEqual(testB1.TestB43.Equals(testB2.TestB43), singleton);
            Assert.AreEqual(testB1.TestB42.Equals(testB2.TestB42), singleton);
            Assert.AreEqual(testB1.TestB41.Equals(testB2.TestB41), singleton);
            Assert.AreEqual(testB1.TestB40.Equals(testB2.TestB40), singleton);

            Assert.AreEqual(testB1.TestB49.TestB39.Equals(testB2.TestB49.TestB39), singleton);
            Assert.AreEqual(testB1.TestB49.TestB38.Equals(testB2.TestB49.TestB38), singleton);
            Assert.AreEqual(testB1.TestB49.TestB37.Equals(testB2.TestB49.TestB37), singleton);
            Assert.AreEqual(testB1.TestB49.TestB36.Equals(testB2.TestB49.TestB36), singleton);
            Assert.AreEqual(testB1.TestB49.TestB35.Equals(testB2.TestB49.TestB35), singleton);
            Assert.AreEqual(testB1.TestB49.TestB34.Equals(testB2.TestB49.TestB34), singleton);
            Assert.AreEqual(testB1.TestB49.TestB33.Equals(testB2.TestB49.TestB33), singleton);
            Assert.AreEqual(testB1.TestB49.TestB32.Equals(testB2.TestB49.TestB32), singleton);
            Assert.AreEqual(testB1.TestB49.TestB31.Equals(testB2.TestB49.TestB31), singleton);
            Assert.AreEqual(testB1.TestB49.TestB30.Equals(testB2.TestB49.TestB30), singleton);
            
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.Equals(testB2.TestB49.TestB39.TestB29), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB28.Equals(testB2.TestB49.TestB39.TestB28), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB27.Equals(testB2.TestB49.TestB39.TestB27), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB26.Equals(testB2.TestB49.TestB39.TestB26), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB25.Equals(testB2.TestB49.TestB39.TestB25), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB24.Equals(testB2.TestB49.TestB39.TestB24), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB23.Equals(testB2.TestB49.TestB39.TestB23), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB22.Equals(testB2.TestB49.TestB39.TestB22), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB21.Equals(testB2.TestB49.TestB39.TestB21), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB20.Equals(testB2.TestB49.TestB39.TestB20), singleton);

            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB19.Equals(testB2.TestB49.TestB39.TestB29.TestB19), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB18.Equals(testB2.TestB49.TestB39.TestB29.TestB18), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB17.Equals(testB2.TestB49.TestB39.TestB29.TestB17), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB16.Equals(testB2.TestB49.TestB39.TestB29.TestB16), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB15.Equals(testB2.TestB49.TestB39.TestB29.TestB15), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB14.Equals(testB2.TestB49.TestB39.TestB29.TestB14), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB13.Equals(testB2.TestB49.TestB39.TestB29.TestB13), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB12.Equals(testB2.TestB49.TestB39.TestB29.TestB12), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB11.Equals(testB2.TestB49.TestB39.TestB29.TestB11), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB10.Equals(testB2.TestB49.TestB39.TestB29.TestB10), singleton);

            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB19.TestB09.Equals(testB2.TestB49.TestB39.TestB29.TestB19.TestB09), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB19.TestB08.Equals(testB2.TestB49.TestB39.TestB29.TestB19.TestB08), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB19.TestB07.Equals(testB2.TestB49.TestB39.TestB29.TestB19.TestB07), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB19.TestB06.Equals(testB2.TestB49.TestB39.TestB29.TestB19.TestB06), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB19.TestB05.Equals(testB2.TestB49.TestB39.TestB29.TestB19.TestB05), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB19.TestB04.Equals(testB2.TestB49.TestB39.TestB29.TestB19.TestB04), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB19.TestB03.Equals(testB2.TestB49.TestB39.TestB29.TestB19.TestB03), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB19.TestB02.Equals(testB2.TestB49.TestB39.TestB29.TestB19.TestB02), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB19.TestB01.Equals(testB2.TestB49.TestB39.TestB29.TestB19.TestB01), singleton);
            Assert.AreEqual(testB1.TestB49.TestB39.TestB29.TestB19.TestB00.Equals(testB2.TestB49.TestB39.TestB29.TestB19.TestB00), singleton);
        }

        public static void Check(ITestC testC, bool singleton)
        {
            Assert.IsNotNull(testC);

            Assert.IsNotNull(testC.TestCa10);
            Assert.IsNotNull(testC.TestCb10);
            Assert.IsNotNull(testC.TestCc10);

            Assert.IsNotNull(testC.TestCa10.TestCa9);
            Assert.IsNotNull(testC.TestCa10.TestCa8);
            Assert.IsNotNull(testC.TestCa10.TestCa7);
            Assert.IsNotNull(testC.TestCa10.TestCa6);
            Assert.IsNotNull(testC.TestCa10.TestCa5);
            Assert.IsNotNull(testC.TestCa10.TestCa4);
            Assert.IsNotNull(testC.TestCa10.TestCa3);
            Assert.IsNotNull(testC.TestCa10.TestCa2);
            Assert.IsNotNull(testC.TestCa10.TestCa1);
            Assert.IsNotNull(testC.TestCa10.TestCa0);

            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa7);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa6);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa5);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa4);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa3);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa2);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa1);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa0);

            if (singleton)
            {
                Assert.AreEqual(testC.TestCa10.TestCa8, testC.TestCa10.TestCa9.TestCa8);
                Assert.AreEqual(testC.TestCa10.TestCa7, testC.TestCa10.TestCa9.TestCa7);
                Assert.AreEqual(testC.TestCa10.TestCa6, testC.TestCa10.TestCa9.TestCa6);
                Assert.AreEqual(testC.TestCa10.TestCa5, testC.TestCa10.TestCa9.TestCa5);
                Assert.AreEqual(testC.TestCa10.TestCa4, testC.TestCa10.TestCa9.TestCa4);
                Assert.AreEqual(testC.TestCa10.TestCa3, testC.TestCa10.TestCa9.TestCa3);
                Assert.AreEqual(testC.TestCa10.TestCa2, testC.TestCa10.TestCa9.TestCa2);
                Assert.AreEqual(testC.TestCa10.TestCa1, testC.TestCa10.TestCa9.TestCa1);
                Assert.AreEqual(testC.TestCa10.TestCa0, testC.TestCa10.TestCa9.TestCa0);
            }
            else
            {
                Assert.AreNotEqual(testC.TestCa10.TestCa8, testC.TestCa10.TestCa9.TestCa8);
                Assert.AreNotEqual(testC.TestCa10.TestCa7, testC.TestCa10.TestCa9.TestCa7);
                Assert.AreNotEqual(testC.TestCa10.TestCa6, testC.TestCa10.TestCa9.TestCa6);
                Assert.AreNotEqual(testC.TestCa10.TestCa5, testC.TestCa10.TestCa9.TestCa5);
                Assert.AreNotEqual(testC.TestCa10.TestCa4, testC.TestCa10.TestCa9.TestCa4);
                Assert.AreNotEqual(testC.TestCa10.TestCa3, testC.TestCa10.TestCa9.TestCa3);
                Assert.AreNotEqual(testC.TestCa10.TestCa2, testC.TestCa10.TestCa9.TestCa2);
                Assert.AreNotEqual(testC.TestCa10.TestCa1, testC.TestCa10.TestCa9.TestCa1);
                Assert.AreNotEqual(testC.TestCa10.TestCa0, testC.TestCa10.TestCa9.TestCa0);
            }

            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa6);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa5);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa4);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa3);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa2);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa1);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa0);

            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa5);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa4);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa3);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa2);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa1);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa0);

            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa4);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa3);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa2);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa1);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa0);

            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa3);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa2);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa1);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa0);

            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa2);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa1);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa0);

            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa1);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa0);

            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa1);
            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa0);

            Assert.IsNotNull(testC.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa1.TestCa0);
        }

        public static void Check(ITestC testC1, ITestC testC2, bool singleton)
        {
            Assert.AreEqual(testC1.Equals(testC2), singleton);

            Assert.AreEqual(testC1.TestCa10.Equals(testC2.TestCa10), singleton);
            Assert.AreEqual(testC1.TestCb10.Equals(testC2.TestCb10), singleton);
            Assert.AreEqual(testC1.TestCc10.Equals(testC2.TestCc10), singleton);

            Assert.AreEqual(testC1.TestCa10.TestCa9.Equals(testC2.TestCa10.TestCa9), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa8.Equals(testC2.TestCa10.TestCa8), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa7.Equals(testC2.TestCa10.TestCa7), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa6.Equals(testC2.TestCa10.TestCa6), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa5.Equals(testC2.TestCa10.TestCa5), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa4.Equals(testC2.TestCa10.TestCa4), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa3.Equals(testC2.TestCa10.TestCa3), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa2.Equals(testC2.TestCa10.TestCa2), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa1.Equals(testC2.TestCa10.TestCa1), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa0.Equals(testC2.TestCa10.TestCa0), singleton);

            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.Equals(testC2.TestCa10.TestCa9.TestCa8), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa7.Equals(testC2.TestCa10.TestCa9.TestCa7), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa6.Equals(testC2.TestCa10.TestCa9.TestCa6), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa5.Equals(testC2.TestCa10.TestCa9.TestCa5), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa4.Equals(testC2.TestCa10.TestCa9.TestCa4), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa3.Equals(testC2.TestCa10.TestCa9.TestCa3), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa2.Equals(testC2.TestCa10.TestCa9.TestCa2), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa1.Equals(testC2.TestCa10.TestCa9.TestCa1), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa0.Equals(testC2.TestCa10.TestCa9.TestCa0), singleton);
            
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa6.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa6), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa5.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa5), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa4.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa4), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa3.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa3), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa2.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa2), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa1.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa1), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa0.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa0), singleton);

            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa5.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa5), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa4.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa4), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa3.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa3), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa2.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa2), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa1.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa1), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa0.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa0), singleton);

            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa4.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa4), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa3.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa3), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa2.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa2), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa1.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa1), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa0.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa0), singleton);

            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa3.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa3), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa2.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa2), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa1.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa1), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa0.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa0), singleton);

            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa2.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa2), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa1.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa1), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa0.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa0), singleton);

            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa1.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa1), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa0.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa0), singleton);

            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa1.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa1), singleton);
            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa0.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa0), singleton);

            Assert.AreEqual(testC1.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa1.TestCa0.Equals(testC2.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa1.TestCa0), singleton);
        }
    }
}