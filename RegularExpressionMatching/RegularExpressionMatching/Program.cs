using System;

namespace RegularExpressionMatching
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("aa a TEST {0}", false == new Solution().IsMatch("aa", "a"));
            Console.WriteLine("aa a* TEST {0}", true == new Solution().IsMatch("aa", "a*"));
            Console.WriteLine("ab .* TEST {0}", true == new Solution().IsMatch("ab", ".*"));
            Console.WriteLine("aab c*a*b TEST {0}", true == new Solution().IsMatch("aab", "c*a*b"));
            Console.WriteLine("mississippi mis*is*p*. TEST {0}", false == new Solution().IsMatch("mississippi", "mis*is*p*."));
            Console.WriteLine("mississippi mis*is*p*. TEST {0}", false == new Solution().IsMatch("mississippi", "mis*is*p*."));
            
            Console.WriteLine("a a TEST {0}", true == new Solution().IsMatch("a", "a"));
            Console.WriteLine(" a TEST {0}", false == new Solution().IsMatch("", "a"));
            Console.WriteLine("a  TEST {0}", false == new Solution().IsMatch("a", ""));
            Console.WriteLine("  TEST {0}", true == new Solution().IsMatch("", ""));
            
            Console.WriteLine("mississippi mis*is*ip*. TEST {0}", true == new Solution().IsMatch("mississippi", "mis*is*ip*."));
            
            Console.WriteLine("ab .*c TEST {0}", false == new Solution().IsMatch("ab", ".*c"));
        }
    }
}

public class Solution {
    public bool IsMatch(string s, string p)
    {
        if (string.IsNullOrEmpty(p))
        {
            return string.IsNullOrEmpty(s);
        }

        var firstMatch = !string.IsNullOrEmpty(s) && (p[0] == s[0] || p[0] == '.') ;

        if (p.Length >= 2 && p[1] == '*')
        {
            return (IsMatch(s, p.Substring(2)) || (firstMatch && IsMatch(s.Substring(1), p)));
        }
        else
        {
            return firstMatch && IsMatch(s.Substring(1), p.Substring(1));
        }
    }
}