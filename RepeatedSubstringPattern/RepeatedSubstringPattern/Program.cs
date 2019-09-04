using System;
using System.Text;

namespace RepeatedSubstringPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().RepeatedSubstringPattern("bb"));
            Console.WriteLine(true == new Solution().RepeatedSubstringPattern("abab"));
            Console.WriteLine(false == new Solution().RepeatedSubstringPattern("abac"));
            Console.WriteLine(false == new Solution().RepeatedSubstringPattern("aba"));
            Console.WriteLine(true == new Solution().RepeatedSubstringPattern("abcabcabcabc"));
        }
    }
}

public class Solution
 {
     public bool RepeatedSubstringPattern(string s)
     {
         for (var i = s.Length / 2; i >= 1; i--)
         {
             if (s.Length % i != 0)
             {
                 continue;
             }
 
             var m = s.Length / i;
             var subS = s.Substring(0, i);
             var sb = new StringBuilder();
             
             for (var j = 0; j < m; j++)
             {
                 sb.Append(subS);
             }
 
             if (sb.ToString().Equals(s))
             {
                 return true;
             }
         }
 
         return false;
     }
 }