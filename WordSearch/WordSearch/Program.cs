using System;
using System.Collections.Generic;

namespace WordSearch
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var board = new char[][]
            {
                new char[] {'A', 'B', 'C', 'E'},
                new char[] {'S', 'F', 'C', 'S'},
                new char[] {'A', 'D', 'E', 'E'},
            };

            Console.WriteLine(true == new Solution().Exist(board, "ABCCED"));
            Console.WriteLine(true == new Solution().Exist(board, "SEE"));
            Console.WriteLine(false == new Solution().Exist(board, "ABCB"));

            var board2 = new char[][]
            {
                new char[] {'a', 'a'}
            };
            
            Console.WriteLine(false == new Solution().Exist(board2, "aaa"));
            
            var board3 = new char[][]
            {
                new char[] {'a', 'b'},
                new char[] {'c', 'd'}
            };

            
            Console.WriteLine(true == new Solution().Exist(board3, "acdb"));
            
            var board4 = new char[][]
            {
                new char[] {'A', 'B', 'C', 'E'},
                new char[] {'S', 'F', 'E', 'S'},
                new char[] {'A', 'D', 'E', 'E'},
            };
            
            Console.WriteLine(true == new Solution().Exist(board4, "ABCESEEEFS"));
        }
    }
}

public class Solution {
    public bool Exist(char[][] board, string word)
    {
        for (var i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (ExistHelper(board, i, j, word, 0))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool ExistHelper(char[][] board, int y, int x, string word, int depth)
    {
        if (depth == word.Length)
        {
            return true;
        }

        if (y < 0 || x < 0 || y == board.Length || x == board[y].Length)
        {
            return false;
        }

        if (board[y][x] != word[depth])
        {
            return false;
        }
        
        board[y][x] = '*';

        var nextDepth = depth + 1;

        var exist = ExistHelper(board, y, x + 1, word, nextDepth) ||
                    ExistHelper(board, y, x - 1, word, nextDepth) ||
                    ExistHelper(board, y + 1, x, word, nextDepth) ||
                    ExistHelper(board, y - 1, x, word, nextDepth);
        
        board[y][x] = word[depth];

        return exist;
    }
}