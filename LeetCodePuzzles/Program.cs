using LeetCodePuzzles.Question;
using LeetCodePuzzles.Question.EasyWarmUp;
using LeetCodePuzzles.Question.Medium;
using LeetCodePuzzles.Question.Hard;
using System;
using LeetCodePuzzles.Knowledge.Binary_Search;

namespace LeetCodePuzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            //Easy
                //var question = new TwoSum();
                //var question = new PalindromeNumber();
                //var question = new RomanToInteger();
                //var question = new LongestCommonPrefixQuestion();
                //var question = new ValidParentheses();
                //var question = new MergeTwoSortedLists();
                //var question = new RemoveDuplicatesFromSortedArray();
                //var question = new RemoveElement();
                //var question = new AddTwoNumbers();
                //var question = new SudokuSolver();
            //Hard
                //var question = new LongestSubstringWithoutRepeatingCharacters();

            //Knowledge
                //Binary Search
                //var question = new _1_BinarySearch();
                //var question = new _2_Sqrt();
                var question = new _3_GuessNumberHigherOrLower();
            question.Run();
        }
    }
}
