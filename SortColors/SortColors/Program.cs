using System;

namespace SortColors
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var arr = new[] {2, 0, 2, 1, 1, 0};
            new Solution().SortColors(arr);
            Console.WriteLine(string.Join(",", arr)); //0, 0, 1, 1, 2, 2
        }
    }
}

public class Solution
{
    public void SortColors(int[] nums)
    {
        var dict = new int[3];

        foreach (var num in nums)
        {
            dict[num] = dict[num] + 1;
        }

        var counter = 0;
        
        for (var j = 0; j < 3; j++)
        {
            for (var i = 0; i < dict[j]; i++)
            {
                nums[counter] = j;
                counter++;
            }
        }
    }
}