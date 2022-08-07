using LeetCodePuzzles.Helpers.Assert;
using LeetCodePuzzles.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePuzzles.Knowledge.Binary_Search
{
    /// <summary>
    /// We are playing the Guess Game. The game is as follows:
    ///    I pick a number from 1 to n.You have to guess which number I picked.
    ///    Every time you guess wrong, I will tell you whether the number I picked is higher or lower than your guess.
    ///    You call a pre-defined API int guess(int num), which returns three possible results:
    ///    -1: Your guess is higher than the number I picked (i.e.num > pick).
    ///    1: Your guess is lower than the number I picked(i.e.num<pick).
    ///    0: your guess is equal to the number I picked(i.e.num == pick).
    ///Return the number that I picked.
    ///
    ///Example 1:
    ///Input: n = 10, pick = 6
    ///Output: 6
    ///
    ///Example 2:
    ///Input: n = 1, pick = 1
    ///Output: 1
    ///
    ///Example 3:
    ///Input: n = 2, pick = 1
    ///Output: 1
    ///
    ///Constraints:
    ///    1 <= n <= 231 - 1
    ///    1 <= pick <= n


    /// </summary>
    public class _3_GuessNumberHigherOrLower : IQuestion
    {
        public int pick = 5;
        public void Run()
        {
            pick = 6;
            Assert.AreEqual(pick, GuessNumber(10));

            pick = 1;
            Assert.AreEqual(pick, GuessNumber(1));

            pick = 1;
            Assert.AreEqual(pick, GuessNumber(2));

            pick = 123;
            Assert.AreEqual(pick, GuessNumber(230));
        }

        public int GuessNumber(int n)
        {
            int left = 1;
            int right = n;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;

                var ret = guess(mid);
                if (ret == -1)
                {
                    right = mid - 1;
                }
                else if (ret == 1)
                {
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return 1;
        }

        int guess(int num)
        {
            if (num > pick)
            {
                return -1;
            }
            else if (num < pick)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
