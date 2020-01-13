using System;
using System.Collections.Generic;

namespace TopKFrequentElements
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().TopKFrequent(new []{ 1, 1, 1, 2, 2, 3}, 2)));
            Console.WriteLine(string.Join(",", new Solution().TopKFrequent(new []{ 1 }, 1)));
        }
    }
}

public class Solution
{
    public IList<int> TopKFrequent(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            dict[num] = dict.ContainsKey(num) ? dict[num] + 1 : 1;
        }

        var result = new List<int>();
        
        for (var i = 0; i < k; i++)
        {
            var max = int.MinValue;
            var item = 0;
            
            foreach (var kv in dict)
            {
                if (kv.Value > max)
                {
                    max = kv.Value;
                    item = kv.Key;
                }
            }

            dict.Remove(item);
            result.Add(item);
        }

        return result;
    }
}