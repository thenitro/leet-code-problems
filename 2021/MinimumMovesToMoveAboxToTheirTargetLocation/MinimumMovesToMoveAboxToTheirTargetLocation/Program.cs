using System;
using System.Collections.Generic;

namespace MinimumMovesToMoveAboxToTheirTargetLocation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

public class Solution
{
    private static readonly List<List<int>> directions = new List<List<int>>()
    {
        new List<int>() { 0, 1},
        new List<int>() { 0, -1},
        new List<int>() { 1, 0},
        new List<int>() { -1, 0},
    };

    public int MinPushBox(char[][] grid)
    {
        Coordinates player = null;
        Coordinates box = null; 
        Coordinates target = null;

        var rows = grid.Length;
        var cols = grid[0].Length;
        
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] == 'S')
                {
                    player = new Coordinates(i, j);
                }

                if (grid[i][j] == 'B')
                {
                    box = new Coordinates(i, j);
                }

                if (grid[i][j] == 'T')
                {
                    target = new Coordinates(i, j);
                }
            }
        }

        var startPosition = Coordinates.ConvertToString(box, player);

        var queue = new Queue<string>();
            queue.Enqueue(startPosition);

        var visited = new HashSet<string>();
            visited.Add(startPosition);

        var result = 0;

        while (queue.Count > 0)
        {
            result++;

            var count = queue.Count;
            while (count > 0)
            {
                count--;

                var decodedPositions = Coordinates.GetPositions(queue.Dequeue());

                var boxPosition = decodedPositions.Item1;
                var playerPosition = decodedPositions.Item2;

                var canVisit = new bool[rows, cols];

                UpdatePlayerReachablePositions(grid, canVisit, playerPosition, boxPosition);

                foreach (var direction in directions)
                {
                    var bxNew = boxPosition.X + direction[0];
                    var byNew = boxPosition.Y + direction[1];
                    
                    var pxNew = boxPosition.X - direction[0];
                    var pyNew = boxPosition.Y - direction[1];

                    var newBox = new Coordinates(bxNew, byNew);
                    var newPlayer = new Coordinates(pxNew, pyNew);

                    if (!newPlayer.IsValid(grid) || !newBox.IsValid(grid) ||
                        newBox.IsWall(grid) || !canVisit[pxNew, pyNew])
                    {
                        continue;
                    }

                    if (newBox.Equals(target))
                    {
                        return result;
                    }

                    var newPosition = Coordinates.ConvertToString(newBox, newPlayer);
                    if (!visited.Contains(newPosition))
                    {
                        visited.Add(newPosition);
                        queue.Enqueue(newPosition);
                    }
                }
            }
        }
        
        return -1;
    }

    private void UpdatePlayerReachablePositions(char[][] grid, bool[,] canVisit, Coordinates player, Coordinates box)
    {
        if (!player.IsValid(grid) ||
            player.IsWall(grid) ||
            player.Equals(box) ||
            canVisit[player.X, player.Y])
        {
            return;
        }

        canVisit[player.X, player.Y] = true;

        foreach (var direction in directions)
        {
            var newPlayer = new Coordinates(player.X + direction[0], player.Y + direction[1]);
            UpdatePlayerReachablePositions(grid, canVisit, newPlayer, box);
        }
    }
    
    private class Coordinates
    {
        public int X;
        public int Y;

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinates(string x, string y)
        {
            X = int.Parse(x);
            Y = int.Parse(y);
        }

        public static string ConvertToString(Coordinates box, Coordinates player)
        {
            return box.ToString() + "|" + player.ToString();
        }

        public static Tuple<Coordinates, Coordinates> GetPositions(string s)
        {
            var positions = s.Split('|');
            return new Tuple<Coordinates, Coordinates>(
                new Coordinates(positions[0], positions[1]),
                new Coordinates(positions[2], positions[3]));
        }

        public override string ToString()
        {
            return X + "|" + Y;
        }

        public bool IsValid(char[][] grid)
        {
            return X >= 0 && Y >= 0 && X < grid.Length && Y < grid[0].Length;
        }
        
        public bool IsWall(char[][] grid)
        {
            return grid[X][Y] == '#';
        }

        public bool Equals(Coordinates other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}