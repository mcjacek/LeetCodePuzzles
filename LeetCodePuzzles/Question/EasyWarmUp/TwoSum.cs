using LeetCodePuzzles.Helpers.Assert;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePuzzles.Question.EasyWarmUp
{
    /// <summary>
    /// https://leetcode.com/problems/two-sum/
    /// Solution explanation: https://www.code-recipe.com/post/two-sum
    /// 
    /// Given an array of integers "nums" and an integer "target", return indices of the two numbers such that they add up to "target".
    ///    You may assume that each input would have exactly one solution, and you may not use the same element twice.
    ///
    ///    You can return the answer in any order.
    ///
    ///
    ///
    ///    Example 1:
    ///
    ///Input: nums = [2, 7, 11, 15], target = 9
    ///    Output: [0,1]
    ///Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    ///
    ///
    ///    Example 2:
    ///
    ///
    ///    Input: nums = [3, 2, 4], target = 6
    ///    Output: [1,2]
    ///
    ///Example 3:
    ///
    ///
    ///    Input: nums = [3, 3], target = 6
    ///    Output: [0,1]
    ///
    ///
    ///
    ///Constraints:
    ///
    ///    2 <= nums.length <= 104
    ///    -109 <= nums[i] <= 109
    ///    -109 <= target <= 109
    ///
    ///        Only one valid answer exists.
    ///
    ///
    ///    Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
    /// </summary>
    public class TwoSum : IQuestion
    {
        public void Run()
        {
            // Test 1
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            var result = TwoSumAlgorithm(nums, target);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(1, result[1]);

            // Test 2
            target = 22;
            result = TwoSumAlgorithm(nums, target);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(3, result[1]);

            // Test 3
            nums = new int[] { 3, 2, 4 };
            target = 6;
            result = TwoSumAlgorithm(nums, target);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);

            // Test 4
            nums = new int[] { 3, 3 };
            target = 6;
            result = TwoSumAlgorithm(nums, target);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(1, result[1]);
        }

        public int[] TwoSumAlgorithm(int[] nums, int target)
        {
            var seen = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (seen.TryGetValue(target - nums[i], out var index))
                {
                    return new[] { index, i };
                }
                else if (!seen.ContainsKey(nums[i]))
                {
                    seen.Add(nums[i], i);
                }
            }

            return null;
        }

        public int[] TwoSumBruteForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { 0, 1 };
        }
    }
}
