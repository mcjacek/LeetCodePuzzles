using LeetCodePuzzles.Helpers.Assert;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePuzzles.Question.EasyWarmUp
{
    /// <summary>
    /// https://leetcode.com/problems/palindrome-number/
    /// 
    /// Given an integer x, return true if x is palindrome integer.
    ///    An integer is a palindrome when it reads the same backward as forward.
    ///
    ///        For example, 121 is a palindrome while 123 is not.
    ///
    ///
    ///
    ///    Example 1:
    ///
    ///Input: x = 121
    ///Output: true
    ///Explanation: 121 reads as 121 from left to right and from right to left.
    ///
    ///Example 2:
    ///
    ///Input: x = -121
    ///Output: false
    ///Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
    ///
    ///Example 3:
    ///
    ///Input: x = 10
    ///Output: false
    ///Explanation: Reads 01 from right to left.Therefore it is not a palindrome.
    ///
    ///
    ///
    ///Constraints:
    ///
    ///    -231 <= x <= 231 - 1
    ///
    ///
    ///
    ///Follow up: Could you solve it without converting the integer to a string?
    /// </summary>
    public class PalindromeNumber : IQuestion
    {
        public void Run()
        {
            Assert.IsTrue(IsPalindrome(121));
            Assert.IsFalse(IsPalindrome(-123));
            Assert.IsFalse(IsPalindrome(10));
        }

        public bool IsPalindromeAsString(int x)
        {
            var number = x.ToString();
            var numberLength = number.Length;

            for(int i = 0; i < numberLength / 2; i++)
            {
                if (!number[i].Equals(number[numberLength - 1 - i]))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPalindrome(int x)
        {
            var numberToReverseTemp = x;
            int result = 0;
            while (numberToReverseTemp > 0)
            {
                result = result * 10 + numberToReverseTemp % 10;
                numberToReverseTemp /= 10;
            }

            if (x == result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}