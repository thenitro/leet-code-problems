using System;

namespace CanPlaceFlowers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().CanPlaceFlowers(new[] {1, 0, 0, 0, 1}, 1));
            Console.WriteLine(false == new Solution().CanPlaceFlowers(new[] {1, 0, 0, 0, 1}, 2));
            Console.WriteLine(false == new Solution().CanPlaceFlowers(new[] {1, 0, 0, 0, 0, 1}, 2));
        }
    }
}

public class Solution
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        var result = 0;
        
        for (var i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 1)
            {
                continue;
            }
            
            var rightIsFree = i == flowerbed.Length - 1 || flowerbed[i + 1] == 0; 
            var leftIsFree = i == 0 || flowerbed[i - 1] == 0; 
            
            if (leftIsFree && rightIsFree)
            {
                flowerbed[i] = 1;
                result++;
            }
        }

        return result >= n;
    }
}