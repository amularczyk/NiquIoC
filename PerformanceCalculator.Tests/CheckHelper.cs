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

        public static void Check(ITestD testD, bool singleton)
        {
            Assert.IsNotNull(testD);

            Assert.IsNotNull(testD.TestD49);
            Assert.IsNotNull(testD.TestD48);
            Assert.IsNotNull(testD.TestD47);
            Assert.IsNotNull(testD.TestD46);
            Assert.IsNotNull(testD.TestD45);
            Assert.IsNotNull(testD.TestD44);
            Assert.IsNotNull(testD.TestD43);
            Assert.IsNotNull(testD.TestD42);
            Assert.IsNotNull(testD.TestD41);
            Assert.IsNotNull(testD.TestD40);

            Assert.IsNotNull(testD.TestD49.TestD39);
            Assert.IsNotNull(testD.TestD49.TestD38);
            Assert.IsNotNull(testD.TestD49.TestD37);
            Assert.IsNotNull(testD.TestD49.TestD36);
            Assert.IsNotNull(testD.TestD49.TestD35);
            Assert.IsNotNull(testD.TestD49.TestD34);
            Assert.IsNotNull(testD.TestD49.TestD33);
            Assert.IsNotNull(testD.TestD49.TestD32);
            Assert.IsNotNull(testD.TestD49.TestD31);
            Assert.IsNotNull(testD.TestD49.TestD30);

            if (singleton)
            {
                Assert.AreEqual(testD.TestD49.TestD39, testD.TestD48.TestD39);
                Assert.AreEqual(testD.TestD49.TestD38, testD.TestD48.TestD38);
                Assert.AreEqual(testD.TestD49.TestD37, testD.TestD48.TestD37);
                Assert.AreEqual(testD.TestD49.TestD36, testD.TestD48.TestD36);
                Assert.AreEqual(testD.TestD49.TestD35, testD.TestD48.TestD35);
                Assert.AreEqual(testD.TestD49.TestD34, testD.TestD48.TestD34);
                Assert.AreEqual(testD.TestD49.TestD33, testD.TestD48.TestD33);
                Assert.AreEqual(testD.TestD49.TestD32, testD.TestD48.TestD32);
                Assert.AreEqual(testD.TestD49.TestD31, testD.TestD48.TestD31);
                Assert.AreEqual(testD.TestD49.TestD30, testD.TestD48.TestD30);
            }
            else
            {
                Assert.AreNotEqual(testD.TestD49.TestD39, testD.TestD48.TestD39);
                Assert.AreNotEqual(testD.TestD49.TestD38, testD.TestD48.TestD38);
                Assert.AreNotEqual(testD.TestD49.TestD37, testD.TestD48.TestD37);
                Assert.AreNotEqual(testD.TestD49.TestD36, testD.TestD48.TestD36);
                Assert.AreNotEqual(testD.TestD49.TestD35, testD.TestD48.TestD35);
                Assert.AreNotEqual(testD.TestD49.TestD34, testD.TestD48.TestD34);
                Assert.AreNotEqual(testD.TestD49.TestD33, testD.TestD48.TestD33);
                Assert.AreNotEqual(testD.TestD49.TestD32, testD.TestD48.TestD32);
                Assert.AreNotEqual(testD.TestD49.TestD31, testD.TestD48.TestD31);
                Assert.AreNotEqual(testD.TestD49.TestD30, testD.TestD48.TestD30);
            }

            Assert.IsNotNull(testD.TestD49.TestD39.TestD29);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD28);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD27);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD26);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD25);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD24);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD23);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD22);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD21);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD20);

            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD19);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD18);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD17);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD16);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD15);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD14);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD13);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD12);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD11);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD10);

            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD19.TestD09);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD19.TestD08);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD19.TestD07);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD19.TestD06);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD19.TestD05);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD19.TestD04);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD19.TestD03);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD19.TestD02);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD19.TestD01);
            Assert.IsNotNull(testD.TestD49.TestD39.TestD29.TestD19.TestD00);
        }

        public static void Check(ITestD TestD1, ITestD TestD2, bool singleton)
        {
            Assert.AreEqual(TestD1.Equals(TestD2), singleton);

            Assert.AreEqual(TestD1.TestD49.Equals(TestD2.TestD49), singleton);
            Assert.AreEqual(TestD1.TestD48.Equals(TestD2.TestD48), singleton);
            Assert.AreEqual(TestD1.TestD47.Equals(TestD2.TestD47), singleton);
            Assert.AreEqual(TestD1.TestD46.Equals(TestD2.TestD46), singleton);
            Assert.AreEqual(TestD1.TestD45.Equals(TestD2.TestD45), singleton);
            Assert.AreEqual(TestD1.TestD44.Equals(TestD2.TestD44), singleton);
            Assert.AreEqual(TestD1.TestD43.Equals(TestD2.TestD43), singleton);
            Assert.AreEqual(TestD1.TestD42.Equals(TestD2.TestD42), singleton);
            Assert.AreEqual(TestD1.TestD41.Equals(TestD2.TestD41), singleton);
            Assert.AreEqual(TestD1.TestD40.Equals(TestD2.TestD40), singleton);

            Assert.AreEqual(TestD1.TestD49.TestD39.Equals(TestD2.TestD49.TestD39), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD38.Equals(TestD2.TestD49.TestD38), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD37.Equals(TestD2.TestD49.TestD37), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD36.Equals(TestD2.TestD49.TestD36), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD35.Equals(TestD2.TestD49.TestD35), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD34.Equals(TestD2.TestD49.TestD34), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD33.Equals(TestD2.TestD49.TestD33), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD32.Equals(TestD2.TestD49.TestD32), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD31.Equals(TestD2.TestD49.TestD31), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD30.Equals(TestD2.TestD49.TestD30), singleton);
            
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.Equals(TestD2.TestD49.TestD39.TestD29), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD28.Equals(TestD2.TestD49.TestD39.TestD28), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD27.Equals(TestD2.TestD49.TestD39.TestD27), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD26.Equals(TestD2.TestD49.TestD39.TestD26), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD25.Equals(TestD2.TestD49.TestD39.TestD25), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD24.Equals(TestD2.TestD49.TestD39.TestD24), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD23.Equals(TestD2.TestD49.TestD39.TestD23), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD22.Equals(TestD2.TestD49.TestD39.TestD22), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD21.Equals(TestD2.TestD49.TestD39.TestD21), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD20.Equals(TestD2.TestD49.TestD39.TestD20), singleton);

            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD19.Equals(TestD2.TestD49.TestD39.TestD29.TestD19), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD18.Equals(TestD2.TestD49.TestD39.TestD29.TestD18), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD17.Equals(TestD2.TestD49.TestD39.TestD29.TestD17), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD16.Equals(TestD2.TestD49.TestD39.TestD29.TestD16), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD15.Equals(TestD2.TestD49.TestD39.TestD29.TestD15), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD14.Equals(TestD2.TestD49.TestD39.TestD29.TestD14), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD13.Equals(TestD2.TestD49.TestD39.TestD29.TestD13), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD12.Equals(TestD2.TestD49.TestD39.TestD29.TestD12), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD11.Equals(TestD2.TestD49.TestD39.TestD29.TestD11), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD10.Equals(TestD2.TestD49.TestD39.TestD29.TestD10), singleton);

            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD19.TestD09.Equals(TestD2.TestD49.TestD39.TestD29.TestD19.TestD09), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD19.TestD08.Equals(TestD2.TestD49.TestD39.TestD29.TestD19.TestD08), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD19.TestD07.Equals(TestD2.TestD49.TestD39.TestD29.TestD19.TestD07), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD19.TestD06.Equals(TestD2.TestD49.TestD39.TestD29.TestD19.TestD06), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD19.TestD05.Equals(TestD2.TestD49.TestD39.TestD29.TestD19.TestD05), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD19.TestD04.Equals(TestD2.TestD49.TestD39.TestD29.TestD19.TestD04), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD19.TestD03.Equals(TestD2.TestD49.TestD39.TestD29.TestD19.TestD03), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD19.TestD02.Equals(TestD2.TestD49.TestD39.TestD29.TestD19.TestD02), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD19.TestD01.Equals(TestD2.TestD49.TestD39.TestD29.TestD19.TestD01), singleton);
            Assert.AreEqual(TestD1.TestD49.TestD39.TestD29.TestD19.TestD00.Equals(TestD2.TestD49.TestD39.TestD29.TestD19.TestD00), singleton);
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