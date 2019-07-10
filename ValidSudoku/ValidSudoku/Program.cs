using System;
using System.Collections.Generic;

namespace ValidSudoku
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsValidSudoku(
                                  new char[][]
                                  {
                                      new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                                      new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                                      new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                                      new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                                      new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                                      new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                                      new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                                      new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                                      new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
                                  }));

            Console.WriteLine(false == new Solution().IsValidSudoku(
                                  new char[][]
                                  {
                                      new char[] {'8', '3', '.', '.', '7', '.', '.', '.', '.'},
                                      new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                                      new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                                      new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                                      new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                                      new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                                      new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                                      new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                                      new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
                                  }));
        }
    }
}

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                var set = new HashSet<int>();

                for (var n = 0; n < 3; n++)
                {
                    for (var m = 0; m < 3; m++)
                    {
                        var character = board[i * 3 + n][j * 3 + m];
                        if (character == '.')
                        {
                            continue;
                        }

                        if (set.Contains(character))
                        {
                            return false;
                        }

                        set.Add(character);
                    }
                }
            }
        }

        for (var i = 0; i < 9; i++)
        {
            var set = new HashSet<int>();

            for (var j = 0; j < 9; j++)
            {
                var character = board[i][j];
                if (character == '.')
                {
                    continue;
                }

                if (set.Contains(character))
                {
                    return false;
                }

                set.Add(character);
            }
        }

        for (var i = 0; i < 9; i++)
        {
            var set = new HashSet<int>();

            for (var j = 0; j < 9; j++)
            {
                var character = board[j][i];
                if (character == '.')
                {
                    continue;
                }

                if (set.Contains(character))
                {
                    return false;
                }

                set.Add(character);
            }
        }

        return true;
    }
}