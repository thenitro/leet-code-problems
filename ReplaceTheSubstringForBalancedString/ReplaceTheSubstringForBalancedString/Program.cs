using System;
using System.Collections.Generic;

namespace ReplaceTheSubstringForBalancedString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(0 == new Solution().BalancedString("QWER"));
            Console.WriteLine(1 == new Solution().BalancedString("QQWE"));
            Console.WriteLine(2 == new Solution().BalancedString("QQQW"));
            Console.WriteLine(3 == new Solution().BalancedString("QQQQ"));
            Console.WriteLine(4 == new Solution().BalancedString("WWEQERQWQWWRWWERQWEQ"));
        }
    }
}

public class Solution
{
    public int BalancedString(string s)
    {
        var count = new Dictionary<char, int>();
            count['Q'] = 0;
            count['W'] = 0;
            count['E'] = 0;
            count['R'] = 0;

        var arr = s.ToCharArray();

        foreach (var c in s)
        {
            count[c] = count.ContainsKey(c) ? count[c] + 1 : 1;
        }
        
        var need = s.Length / 4;

        var left = 0;
        var right = 0;
        var min = arr.Length;

        while (right <= arr.Length)
        {
            if (count['Q'] > need || count['W'] > need || count['E'] > need || count['R'] > need)
            {
                if (right >= arr.Length)
                {
                    break;
                }

                var rightCh = arr[right];
                count[rightCh]--;
                right++;
                continue;
            }

            min = Math.Min(min, right - left);
            if (min == 0)
            {
                break;
            }

            var leftCh = arr[left];
            count[leftCh]++;
            left++;
        }
        
        return min;
    }
}