using System;

namespace ReplaceElementsWithGreatestElementOnRightSide
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().ReplaceElements(new []{ 17,18,5,4,6,1 })));
            Console.WriteLine(string.Join(",", new Solution().ReplaceElements(new []{ 23727,37383,95658,71922,31756 })));
        }
    }
}

public class Solution
{
    public int[] ReplaceElements(int[] arr)
    {
        var mx = -1;
        for (var i = arr.Length - 1; i >= 0; i--)
        {
            mx = Math.Max(arr[i], arr[i] = mx);
        }

        return arr;
    }
}