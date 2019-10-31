using System;
using System.Diagnostics.PerformanceData;

namespace ReverseWordsInString3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("s'teL ekat edoCteeL tsetnoc" ==
                              new Solution().ReverseWords("Let's take LeetCode contest"));
        }
    }
}

public class Solution
{
    public string ReverseWords(string s)
    {
        var arr = s.ToCharArray();
        var counter = 0;
        
        for (var end = 0; end < s.Length; end++)
        {
            if (s[end] == ' ' || end == s.Length - 1)
            {
                if (end == s.Length - 1)
                {
                    end = s.Length;
                    counter++;
                }
                
                var i = end - counter;
                
                for (var j = 0; j < counter / 2; j++)
                {
                    var left = i + j;
                    var right = i + counter - j - 1;

                    var temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                
                counter = 0;
            }
            else
            {
                counter++;
            }
        }
        
        return new string(arr);
    }
}