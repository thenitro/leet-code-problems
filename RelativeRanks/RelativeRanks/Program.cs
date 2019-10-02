using System;

namespace RelativeRanks
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().FindRelativeRanks(new[] {5, 4, 3, 2, 1});
            Console.WriteLine(string.Join(",", result));//1 2 3
            
            var result2 = new Solution().FindRelativeRanks(new[] {10, 3, 8, 9, 4});
            Console.WriteLine(string.Join(",", result2)); // 1, 5, 3, 2
        }
    }
}

public class Solution
{
    public string[] FindRelativeRanks(int[] nums)
    {
        var sorted = new int[nums.Length];
        
        Array.Copy(nums, sorted, nums.Length);
        Array.Sort(sorted);
        Array.Reverse(sorted);
        
        var result = new string[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            var index = Array.IndexOf(sorted, nums[i]);
            
            if (index == 0)
            {
                result[i] = "Gold Medal";
            }
            else if (index == 1)
            {
                result[i] = "Silver Medal";
            }
            else if (index == 2)
            {
                result[i] = "Bronze Medal";
            }
            else
            {
                result[i] = (index + 1).ToString();
            }
        }

        return result;
    }
}