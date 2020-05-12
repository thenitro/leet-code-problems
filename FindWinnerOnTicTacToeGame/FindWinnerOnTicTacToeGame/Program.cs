using System;

namespace FindWinnerOnTicTacToeGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("A" == new Solution().Tictactoe(new[]
            {
                new[] {0, 0},
                new[] {2, 0},
                new[] {1, 1},
                new[] {2, 1},
                new[] {2, 2}
            }));
            
            Console.WriteLine("B" == new Solution().Tictactoe(new[]
            {
                new[] {0, 0},
                new[] {1, 1},
                new[] {0, 1},
                new[] {0, 2},
                new[] {1, 0},
                new[] {2, 0},
            }));
            
            Console.WriteLine("Draw" == new Solution().Tictactoe(new[]
            {
                new[] {0,0},
                new[] {1,1},
                new[] {2,0},
                new[] {1,0},
                new[] {1,2},
                new[] {2,1},
                new[] {0,1},
                new[] {0,2},
                new[] {2,2}
            }));
            
            Console.WriteLine("Pending" == new Solution().Tictactoe(new[]
            {
                new[] {0,0},
                new[] {1,1},
            }));
        }
    }
}

public class Solution
{
    public string Tictactoe(int[][] moves)
    {
        var board = new char[3, 3];

        for (var i = 0; i < moves.Length; i++)
        {
            board[moves[i][0], moves[i][1]] = i % 2 == 0 ? 'X' : 'O';
        }

        var winner = FindWinner(board);
        if (winner == null)
        {
            if (moves.Length >= 9)
            {
                return "Draw";
            }
            
            return "Pending";            
        } 

        return winner;
    }

    private string FindWinner(char[,] board)
    {
        var isWinnerA = CheckIfPlayerWinner('X', board);
        var isWinnerB = CheckIfPlayerWinner('O', board);

        return isWinnerA ? "A" : isWinnerB ? "B" : null;
    }

    private bool CheckIfPlayerWinner(char player, char[,] board)
    {
        return CheckRowsAndCols(player, board) || CheckDiagonals(player, board);
    }

    private bool CheckRowsAndCols(char player, char[,] board)
    {
        for (var i = 0; i < 3; i++)
        {
            if (CheckRow(i, player, board))
            {
                return true;
            }
        }
        
        for (var i = 0; i < 3; i++)
        {
            if (CheckCol(i, player, board))
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckRow(int index, char player, char[,] board)
    {
        for (var i = 0; i < 3; i++)
        {
            if (board[index, i] != player)
            {
                return false;
            } 
        }

        return true;
    }

    private bool CheckCol(int index, char player, char[,] board)
    {
        for (var i = 0; i < 3; i++)
        {
            if (board[i, index] != player)
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckDiagonals(char player, char[,] board)
    {
        return CheckLeftToRight(player, board) || CheckRightToLeft(player, board);
    }

    private bool CheckLeftToRight(char player, char[,] board)
    {
        for (var i = 0; i < 3; i++)
        {
            if (board[i, i] != player)
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckRightToLeft(char player, char[,] board)
    {
        for (var i = 0; i < 3; i++)
        {
            if (board[i, 2 - i] != player)
            {
                return false;
            }
        }

        return true;
    }
}