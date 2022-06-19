using LeetCodePuzzles.Helpers.Assert;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePuzzles.Question.Hard
{
    /// <summary>
    /// https://leetcode.com/problems/sudoku-solver/
    /// Write a program to solve a Sudoku puzzle by filling the empty cells.
    ///     A sudoku solution must satisfy all of the following rules:
    /// 
    ///     Each of the digits 1-9 must occur exactly once in each row.
    ///     Each of the digits 1-9 must occur exactly once in each column.
    ///     Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
    /// 
    /// The '.' character indicates empty cells.
    /// Example 1:
    /// Input: board = [["5", "3", ".", ".", "7", ".", ".", ".", "."], ["6",".",".","1","9","5",".",".","."], [".","9","8",".",".",".",".","6","."], ["8",".",".",".","6",".",".",".","3"], ["4",".",".","8",".","3",".",".","1"], ["7",".",".",".","2",".",".",".","6"], [".","6",".",".",".",".","2","8","."], [".",".",".","4","1","9",".",".","5"], [".",".",".",".","8",".",".","7","9"]]
    /// Output: [["5","3","4","6","7","8","9","1","2"],["6","7","2","1","9","5","3","4","8"],["1","9","8","3","4","2","5","6","7"],["8","5","9","7","6","1","4","2","3"],["4","2","6","8","5","3","7","9","1"],["7","1","3","9","2","4","8","5","6"],["9","6","1","5","3","7","2","8","4"],["2","8","7","4","1","9","6","3","5"],["3","4","5","2","8","6","1","7","9"]]
    /// Explanation: The input board is shown above and the only valid solution is shown below:
    /// 
    /// Constraints:
    /// 
    ///     board.length == 9
    ///     board[i].length == 9
    ///     board[i][j] is a digit or '.'.
    ///     It is guaranteed that the input board has only one solution.
    /// </summary>
    public class SudokuSolver : IQuestion
    {
        public void Run()
        {
            char[][] dasdas = new char[][] 
            { 
                new char[] { '1', '2' },
                new char[] { '3', '4' }
            };

            char[][] board = new char[][]
            {
                new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            SolveSudoku(board);


            char[][] expectedBoard = new char[][]
            {
                new char[] {'5','3','4','6','7','8','9','1','2'},
                new char[] {'6','7','2','1','9','5','3','4','8'},
                new char[] {'1','9','8','3','4','2','5','6','7'},
                new char[] {'8','5','9','7','6','1','4','2','3'},
                new char[] {'4','2','6','8','5','3','7','9','1'},
                new char[] {'7','1','3','9','2','4','8','5','6'},
                new char[] {'9','6','1','5','3','7','2','8','4'},
                new char[] {'2','8','7','4','1','9','6','3','5'},
                new char[] {'3','4','5','2','8','6','1','7','9'}
            };

            TestBoard(board, expectedBoard);
        }

        private const char EMPTY_ENTRY = '.';
        /// <summary>
        ///   Driver function to kick off the recursion
        /// </summary>
        /// <param name="board"></param>
        public void SolveSudoku(char[][] board)
        {
            solveSudokuCell(0, 0, board);
        }

        /*
          This function chooses a placement for the cell at (row, col)
          and continues solving based on the rules we define.
  
          Our strategy:
          We will start at row 0.
          We will solve every column in that row.
          When we reach the last column we move to the next row.
          If this is past the last row (row == board.length) we are done.
          The whole board has been solved.
        */
        private static bool solveSudokuCell(int row, int col, char[][] board)
        {

            /*
              Have we finished placements in all columns for
              the row we are working on?
            */
            if (col == board[row].Length)
            {

                /*
                  Yes. Reset to col 0 and advance the row by 1.
                  We will work on the next row.
                */
                col = 0;
                row++;

                /*
                  Have we completed placements in all rows? If so then we are done.
                  If not, drop through to the logic below and keep solving things.
                */
                if (row == board.Length)
                {
                    return true; // Entire board has been filled without conflict.
                }

            }

            // Skip non-empty entries. They already have a value in them.
            if (board[row][col] != EMPTY_ENTRY)
            {
                return solveSudokuCell(row, col + 1, board);
            }

            /*
              Try all values 1 through 9 in the cell at (row, col).
              Recurse on the placement if it doesn't break the constraints of Sudoku.
            */
            for (int value = 1; value <= board.Length; value++)
            {

                char charToPlace = (char)(value + '0'); // convert int value to char

                /*
                  Apply constraints. We will only add the value to the cell if
                  adding it won't cause us to break sudoku rules.
                */
                if (canPlaceValue(board, row, col, charToPlace))
                {
                    board[row][col] = charToPlace;
                    if (solveSudokuCell(row, col + 1, board))
                    { // recurse with our VALID placement
                        return true;
                    }
                }

            }

            /*
              Undo assignment to this cell. No values worked in it meaning that
              previous states put us in a position we cannot solve from. Hence,
              we backtrack by returning "false" to our caller.
            */
            board[row][col] = EMPTY_ENTRY;
            return false; // No valid placement was found, this path is faulty, return false
        }

        /*
          Will the placement at (row, col) break the Sudoku properties?
        */
        private static bool canPlaceValue(char[][] board, int row, int col, char charToPlace)
        {

            // Check column constraint. For each row, we do a check on column "col".
            for(int i = 0; i < board.Length; i++)
            //for (char[] element : board)
            {
                if (charToPlace == board[i][col])
                {
                    return false;
                }
            }

            // Check row constraint. For each column in row "row", we do a check.
            for (int i = 0; i < board.Length; i++)
            {
                if (charToPlace == board[row][i])
                {
                    return false;
                }
            }

            /*
              Check region constraints.

              In a 9 x 9 board, we will have 9 sub-boxes (3 rows of 3 sub-boxes).

              The "I" tells us that we are in the Ith sub-box row. (there are 3 sub-box rows)
              The "J" tells us that we are in the Jth sub-box column. (there are 3 sub-box columns)

              I tried to think of better variable names for like 20 minutes but couldn't so just left
              I and J.

              Integer properties will truncate the decimal place so we just know the sub-box number we are in.
              Each coordinate we touch will be found by an offset from topLeftOfSubBoxRow and topLeftOfSubBoxCol.
            */
            int regionSize = (int)Math.Sqrt(board.Length); // gives us the size of a sub-box

            int I = row / regionSize;
            int J = col / regionSize;

            /*
              This multiplication takes us to the EXACT top left of the sub-box. We keep the (row, col)
              of these values because it is important. It lets us traverse the sub-box with our double for loop.
            */
            int topLeftOfSubBoxRow = regionSize * I; // the row of the top left of the block
            int topLeftOfSubBoxCol = regionSize * J; // the column of the tol left of the block

            for (int i = 0; i < regionSize; i++)
            {
                for (int j = 0; j < regionSize; j++)
                {

                    /*
                      i and j just define our offsets from topLeftOfBlockRow
                      and topLeftOfBlockCol respectively
                    */
                    if (charToPlace == board[topLeftOfSubBoxRow + i][topLeftOfSubBoxCol + j])
                    {
                        return false;
                    }

                }
            }

            return true; // placement is valid
        }

        private void TestBoard(char[][] board, char[][] expectedBoard)
        {
            for(int i = 0; i < expectedBoard.Length; i++)
            {
                for(int j = 0; j < expectedBoard[i].Length; j++)
                {
                    Assert.AreEqual(expectedBoard[i][j], board[i][j]);
                    Console.Write(expectedBoard[i][j] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
