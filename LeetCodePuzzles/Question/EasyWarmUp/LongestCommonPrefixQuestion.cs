using LeetCodePuzzles.Helpers.Assert;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePuzzles.Question.EasyWarmUp
{
    /// <summary>
    /// https://leetcode.com/problems/longest-common-prefix/
    /// 
    /// Write a function to find the longest common prefix string amongst an array of strings.
    ///    If there is no common prefix, return an empty string "".
    ///
    /// 
    ///
    ///Example 1:
    ///
    ///Input: strs = ["flower","flow","flight"]
    ///    Output: "fl"
    ///
    ///Example 2:
    ///
    ///Input: strs = ["dog","racecar","car"]
    ///    Output: ""
    ///Explanation: There is no common prefix among the input strings.
    ///
    ///
    ///
    ///Constraints:
    ///
    ///    1 <= strs.length <= 200
    ///    0 <= strs[i].length <= 200
    ///    strs[i] consists of only lower-case English letters.
    /// </summary>
    public class LongestCommonPrefixQuestion : IQuestion
    {
        public void Run()
        {
            Assert.AreEqual("fl", LongestCommonPrefixDivideAndConquer(new string[] { "flower", "flow", "flight" }));
            Assert.AreEqual("", LongestCommonPrefixDivideAndConquer(new string[] { "dog", "racecar", "car" }));
            Assert.AreEqual("jack", LongestCommonPrefixDivideAndConquer(new string[] { "jack" }));
        }


        public string LongestCommonPrefixDivideAndConquer(string[] strs)
        {
            return longestCommonPrefix(strs, 0, strs.Length - 1);
        }

        private string longestCommonPrefix(string[] strs, int leftIndex, int rightIndex)
        {
            if(leftIndex == rightIndex)
            {
                return strs[leftIndex];
            }
            else
            {
                int mid = (leftIndex + rightIndex) / 2;
                var leftString = longestCommonPrefix(strs, leftIndex, mid);
                var rightString = longestCommonPrefix(strs, mid + 1, rightIndex);
                return GetPrefix(leftString, rightString);
            }
        }

        private string GetPrefix(string leftString, string rightString)
        {
            var min = Math.Min(leftString.Length, rightString.Length);
            for(int i = 0; i < min; i++)
            {
                if(leftString[i] != rightString[i])
                {
                    return leftString.Substring(0, i);
                }
            }

            return leftString.Substring(0, min);
        }

        public string LongestCommonPrefixVerticalScanning(string[] strs)
        {
            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if(i == strs[j].Length || strs[j][i] != c)
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }

            return strs[0];
        }

        public string LongestCommonPrefixHorizontalScanning(string[] strs)
        {
            string prefix = strs[0];
            for(int i = 1; i < strs.Length; i++)
            {
                while(strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if(prefix.Equals(string.Empty))
                    {
                        return string.Empty;
                    }
                }
            }

            return prefix;
        }
    }
}
