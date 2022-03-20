using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePuzzles.Helpers.Assert
{
    public class Assert
    {
        public static bool AreEqual(int expected, int actual)
        {
            if(expected == actual)
            {
                return true;
            }

            throw new Exception($"Numbers are not equal. Expected: {expected}, Actual: {actual}");
        }

        public static bool IsTrue(bool condition)
        {
            if (condition)
            {
                return true;
            }

            throw new Exception($"Condition: {condition} is not true as expected.");
        }

        public static bool IsFalse(bool condition)
        {
            if (!condition)
            {
                return true;
            }

            throw new Exception($"Condition: {condition} is not false as expected.");
        }
    }
}
