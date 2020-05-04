using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MinimumDistanceToTypeWordUsingTwoFingers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().MinimumDistance("cake"));
            Console.WriteLine(6 == new Solution().MinimumDistance("HAPPY"));
            Console.WriteLine(3 == new Solution().MinimumDistance("NEW"));
            Console.WriteLine(7 == new Solution().MinimumDistance("YEAR"));

            var watch = Stopwatch.StartNew();
            
            Console.WriteLine(295 == new Solution().MinimumDistance("OPVUWZLCKTDPSUKGHAXIDWHLZFKNBDZEWHBSURTVCADUGTSDMCLDBTAGFWDPGXZBVARNTDICHCUJLNFBQOBTDWMGILXPSFWVGYBZVFFKQIDTOVFAPVNSQJULMVIERWAOXCKXBRI"));

            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}

public class Solution
{
    private char[,] TABLE = new char[,]
    {
        { 'a', 'b', 'c', 'd', 'e', 'f' },
        { 'g', 'h', 'i', 'j', 'k', 'l' },
        { 'm', 'n', 'o', 'p', 'q', 'r' },
        { 's', 't', 'u', 'v', 'w', 'x' },
        { 'y', 'z', '0', '0', '0', '0'},
    };
    
    public int MinimumDistance(string word)
    {
        word = word.ToLower();

        var memo = new Dictionary<string, int>();
        var dict = ConvertTableToDictionary();
        
        return Math.Min(
            SolutionHelper(true, null, null, 0, word, dict, memo),
            SolutionHelper(false, null, null, 0, word, dict, memo));
    }

    private Dictionary<char, Point> ConvertTableToDictionary()
    {
        var result = new Dictionary<char, Point>();

        for (var i = 0; i < TABLE.GetLength(0); i++)
        {
            for (var j = 0; j < TABLE.GetLength(1); j++)
            {
                if (TABLE[i, j] != '0')
                {
                    result[TABLE[i, j]] = new Point() {X = i, Y = j};
                }
            }
        }

        return result;
    }

    private int SolutionHelper(bool useFinger1, Point finger1, Point finger2, int index, string word, Dictionary<char, Point> positions, Dictionary<string, int> memo)
    {
        if (index >= word.Length)
        {
            return 0;
        }
        
        var key = useFinger1 + " " + finger1 + " " + finger2 + " " + index;

        if (memo.ContainsKey(key))
        {
            return memo[key];
        }

        var cost = 0;
        
        var character = word[index];
        var point = positions[character];
        
        if (useFinger1)
        {
            if (finger1 == null)
            {
                finger1 = point;
            }
            else
            {
                cost = finger1.DistanceTo(point);
                finger1 = point;
            }
        }
        else
        {
            if (finger2 == null)
            {
                finger2 = point;
            }
            else
            {
                cost = finger2.DistanceTo(point);
                finger2 = point;
            }
        }

        memo[key] = cost + Math.Min(
                        SolutionHelper(true, finger1, finger2, index + 1, word, positions, memo),
                        SolutionHelper(false, finger1, finger2, index + 1, word, positions, memo)); 
        
        return memo[key];
    }

    private class Point
    {
        public int X;
        public int Y;
        
        public int DistanceTo(Point to)
        {
            return Math.Abs(X - to.X) + Math.Abs(Y - to.Y);
        }

        public override string ToString()
        {
            return string.Format("[Point X={0}, Y={1}]", X, Y);
        }
    }
}