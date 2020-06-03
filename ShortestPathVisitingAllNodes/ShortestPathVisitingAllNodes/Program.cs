using System;
using System.Collections.Generic;

namespace ShortestPathVisitingAllNodes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().ShortestPathLength(new[]
            {
                new int[] {1, 2, 3},
                new int[] {0},
                new int[] {0},
                new int[] {0},
            }));

            Console.WriteLine(4 == new Solution().ShortestPathLength(new[]
            {
                new int[] {1},
                new int[] {0, 2, 4},
                new int[] {1, 3, 4},
                new int[] {2},
                new int[] {1, 2},
            }));
        }
    }
}

public class Solution
{
    public int ShortestPathLength(int[][] graph)
    {
        var N = graph.Length;

        var queue = new Queue<Tuple>();
        var set = new HashSet<Tuple>();

        for (var i = 0; i < N; i++)
        {
            var tmp = (1 << i);

            set.Add(new Tuple(tmp, i, 0));
            queue.Enqueue(new Tuple(tmp, i, 1));
        }

        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();
            if (curr.BitMask == (1 << N) - 1)
            {
                return curr.Cost - 1;
            }

            var neighbors = graph[curr.Curr];

            foreach (var v in neighbors)
            {
                var bitMask = curr.BitMask;
                bitMask = bitMask | (1 << v);

                var tuple = new Tuple(bitMask, v, 0);
                if (!set.Contains(tuple))
                {
                    queue.Enqueue(new Tuple(bitMask, v, curr.Cost + 1));
                    set.Add(tuple);
                }
            }
        }

        return -1;
    }

    private class Tuple
    {
        public int BitMask { get; }
        public int Cost { get; }
        public int Curr { get; }

        public Tuple(int bitMask, int curr, int cost)
        {
            BitMask = bitMask;
            Curr = curr;
            Cost = cost;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Tuple;

            return BitMask == other.BitMask && Curr == other.Curr && Cost == other.Cost;
        }

        public override int GetHashCode()
        {
            return 1331 * BitMask + 7193 * Curr + 727 * Cost;
        }
    }
}