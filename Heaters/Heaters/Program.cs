using System;

namespace Heaters
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(1 == new Solution().FindRadius(new []{ 1, 2, 3 }, new []{ 2 }));
            //Console.WriteLine(1 == new Solution().FindRadius(new []{ 1, 2, 3, 4 }, new []{ 1, 4 }));
            Console.WriteLine(9 == new Solution().FindRadius(new []{ 1, 5 }, new []{ 10 }));
            //Console.WriteLine(3 == new Solution().FindRadius(new []{ 1, 5 }, new []{ 2 }));
        }
    }
}

public class Solution {
    public int FindRadius(int[] houses, int[] heaters)
    {
        Array.Sort(heaters);

        var result = int.MinValue;

        foreach (var house in houses)
        {
            var index = Array.BinarySearch(heaters, house);
            if (index < 0)
            {
                index = -(index + 1);
            }

            var dist1 = index - 1 >= 0 ? house - heaters[index - 1] : int.MaxValue;
            var dist2 = index < heaters.Length ? heaters[index] - house : int.MaxValue;

            result = Math.Max(result, Math.Min(dist1, dist2));
        }
        
        return result;
    }
}