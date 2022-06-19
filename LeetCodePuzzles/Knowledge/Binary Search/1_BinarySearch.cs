using LeetCodePuzzles.Helpers.Assert;
using LeetCodePuzzles.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePuzzles.Knowledge.Binary_Search
{
    /// <summary>
    /// https://leetcode.com/explore/learn/card/binary-search/138/background/1038/
    /// https://leetcode.com/problems/binary-search/solution/
    /// 
    /// Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.
    ///    You must write an algorithm with O(log n) runtime complexity.
    ///    Example 1:
    ///Input: nums = [-1, 0, 3, 5, 9, 12], target = 9
    ///    Output: 4
    ///Explanation: 9 exists in nums and its index is 4
    ///
    ///    Example 2:
    ///    Input: nums = [-1, 0, 3, 5, 9, 12], target = 2
    ///    Output: -1
    ///Explanation: 2 does not exist in nums so return -1
    /// </summary>
    public class _1_BinarySearch : IQuestion
    {
        public void Run()
        {
            Assert.AreEqual(4, Search(new int[] { -1, 0, 3, 5, 9, 12 }, 9));
            Assert.AreEqual(-1, Search(new int[] { -1, 0, 3, 5, 9, 12 }, 2));
        }

        public int SearchByNET(int[] nums, int target)
        {
            int i = Array.BinarySearch(nums, target);
            return (i < 0) ? -1 : i; // or use Math.Clamp
        }

        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                //        //Pay attention to how you calculate the arithmetic mean. There are at least four ways to do that, one of which is wrong:
                //        //(lo + hi) / 2;                   // WRONG because lo + hi might result in an int overflow
                //        //lo + (hi - lo) / 2;              // RIGHT, also best performance in .NET
                //        //lo & hi + (lo ^ hi) / 2;         // CONFUSING
                //        //lo / 2 + hi / 2 + lo & hi & 1;   // FANCY

                if (nums[mid] == target)
                {
                    return mid;                        
                }
                else if(nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            
            return -1;
        }
    }
}
