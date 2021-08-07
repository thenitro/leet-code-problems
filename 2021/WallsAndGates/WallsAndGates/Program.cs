using System;
using System.Collections.Generic;

namespace WallsAndGates
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = new int[][]
            {
                new int[] { 2147483647, -1, 0, 2147483647 },
                new int[] { 2147483647, 2147483647, 2147483647, -1 },
                new int[] { 2147483647, -1, 2147483647, -1 },
                new int[] { 0, -1, 2147483647, 2147483647 },
            };
            
            new Solution().WallsAndGates(input);

            foreach (var i in input)
            {
                Console.WriteLine(string.Join(",",i));
            }
        }
    }
}

public class Solution
{
    private const int EMPTY_ROOM = 2147483647;
    private const int WALL = -1;
    private const int GATE = 0;
    
    public void WallsAndGates(int[][] rooms)
    {
        var neighbors = new Queue<Coordinates>();

        for (var row = 0; row < rooms.Length; row++)
        {
            for (var column = 0; column < rooms[row].Length; column++)
            {
                if (rooms[row][column] == GATE)
                {
                    neighbors.Enqueue(new Coordinates(row, column));
                }
            }
        }
        
        var cache = new Dictionary<int, HashSet<int>>();
        var distance = 0;
        var count = neighbors.Count;

        while (neighbors.Count > 0)
        {
            var node = neighbors.Dequeue();
            count--;

            ProcessNode(node, rooms, cache, distance, neighbors);

            if (count <= 0)
            {
                count = neighbors.Count;
                distance++;
            }
        }
    }

    private void ProcessNode(Coordinates node, int[][] rooms, Dictionary<int, HashSet<int>> cache, int distance, Queue<Coordinates> neighbors)
    {
        if (node.Row < 0 || node.Row >= rooms.Length ||
            node.Column < 0 || node.Column >= rooms[node.Row].Length)
        {
            return;
        }

        if (cache.ContainsKey(node.Row) && cache[node.Row].Contains(node.Column))
        {
            return;
        }

        var rowSet = cache.ContainsKey(node.Row) ? cache[node.Row] : new HashSet<int>();
            rowSet.Add(node.Column);

        cache[node.Row] = rowSet;

        if (rooms[node.Row][node.Column] == WALL)
        {
            return;
        }

        if (rooms[node.Row][node.Column] != GATE)
        {
            rooms[node.Row][node.Column] = Math.Min(rooms[node.Row][node.Column], distance);
        }
                
        neighbors.Enqueue(new Coordinates(node.Row + 1, node.Column));
        neighbors.Enqueue(new Coordinates(node.Row - 1, node.Column));
        neighbors.Enqueue(new Coordinates(node.Row, node.Column + 1));
        neighbors.Enqueue(new Coordinates(node.Row, node.Column - 1));
    }

    private class Coordinates
    {
        public int Row { get; }
        public int Column { get; }

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}