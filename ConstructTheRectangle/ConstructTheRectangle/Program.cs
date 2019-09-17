using System;

namespace ConstructTheRectangle
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result1 = new Solution().ConstructRectangle(1);
            Console.WriteLine("1,1" == string.Join(",", result1));
            
            var result3 = new Solution().ConstructRectangle(2);
            Console.WriteLine("2,1" == string.Join(",", result3));
            
            var result = new Solution().ConstructRectangle(4);
            Console.WriteLine("2,2" == string.Join(",", result));
            
            var result2 = new Solution().ConstructRectangle(6);
            Console.WriteLine("3,2" == string.Join(",", result2));
        }
    }
}

public class Solution
{
    public int[] ConstructRectangle(int area)
    {
        var sqrt = (int)Math.Sqrt(area);

        while (area % sqrt != 0)
        {
            sqrt--;
        }

        return new[] {area / sqrt, sqrt};
    }
}