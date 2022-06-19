using LeetCodePuzzles.Helpers.Assert;
using LeetCodePuzzles.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePuzzles.Knowledge.Binary_Search
{
    /// <summary>
    /// https://leetcode.com/explore/learn/card/binary-search/125/template-i/950/
    /// https://leetcode.com/problems/sqrtx/
    /// 
    /// Given a non-negative integer x, compute and return the square root of x.
    /// Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.
    /// Note: You are not allowed to use any built-in exponent function or operator, such as pow(x, 0.5) or x ** 0.5.
    ///
    ///Example 1:
    ///Input: x = 4
    ///Output: 2
    ///
    ///Example 2:
    ///Input: x = 8
    ///Output: 2
    ///Explanation: The square root of 8 is 2.82842..., and since the decimal part is truncated, 2 is returned.
    ///
    ///Constraints:
    ///    0 <= x <= 231 - 1
    /// </summary>
    public class _2_Sqrt : IQuestion
    {
        public void Run()
        {
            Assert.AreEqual(0, MySqrt(0));
            Assert.AreEqual(2, MySqrt(4));
            Assert.AreEqual(2, MySqrt(8));
            Assert.AreEqual(3, MySqrt(9));
            Assert.AreEqual(3, MySqrt(10));
            Assert.AreEqual(100, MySqrt(10001));
        }

        public int MySqrt(int x)
        {
            if(x == 0)
            {
                return 0;
            }

            int left = 1;
            int right = x / 2 + 1; // square root can only be in the range, so no need to check remaining elements

            while(left <= right)
            {
                int mid = left + (right - left) / 2;

                if(mid == x / mid) // Not multiplying as the product for a large number may be greater than the max value of int
                {
                    return mid;
                }

                if(mid < x / mid)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return right; // end will be the largest integer such that right^2 < x
        }
    }
}
