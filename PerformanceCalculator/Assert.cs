using System;

namespace PerformanceCalculator
{
    public static class Assert
    {
        public static void IsNotNull(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
        }

        public static void AreEqual(object obj1, object obj2)
        {
            if (!obj1.Equals(obj2))
                throw new InvalidOperationException();
        }

        public static void AreNotEqual(object obj1, object obj2)
        {
            if (obj1.Equals(obj2))
                throw new InvalidOperationException();
        }
    }
}