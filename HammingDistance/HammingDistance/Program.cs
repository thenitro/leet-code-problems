using System;

namespace HammingDistance
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().HammingDistance(1, 4));
        }
    }
}

public class Solution {
    public int HammingDistance(int x, int y)
    {
        var strX = Convert.ToString(x, 2);
        var strY = Convert.ToString(y, 2);

        var smaller = Math.Min(strX.Length, strY.Length);
        var bigger = Math.Max(strX.Length, strY.Length);

        var count = 0;

        for (var i = 0; i < bigger; i++)
        {
            var xIndex = strX.Length - i - 1;
            var yIndex = strY.Length - i - 1;

            var xValue = 0;
            if (xIndex >= 0)
            {
                xValue = strX[xIndex] - '0';
            }
            
            var yValue = 0;
            if (yIndex >= 0)
            {
                yValue = strY[yIndex] - '0';
            }
            
            if (xValue != yValue)
            {
                count++;
            }
        }

        return count;
    }
}