using LeetCodePuzzles.Question;
using LeetCodePuzzles.Question.EasyWarmUp;
using LeetCodePuzzles.Question.Medium;
using LeetCodePuzzles.Question.Hard;
using System;

namespace LeetCodePuzzles
{
    class Program
    {
        static void Main(string[] args)
        {
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
            var question = new LongestSubstringWithoutRepeatingCharacters();
            question.Run();
        }
    }
}
