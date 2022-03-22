using LeetCodePuzzles.Helpers.Assert;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePuzzles.Question.EasyWarmUp
{
    /// <summary>
    /// https://leetcode.com/problems/valid-parentheses/
    /// 
    /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    ///    An input string is valid if:
    ///
    ///    Open brackets must be closed by the same type of brackets.
    ///    Open brackets must be closed in the correct order.
    ///
    ///
    ///
    ///Example 1:
    ///
    ///Input: s = "()"
    ///Output: true
    ///
    ///Example 2:
    ///
    ///Input: s = "()[]{}"
    ///Output: true
    ///
    ///Example 3:
    ///
    ///Input: s = "(]"
    ///Output: false
    ///
    /// 
    ///
    ///Constraints:
    ///
    ///    1 <= s.length <= 104
    ///    s consists of parentheses only '()[]{}'.
    /// </summary>
    public class ValidParentheses : IQuestion
    {
        public void Run()
        {
            Assert.IsTrue(IsValid("()"));
            Assert.IsTrue(IsValid("()[]{}"));
            Assert.IsFalse(IsValid("(]"));
        }

        public bool IsValid(string s)
        {
            var stack = new Stack<char>();

            foreach(char letter in s)
            {
                if(letter == '(')
                {
                    stack.Push(')');
                    continue;
                }

                if (letter == '[')
                {
                    stack.Push(']');
                    continue;
                }

                if (letter == '{')
                {
                    stack.Push('}');
                    continue;
                }

                if(stack.Count == 0 || letter != stack.Pop())
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
