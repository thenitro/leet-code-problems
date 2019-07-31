using System;
using System.Collections.Generic;

namespace EscapeLargeMaze
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(false == new Solution().IsEscapePossible(
                                  new[] {new[] {0, 1}, new[] {1, 0}}, 
                                  new[] {0, 0},
                                  new[] {0, 2}));
            
            Console.WriteLine(true == new Solution().IsEscapePossible(
                                  new int[0][], 
                                  new[] {0, 0},
                                  new[] {0, 2}));
            
            Console.WriteLine(true == new Solution().IsEscapePossible(
                                  new[]
                                  {
                                      new [] {691938,300406},
                                      new [] {710196,624190},
                                      new [] {858790,609485},
                                      new [] {268029,225806},
                                      new [] {200010,188664},
                                      new [] {132599,612099},
                                      new [] {329444,633495},
                                      new [] {196657,757958},
                                      new [] {628509,883388}
                                  }, 
                                  new[] {655988, 180910},
                                  new[] {267728, 840949}));
        }
    }
}

public class Solution
{
    public bool IsEscapePossible(int[][] blocked, int[] source, int[] target)
    {
        if (blocked.Length == 0)
        {
            return true;
        }
        
        var blockedIds = new HashSet<string>();

        foreach (var block in blocked)
        {
            blockedIds.Add(block[0] + ":" + block[1]);
        }

        return
            EscapeHelper(blockedIds, source[0], source[1], target, new HashSet<string>()) &&
            EscapeHelper(blockedIds, target[0], target[1], source, new HashSet<string>());
    }

    private bool EscapeHelper(HashSet<string> blockedIds, int x, int y, int[] target, HashSet<string> visited)
    {
        visited.Add(x + ":" + y);

        if ((x == target[0] && y == target[1]) || visited.Count >= 20000)
        {
            return true;
        }

        for (var i = -1; i < 2; i++)
        {
            for (var j = -1; j < 2; j++)
            {
                if (Math.Abs(i) == Math.Abs(j))
                {
                    continue;
                }

                var nextX = x + i;
                var nextY = y + j;

                if (nextX < 0 || nextY < 0 || nextX >= 1000000 || nextY >= 1000000)
                {
                    continue;
                }

                var key = nextX + ":" + nextY;

                if (visited.Contains(key) || blockedIds.Contains(key))
                {
                    continue;
                }

                if (EscapeHelper(blockedIds, nextX, nextY, target, visited))
                {
                    return true;
                }
            }
        }

        return false;
    }
}