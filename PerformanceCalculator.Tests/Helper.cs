using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests
{
    public static class Helper
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

        public static void Check(ITestC test, bool singleton)
        {
            Assert.IsNotNull(test);

            Assert.IsNotNull(test.TestCa10);
            Assert.IsNotNull(test.TestCb10);
            Assert.IsNotNull(test.TestCc10);

            Assert.IsNotNull(test.TestCa10.TestCa9);
            Assert.IsNotNull(test.TestCa10.TestCa8);
            Assert.IsNotNull(test.TestCa10.TestCa7);
            Assert.IsNotNull(test.TestCa10.TestCa6);
            Assert.IsNotNull(test.TestCa10.TestCa5);
            Assert.IsNotNull(test.TestCa10.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa7);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa6);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa5);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa0);

            if (singleton)
            {
                Assert.AreEqual(test.TestCa10.TestCa8, test.TestCa10.TestCa9.TestCa8);
                Assert.AreEqual(test.TestCa10.TestCa7, test.TestCa10.TestCa9.TestCa7);
                Assert.AreEqual(test.TestCa10.TestCa6, test.TestCa10.TestCa9.TestCa6);
                Assert.AreEqual(test.TestCa10.TestCa5, test.TestCa10.TestCa9.TestCa5);
                Assert.AreEqual(test.TestCa10.TestCa4, test.TestCa10.TestCa9.TestCa4);
                Assert.AreEqual(test.TestCa10.TestCa3, test.TestCa10.TestCa9.TestCa3);
                Assert.AreEqual(test.TestCa10.TestCa2, test.TestCa10.TestCa9.TestCa2);
                Assert.AreEqual(test.TestCa10.TestCa1, test.TestCa10.TestCa9.TestCa1);
                Assert.AreEqual(test.TestCa10.TestCa0, test.TestCa10.TestCa9.TestCa0);
            }
            else
            {
                Assert.AreNotEqual(test.TestCa10.TestCa8, test.TestCa10.TestCa9.TestCa8);
                Assert.AreNotEqual(test.TestCa10.TestCa7, test.TestCa10.TestCa9.TestCa7);
                Assert.AreNotEqual(test.TestCa10.TestCa6, test.TestCa10.TestCa9.TestCa6);
                Assert.AreNotEqual(test.TestCa10.TestCa5, test.TestCa10.TestCa9.TestCa5);
                Assert.AreNotEqual(test.TestCa10.TestCa4, test.TestCa10.TestCa9.TestCa4);
                Assert.AreNotEqual(test.TestCa10.TestCa3, test.TestCa10.TestCa9.TestCa3);
                Assert.AreNotEqual(test.TestCa10.TestCa2, test.TestCa10.TestCa9.TestCa2);
                Assert.AreNotEqual(test.TestCa10.TestCa1, test.TestCa10.TestCa9.TestCa1);
                Assert.AreNotEqual(test.TestCa10.TestCa0, test.TestCa10.TestCa9.TestCa0);
            }

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa6);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa5);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa5);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa1);
            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa0);

            Assert.IsNotNull(test.TestCa10.TestCa9.TestCa8.TestCa7.TestCa6.TestCa5.TestCa4.TestCa3.TestCa2.TestCa1.TestCa0);
        }
    }
}